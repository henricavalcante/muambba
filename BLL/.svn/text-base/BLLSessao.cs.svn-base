using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio;
using MVC.Models;
using System.Data.Objects;
using Util;

namespace BLL
{
    public class BLLSessao : Repositorio<Sessao>
    {
        
        public BLLSessao()
            : base()
        {
        
        }

        public BLLSessao(ObjectContext _contexto)
            : base(_contexto)
        { 
        
        }

        public override void Validate(Sessao entity)
        {
            Validar.Nulo(entity.Guid, "Identificador da Sessão Inválido");
            Validar.Nulo(entity.DataHoraFim, "Horário da Sessão Inválido");
            Validar.Nulo(entity.DataHoraInicio, "Horário da Sessão Inválido");

        }
    }
}
