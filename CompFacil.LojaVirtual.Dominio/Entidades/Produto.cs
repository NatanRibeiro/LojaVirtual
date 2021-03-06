﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CompFacil.LojaVirtual.Dominio.Entidades
{
    public class Produto
    {
        [HiddenInput(DisplayValue = false)]
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "Digite o nome do produto!")]
        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Digite a descrição do produto!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite o valor do produto!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor inválido!")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Digite a categoria do produto!")]
        public string Categoria { get; set; }

        public byte[] Imagem { get; set; }

        public string ImagemMimeType { get; set; }
    }
}
