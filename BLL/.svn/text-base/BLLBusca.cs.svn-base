using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using Repositorio;
using MVC.Models;

namespace BLL
{
    public class BLLBusca: Repositorio<Busca>
    {

        public BLLBusca()
            : base()
        { 
        
        }

        public BLLBusca(ObjectContext _contexto)
            : base(_contexto)
        { 
        
        }

        public override void Validate(Busca entity)
        {
            
        }

        public void Inserir(string _busca, Usuario _usuariologado)
        {
            var o = new Busca();
            o.Busca1 = _busca;
            o.DataInc = DateTime.Now;
            o.Usuario = _usuariologado;
            
            InsertAndSave(o);
            
        }


        
    }
}
