namespace Core {
    class MenuPrincipal {
        public void Iniciar() {
            int opcao;

            do
            {
                Console.WriteLine("===== SISTEMA DE EXERCÍCIOS =====");
                Console.WriteLine("1 - Exercícios Iniciais");
                Console.WriteLine("2 - Exercícios Condicionais");
                Console.WriteLine("3 - Exercícios de Repetição");
                Console.WriteLine("4 - Exercícios de Vetores e Matrizes");
                Console.WriteLine("5 - Exercícios do Laboratório");
                Console.WriteLine("6 - Trabalho Prático 01");
                Console.WriteLine("7 - Trabalho Prático 02");
                Console.WriteLine("8 - Trabalho Prático 03");
                Console.WriteLine("0 - Sair");

                Console.Write("Escolha: ");
                opcao = int.Parse(Console.ReadLine()!);

                Console.Clear();

                MenuCategoria menuCategoria = new MenuCategoria();
                menuCategoria.AbrirCategoria(opcao);

            } while (opcao != 0);
        }
    }
}