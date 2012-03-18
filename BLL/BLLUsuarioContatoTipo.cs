using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio;
using MVC.Models;
using System.Data.Objects;

namespace BLL
{
    public class BLLUsuarioContatoTipo : Repositorio<UsuarioContatoTipo>
    {

        public BLLUsuarioContatoTipo()
        {

        }

        public BLLUsuarioContatoTipo(ObjectContext _contexto)
            : base(_contexto)
        {
        }

        public override void Validate(UsuarioContatoTipo entity)
        {
           
        }
    }
}
