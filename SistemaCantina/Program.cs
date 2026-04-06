/* 
USO DAS HEURÍSTICAS DE NIELSEN
Heurística #1 (Visibilidade do Status): partindo da ideia de que o usuário siga as instruões fornecidas 
para finalizar o pedido, ao avançar pelas escolhas é exibida uma mensagem no topo da tela, informando o 
status atual do programa.

Heurística #3 (Controle e Liberdade): foi usado ao dar a opção ao usuário de cancelar seu pedido a qualquer
momento e também de voltar à tela anterior sempre que avançar.

Heurística #9 (Ajuda e Erros): quando o usuário digita um número diferente do que o sistema aceita, o programa
exibe uma mensagem explicativa de erro (em vermelho), para que esse não cometa o mesmo erro e possa 
prosseguir corretamente no pedido.
*/



using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var itens = new Dictionary<int, string>()
        {
            {1, "Hambúrguer"},
            {2, "Pão de queijo"},
            {3, "Cachorro-quente"},
            {4, "Empada de frango"},
            {5, "Coxinha"},
            {6, "Quibe"},
            {7, "Mini-pizza"},
            {8, "Salada de frutas"},
            {9, "Pastel de carne"},
            {10, "Pastel de queijo"}
        };

        int CodigoProduto = 0;
        int QuantidadeProduto = 0;

        while (true)
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Status atual: [Passo 1 de 3 - Escolha de lanche]\n");

                Console.WriteLine("Menu da Cantina:");
                foreach (var escolha in itens)
                {
                    Console.WriteLine($"{escolha.Key} - {escolha.Value}");
                }

                Console.WriteLine("\nDigite o código do lanche que deseja:");
                Console.WriteLine("Ou digite 'cancelar' para sair.");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }

                if (!int.TryParse(entrada, out CodigoProduto))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entrada inválida. Digite um valor numérico.");
                    Console.ResetColor();
                    Pausar();
                    continue;
                }

                if (!itens.ContainsKey(CodigoProduto))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Código {CodigoProduto} não encontrado. Escolha um número entre 1 e 10.");
                    Console.ResetColor();
                    Pausar();
                    continue;
                }

                break;
            }


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Status atual: [Passo 2 de 3 - Quantidade]\n");
                Console.WriteLine($"Produto: {itens[CodigoProduto]}");

                Console.WriteLine("Digite a quantidade do produto escolhido:");
                Console.WriteLine("Ou digite 'voltar' para retornar à tela de seleção;");
                Console.WriteLine("Ou digite 'cancelar' para esquecer pedido.");

                string entrada = Console.ReadLine().ToLower();

                if (entrada == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }

                if (entrada == "voltar")
                {
                    break;
                }

                if (!int.TryParse(entrada, out QuantidadeProduto))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite um número válido.");
                    Console.ResetColor();
                    Pausar();
                    continue;
                }

                if (QuantidadeProduto <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantidade deve ser maior que zero.");
                    Console.ResetColor();
                    Pausar();
                    continue;
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Status atual: [Passo 3 de 3 - Confirmação]\n");

                    Console.WriteLine($"Produto: {itens[CodigoProduto]}");
                    Console.WriteLine($"Quantidade: {QuantidadeProduto}");

                    Console.WriteLine("\nConfirmar pedido? (S/N)");
                    Console.WriteLine("Ou digite 'voltar' para retornar à tela anterior;");
                    Console.WriteLine("Ou digite 'cancelar' para esquecer pedido.");

                    string resposta = Console.ReadLine().ToLower();

                    if (resposta == "cancelar")
                    {
                        Console.WriteLine("Pedido cancelado.");
                        return;
                    }

                    if (resposta == "voltar")
                    {
                        break;
                    }

                    if (resposta == "s")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Pedido realizado com sucesso! Obrigado pela preferência!");
                        Console.ReadKey();
                        return;
                    }

                    if (resposta == "n")
                    {
                        break;
                    }
                }
            }
        }
    }
    static void Pausar()
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}