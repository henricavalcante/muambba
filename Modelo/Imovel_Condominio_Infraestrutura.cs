using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MVC.Models
{
    public static class Imovel_Condominio_Infraestrutura
    {

        private static List<string> _Item;

        private static void Preenche()
        {
            _Item = new List<string>();

            _Item.Add("Salão de convenções");
            _Item.Add("Ruas asfaltadas");
            _Item.Add("TV a cabo");
            _Item.Add("Automação predial");
            _Item.Add("Guarita");
            _Item.Add("Portaria com controle de acesso");
            _Item.Add("Taxa de água inclusa");
            _Item.Add("Conveniência");
            _Item.Add("Lavanderia");

            _Item.Sort();
        }

        public static List<string> GetAll()
        {
            if (_Item == null)
            {
                Preenche();

            }
            return _Item;
        }



    }
}
