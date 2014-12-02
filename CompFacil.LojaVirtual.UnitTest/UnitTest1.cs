using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompFacil.LojaVirtual.UnitTest
{
    public class CompFacilUnitTest
    {
        public void Take()
        {  
            //O Operador Take é usado para selecionar os primeiros n objetos de uma coleção

            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var resultado = from num in numeros.Take(5) select num;

            int[] teste = { 5, 4, 1, 3, 9};

            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void Skip()    
        {
            //O Operador Skip é usado para ignorar os primeiros n objetos de uma coleção

            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var resultado = from num in numeros.Take(5).Skipe(2) select num;
        }
    }
}
