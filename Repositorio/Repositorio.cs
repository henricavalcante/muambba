using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq.Expressions;

namespace Repositorio
{
    public abstract class Repositorio<T> : IDisposable where T : EntityObject
    {

        #region Atributos

        public readonly ObjectContext _context;


        private IObjectSet<T> _objectSet;
        #endregion

        #region Construtores
        public Repositorio()
            : this(new Contexto())
        {
        }

        public Repositorio(ObjectContext context)
        {

            _context = context;

            _objectSet = _context.CreateObjectSet<T>();

        }

        #endregion

        #region Métodos Privados

        private void IfExists(T entity)
        {
            if (entity == null)
            {

                throw new ArgumentNullException("entity");

            }

        }

        private void CompleteValidate(T entity)
        {
            IfExists(entity);

            Validate(entity);
        }

        #endregion

        #region Métodos Públicos

        #region Retrieve

        public IQueryable<T> Fetch()
        {

            return _objectSet;

        }

        public IEnumerable<T> GetAll()
        {
            return Fetch().AsEnumerable();

        }

        public IEnumerable<T> GetAll<TKey>(Func<T, TKey> orderBy, bool asc, int skip, int take)
        {
            if (asc)
            {
                return _objectSet.OrderBy(orderBy).Skip(skip).Take(take).AsEnumerable();
            }
            else
            {
                return _objectSet.OrderByDescending(orderBy).Skip(skip).Take(take).AsEnumerable();
            }
            
        }

        public virtual IList<T> ToList()
        {
            return Fetch().ToList();
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {

            return _objectSet.Where<T>(predicate);

        }

        public IEnumerable<T> Where<TKey>(Func<T, bool> predicate, Func<T, TKey> orderBy, bool asc, int skip, int take)
        {
            var retorno = _objectSet.Where(predicate);

            if (asc)
            {
                return retorno.OrderBy(orderBy).Skip(skip).Take(take);
            }
            else
            {
                //var retorno = from a in _objectSet
                //              where a.EntityKey == 20
                //              select a;
                return retorno.OrderByDescending(orderBy).Skip(skip).Take(take);
            }
        }


        public virtual T SelectByKey(int Key)
        {



            return Single(a => int.Parse(a.EntityKey.EntityKeyValues[0].Value.ToString()) == Key);
            //return Single(a => a.EntityKey. == ID);
            //return null;
        }

        public virtual T SelectByKey(Guid Key)
        {

            return Single(a => Guid.Parse(a.EntityKey.EntityKeyValues[0].Value.ToString()) == Key);
            //return Single(a => a.EntityKey. == ID);
            //return null;
        }

        public T Single(Func<T, bool> predicate)
        {

            return _objectSet.SingleOrDefault<T>(predicate);

        }

        public T First(Func<T, bool> predicate)
        {

            return _objectSet.FirstOrDefault<T>(predicate);

        }

        public int Count(Func<T, bool> predicate)
        {

            return _objectSet.Count(predicate);

        }

        public bool Exists(Func<T, bool> predicate)
        { 
            return (Count(predicate) > 0);
        }

        #endregion

        #region InsertUpdate

        public void Attach(T entity)
        {

            CompleteValidate(entity);

            _objectSet.Attach(entity);

        }

        public void Detach(T entity)
        {

            CompleteValidate(entity);

            _objectSet.Detach(entity);

        }



        public void AddObject(T entity)
        {
            CompleteValidate(entity);
            entity = InsertRule(entity);
            _objectSet.AddObject(entity);
        }

        public virtual void Insert(T entity)
        {

            if (entity.EntityKey == null)
            {
                AddObject(entity);
            }
            else
            {
                Update(entity);
            }

        }

        public virtual void InsertAndSave(T entity)
        {
            Insert(entity);
            SaveChanges();
        }

        protected virtual T InsertRule(T entity)
        {
            return entity;
        }

        public virtual void Update(T entity)
        {

            CompleteValidate(entity);

            entity = UpdateRule(entity);

            _context.ApplyCurrentValues<T>(entity.GetType().Name, entity);

        }

        public virtual void UpdateAndSave(T entity)
        {
            Update(entity);
            SaveChanges();
        }

        protected virtual T UpdateRule(T entity)
        {

            return entity;
        }

        #endregion

        #region Delete

        public void Delete(T entity)
        {

            IfExists(entity);

            DeleteRule(entity);

            _objectSet.DeleteObject(entity);

        }

        public void Delete(int key)
        {
            Delete(SelectByKey(key));
        }

        public void Delete(Func<T, bool> predicate)
        {

            IEnumerable<T> records = from x in _objectSet.Where<T>(predicate) select x;



            foreach (T record in records)
            {

                _objectSet.DeleteObject(record);

            }

        }

        public void DeleteAndSave(T entity)
        {

            Delete(entity);

            SaveChanges();
        }

        public void DeleteAndSave(int key)
        {

            Delete(key);

            SaveChanges();
        }

        protected virtual void DeleteRule(T entity) { }

        #endregion

        #region Save

        public void SaveChanges()
        {

            _context.SaveChanges();

        }

        public void SaveChanges(SaveOptions options)
        {

            _context.SaveChanges(options);

        }

        #endregion

        #endregion

        #region Métodos Abstratos

        public abstract void Validate(T entity);



        #endregion

        #region Dispose

        public void Dispose()
        {

            Dispose(true);

            GC.SuppressFinalize(this);

        }

        protected virtual void Dispose(bool disposing)
        {

            if (disposing)
            {

                if (_context != null)
                {

                    _context.Dispose();

                    //_context = null;

                }

            }

        }


        #endregion

    }
}
