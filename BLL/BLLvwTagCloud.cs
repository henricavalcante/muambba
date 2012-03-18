using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVC.Models;
using Repositorio;
using System.Data.Objects;

namespace BLL
{
    public class BLLvwTagCloud : Repositorio<vwTagCloud>
    {
        public BLLvwTagCloud()
            : base()
        { 
        
        }

        public BLLvwTagCloud(ObjectContext _contexto)
            : base(_contexto)
        { 
        
        }

        public override void Validate(vwTagCloud entity)
        {
            
        }

        public override IList<vwTagCloud> ToList()
        {
            return base.ToList().OrderByDescending(a => a.Quantidade).ToList();
        }
    }
}
