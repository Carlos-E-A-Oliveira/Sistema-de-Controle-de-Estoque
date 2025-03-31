

namespace ControleDeEstoque.Models
{
    public class EstoqueService
    {
        //<Produto> lista que armazena instancias da classe Produto
        private List<Produto> _produtos = new List<Produto>();

        // Método para adicionar um produto ao estoque
        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }

        // Método para listar todos os produtos do estoque
        public List<Produto> ListarProdutos()
        {
            return _produtos;
        } 

        // Método para atualizar a quantidade de um produto
        public void AtualizarQuantidade(int id, int novaQuantidade)
        {
            Produto produto = _produtos.Find(p => p.Id == id);
            if(produto != null)
            {
                produto.Quantidade = novaQuantidade;
            }
            else
            {
                Console.WriteLine($"Produto com ID {id} não encontrado.");
            }
        }

        // Método para remover um produto do estoque
        public bool RemoverProduto(int id)
        {
            Produto? produto = _produtos.Find(p => p.Id == id);
            if(produto != null)
            {
                _produtos.Remove(produto);
                return true;
            }
            else
            {
                Console.WriteLine($"Produto com ID {id} não encontrado.");
                return false;
            }
        }
    }
}


