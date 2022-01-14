using System;
using DIO.Series.Classes.Filme;

namespace DIO.Series
{
    class Program
    {
        // Declarando a variavel repositorio instancianda em SerieRepositorio
    
    static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
    static SerieRepositorio repositorio = new SerieRepositorio();
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
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        ListarFilme();
                        break;
                    case "7":
                        InserirFilme();
                        break;
                    case "8":
                        AtualizarFilme();
                        break;
                    
                    case "9":
                        ExcluirFilme();
                        break;

                    case "10":
                        VisualizarFilme();
                        break;

                    case "C":
                        Console.Clear();
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        public static void VisualizarFilme()
        {
            Console.WriteLine("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

        private static void AtualizarFilme()
        {
            Console.WriteLine("Digite o Id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Dgite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorioFilme.Atualiza(indiceFilme, atualizaFilme);

        }
        public static void ExcluirFilme()
        {
            Console.WriteLine("Digite o Id do filme a ser excluido: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            repositorioFilme.Exclui(indiceFilme);
        }
        public static void ListarFilme()
        {
            Console.WriteLine("Listar Filmes: ");
            var lista = repositorioFilme.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Filme cadastrado!");
                return;
            }
            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#{0} - {1} {2}", filme.retornaId(), filme.retornaTitulo(), excluido? "*Excluido*" : "" );
            }
        }
        
        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioFilme.Insere(novoFilme);
                                    
        }
        
        public static void VisualizarSerie()
        {
            Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        public static void ExcluirSerie()
        {
            Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }


        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista(); // variavel lista recebe a Lista() instanciada em SerieRepositorio

            if (lista.Count == 0) // O .Count faz a contagem da lista e verifica se e vazia ou não
            {
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }
            foreach (var serie in lista) // Para cada variavel serie na lista
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("#{0} - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? " *Excluido*" : "");
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            /* Faz a varredura dentro dentro do enum de Genero. 
            O GetValues vai retornar todas as opções e o GetName vai 
            exibir cada opção
            */
            foreach (int i in Enum.GetValues(typeof(Genero))) // Para cada inteiro i no Enum de Genero
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static string ObterOpcaoUsuario() // CRIAÇÃO MÉTODO PARA OBTER OPÇÃO DO MENU
        {
            Console.WriteLine();
            Console.WriteLine("LF Séries ao seu dispor!!!");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("6- Listar Filmes");
            Console.WriteLine("7- Inserir novo filme");
            Console.WriteLine("8- Atualizar Filme");
            Console.WriteLine("9- Excluir filmme");
            Console.WriteLine("10-Visualizar Filme");
            Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
