using System;

namespace APP.Cadastro
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new NotImplementException();
                }
            }
        }

        
        private static void VisualizarSeries()
        {
            Console.WriteLine("Informe o Id");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(idSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSeries()
        {
            Console.WriteLine("Informe o Id");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui()idSerie;
        }

        private static void AtualizarSeries()
        {
            Console.WriteLine("Informe o Id");
            int idSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o Gênero");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o Título");
            string entraTitulo = Console.ReadLine();

            Console.WriteLine("Informe o Ano");
            int entraAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a Descrição");
            string entraDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(
                id: idSerie,
                genero: entraGenero,
                titulo: entraTitulo,
                ano: entraAno,
                descricao: entraDescricao
            );

            repositorio.Atualiza(idSerie, atualizaSerie);
        }        

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir");

            Console.WriteLine("Informe o Gênero");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o Título");
            string entraTitulo = Console.ReadLine();

            Console.WriteLine("Informe o Ano");
            int entraAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a Descrição");
            string entraDescricao = Console.ReadLine();

            Series novaSerie = new Series(
                id: repositorio.ProximoId(),
                genero: entraGenero,
                titulo: entraTitulo,
                ano: entraAno,
                descricao: entraDescricao
            );

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nada Cadastrado!");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe Opção Desejada:");

            Console.WriteLine("1- Listar");
            Console.WriteLine("2- Inserir");
            Console.WriteLine("3- Atualizar");
            Console.WriteLine("4- Excluir");
            Console.WriteLine("5- Visualizar");
            Console.WriteLine("C- Limpar");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
