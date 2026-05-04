/* Felipe de Carvalho Andrade - SI */

// Namespace utilizado para organizar o código dentro do projeto
namespace Exercicios.Categorias.TrabalhoPratico01 {

    // Classe principal da aplicação
    public class TP1 {

        // Método principal, onde a execução do programa se inicia
        public void RealizarCompra() {

            // =========================
            // 1. Entrada de Dados
            // =========================

            // Exibe mensagem inicial orientando o usuário sobre a entrada de dados
            Console.WriteLine("=== INFORME OS DADOS ABAIXO ===\n");

            // Solicita ao usuário o valor total da compra
            Console.Write("Valor Total da Compra: ");

            // Tenta converter a entrada para double e valida se o valor é não negativo
            // Caso falhe, o programa é encerrado para evitar inconsistência nos cálculos
            if (!double.TryParse(Console.ReadLine(), out double valorCompra) || valorCompra < 0) {
                Console.WriteLine("Valor inválido.");
                Console.WriteLine("Encerrando o Programa...");
                return; // Interrompe execução em caso de erro
            }

            // leitura da Forma de Pagamento - 'D' representa Dinheiro e 'C' representa Cartão
            Console.Write("Forma de Pagamento (D para Dinheiro / C para Cartão): ");

            // Captura entrada, padroniza para maiúsculo e evita nulos
            string inputPagamento = Console.ReadLine()?.ToUpper() ?? ""; 

            // Converte a string para char pegando o primeiro índice
            char tipoPagamento = inputPagamento.Length > 0 ? inputPagamento[0] : ' ';

            // Valida se a opção de pagamento é uma das permitidas ('D' ou 'C')
            if (tipoPagamento != 'D' && tipoPagamento != 'C') {
                Console.WriteLine("Erro: Forma de pagamento inválida. Use 'D' ou 'C'.");
                return;
            }

            // Leitura do Tipo de Cliente - 'N' representa Cliente Normal e 'F' representa Cliente Fidelidade
            Console.Write("Tipo de Cliente (N para Normal / F para Cliente Fidelidade): ");

            // Captura entrada, padroniza para maiúsculo e evita nulos
            string inputCliente = Console.ReadLine()?.ToUpper() ?? "";

            // Converte a string para char pegando o primeiro índice
            char tipoCliente = inputCliente.Length > 0 ? inputCliente[0] : ' ';

            // Valida se a opção de cliente é uma das permitidas ('N' ou 'F')
            if (tipoCliente != 'N' && tipoCliente != 'F') {
                Console.WriteLine("Erro: Tipo de cliente inválido. Use 'N' ou 'F'.");
                return;
            }

            // Variável acumuladora que armazena o percentual total de desconto aplicado
            // O valor é representado em formato decimal (ex: 0.05 = 5%)
            double percentualDesconto = 0.0;

            // =========================
            // 2. Desconto por pagamento
            // =========================

            // Aplica regras de desconto baseadas na forma de pagamento escolhida
            if (tipoPagamento == 'D') // Pagamento em dinheiro
            {
                if (valorCompra <= 100)
                    percentualDesconto += 0.05; // Compras até R$100 recebem 5% de desconto
                else
                    percentualDesconto += 0.10; // Compras acima de R$100 recebem 10% de desconto
            }
            else if (tipoPagamento == 'C') // Pagamento via cartão
            {
                if (valorCompra <= 100) 
                    percentualDesconto += 0.0;  // Compras pequenas não recebem desconto (Atribuição Explícita)
                else if (valorCompra <= 300)
                    percentualDesconto += 0.05; // Faixa intermediária recebe 5%
                else
                    percentualDesconto += 0.10; // Compras altas recebem 10%
            }
            else {
                // Validação extra (não deve ocorrer devido à função de validação)
                Console.WriteLine("Forma de pagamento inválida.");
                return;
            }

            // =========================
            // 3. Desconto por fidelidade
            // =========================

            // Condição: apenas para compras acima de R$200
            if (tipoCliente == 'F' && valorCompra > 200) {
                percentualDesconto += 0.05; // Acrescenta 5% adicional
            }

            // =========================
            // 4. Regra extra (Fidelidade + Dinheiro)
            // =========================

            // Regra adicional: combinação de cliente fidelidade + pagamento em dinheiro
            if (tipoCliente == 'F' && tipoPagamento == 'D') {
                percentualDesconto += 0.02; // Acrescenta 2% extra
            }

            // =========================
            // 5. Limite máximo de desconto
            // =========================

            // Define um teto máximo de 15% para qualquer combinação de regras
            if (percentualDesconto > 0.15) {
                percentualDesconto = 0.15;
            }

            // =========================
            // 6. Cálculo final
            // =========================

            // Calcula o valor monetário do desconto com base no percentual acumulado
            double valorDesconto = valorCompra * percentualDesconto;

            // Calcula o valor final a ser pago após aplicação do desconto
            double valorFinal = valorCompra - valorDesconto;

            // =========================
            // 7. Saída de Dados
            // =========================

            // Exibe os resultados finais de forma formatada para o usuário
            Console.WriteLine("\n=== RESULTADO ===");

            // Mostra o valor original informado
            Console.WriteLine($"Valor original: R$ {valorCompra:F2}");

            // Mostra o percentual total de desconto aplicado (convertido para %)
            Console.WriteLine($"Desconto aplicado: {percentualDesconto * 100:F0}%");

            // Mostra o valor absoluto do desconto em reais
            Console.WriteLine($"Valor do desconto: R$ {valorDesconto:F2}");

            // Mostra o valor final após desconto
            Console.WriteLine($"Valor final: R$ {valorFinal:F2}");
        }

    }
} 