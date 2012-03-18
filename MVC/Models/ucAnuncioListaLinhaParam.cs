using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ucAnuncioListaLinhaParam : Anuncio
    {

        public string Categoria { get; set; }
        public string Categoria_Link { get; set; }
        public int QuantidadeAnuncios { get; set; }


    }
}