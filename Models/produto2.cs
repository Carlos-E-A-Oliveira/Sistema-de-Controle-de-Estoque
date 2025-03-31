namespace ControleDeEstoque.Models
{
    public class Produto2
    {
        private int Id;
        private string Nome;
        private int Quantidade;
        private decimal Valor;

        public Produto2(int Id, string Nome, int Quantidade, decimal Valor)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Quantidade = Quantidade;
            this.Valor = Valor;
        }

        /* Método override sobrescreve o método padrão do ToString() da classe que, quando padrão,
        devolve apenas o nome da classe, enquanto com o override o retorno pode ser personalizado. */
        public override string ToString()
        {
            return $"Id: {Id} | Nome: {Nome} | Qtde: {Quantidade} | Valor: {Valor:C}";
        }



    }
}