/* Felipe de Carvalho Andrade - SI */

// Namespace utilizado para organizar o código dentro do projeto
namespace Exercicios.Categorias.TrabalhoPratico02 {

    // Classe principal da aplicação
    public class TP2 {

        // Método principal, onde a execução do programa se inicia
        public void EleicaoPrefeito() {

            // Variável que controla se haverá nova eleição (em caso de empate)
            bool houveEmpate;

            // Loop principal: executa novamente caso haja empate
            do {
                houveEmpate = false; // reinicia controle de empate

                // =========================
                // 1. Entrada de Dados
                // =========================

                Console.WriteLine("=== ELEIÇÃO PARA PREFEITO ===\n");

                int numeroEleitores; // armazena quantidade de eleitores

                // Validação: número de eleitores deve ser >= 10
                do {
                    Console.Write("Informe o número de eleitores (mínimo 10): ");
                } while (!int.TryParse(Console.ReadLine(), out numeroEleitores) || numeroEleitores < 10);

                // Leitura dos números dos candidatos
                int numeroTeobaldo; // número do candidato Teobaldo
                Console.Write("Informe o número do candidato Teobaldo: ");
                while (!int.TryParse(Console.ReadLine(), out numeroTeobaldo) || numeroTeobaldo == 0) {
                    Console.Write("Valor inválido. Digite novamente (diferente de 0): ");
                }

                int numeroAstrogildo; // número do candidato Astrogildo
                Console.Write("Informe o número do candidato Astrogildo: ");
                while (!int.TryParse(Console.ReadLine(), out numeroAstrogildo) || numeroAstrogildo == 0 || numeroAstrogildo == numeroTeobaldo) {
                    Console.Write("Valor inválido. Digite novamente (diferente de 0 e do outro candidato): ");
                }

                // =========================
                // 2. Inicialização de contadores
                // =========================

                int votosTeobaldo = 0;   // contador de votos do Teobaldo
                int votosAstrogildo = 0; // contador de votos do Astrogildo
                int votosBrancos = 0;    // contador de votos em branco
                int votosNulos = 0;      // contador de votos nulos

                // =========================
                // 3. Leitura dos votos
                // =========================

                for (int i = 1; i <= numeroEleitores; i++) {
                    Console.Write($"Voto do eleitor {i}: ");
                    int voto; // variável para armazenar o voto do eleitor

                    // Validação de entrada
                    while (!int.TryParse(Console.ReadLine(), out voto)) {
                        Console.Write("Valor inválido. Digite novamente: ");
                    }

                    // Classificação do voto
                    if (voto == 0) 
                        votosBrancos++; // voto em branco
                    else if (voto == numeroTeobaldo) 
                        votosTeobaldo++; // voto para Teobaldo
                    else if (voto == numeroAstrogildo) 
                        votosAstrogildo++; // voto para Astrogildo
                    else 
                        votosNulos++; // voto inválido
                }

                // =========================
                // 4. Cálculo de votos válidos
                // =========================

                int votosValidos = votosTeobaldo + votosAstrogildo; // soma apenas votos válidos

                // =========================
                // 5. Resultado da eleição
                // =========================

                Console.WriteLine("\n=== RESULTADO DA ELEIÇÃO ===");
                Console.WriteLine($"Teobaldo ({numeroTeobaldo}): {votosTeobaldo} voto(s)");
                Console.WriteLine($"Astrogildo ({numeroAstrogildo}): {votosAstrogildo} voto(s)");
                Console.WriteLine($"Votos em branco: {votosBrancos}");
                Console.WriteLine($"Votos nulos: {votosNulos}");

                // =========================
                // 6. Verificação de empate
                // =========================

                if (votosTeobaldo > votosAstrogildo) {
                    double percentual = ((double)votosTeobaldo / votosValidos) * 100; // calcula percentual

                    Console.WriteLine("\nTeobaldo venceu a eleição!");
                    Console.WriteLine($"Percentual do vencedor: {percentual:F2}%");
                }
                else if (votosAstrogildo > votosTeobaldo) {
                    double percentual = ((double)votosAstrogildo / votosValidos) * 100; // calcula percentual

                    Console.WriteLine("\nAstrogildo venceu a eleição!");
                    Console.WriteLine($"Percentual do vencedor: {percentual:F2}%");
                }
                else {
                    Console.WriteLine("\nEmpate! Nova eleição será realizada...\n");
                    houveEmpate = true; // ativa repetição do processo
                }

            } while (houveEmpate); // repete se houve empate

            Console.WriteLine("\nProcesso finalizado. Pressione qualquer tecla para sair...");
            Console.ReadKey(); // aguarda interação do usuário
        }
    }
}