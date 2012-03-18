using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ucPaginacaoOrdenacaoFiltrosParam
    {
        public List<string> _Ordenacao;

        public List<string> Ordenacao
        {
            get
            {
                if (_Ordenacao == null)
                {
                    _Ordenacao = new List<string>();
                }
                return _Ordenacao;
            }
            set
            {
                _Ordenacao = value;
            }
        }

        public List<string> _Filtro;

        public List<string> Filtro
        {
            get
            {
                if (_Filtro == null)
                {
                    _Filtro = new List<string>();
                }
                return _Filtro;
            }
            set
            {
                _Filtro = value;
            }
        }
        
        public string UrlRetorno { get; set; }
        public int QuantidadeRegistros { get; set; }
        public int RegistrosPorPagina { get; set; }
    }
}