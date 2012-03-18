using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using Repositorio;
using MVC.Models;

namespace BLL
{
    public class BLLAnuncioOferta: Repositorio<AnuncioOferta>
    {
        public BLLAnuncioOferta()
            : base()
        {
        
        }

        public BLLAnuncioOferta(ObjectContext _contexto)
            : base(_contexto)
        { 
        
        }

        public override void Validate(AnuncioOferta entity)
        {
            
        }

        protected override AnuncioOferta InsertRule(AnuncioOferta entity)
        {
            var bllAnuncio = new BLLAnuncio(_context);

            var a = bllAnuncio.SelectByKey(entity.Anuncio_ID);

            a.Ofertas += 1;

            entity.DataInc = DateTime.Now;



            if (entity.OfertaValor == 0)
            {
                entity.OfertaValor = null;
            }
            return base.InsertRule(entity);
        }
    }
}
