using System;
using CompFacil.LojaVirtual.Dominio.Entidades;
using CompFacil.LojaVirtual.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompFacil.LojaVirtual.CompFacilUniTest
{
    [TestClass]
    public class CarrinhoControllerTestes
    {
        [TestMethod]
        public void AdicionarItemAoCarrinho()
        {

            /*Preparação  (Arrange)   * Estímulo   (Act)   * Veriicação (Assert) */
            
            //Arrange

            Produto produto1 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste2"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 3);

            CarrinhoController controller = new CarrinhoController();

            //Act
            //controller.Adicionar(carrinho, 2, "");

            //Assert
            //Assert.AreEqual(carrinho.ItensCarrinho.Count(), 1);
            //Assert.AreEqual(carrinho.ItensCarrinho.ToArray()[0].Produto.ProdutoID, 1);
        }
    }
}
