using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVC.Models;
using Repositorio;
using System.Data.Objects;
using Util;
using System.Collections;

namespace BLL
{
    public class BLLDenuncia : Repositorio<Denuncia>
    {



        public BLLDenuncia()
            : base()
        {

        }

        public BLLDenuncia(ObjectContext _contexto)
            : base(_contexto)
        {

        }

        protected override Denuncia InsertRule(Denuncia entity)
        {
            entity.DataInc = DateTime.Now;
            entity.DenunciaStatus_ID = 1;


            return entity;
        }


        public override void Validate(Denuncia entity)
        {
            

        }


        
    }
}
