using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}