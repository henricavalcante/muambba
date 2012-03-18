using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MVC.Models
{
    public static class Imovel_Instalacoes
    {

        private static List<string> _Item;

        private static void Preenche()
        {
            _Item = new List<string>();

            _Item.Add("Guarita");
            _Item.Add("Piso frio");
            _Item.Add("Telefone");
            _Item.Add("Piso Laminado");
            _Item.Add("Ar condicionado");
            _Item.Add("Armário de cozinha");
            _Item.Add("Armário embutido");
            _Item.Add("Carpete");
            _Item.Add("Esgoto");
            _Item.Add("Hidromassagem");
            _Item.Add("TV a cabo");
            _Item.Add("Forro de Gesso");
            _Item.Add("Forro de PVC");
            _Item.Add("Forro de Madeira");

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
