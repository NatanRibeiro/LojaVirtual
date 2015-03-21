using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompFacil.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        //Lista
        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();

        //Adicionar
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.ProdutoID == produto.ProdutoID);

            if(item == null)
            {
                _itemCarrinho.Add(new ItemCarrinho
                    {
                        Produto = produto,
                        Quantidade = quantidade
                    });
            }
        }

        //Remover
        public void RemoverItem(Produto produto)
        {
            _itemCarrinho.RemoveAll(l =>  l.Produto.ProdutoID == produto.ProdutoID);
        }
        
        //Total
        public decimal ObterValorTotal()
        {
            return _itemCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        //Itens 
        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itemCarrinho; }
        }

        //Limpar
        public  void LimparCarrinho()
        {
            _itemCarrinho.Clear();
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}