using DIO.Gaming.Classes;
using System;


namespace DIO.Gaming
{
    internal class Program
    {
        static gamesRepositorio repositorio = new gamesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarGames();
                        break;
                    case "2":
                        InserirGames();
                        break;
                    case "3":
                        AtualizarGame();
                        break;
                    case "4":
                        ExcluirGame();
                        break;
                    case "5":
                        VisualizarGame();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirGame()
        {
            Console.Write("Digite o ID do Game: ");
            int indiceGame = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceGame);
        }

        private static void VisualizarGame()
        {
            Console.Write("Digite o ID do Game: ");
            int indiceGame = int.Parse(Console.ReadLine());

            var Game = repositorio.RetornaPorID(indiceGame);

            Console.WriteLine(Game);
        }

        private static void AtualizarGame()
        {
            Console.Write("Digite o ID do Game: ");
            int indiceGame = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do Game: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento do Game: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Game");
            string entradaDescricao = Console.ReadLine();

            Games atualizarGames = new Games(id: indiceGame,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceGame, atualizarGames);
        }
        private static void ListarGames()
        {
            Console.WriteLine("Listar Games");

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Game cadastrado.");
                return;
            }

            foreach (var Game in lista)
            {
                var Excluido = Game.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", Game.retornaId(), Game.retornaTitulo(), (Excluido ? "*Excluido*" : ""));
            }
        }

        private static void InserirGames()
        {
            Console.WriteLine("Inserir novo Game");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");

            int entradaGeneros = ValidaInput(Console.ReadLine());

            if (entradaGeneros == -99)
            {
                Console.WriteLine("\n \n APENAS NÚMEROS VÁLIDOS \n \n INSERIR OPÇÕES DE GÊNERO DE 1 A 13 \n \n ");

                InserirGames();
            }

            Console.Write("Digite o título do Game: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento do Game: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Game: ");
            string entradaDescricao = Console.ReadLine();

            Games novaGames = new Games(id: repositorio.ProximoID(),
                                        genero: (Genero)entradaGeneros,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaGames);
        }

        private static int ValidaInput(string input)
        {
            int output;
            if (!int.TryParse(input, out output))
            {
                return -99;
            }

            return output;
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Gaming a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Games");
            Console.WriteLine("2- Inserir novo Game");
            Console.WriteLine("3- Atualizar Game");
            Console.WriteLine("4- Excluir Game");
            Console.WriteLine("5- Visualizar Game");
            Console.WriteLine("c- Limpar Tela");
            Console.WriteLine("X- Sairl");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

