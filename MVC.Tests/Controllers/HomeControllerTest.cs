using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC;
using MVC.Controllers;
using MVC.Models;
using Repositorio;
using BLL;
using System.Web.Script.Serialization;

namespace MVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        //[TestMethod]
        //public void Index()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;

        //    // Assert
        //    ViewDataDictionary viewData = result.ViewData;
        //    Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
        //}

        [TestMethod]
        public void TestarGeracaoDeListaDeCategoriasFilhas()
        {

            DateTime t_inicio;
            DateTime t_fim;
            TimeSpan t_diferenca;
            DateTime t_fim2;
            TimeSpan t_diferenca2;

            
                t_inicio = DateTime.Now;
            
                
               
            var bll = new BLLCategoria();
            List<List<int>> Matriz = new List<List<int>>();
            foreach (var item in bll.ToList())
            {
                var ListaDeIDs =
                    bll.ListaDeIDsFilhos(item.ID);
                ListaDeIDs.Insert(0, item.ID);
                Matriz.Add(ListaDeIDs);
            }

            

            t_fim = DateTime.Now;
            t_diferenca = t_fim.Subtract(t_inicio);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string result = jss.Serialize(Matriz);
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
            file.WriteLine(result);

            file.Close();


            Assert.AreNotEqual(String.Empty, result);



            System.IO.StreamReader myFile = new System.IO.StreamReader("c:\\test.txt");
            string myString = myFile.ReadToEnd();

            myFile.Close();

            var retorno = jss.Deserialize<List<List<int>>>(myString);

            retorno.Where(a => a[0] == 8).SingleOrDefault();

            t_fim2 = DateTime.Now;
            t_diferenca2 = t_fim2.Subtract(t_fim);

            Assert.AreNotEqual(String.Empty, myString);


        }

    }
}
