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
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 3;
        
        // GET: Vitrine
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = _repositorio.Produtos
                    .Where(p => categoria == null || p.Categoria == categoria)
                    .OrderBy(p => p.Descricao)
                    .Skip((pagina - 1)*ProdutosPorPagina)
                    .Take(ProdutosPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()
                },

                CategoriaAtual = categoria

            };

            return View(model);
        }

        //[Route("Vitrine/ObterImagem/{produtoID}")]
        //public FileContentResult ObterImagem(int produtoID)
        //{
        //    _repositorio = new ProdutosRepositorio();
        //    Produto prod = _repositorio.Produtos
        //        .FirstOrDefault(p => p.ProdutoID == produtoID);

        //    if (prod != null)
        //        return File(prod.Imagem, prod.ImagemMimeType);

        //    return null;
        //}
    }
}