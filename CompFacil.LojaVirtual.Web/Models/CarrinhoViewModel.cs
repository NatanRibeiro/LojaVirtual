using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompFacil.LojaVirtual.Dominio.Entidades;

namespace CompFacil.LojaVirtual.Web.Models
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }

        public string ReturnUrl { get; set; }
    }
}