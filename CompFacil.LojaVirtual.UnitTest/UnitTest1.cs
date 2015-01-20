using System;
using System.Data.Linq;
using System.Web.Mvc;
using CompFacil.LojaVirtual.Web.Models;
using CompFacil.LojaVirtual.Web.HtmlHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompFacil.LojaVirtual.CompFacilUniTest
{
    [TestClass]

    public class CompFacilUnitTest
    {
        [TestMethod]
        public void Take()
        {  
           // O Operador Take é usado para selecionar os primeiros n objetos de uma coleção

            //int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var resultado = from num in numeros.Take(5) select num;

            //int[] teste = { 5, 4, 1, 3, 9};

            //CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void Skip()    
        {
            //O Operador Skip é usado para ignorar os primeiros n objetos de uma coleção

            /*int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var resultado = from num in numeros.Take(5).Skipe(2) select num;*/
        }

        [TestMethod]
        public void TestarSeAPaginacaoEstaSendoGeradaCorretamente()
        {
            //Arrange

            HtmlHelper html = null;

            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act

            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //Assert
            Assert.AreEqual(
                    @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                +   @"<a class""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                +   @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
                );


        }


    }
}
