/* Felipe de Carvalho Andrade - SI */

using System;
using System.IO;

namespace Exercicios.Categorias.TrabalhoPratico04 {
    // Classe principal responsável pela execução do sistema de apuração da eleição
    class TP4 {
        // Declaração dos arquivos de entrada e saída de dados para manipulação do sistema
        static StreamReader arqEntrada = new StreamReader("eleicao_in.txt");
        static StreamWriter arqSaida = new StreamWriter("eleicao_out.txt");

        // Ponto de entrada principal do programa e gerenciador do fluxo do programa
        public void EleicaoPrefeito() {
            int n = LerQuantidadeCandidatos();

            // Cria os vetores paralelos para armazenar os números e nomes dos 'n' candidatos
            int[] numCandidatos = new int[n];
            string[] nomesCandidatos = new string[n];

            LerCandidatos(numCandidatos, nomesCandidatos);

            int m = LerQuantidadeEleitores();

            // Cria os vetores para armazenar as informações cadastrais e o voto dos 'm' eleitores
            string[] titulosEleitores = new string[m];
            string[] nomesEleitores = new string[m];
            string[] datasNascEleitores = new string[m];
            int[] idadesEleitores = new int[m];
            int[] votosEleitores = new int[m];

            LerEleitores(titulosEleitores, nomesEleitores, datasNascEleitores, idadesEleitores, votosEleitores);

            // Processa a votação e exibe o balanço final da eleição
            MostrarResultado(numCandidatos, nomesCandidatos, votosEleitores);

            // Garante o fechamento dos arquivos utilizados no fluxo de dados
            arqEntrada.Close();
            arqSaida.Close();
        }

        // Realiza a leitura e validação da quantidade mínima de candidatos requisitada
        // Retorna: quantidade válida de candidatos (mínimo 3)
        static int LerQuantidadeCandidatos() {
            int qtd = 0;
        
            // Garante que o programa insista até obter pelo menos 3 candidatos
            while (!(qtd >= 3)) {
                string linha = arqEntrada.ReadLine()!;

                if (linha != null)
                    qtd = int.Parse(linha);
            }

            return qtd;
        }

        // Lê os dados cadastrais de cada candidato diretamente do arquivo texto
        // Parâmetro (numeros): vetor para armazenar os números dos candidatos
        // Parâmetro (nomes): vetor para armazenar os nomes dos candidatos
        static void LerCandidatos(int[] numeros, string[] nomes) {
            // Percorre o vetor preenchendo as informações na ordem correta do arquivo
            for (int i = 0; i < numeros.Length; i++) {
                numeros[i] = int.Parse(arqEntrada.ReadLine()!);
                nomes[i] = arqEntrada.ReadLine()!;
            }
        }

        // Realiza a leitura e validação da quantidade mínima de eleitores requisitada
        // Retorna: quantidade válida de eleitores (mínimo 10)
        static int LerQuantidadeEleitores() {
            int qtd = 0;
        
            // Garante que o programa insista até obter pelo menos 10 eleitores
            while (!(qtd >= 10)) {
                string linha = arqEntrada.ReadLine()!;

                if (linha != null)
                    qtd = int.Parse(linha);
            }

            return qtd;
        }

        // Lê o histórico completo de dados de cada eleitor a partir do arquivo
        // Parâmetros (titulos, nomes, datasNasc, idades, votos): vetores contendo os dados dos eleitores
        static void LerEleitores(string[] titulos, string[] nomes, string[] datasNasc, int[] idades, int[] votos) {
            // Laço sequencial estruturado para mapear todos os atributos de cada eleitor
            for (int i = 0; i < titulos.Length; i++) {
                titulos[i] = arqEntrada.ReadLine()!;
                nomes[i] = arqEntrada.ReadLine()!;
                datasNasc[i] = arqEntrada.ReadLine()!;
                idades[i] = int.Parse(arqEntrada.ReadLine()!);
                votos[i] = int.Parse(arqEntrada.ReadLine()!);
            }
        }

        // Determina a contagem de votos, verifica o vencedor e expõe o resultado
        // Parâmetro (numCandidatos): vetor com os números de identificação dos candidatos
        // Parâmetro (nomesCandidatos): vetor com os nomes dos candidatos
        // Parâmetro (votos): vetor contendo as escolhas de todos os eleitores
        static void MostrarResultado(int[] numCandidatos, string[] nomesCandidatos, int[] votos) {
            // Cria um vetor contador indexado para rastrear a quantidade de votos de cada candidato
            int[] contagemVotos = new int[numCandidatos.Length];
            int votosBrancos = 0;
            int votosNulos = 0;

            // Laço para apurar a opção de cada voto registrado
            for (int i = 0; i < votos.Length; i++) {
                int votoAtual = votos[i];

                // Identifica voto em branco de acordo com a regra (valor 0)
                if (votoAtual == 0)
                    votosBrancos++;
                else {
                    bool achouCandidato = false;

                    // Busca o número do candidato correspondente no vetor
                    for (int j = 0; j < numCandidatos.Length; j++) {
                        if (votoAtual == numCandidatos[j]) {
                            contagemVotos[j]++; // Incrementa o contador do candidato localizado
                            achouCandidato = true;
                            j = numCandidatos.Length; // Força a saída do laço interno (otimização)
                        }
                    }

                    // Se não corresponder a nenhum número cadastrado, contabiliza como nulo
                    if (!achouCandidato)
                        votosNulos++;
                }
            }

            // Exibição e gravação estruturada do cabeçalho de resultados
            ImprimirMensagem("==================================================");
            ImprimirMensagem("   RESULTADO DA ELEIÇÃO - FIM DO MUNDO DO SUL   ");
            ImprimirMensagem("==================================================");
            ImprimirMensagem($"Total de Eleitores que votaram: {votos.Length}");
            ImprimirMensagem("--------------------------------------------------");
            ImprimirMensagem("Votação dos Candidatos:");

            int maxVotos = -1;
            int indiceVencedor = -1;
            bool houveEmpate = false;

            // Laço para listar o desempenho individual e apurar o candidato majoritário
            for (int i = 0; i < numCandidatos.Length; i++) {
                ImprimirMensagem($" --> {nomesCandidatos[i]} ({numCandidatos[i]}): {contagemVotos[i]} votos");

                // Avalia se o candidato atual assume a liderança isolada
                if (contagemVotos[i] > maxVotos) {
                    maxVotos = contagemVotos[i];
                    indiceVencedor = i;
                    houveEmpate = false;
                }
                // Detecta uma situação de igualdade entre os mais votados
                else if (contagemVotos[i] == maxVotos && maxVotos > 0)
                    houveEmpate = true;
            }

            ImprimirMensagem("--------------------------------------------------");
            ImprimirMensagem($"Votos em Branco: {votosBrancos}");
            ImprimirMensagem($"Votos Nulos: {votosNulos}");
            ImprimirMensagem("--------------------------------------------------");

            // Define a mensagem final com base nas condições de empate e volume de votos
            if (houveEmpate)
                ImprimirMensagem("Resultado Final: Houve um EMPATE entre os candidatos mais votados!");
            else if (indiceVencedor != -1 && maxVotos > 0)
                ImprimirMensagem($"PREFEITO ELEITO: {nomesCandidatos[indiceVencedor]} com {maxVotos} votos!");
            else
                ImprimirMensagem("Resultado Final: Não houve votos válidos para nenhum candidato.");

            ImprimirMensagem("==================================================");
        }

        // Função utilitária responsável por centralizar as impressões em tela e arquivo simultaneamente
        // Parâmetro (texto): cadeia de caracteres a ser impressa e arquivada
        static void ImprimirMensagem(string texto) {
            Console.WriteLine(texto);
            arqSaida.WriteLine(texto);
        }
    }
}