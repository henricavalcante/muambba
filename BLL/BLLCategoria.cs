using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using Repositorio;
using MVC.Models;
using System.Web.Script.Serialization;

namespace BLL
{
    public class BLLCategoria : Repositorio<Categoria>
    {

        private const string ARQUIVO_CATEGORIAS = "c:\\test.txt";

        public BLLCategoria()
            : base()
        {
        
        }

        public BLLCategoria(ObjectContext _contexto)
            : base(_contexto)
        { 
        
        }

        public List<int> ListaDeIDsFilhosCompletaBanco(int id)
        {

            List<int> r;

            r = MVC.Models.CategoriasFilhas.Get(id);

            if (r == null)
            {
                AtualizaListaDeIdsFilhosPorCategoriaBanco(id);
                r = MVC.Models.CategoriasFilhas.Get(id);

            }

            return r;
        }

        private void AtualizaListaDeIdsFilhosPorCategoriaBanco(int id)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            var str = SelectByKey(id).CategoriasFilhas;

            if (str == "")
            {
                BLLProcedures.stpCategoriasFilhasUpd(id);
                
            }

            MVC.Models.CategoriasFilhas.Set(jss.Deserialize<List<int>>("[" + str + "]"));
        
        }

        public List<int> ListaDeIDsFilhosCompleta(int ID)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            System.IO.StreamReader myFile = new System.IO.StreamReader(ARQUIVO_CATEGORIAS);
            string myString = myFile.ReadToEnd();

            myFile.Close();

            var retorno = jss.Deserialize<List<List<int>>>(myString);

            var retornoFinal = retorno.Where(a => a[0] == ID).SingleOrDefault();

            if (retornoFinal == null)
            { 
                //se não encontrar a categoria ele vai tentar gerar um novo  arquivo json das categorias.
                AtualizarListaDeIDsFilhosCompleta();


                //tenta ler novamente

                myFile = new System.IO.StreamReader(ARQUIVO_CATEGORIAS);
                myString = myFile.ReadToEnd();

                myFile.Close();

                retorno = jss.Deserialize<List<List<int>>>(myString);

                retornoFinal = retorno.Where(a => a[0] == ID).SingleOrDefault();


            }

            return retornoFinal;

        }
        
        private void AtualizarListaDeIDsFilhosCompleta()
        {
            
            List<List<int>> Matriz = new List<List<int>>();
            foreach (var item in ToList())
            {
                var ListaDeIDs =
                    ListaDeIDsFilhos(item.ID);
                ListaDeIDs.Insert(0, item.ID);
                Matriz.Add(ListaDeIDs);
            }


            JavaScriptSerializer jss = new JavaScriptSerializer();
            string result = jss.Serialize(Matriz);
            System.IO.StreamWriter file = new System.IO.StreamWriter(ARQUIVO_CATEGORIAS);
            file.WriteLine(result);

            file.Close();
        }

        public override void Validate(Categoria entity)
        {
            
        }



        public List<Categoria> ListarPais(int _idCategoriaPai)
        {
            if (_idCategoriaPai == 0)
            {
                return Where(a => a.CategoriaFK_ID == null).ToList();
            
            }
            else
            {
                return Where(a => a.CategoriaFK_ID == _idCategoriaPai).ToList();
            
            }
            
            
        }

        public Categoria SelectByName(string NomeCategoria)
        {

            return Where(a => a.Categoria1 == NomeCategoria).SingleOrDefault();

        }

        public Categoria SelectBaseByName(string NomeCategoria)
        {

            return Where(a => a.Categoria1 == NomeCategoria && a.CategoriaFK_ID == null).SingleOrDefault();

        }

        public Categoria SelectByName(string NomeCategoria, string NomeCategoriaPai)
        {

            var pai = Where(a => a.Categoria1 == NomeCategoriaPai).SingleOrDefault();

            return pai.Categoria11.Where(a => a.Categoria1 == NomeCategoria).SingleOrDefault();

        }

        public List<int> ListaDeIDsFilhos(int ID)
        {
            var retorno = new List<int>();
            foreach (var item in SelectByKey(ID).Categoria11)
	        {
                retorno.Add(item.ID);
                if (item.Categoria11.Count > 0)
                {
                    foreach (var j in ListaDeIDsFilhos(item.ID))
                    {
                        retorno.Add(j);
                    }
                }
                
	        }
            

            return retorno;
        }



    }
}
