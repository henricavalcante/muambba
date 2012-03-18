using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MVC.Models
{
    public static class AnuncioOfertaStatus
    {
        public class AnuncioOfertaStatusItem
        {
            public int ID { get; set; }
            public string Status { get; set; }

        }

        private static List<AnuncioOfertaStatusItem> _Status;

        private static void Preenche()
        {
            _Status = new List<AnuncioOfertaStatusItem>();

            _Status.Add(new AnuncioOfertaStatusItem() { ID = 1, Status = "Cadastrada" });
            _Status.Add(new AnuncioOfertaStatusItem() { ID = 2, Status = "Em Negociação" });
            _Status.Add(new AnuncioOfertaStatusItem() { ID = 3, Status = "Aceita" });
            _Status.Add(new AnuncioOfertaStatusItem() { ID = 4, Status = "Recusada" });

        }

        public static List<AnuncioOfertaStatusItem> GetAll()
        {
            if (_Status == null)
            {
                Preenche();

            }
            return _Status;
        }

        public static AnuncioOfertaStatusItem SelectByKey(int Key)
        {
            if (_Status == null)
            {
                Preenche();

            }
            return _Status.Where(a => a.ID == Key).SingleOrDefault();
        }

        public static string ToString(int Key)
        {
            if (_Status == null)
            {
                Preenche();

            }
            return _Status.Where(a => a.ID == Key).SingleOrDefault().Status;
        }
    }
}
