using System;
using System.IO; // Necessário para manipulação de arquivos
using System.Collections.Generic;

namespace OEscriba
{
    class Program
    {
        static void MensagemSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine(mensagem);
            Console.ResetColor(); 
        }
        static void MensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor(); 
        }
        static void MensagemLeitura(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine(mensagem);
            Console.ResetColor(); 
        }

        static void EscreverMemoria()
        {
            Console.WriteLine("\nEscreva sua memória (aperte Enter para salvar):");
            string texto = Console.ReadLine();
            File.AppendAllText("memorias.txt", texto + Environment.NewLine);     
            MensagemSucesso("Memória salva com sucesso! Pressione qualquer tecla para voltar ao menu.");           
            Console.ReadKey();
        }

        static void LerMemorias()
        {
            Console.WriteLine("\n=== LENDO O DIÁRIO ===");
            if (File.Exists("memorias.txt"))
            {
                string conteudo = File.ReadAllText("memorias.txt");
                MensagemLeitura(conteudo);
            }
            else
            {
                MensagemErro("=== Nenhuma memória encontrada. Escreva uma nova memória primeiro! ===");                        
            }
            Console.WriteLine("\nFim da leitura. Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        static void ApagarTodasMemorias()
        {
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

        static void ApagarMemoriaEspecifica()
        {
            Console.WriteLine("\n=== LENDO O DIÁRIO ===");
            Console.WriteLine("\n=== APAGANDO UMA MEMÓRIA ESPECÍFICA ===");
            if (File.Exists("memorias.txt"))
            {
                string[] linhasArray = File.ReadAllLines("memorias.txt");
                List<string> listaMemorias = new List<string>(linhasArray);

                Console.WriteLine("Qual memória você quer apagar?");
                for (int i = 0; i < listaMemorias.Count; i++)
                {
                    MensagemLeitura($"{i + 1} - {listaMemorias[i]}");
                }
                Console.WriteLine("Digite o número da memória a ser apagada:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int numeroDigitado))
                {
                    if (numeroDigitado > 0 && numeroDigitado <= listaMemorias.Count)
                    {
                        listaMemorias.RemoveAt(numeroDigitado - 1);
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
        static void Main(string[] args)
        {
        bool continuarNarrativa = true;
        while (continuarNarrativa)
        {
                Console.Clear();
                Console.WriteLine("===📜 O ESCRIBA DIGITAL 📜 ===");
                Console.WriteLine("1 - Escrever nova memória");
                Console.WriteLine("2 - Ler memórias antigas");
                Console.WriteLine("3 - Apagar todas as memórias");
                Console.WriteLine("4 - Apagar uma memória específica");
                Console.WriteLine("0 - Sair");
                Console.Write("Qual o seu desejo? ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                    EscreverMemoria();
                    break;
                    case "2":
                    LerMemorias();
                    break;
                    case "3":
                    ApagarTodasMemorias();
                    break;
                    case "4":
                    ApagarMemoriaEspecifica();
                    break;
                    case "0":
                    Console.WriteLine("Fechando diário... Até a próxima!");
                    continuarNarrativa = false;
                    break;
                    default:
                    Console.WriteLine("Opção desconhecida, viajante.");
                    Console.ReadKey(); // Espere a pessoa ler antes de limpar a tela
                    break;
                }
            }

            
            Console.WriteLine("O programa foi encerrado corretamente.");
            Console.ReadKey();
        }
    }
    }
