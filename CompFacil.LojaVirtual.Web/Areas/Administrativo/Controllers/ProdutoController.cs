using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompFacil.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        public ActionResult Index()
        {
            return View();
        }
    }
}