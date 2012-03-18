using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MVC.Models
{
    public static class AnuncioTipo
    {
        public class AnuncioTipoItem
        {
            public int ID { get; set; }
            public string Tipo { get; set; }

        }

        private static List<AnuncioTipoItem> _Tipo;

        private static void Preenche()
        {
            _Tipo = new List<AnuncioTipoItem>();

            _Tipo.Add(new AnuncioTipoItem() { ID = 1, Tipo = "Venda" });
            _Tipo.Add(new AnuncioTipoItem() { ID = 2, Tipo = "Troca" });
            _Tipo.Add(new AnuncioTipoItem() { ID = 3, Tipo = "Compra" });
            _Tipo.Add(new AnuncioTipoItem() { ID = 4, Tipo = "Qualquer Negócio" });
        }

        public static List<AnuncioTipoItem> GetAll()
        {
            if (_Tipo == null)
            {
                Preenche();

            }
            return _Tipo;
        }

        public static AnuncioTipoItem SelectByKey(int Key)
        {
            if (_Tipo == null)
            {
                Preenche();

            }
            return _Tipo.Where(a => a.ID == Key).SingleOrDefault();
        }

        public static string ToString(int Key)
        {
            if (_Tipo == null)
            {
                Preenche();

            }
            return _Tipo.Where(a => a.ID == Key).SingleOrDefault().Tipo;
        }
    }
}
