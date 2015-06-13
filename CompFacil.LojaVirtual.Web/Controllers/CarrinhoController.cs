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

        public ViewResult Index(Carrinho carrinho, string ReturnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = carrinho,
                ReturnUrl = ReturnUrl
            });
        }

        public PartialViewResult Resumo(Carrinho carrinho)
        {
            return PartialView(carrinho);
        }
        
        public RedirectToRouteResult Adicionar(Carrinho carrinho, int ProdutoID, string ReturnUrl)
        {
            Repositorio = new ProdutosRepositorio();
            Produto oProduto = Repositorio.Produtos.FirstOrDefault(p => p.ProdutoID == ProdutoID);

            if (oProduto != null)
            {
                carrinho.AdicionarItem(oProduto, 1);
            }

            return RedirectToAction("Index", new { ReturnUrl = ReturnUrl });
        }
        
        public RedirectToRouteResult Remover(Carrinho carrinho, int ProdutoID, string ReturnUrl)
        {
            Repositorio = new ProdutosRepositorio();
            Produto oProduto = Repositorio.Produtos.FirstOrDefault(p => p.ProdutoID == ProdutoID);

            if (oProduto != null)
                carrinho.RemoverItem(oProduto);

            return RedirectToAction("Index", new { _ReturnUrl = ReturnUrl });
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Carrinho carrinho, Pedido pedido)
        {
            EmailConfigurado email = new EmailConfigurado
            {
                EscreverArquivo = bool.Parse(ConfigurationManager
                .AppSettings["Email.EscreverArquivo"] ?? "false")
            };

            EmailPedido emailPedido = new EmailPedido(email);

            if (!carrinho.ItensCarrinho.Any())
                ModelState.AddModelError("", "Não foi possível concluir o pedido, seu carrinho esta vazio!");

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
                return View(pedido);
        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }
    }
}