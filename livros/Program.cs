using System;
using System.Collections.Generic;

class Livro
{
    public int Codigo { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoPublicacao { get; set; }

    public Livro(int codigo, string titulo, string autor, int anoPublicacao)
    {
        Codigo = codigo;
        Titulo = titulo;
        Autor = autor;
        AnoPublicacao = anoPublicacao;
    }

    public override string ToString()
    {
        return $"Código: {Codigo}, Título: {Titulo}, Autor: {Autor}, Ano: {AnoPublicacao}";
    }
}

class Program
{
    static List<Livro> colecaoLivros = new List<Livro>();

    static void Main()
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("=== Sistema de Gerenciamento de Livros ===");
            Console.WriteLine("1. Adicionar um livro");
            Console.WriteLine("2. Listar todos os livros");
            Console.WriteLine("3. Remover um livro");
            Console.WriteLine("4. Buscar um livro pelo título");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    AdicionarLivro();
                    break;
                case 2:
                    ListarLivros();
                    break;
                case 3:
                    RemoverLivro();
                    break;
                case 4:
                    BuscarLivro();
                    break;
                case 5:
                    sair = true;
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void AdicionarLivro()
    {
        Console.Write("Digite o código do livro: ");
        int codigo = int.Parse(Console.ReadLine());
        Console.Write("Digite o título do livro: ");
        string titulo = Console.ReadLine();
        Console.Write("Digite o autor do livro: ");
        string autor = Console.ReadLine();
        Console.Write("Digite o ano de publicação: ");
        int anoPublicacao = int.Parse(Console.ReadLine());

        Livro novoLivro = new Livro(codigo, titulo, autor, anoPublicacao);
        colecaoLivros.Add(novoLivro);
        Console.WriteLine("Livro adicionado com sucesso!");
    }

    static void ListarLivros()
    {
        if (colecaoLivros.Count == 0)
        {
            Console.WriteLine("Nenhum livro cadastrado.");
        }
        else
        {
            foreach (var livro in colecaoLivros)
            {
                Console.WriteLine(livro);
            }
        }
    }

    static void RemoverLivro()
    {
        Console.Write("Digite o código do livro a ser removido: ");
        int codigo = int.Parse(Console.ReadLine());

        Livro livroRemover = colecaoLivros.Find(livro => livro.Codigo == codigo);

        if (livroRemover != null)
        {
            colecaoLivros.Remove(livroRemover);
            Console.WriteLine("Livro removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    static void BuscarLivro()
    {
        Console.Write("Digite o título do livro que deseja buscar: ");
        string titulo = Console.ReadLine();

        Livro livroEncontrado = colecaoLivros.Find(livro => livro.Titulo.ToLower().Contains(titulo.ToLower()));

        if (livroEncontrado != null)
        {
            Console.WriteLine("Livro encontrado:");
            Console.WriteLine(livroEncontrado);
        }
        else
        {
            Console.WriteLine("Nenhum livro encontrado com esse título.");
        }
    }
}

