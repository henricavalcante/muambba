using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio;
using MVC.Models;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;


namespace BLL
{
    public static class BLLstpEndereco
    {

        public static string listar(string query)
        {
            var x = new muambbasqlEntities();

            var lst = x.stpEnderecoList(query).ToList();

            string retorno = "";

            foreach (var item in lst)
            {
                retorno = retorno + "<li>" + item.Endereco + "</li>";
            }

            return retorno;
        }
    }
}
