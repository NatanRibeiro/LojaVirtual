using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CompFacil.LojaVirtual.Dominio.Entidades;
using CompFacil.LojaVirtual.Dominio.Repositório;
using CompFacil.LojaVirtual.Web.Models;

namespace CompFacil.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        #region Propriedades
        private ProdutosRepositorio Repositorio;
        #endregion

        public RedirectToRouteResult Adicionar(int ProdutoID, string ReturnUrl)
        {
            Repositorio = new ProdutosRepositorio();
            Produto oProduto = Repositorio.Produtos.FirstOrDefault(p => p.ProdutoID == ProdutoID);

            if (oProduto != null)
            {
                Obter().AdicionarItem(oProduto, 1);
            }

            return RedirectToAction("Index", new { ReturnUrl = ReturnUrl });
        }
        
        private Carrinho Obter()
        {
            Carrinho oCarrinho = (Carrinho)Session["Carrinho"];

            if (oCarrinho == null)
            {
                oCarrinho = new Carrinho();
                Session["Carrinho"] = oCarrinho;
            }

            return oCarrinho;
        }

        public RedirectToRouteResult Remover(int ProdutoID, string ReturnUrl)
        {
            Repositorio = new ProdutosRepositorio();
            Produto oProduto = Repositorio.Produtos.FirstOrDefault(p => p.ProdutoID == ProdutoID);

            if (oProduto != null)
                Obter().RemoverItem(oProduto);

            return RedirectToAction("Index", new { _ReturnUrl = ReturnUrl });
        }

        public ViewResult Index(string ReturnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = Obter(),
                ReturnUrl = ReturnUrl
            });
        }

        public PartialViewResult Resumo()
        {
            Carrinho oCarrinho = Obter();
            return PartialView(oCarrinho);
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }
    }
}