using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using Repositorio;
using MVC.Models;

namespace BLL
{
    public class BLLUsuarioFoto : Repositorio<UsuarioFoto>
    {
        public BLLUsuarioFoto()
            : base()
        {

        }

        public BLLUsuarioFoto(ObjectContext _contexto)
            : base(_contexto)
        {

        }

        public override void Validate(UsuarioFoto entity)
        {

        }
    }
}
