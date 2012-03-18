using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MVC.Models
{
    public static class Veiculo_Cor
    {

        public class Veiculo_CorItem
        {
            public int ID { get; set; }
            public string Cor { get; set; }

        }

        private static List<Veiculo_CorItem> _Cor;

        private static void Preenche()
        {
            _Cor = new List<Veiculo_CorItem>();

            _Cor.Add(new Veiculo_CorItem() { ID = 1, Cor = "Prata" });
            _Cor.Add(new Veiculo_CorItem() { ID = 2, Cor = "Preto" });
            _Cor.Add(new Veiculo_CorItem() { ID = 3, Cor = "Branco" });
            _Cor.Add(new Veiculo_CorItem() { ID = 4, Cor = "Cinza" });
            _Cor.Add(new Veiculo_CorItem() { ID = 5, Cor = "Azul" });
            _Cor.Add(new Veiculo_CorItem() { ID = 6, Cor = "Vermelho" });
            _Cor.Add(new Veiculo_CorItem() { ID = 7, Cor = "Marrom/Bege" });
            _Cor.Add(new Veiculo_CorItem() { ID = 8, Cor = "Verde" });
            _Cor.Add(new Veiculo_CorItem() { ID = 9, Cor = "Amarelo/Ouro" });
            _Cor.Add(new Veiculo_CorItem() { ID = 10, Cor = "Outros" });
        }

        public static List<Veiculo_CorItem> GetAll()
        {
            if (_Cor == null)
            {
                Preenche();

            }
            return _Cor;
        }

        public static Veiculo_CorItem SelectByKey(int Key)
        {
            if (_Cor == null)
            {
                Preenche();

            }
            return _Cor.Where(a => a.ID == Key).SingleOrDefault();
        }

        public static string ToString(int Key)
        {
            if (_Cor == null)
            {
                Preenche();

            }
            return _Cor.Where(a => a.ID == Key).SingleOrDefault().Cor;
        }
    }
}
