using System;
using System.IO; // IO = Input/Output de entrada e saída

 namespace OEscriba
{
    class Program
    {
        static void Main(string[] args)
        {
            // O loop infinito (Coração do menu)
            while (true)
            {
                // Limpar a tela antes de mostrar menu novamente
                Console.Clear();

                Console.WriteLine("===📜 O ESCRIBA DIGITAL 📜 ===");
                Console.WriteLine("1 - Escrever nova memória");
                Console.WriteLine("2 - Ler memórias antigas");
                Console.WriteLine("0 - Sair");
                Console.Write("Qual o seu desejo? ");

                string opcao = Console.ReadLine();

                // A árvore da decisão
                if (opcao == "1")
                {
                    Console.WriteLine("\nEscreva sua memória (aperte Enter para salvar):");
                    // Usar File.AppendAllText para adicionar texto ao arquivo
                    File.AppendAllText("memorias.txt", Console.ReadLine() + Environment.NewLine);
                    Console.WriteLine("Memória salva com sucesso! Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                }
                else if (opcao == "2")
                {
                    Console.WriteLine("\n=== LENDO O DIÁRIO ===");
                    // Usar File.ReadAllText para ler o conteúdo do arquivo
                    if (File.Exists("memorias.txt"))
                    {
                        string conteudo = File.ReadAllText("memorias.txt");
                        Console.WriteLine(conteudo);
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma memória encontrada. Escreva uma nova memória primeiro!");
                    }
                    // Se arquivo não existir, usar if (File.Exists("memorias.txt"))
                    Console.WriteLine("\nFim da leitura. Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                }
                else if (opcao == "0")
                {
                    Console.WriteLine("Fechando diário... Até a próxima!");
                    break; // Quebra o loop while e encerra o programa
                }
                else
                {
                    Console.WriteLine("Opção desconhecida, viajante.");
                    Console.ReadKey(); // Espere a pessoa ler antes de limpar a tela
                }
            }
        }
    }
}
