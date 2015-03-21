using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompFacil.LojaVirtual.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompFacil.LojaVirtual.CompFacilUniTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        //Teste Adicionar Itens ao Carrinho
        [TestMethod]
        public void AdicionarItensCarrinho()
        {
            //Arrange - Itens Carrinho
            Produto produto1 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste 2"
            };

            //Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }
    }
}
