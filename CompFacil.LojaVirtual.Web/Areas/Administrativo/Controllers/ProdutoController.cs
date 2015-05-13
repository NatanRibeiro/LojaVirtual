using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompFacil.LojaVirtual.Dominio.Entidades;
using CompFacil.LojaVirtual.Dominio.Repositório;

namespace CompFacil.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        public ActionResult Index()
        {
            _repositorio = new ProdutosRepositorio();

            var produtos = _repositorio.Produtos;

            return View(produtos);
        }

        public ViewResult Alterar(int ProdutoID)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoID == ProdutoID);

            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            if(ModelState.IsValid)
            {
                _repositorio = new ProdutosRepositorio();
                _repositorio.Salvar(produto);

                TempData["mensagem"] = string.Format("{0} Salvo com Sucesso", produto.Nome);

                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ViewResult NovoProduto()
        {
            return View("Alterar", new Produto());
        }

        //[HttpPost]
        //public ActionResult Excluir(int produtoID)
        //{
        //    _repositorio = new ProdutosRepositorio();

        //    Produto prod = _repositorio.Excluir(produtoID);

        //    if (prod != null)
        //    {
        //        TempData["mensagem"] = string.Format("{0} Excluído com sucesso!", prod.Nome);
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public JsonResult Excluir(int ProdutoID)
        {
            string mensagem = string.Empty;
            _repositorio = new ProdutosRepositorio();

            Produto prod = _repositorio.Excluir(ProdutoID);

            if (prod != null)
            {
                mensagem = string.Format("{0} Excluído com sucesso!", prod.Nome);
            }

            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }
    }
}