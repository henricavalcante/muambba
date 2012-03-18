using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MVC.Models
{
    public static class AnuncioConservacao
    {

        public class AnuncioConservacaoItem
        { 
            public int ID {get;set;}
            public string Conservacao {get;set;}

        }

        private static List<AnuncioConservacaoItem> _Conservacao;

        private static void Preenche()
        {
            _Conservacao = new List<AnuncioConservacaoItem>();

            _Conservacao.Add(new AnuncioConservacaoItem() { ID = 1, Conservacao = "Novo" });
            _Conservacao.Add(new AnuncioConservacaoItem() { ID = 2, Conservacao = "Semi-Novo" });
            _Conservacao.Add(new AnuncioConservacaoItem() { ID = 3, Conservacao = "Usado" });
            _Conservacao.Add(new AnuncioConservacaoItem() { ID = 4, Conservacao = "Defeito" });
            _Conservacao.Add(new AnuncioConservacaoItem() { ID = 5, Conservacao = "Sucata" });
        }

        public static List<AnuncioConservacaoItem> GetAll()
        {
            if (_Conservacao == null)
            {
                Preenche();

            }
            return _Conservacao;
        }

        public static AnuncioConservacaoItem SelectByKey(int Key)
        {
            if (_Conservacao == null)
            {
                Preenche();

            }
            return _Conservacao.Where(a => a.ID == Key).SingleOrDefault();
        }

        public static string ToString(int Key)
        {
            if (_Conservacao == null)
            {
                Preenche();

            }
            return _Conservacao.Where(a => a.ID == Key).SingleOrDefault().Conservacao;
        }
    }
}
