using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompFacil.LojaVirtual.Dominio.Entidades;
using CompFacil.LojaVirtual.Dominio.Repositório;
using CompFacil.LojaVirtual.Web.Models;

namespace CompFacil.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        #region Propriedades
        private ProdutosRepositorio oRepositorio;
        #endregion

        public RedirectToRouteResult Adicionar(int _ProdutoID, string _ReturnUrl)
        {
            oRepositorio = new ProdutosRepositorio();
            Produto oProduto = oRepositorio.Produtos.FirstOrDefault(p => p.ProdutoID == _ProdutoID);

            if (oProduto != null)
                Obter().AdicionarItem(oProduto, 1);

            return RedirectToAction("Index", new { _ReturnUrl });
        }
        
        private Carrinho Obter()
        {
            Carrinho oCarrinho = (Carrinho) Session["Carrinho"];

            if (oCarrinho == null)
            {
                oCarrinho = new Carrinho();
                Session["Carrinho"] = oCarrinho;
            }

            return oCarrinho;
        }

        public RedirectToRouteResult Remover(int _ProdutoID, string _ReturnUrl)
        {
            oRepositorio = new ProdutosRepositorio();
            Produto oProduto = oRepositorio.Produtos.FirstOrDefault(p => p.ProdutoID == _ProdutoID);

            if (oProduto != null)
                Obter().RemoverItem(oProduto);

            return RedirectToAction("Index", new { _ReturnUrl });
        }

        public ViewResult Index(string _ReturnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = Obter(),
                ReturnUrl = _ReturnUrl
            });
        }
    }
}