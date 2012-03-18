using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.Models
{
    public static class  DenunciaTipo
    {

        public class DenunciaTipoItem
        {
            public int ID { get; set; }
            public string Tipo { get; set; }

        }

        private static List<DenunciaTipoItem> _Tipo;

        private static void Preenche()
        {
            _Tipo = new List<DenunciaTipoItem>();

            _Tipo.Add(new DenunciaTipoItem() { ID = 1, Tipo = "Desrespeita Termos de Uso" });
            _Tipo.Add(new DenunciaTipoItem() { ID = 2, Tipo = "Contém palavras inapropriadas" });
            _Tipo.Add(new DenunciaTipoItem() { ID = 3, Tipo = "Ultiliza ténicas para manipular resultados de buscas" });
            _Tipo.Add(new DenunciaTipoItem() { ID = 4, Tipo = "Conteúdo Pornográfico" });
            _Tipo.Add(new DenunciaTipoItem() { ID = 5, Tipo = "É um possível Golpe" });

        }
        

        public static List<DenunciaTipoItem> GetAll()
        {
            if (_Tipo == null)
            {
                Preenche();

            }
            return _Tipo;
        }

        public static DenunciaTipoItem SelectByKey(int Key)
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
