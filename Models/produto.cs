namespace ControleDeEstoque.Models
{
    public class Produto
    {
        public int Id {get;set;} // get/set melhora o controle sobre os valores das variáveis.
        public string Nome {get;set;}
        public int Quantidade {get;set;}
        public decimal Preco {get;set;}

        public Produto(int Id, string Nome, int Quantidade, decimal Preco)
        { 
            this.Id = Id;
            this.Nome = Nome;
            this.Quantidade = Quantidade;
            this.Preco = Preco;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Nome: {Nome} | Quantidade: {Quantidade} | Preço: {Preco:C}";
        }

    }
}

