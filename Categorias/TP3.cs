/* Felipe de Carvalho Andrade - SI */

namespace Exercicios.Categorias.TrabalhoPratico03  {
    // Classe principal responsável pela execução do sistema de controle de temperaturas
    public class TP3 {
        // Ponto de entrada principal do programa. Gerencia o fluxo e o menu
        public void SistemaDeTemperatura()  {
            Console.WriteLine("=== INICIALIZAÇÃO DO SISTEMA ===");
            
            int n = 0;
            bool numeroValido = false;

            do
            {
                Console.Write("Número de cidades envolvidas: ");
                if (int.TryParse(Console.ReadLine()!, out n) && n > 0)
                    numeroValido = true; 
                else
                    Console.WriteLine("Erro: Por favor, digite um número inteiro maior que zero.\n");
            } while (!numeroValido);

            // Cria o vetor para armazenar os nomes das 'n' cidades
            string[] cidades = new string[n]; 
            
            // Cria a matriz para armazenar as medições das 'n' cidades 
            double[,] medicoes = new double[n, 8]; 

            InicializarMatriz(medicoes); 

            Console.WriteLine();
            
            for (int i = 0; i < n; i++)  {
                Console.Write($"Nome da cidade {i + 1}: ");
                cidades[i] = Console.ReadLine()!.Trim().ToUpper();
            }

            char opcao;
            Console.Clear();

            do
            {
                Console.WriteLine("\n=== MENU DE CONTROLE DE TEMPERATURAS ===");
                Console.WriteLine("a) Registrar temperatura de uma cidade"); 
                Console.WriteLine("b) Exibir temperaturas de uma cidade"); 
                Console.WriteLine("c) Exibir temperaturas geral"); 
                Console.WriteLine("d) Exibir temperatura média de uma cidade"); 
                Console.WriteLine("e) Exibir temperaturas médias geral"); 
                Console.WriteLine("f) Sair"); 
                Console.Write("\nEscolha: ");
                
                // Captura a tecla pressionada e converte para minúsculo
                opcao = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                switch (opcao) {
                    case 'a':
                        RegistraTemperatura(medicoes, cidades);
                        break;
                    case 'b':
                        ExibirTemperaturasCidade(medicoes, cidades);
                        break;
                    case 'c':
                        ExibirTemperaturasGeral(medicoes, cidades);
                        break;
                    case 'd':
                        ExibirMediaCidade(medicoes, cidades);
                        break;
                    case 'e':
                        ExibirMediaGeral(medicoes, cidades);
                        break;
                    case 'f':
                        Console.WriteLine("Encerrando o sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            } while (opcao != 'f'); // Mantém o sistema rodando até o usuário escolher 'f'
        }

        // Inicializa a matriz preenchendo-a com double.NaN para representar slots vazios
        // Parâmetro (medicoes): matriz de medições de temperatura
        public static void InicializarMatriz(double[,] medicoes) {
            // Percorre todas as linhas (cidades)
            for (int i = 0; i < medicoes.GetLength(0); i++) {
                // Percorre todas as colunas (medições)
                for (int j = 0; j < medicoes.GetLength(1); j++) 
                    medicoes[i, j] = double.NaN; // Simula o estado "vazio"
            }
        }

        // Realiza a leitura, validação e busca no vetor de cidades
        // Parâmetro (cidades): vetor contendo os nomes de todas as cidades cadastradas
        public static int BuscaElementos(string[] cidades) {
            int linha = -1;
            string cidade;

            do
            {
                Console.Write("Informe o nome da cidade (ou digite 'sair' para retornar): ");
                cidade = Console.ReadLine()!.Trim();
                
                if (cidade.ToLower() == "sair") 
                    return -1;

                // Realiza a busca no vetor
                for (int i = 0; i < cidades.Length; i++)  
                    if (cidades[i] == cidade.ToUpper()) 
                        linha = i;

                if (linha == -1) 
                    Console.WriteLine("Erro: Cidade inválida. Tente de novamente.\n");
            } while (linha == -1);

            return linha; // Retorna o índice encontrado ou -1 se o usuário digitou 'sair'
        }

        // Desloca os valores da matriz para a direita e insere o novo na primeira coluna
        // Parâmetro (medicoes): matriz de temperaturas
        // Parâmetro (temperatura): novo valor de temperatura a ser registrado
        // Parâmetro (linha): linha da matriz correspondente à cidade selecionada
        public static void DeslocaValores(double[,] medicoes, double temperatura, int linha) {
            int colunas = medicoes.GetLength(1);
            
            // Move os valores de trás para frente para evitar que dados sejam sobrescritos
            for (int i = colunas - 1; i > 0; i--)  
                medicoes[linha, i] = medicoes[linha, i - 1]; // O dado atual assume o valor do seu vizinho da esquerda
            
            // O novo registro assume o início da linha (coluna 0)
            medicoes[linha, 0] = temperatura; 
        }

        // Registra a temperatura de uma cidade específica
        // Parâmetro (medicoes): matriz de temperaturas
        // Parâmetro (cidades): vetor contendo os nomes das cidades
        public static void RegistraTemperatura(double[,] medicoes, string[] cidades) {
            Console.WriteLine("\n=== REGISTRAR TEMPERATURA ===");
            
            int linha = BuscaElementos(cidades);
            
            if (linha == -1) 
                return;

            double temperatura = 0;
            bool tempValida = false;
            string entradaTemp;

            do
            {
                Console.Write("Informe a temperatura atual (°C) (ou digite 'sair' para retornar): ");
                entradaTemp = Console.ReadLine()!.Trim();

                if (entradaTemp == "sair") 
                    return;

                if (double.TryParse(entradaTemp, out temperatura))
                    tempValida = true;
                else
                    Console.WriteLine("Erro: Valor inválido. Digite um número decimal correspondente à temperatura.\n");
            } while (!tempValida);

            DeslocaValores(medicoes, temperatura, linha);
            Console.WriteLine("\nRegistro efetuado com sucesso!");

            Console.ReadKey(); // Aguarda a interação do teclado
        }

        // Exibe o histórico de medições da cidade escolhida
        // Parâmetro (medicoes): matriz de temperaturas
        // Parâmetro (cidades): vetor contendo os nomes das cidades
        public static void ExibirTemperaturasCidade(double[,] medicoes, string[] cidades)  {
            Console.WriteLine("\n=== EXIBIR TEMPERATURAS DA CIDADE ===");
            
            int linha = BuscaElementos(cidades);
            
            if (linha == -1) 
                return;

            Console.WriteLine($"\nTemperaturas registradas para {cidades[linha]}:");
            
            for (int j = 0; j < medicoes.GetLength(1); j++) {
                // Substitui o valor NaN por uma mensagem amigável
                string valor = double.IsNaN(medicoes[linha, j]) ? "-" : $"{medicoes[linha, j]:F1}°C";
                Console.WriteLine($"Medição {j + 1}: {valor}");
            }

            Console.ReadKey(); // Aguarda a interação do teclado
        }

        // Exibe todas as cidades e suas respectivas medições simultaneamente em formato de tabela
        // Parâmetro (medicoes): matriz de temperaturas
        // Parâmetro (cidades): vetor contendo os nomes das cidades
        public static void ExibirTemperaturasGeral(double[,] medicoes, string[] cidades)  {
            Console.WriteLine("\n=== TABELA GERAL DE TEMPERATURAS ===\n");
            
            // Alinha o cabeçalho usando formatação de string (18 caracteres fixos à esquerda para o nome da cidade)
            Console.Write($"{"Cidade",-18}");
            for (int i = 1; i <= medicoes.GetLength(1); i++)
                Console.Write($"{"Med " + i,-10}");

            Console.WriteLine();

            // Laço para renderizar as linhas e colunas estruturadas
            for (int i = 0; i < cidades.Length; i++) {
                Console.Write($"{cidades[i],-18}"); 
                
                for (int j = 0; j < medicoes.GetLength(1); j++) {
                    // Caso o slot esteja vazio, exibe um hífen indicando falta de dado
                    string valor = double.IsNaN(medicoes[i, j]) ? "-" : $"{medicoes[i, j]:F1}°C";
                    Console.Write($"{valor,-10}");
                }
                Console.WriteLine(); 
            }

            Console.ReadKey(); // Aguarda a interação do teclado
        }

        // Calcula e expõe a média térmica da cidade específica escolhida
        // Parâmetro (medicoes): matriz de temperaturas
        // Parâmetro (cidades): vetor contendo os nomes das cidades
        public static void ExibirMediaCidade(double[,] medicoes, string[] cidades)  {
            Console.WriteLine("\n=== MÉDIA DA CIDADE ===");

            int linha = BuscaElementos(cidades);
            
            if (linha == -1) 
                return;

            // Invoca a função responsável pelo cálculo matemático
            double media = CalcularMediaLinha(medicoes, linha);
            
            if (double.IsNaN(media))
                Console.WriteLine($"\nNão há registros de temperatura suficientes para {cidades[linha]}.");
            else
                Console.WriteLine($"\nA temperatura média de {cidades[linha]} é: {media:F2}°C");
                
            Console.ReadKey(); // Aguarda a interação do teclado
        }

        // Exibe uma listagem contendo a média de cada uma das cidades
        // Parâmetro (medicoes): matriz de temperaturas
        // Parâmetro (cidades): vetor contendo os nomes das cidades
        public static void ExibirMediaGeral(double[,] medicoes, string[] cidades)  {
            Console.WriteLine("\n=== MÉDIA GERAL DAS CIDADES ===\n");
            
            for (int i = 0; i < cidades.Length; i++) {
                double media = CalcularMediaLinha(medicoes, i);
                string valor = double.IsNaN(media) ? "-" : $"{media:F2}°C";
                
                Console.WriteLine($"{cidades[i],-18}: {valor}");
            }
            
            Console.ReadKey(); // Aguarda a interação do teclado
        }

        // Função responsável por somar e extrair a média aritmética pulando os slots vazios (NaN)
        // Parâmetro (medicoes): matriz de temperaturas
        // Parâmetro (linha): linha da matriz correspondente à cidade selecionada
        private static double CalcularMediaLinha(double[,] medicoes, int linha) {
            double soma = 0;
            int contador = 0;

            for (int j = 0; j < medicoes.GetLength(1); j++) 
                // Ignora valores não numéricos
                if (!double.IsNaN(medicoes[linha, j])) {
                    soma += medicoes[linha, j];
                    contador++;
                }

            // Previne o erro de divisão por zero caso a cidade não tenha dados
            return contador > 0 ? (soma / contador) : double.NaN;
        }
    }
}