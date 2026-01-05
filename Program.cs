using System;
using System.IO; // IO = Input/Output de entrada e saída
using System.Collections.Generic; // Necessário para usar List<string>

 namespace OEscriba
{
    class Program
    {
    
        static void MensagemSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green; // Texto verde
            Console.WriteLine(mensagem);
            Console.ResetColor(); // Volta à cor padrão
        }
        static void MensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red; // Texto vermelho
            Console.WriteLine(mensagem);
            Console.ResetColor(); // Volta à cor padrão
        }
        static void MensagemLeitura(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Texto amarelo
            Console.WriteLine(mensagem);
            Console.ResetColor(); // Volta à cor padrão
        }
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
                Console.WriteLine("3 - Apagar todas as memórias (opção secreta)");
                Console.WriteLine("4 - Apagar uma memória específica");
                Console.WriteLine("0 - Sair");
                Console.Write("Qual o seu desejo? ");

                string opcao = Console.ReadLine();

                // A árvore da decisão
                if (opcao == "1")
                {
                    Console.WriteLine("\nEscreva sua memória (aperte Enter para salvar):");
                    // Usar File.AppendAllText para adicionar texto ao arquivo
                    File.AppendAllText("memorias.txt", Console.ReadLine() + Environment.NewLine);     
                    MensagemSucesso("Memória salva com sucesso! Pressione qualquer tecla para voltar ao menu.");           
                    Console.ReadKey();
                }
                else if (opcao == "2")
                {
                    Console.WriteLine("\n=== LENDO O DIÁRIO ===");
                    // Usar File.ReadAllText para ler o conteúdo do arquivo
                    if (File.Exists("memorias.txt"))
                    {
                        string conteudo = File.ReadAllText("memorias.txt");
                        MensagemLeitura(conteudo);
                    }
                    else
                    {
                        MensagemErro("=== Nenhuma memória encontrada. Escreva uma nova memória primeiro! ===");                        
                    }
                    // Se arquivo não existir, usar if (File.Exists("memorias.txt"))
                    Console.WriteLine("\nFim da leitura. Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                }
                else if (opcao == "3")
                {
                    // Opção secreta para apagar memórias
                    Console.WriteLine("\nTem certeza que deseja apagar todas as memórias? (s/n)");
                    string confirmacao = Console.ReadLine();
                    if (confirmacao.ToLower() == "s")
                    {
                        if (File.Exists("memorias.txt"))
                        {
                            File.Delete("memorias.txt");
                            MensagemSucesso("Todas as memórias foram apagadas.");
                       }
                        else
                        {
                            MensagemErro("Nenhuma memória para apagar.");
                        }
                    }
                    else
                    {
                        MensagemErro("Operação cancelada.");
                    }
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                }
                else if (opcao == "4")
                {
                    // Opção para apagar apenas uma memória selecionada
                    Console.WriteLine("\n=== LENDO O DIÁRIO ===");
                    Console.WriteLine("\n=== APAGANDO UMA MEMÓRIA ESPECÍFICA ===");
                    if (File.Exists("memorias.txt"))
                    {
                        // Carrega tudo para a memória RAM
                        string[] linhasArray = File.ReadAllLines("memorias.txt");
                        List<string> listaMemorias = new List<string>(linhasArray);

                        // Mostra a lista numerada para usuário escolher
                        Console.WriteLine("Qual memória você quer apagar?");
                        for (int i = 0; i < listaMemorias.Count; i++)
                        {
                            // Mostra: "1 - Memória"
                            MensagemLeitura($"{i + 1} - {listaMemorias[i]}");
                        }
                        // Lê o número que o usário digitar
                        Console.WriteLine("Digite o número da memória a ser apagada:");
                        string input = Console.ReadLine();

                        // Garantindo que é esse número 
                        if (int.TryParse(input, out int numeroDigitado))
                        {
                            // Validação, número maior que 0 e menor ou igual ao total de memórias
                            if (numeroDigitado > 0 && numeroDigitado <= listaMemorias.Count)
                            {
                                // Remove (lembrar do -1 pois a lista começa no 0)
                                listaMemorias.RemoveAt(numeroDigitado - 1);

                                // Salva de volta no arquivo 
                                File.WriteAllLines("memorias.txt", listaMemorias);
                                MensagemSucesso("Memória apagada com sucesso.");
                            }
                            else
                            {
                                MensagemErro("Número inválido! essa memória não existe.");
                            }
                        }
                        else
                        {
                            MensagemErro("Isso não é um número!");
                        }
                }
                else 
                {
                    MensagemLeitura("O diário está vazio. Escreva uma memória primeiro!");
                }
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
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
