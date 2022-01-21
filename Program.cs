using System;
using Dio_Cinematics;

namespace Dio_Cinematics
{
    class Program
    {
        static CinematicsRepositorio repositorio = new CinematicsRepositorio();
        static void Main(string[] args)
        { string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarCinematics();
						break;
					case "2":
						InserirCinematic();
						break;
					case "3":
						AtualizarCinematic();
						break;
					case "4":
						ExcluirCinematic();
						break;
					case "5":
						VisualizarCinematic();
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
        private static void ExcluirCinematic()
		{
			Console.Write("Digite o id da Cinematic que deseja excluir: ");
			int indiceCinematic = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceCinematic);
		}

        private static void VisualizarCinematic()
		{
			Console.Write("Digite o id da cinematic que deseja visualizar: ");
			int indiceCinematic = int.Parse(Console.ReadLine());

			var cinematic = repositorio.RetornaPorId(indiceCinematic);

			Console.WriteLine(cinematic);
		}

        private static void AtualizarCinematic()
		{
			Console.Write("Digite o id da cinematic que deseeja atualizar: ");
			int indiceCinematic = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da cinematic: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da cinematic: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da cinematic: ");
			string entradaDescricao = Console.ReadLine();

			Cinematic atualizaCinematic = new Cinematic(id: indiceCinematic,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceCinematic, atualizaCinematic);
		}
        private static void ListarCinematics()
		{
			Console.WriteLine("Listar cinematics");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma cinematic cadastrada.");
				return;
			}

			foreach (var cinematic in lista)
			{
                var excluido = cinematic.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", cinematic.retornaId(), cinematic.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirCinematic()
		{
			Console.WriteLine("Inserir nova cinematic");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Cinematic: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Cinematic: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Cinematic: ");
			string entradaDescricao = Console.ReadLine();

			Cinematic novaCinematic = new Cinematic(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaCinematic);
		}
        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Cinematics a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar cinematic");
			Console.WriteLine("2- Inserir nova cinematic");
			Console.WriteLine("3- Atualizar cinematic");
			Console.WriteLine("4- Excluir cinematic");
			Console.WriteLine("5- Visualizar cinematic");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
