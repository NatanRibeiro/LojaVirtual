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

        [TestMethod]
        public void AdicionarProdutoExistente()
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

            //Arrange - Carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);

            //Act
            ItemCarrinho[] resultado = carrinho.ItensCarrinho
                .OrderBy(c => c.Produto.ProdutoID).ToArray();

            //Assert
            Assert.AreEqual(resultado.Length, 2);
            Assert.AreEqual(resultado[0].Quantidade, 1);
            Assert.AreEqual(resultado[1].Quantidade, 1);
        }

        [TestMethod]
        public void RemoverItens()
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

            Produto produto3 = new Produto
            {
                ProdutoID = 3,
                Nome = "Teste 3"
            };

            //Arrange - Carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto3, 5);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.RemoverItem(produto2);

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto ==  produto2).Count(), 0);
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);
        }
        
        [TestMethod]
        public void CalcularValorTotal()
        {
            Produto produto1 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            //Arrange - Carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 3);

            decimal resultado = carrinho.ObterValorTotal();

            //Assert
            Assert.AreEqual(resultado, 150M);
        }

        [TestMethod]
        public void LimparItens()
        {
            Produto produto1 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            //Arrange - Carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 3);

            carrinho.LimparCarrinho();

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }
    }
}
