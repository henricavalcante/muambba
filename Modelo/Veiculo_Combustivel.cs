using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MVC.Models
{
    public static class Veiculo_Combustivel
    {

        public class Veiculo_CombustivelItem
        {
            public int ID { get; set; }
            public string Combustivel { get; set; }

        }

        private static List<Veiculo_CombustivelItem> _Combustivel;

        private static void Preenche()
        {
            _Combustivel = new List<Veiculo_CombustivelItem>();

            _Combustivel.Add(new Veiculo_CombustivelItem() { ID = 1, Combustivel = "Gasolina" });
            _Combustivel.Add(new Veiculo_CombustivelItem() { ID = 2, Combustivel = "Álcool" });
            _Combustivel.Add(new Veiculo_CombustivelItem() { ID = 3, Combustivel = "Flex" });
            _Combustivel.Add(new Veiculo_CombustivelItem() { ID = 4, Combustivel = "Diesel" });
            _Combustivel.Add(new Veiculo_CombustivelItem() { ID = 5, Combustivel = "TetraFuel (Gás e Flex)" });
            _Combustivel.Add(new Veiculo_CombustivelItem() { ID = 5, Combustivel = "Gás e Gasolina" });
            _Combustivel.Add(new Veiculo_CombustivelItem() { ID = 5, Combustivel = "Gás e Álcool" });
            _Combustivel.Add(new Veiculo_CombustivelItem() { ID = 6, Combustivel = "Elétrico" });

        }

        public static List<Veiculo_CombustivelItem> GetAll()
        {
            if (_Combustivel == null)
            {
                Preenche();

            }
            return _Combustivel;
        }

        public static Veiculo_CombustivelItem SelectByKey(int Key)
        {
            if (_Combustivel == null)
            {
                Preenche();

            }
            return _Combustivel.Where(a => a.ID == Key).SingleOrDefault();
        }

        public static string ToString(int Key)
        {
            if (_Combustivel == null)
            {
                Preenche();

            }
            return _Combustivel.Where(a => a.ID == Key).SingleOrDefault().Combustivel;
        }
    }
}
