using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompFacil.LojaVirtual.Dominio.Entidades;

namespace CompFacil.LojaVirtual.Dominio.Repositório
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        public void Salvar(Produto produto)
        {
            if(produto.ProdutoID == 0)
            {
                _context.Produtos.Add(produto);
            }
            else
            {
                Produto prod = _context.Produtos.Find(produto.ProdutoID);
                
                if (prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Preco = produto.Preco;
                    prod.Categoria = produto.Categoria;
                    prod.Imagem = produto.Imagem;
                    prod.ImagemMimeType = produto.ImagemMimeType;
                }
            }

            _context.SaveChanges();
        }

        public Produto Excluir (int produtoID)
        {
            Produto prod = _context.Produtos.Find(produtoID);
            
            if (prod != null)
            {
                _context.Produtos.Remove(prod);
                _context.SaveChanges();
            }

            return prod;
        }
    }
}
