using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompFacil.LojaVirtual.Dominio.Entidades;

namespace CompFacil.LojaVirtual.Web.Models
{
    public class ProdutosViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }

        public Paginacao Paginacao { get; set; }

    }
}