using ControleDeEstoque.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        // Criando o serviço de estoque
        EstoqueService estoqueService = new EstoqueService();
        bool continuar = true;

        while(continuar){
            /* Console.Clear(); */
            Console.WriteLine("Controle de Estoque:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Adicionar Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Atualizar quantidade de produto");
            Console.WriteLine("4. Remover Produto");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("5. Sair");
            Console.ResetColor();
            Console.WriteLine("Escolha uma opção");

            string opcao = Console.ReadLine();

            switch(opcao)
            {
                case "1":
                    AdicionarProduto(estoqueService);
                    break;
                case "2":
                    ListarProduto(estoqueService);
                    break;
                case "3":
                    AtualizarQuantidade(estoqueService);
                    break;
                case "4":
                    RemoverProduto(estoqueService);
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.Write("Opção inválida. Tente novamente.");
                    break;
                /* Nota:
                o parâmetro (estoqueService) nos métodos auxiliares serve para que tal método saiba 
                qual instância da classe EstoqueService estaria sendo solicitado caso haja mais de 
                uma instância, isso permite a modulação e reutilização dos métodos auxiliares.*/
            }
            
            static void AdicionarProduto(EstoqueService estoqueService)
            {
                Console.Write("Digite o Id do Produto\n");
                int Id = int.Parse(Console.ReadLine());

                if(estoqueService.ListarProdutos().Any(p => p.Id == Id))
                {
                    Console.WriteLine("Erro: Este Id já existe na lista!");
                    return;
                }

                Console.Write("Digite o nome do Produto\n");
                string nome = Console.ReadLine();

                Console.Write("Digite a Quantidade\n");
                int quantidade = int.Parse(Console.ReadLine());

                Console.Write("Digite o Preço\n");
                decimal preco = decimal.Parse(Console.ReadLine());

                Produto produto = new Produto(Id, nome, quantidade, preco);

                estoqueService.AdicionarProduto(produto);
                Console.WriteLine("Produto adicionado com sucesso!");
            }

            static void ListarProduto(EstoqueService estoqueService)
            {
                Console.WriteLine("\nProdutos no estoque:");

                foreach(var produto in estoqueService.ListarProdutos())
                {
                    Console.WriteLine(produto);
                }
            }

            static void AtualizarQuantidade(EstoqueService estoqueService)
            {
                Console.Write("Digite o Id do produto para atualizar:");
                int Id = int.Parse(Console.ReadLine());
                Console.Write("Digite a nova quantidade:");
                int quantidade = int.Parse(Console.ReadLine());

                estoqueService.AtualizarQuantidade(Id,quantidade);
                Console.Write("Quantidade atualizada com sucesso!");

            }

            static void RemoverProduto(EstoqueService estoqueService)
            {
                Console.Write("Digite o Id do produto para remover:");
                int Id = int.Parse(Console.ReadLine());

                bool removido = estoqueService.RemoverProduto(Id);

                if(removido)
                {
                    Console.Write("Produto removido com sucesso!");
                }else
                {
                    Console.Write("Produto não encontrado.");
                }

            }
        }

       
    }
    
}
