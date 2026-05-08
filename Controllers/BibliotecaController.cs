
using Biblioteca.Models;
using Biblioteca.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class BibliotecaController : Controller
{
    private readonly ILivroRepository _livroRepository;
    private readonly IAutorRepository _autorRepository;

    public BibliotecaController(ILivroRepository livroRepository, IAutorRepository autorRepository)
    {
        _livroRepository = livroRepository;
        _autorRepository = autorRepository;
    }

    public IActionResult Index()
    {
        List<Livro> l1 = new List<Livro>()
        {
            new Livro
            {
                Titulo = "O Pequeno Príncipe",
                NumPaginas = 96,
                Autor = "Antoine de Saint-Exupéry",
                Genero = "Fábula",
                DataPublicacao = new DateOnly(1943, 4, 6)
            },

            new Livro
            {
                Titulo = "Jogos Vorazes",
                NumPaginas = 374,
                Autor = "Suzanne Collins",
                Genero = "Distopia",
                DataPublicacao = new DateOnly(2008, 9, 14)
            },

            new Livro
            {
                Titulo = "1984",
                NumPaginas = 328,
                Autor = "George Orwell",
                Genero = "Distopia",
                DataPublicacao = new DateOnly(1949, 6, 8)
            },

            new Livro
            {
                Titulo = "Percy Jackson e o Ladrão de Raios",
                NumPaginas = 400,
                Autor = "Rick Riordan",
                Genero = "Fantasia",
                DataPublicacao = new DateOnly(2005, 6, 28)
            },

            new Livro
            {
                Titulo = "O Alienista",
                NumPaginas = 112,
                Autor = "Machado de Assis",
                Genero = "Conto",
                DataPublicacao = new DateOnly(1882, 1, 1)
            },

            new Livro
            {
                Titulo = "Assassinato no Expresso do Oriente",
                NumPaginas = 256,
                Autor = "Agatha Christie",
                Genero = "Mistério",
                DataPublicacao = new DateOnly(1934, 1, 1)
            },

            new Livro
            {
                Titulo = "O Diário de Anne Frank",
                NumPaginas = 352,
                Autor = "Anne Frank",
                Genero = "Biografia",
                DataPublicacao = new DateOnly(1947, 6, 25)
            },

            new Livro
            {
                Titulo = "Um Estudo em Vermelho",
                NumPaginas = 188,
                Autor = "Arthur Conan Doyle",
                Genero = "Mistério",
                DataPublicacao = new DateOnly(1887, 1, 1)
            },

            new Livro
            {
                Titulo = "O Sol é para Todos",
                NumPaginas = 281,
                Autor = "Harper Lee",
                Genero = "Drama",
                DataPublicacao = new DateOnly(1960, 7, 11)
            },

            new Livro
            {
                Titulo = "Memórias Póstumas de Brás Cubas",
                NumPaginas = 300,
                Autor = "Machado de Assis",
                Genero = "Romance",
                DataPublicacao = new DateOnly(1881, 1, 1)
            },

            new Livro
            {
                Titulo = "A Menina que Roubava Livros",
                NumPaginas = 480,
                Autor = "Markus Zusak",
                Genero = "Drama",
                DataPublicacao = new DateOnly(2005, 3, 14)
            },

            new Livro
            {
                Titulo = "O Código Da Vinci",
                NumPaginas = 454,
                Autor = "Dan Brown",
                Genero = "Suspense",
                DataPublicacao = new DateOnly(2003, 4, 1)
            }
        };

        return View(l1);
    }

    public IActionResult Livro()
    {
        Livro livro = new Livro
        {
            Titulo = "O Pequeno Príncipe",
            Autor = "Antoine de Saint-Exupéry",
            Genero = "Fábula",
            DataPublicacao = new DateOnly(1943, 4, 6)
        };

        return View(livro);
    }

    public IActionResult Autor(string nome)
    {
        List<Autor> autores = new List<Autor>()
        {
            new Autor
            {
                Nome = "Antoine de Saint-Exupéry",
                DataNascimento = new DateOnly(1900, 6, 29),
                Biografia = "Escritor e aviador francês.",
                Livros = new List<Livro>()
            },

            new Autor
            {
                Nome = "Suzanne Collins",
                DataNascimento = new DateOnly(1962, 8, 10),
                Biografia = "Autora de Jogos Vorazes.",
                Livros = new List<Livro>()
            },

            new Autor
            {
                Nome = "George Orwell",
                DataNascimento = new DateOnly(1903, 6, 25),
                Biografia = "Autor de 1984.",
                Livros = new List<Livro>()
            },

            new Autor
            {
                Nome = "Rick Riordan",
                DataNascimento = new DateOnly(1964, 6, 5),
                Biografia = "Autor de Percy Jackson.",
                Livros = new List<Livro>()
            },

            new Autor
            {
                Nome = "Machado de Assis",
                DataNascimento = new DateOnly(1839, 6, 21),
                Biografia = "Mestre do Realismo brasileiro.",
                Livros = new List<Livro>()
            }
        };

        Autor autorSelecionado =
            autores.FirstOrDefault(a => a.Nome == nome) ?? autores[0];

        ViewBag.Autores = autores;

        return View(autorSelecionado);
    }

    public IActionResult CriarAutor()
    {
        return View();
    }

    public IActionResult CriarLivro()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriarLivroAsync(Livro livro)
    {
        await _livroRepository.CriarLivroAsync(livro);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> CriarAutorAsync(Autor autor)
    {
        await _autorRepository.CriarAutorAsync(autor);

        return RedirectToAction("Index");
    }
}