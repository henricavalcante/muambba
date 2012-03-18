using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MVC.Models
{
    public static class Imovel_Lazer
    {

        private static List<string> _Item;

        private static void Preenche()
        {
            _Item = new List<string>();

            _Item.Add("Jardim");
            _Item.Add("Piscina");
            _Item.Add("Playground");
            _Item.Add("Quadra poli-esportiva");
            _Item.Add("Sala de ginástica");
            _Item.Add("Salão de Jogos");
            _Item.Add("Sala de ginástica");
            _Item.Add("Sauna");
            _Item.Add("Academia");
            _Item.Add("Lan-House");
           

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
