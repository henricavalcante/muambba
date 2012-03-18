using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.Models
{
    public static class DenunciaClasse
    {
        public class DenunciaClasseItem
        {
            public int ID { get; set; }
            public string Classe { get; set; }

        }

        private static List<DenunciaClasseItem> _Classe;

        private static void Preenche()
        {
            _Classe = new List<DenunciaClasseItem>();

            _Classe.Add(new DenunciaClasseItem() { ID = 1, Classe = "Anuncio" });
            _Classe.Add(new DenunciaClasseItem() { ID = 2, Classe = "Pergunta" });
            _Classe.Add(new DenunciaClasseItem() { ID = 3, Classe = "Resposta" });

        }

        public static List<DenunciaClasseItem> GetAll()
        {
            if (_Classe == null)
            {
                Preenche();

            }
            return _Classe;
        }

        public static DenunciaClasseItem SelectByKey(int Key)
        {
            if (_Classe == null)
            {
                Preenche();

            }
            return _Classe.Where(a => a.ID == Key).SingleOrDefault();
        }

        public static string ToString(int Key)
        {
            if (_Classe == null)
            {
                Preenche();

            }
            return _Classe.Where(a => a.ID == Key).SingleOrDefault().Classe;
        }
    }
}
