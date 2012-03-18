using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Repositorio;
using MVC.Models;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Data.Objects;


namespace BLL
{
    public static class BLLProcedures
    {

        public static ObjectResult<stpEnderecoList_Result> stpEnderecoList(string query)
        {
            var x = new muambbasqlEntities();

            var lst = x.stpEnderecoList(query);


            //var tbl = new Hashtable();
            ////string retorno = "";

            //foreach (var item in lst)
            //{
            //    tbl.Add(item.id, item.Endereco);
                
            //}

            return lst;
        }

        public static bool? stpNomeUsuarioList(string nome)
        {
            var x = new muambbasqlEntities();

            return x.stpNomeUsuarioList(nome).SingleOrDefault();

            
        }

        public static bool? stpEmailUsuarioList(string email)
        {
            var x = new muambbasqlEntities();

            return x.stpEmailUsuarioList(email).SingleOrDefault();


        }


        public static void stpCategoriaLinksUpd()
        {
            var x = new muambbasqlEntities();

            x.stpCategoriaLinksUpd();


        }

        public static void stpCategoriasFilhasUpd(int id)
        {
            var x = new muambbasqlEntities();
            
            x.stpCategoriasFilhasUpd(id);


        }

    }
}
