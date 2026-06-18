using Exercicios.Categorias.Iniciais;
using Exercicios.Categorias.Condicionais;
using Exercicios.Categorias.Laboratorio;
using Exercicios.Categorias.Repeticoes;
using Exercicios.Categorias.Vetores;
using Exercicios.Categorias.TrabalhoPratico01;
using Exercicios.Categorias.TrabalhoPratico02;
using Exercicios.Categorias.TrabalhoPratico03;
using Exercicios.Categorias.TrabalhoPratico04;

namespace Core {
    class MenuCategoria {
        public void AbrirCategoria(int categoria) {
            switch (categoria) {
                case 1:
                    new Iniciais().Menu();
                    break;

                case 2:
                    new Condicionais().Menu();
                    break;

                case 3:
                    new Repeticao().Menu();
                    break;

                case 4:
                    new Vetores().Menu();
                    break;

                case 5:
                    new Laboratório().Menu();
                    break;

                case 6:
                    new TP1().RealizarCompra();
                    break;

                case 7:
                    new TP2().EleicaoPrefeito();
                    break;
                
                case 8:
                    new TP3().SistemaDeTemperatura();
                    break;

                case 9:
                    new TP4().EleicaoPrefeito();
                    break;

                case 0:
                    Console.WriteLine("Encerrando...");
                    break;
                
                default:
                    Console.WriteLine("Categoria inválida.");
                    break;
            }
        }
    }
}