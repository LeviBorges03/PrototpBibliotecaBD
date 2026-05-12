using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Biblioteca.Repositories;
using System;

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

    private List<Livro> _livrosFallback = new List<Livro>
    {
        new Livro { Titulo = "O Alquimista", Autor = "Paulo Coelho", Genero = "Ficção", NumPaginas = 208, DataPublicacao = new DateOnly(1988, 1, 1), CorCapa = "#F5B041" },
        new Livro { Titulo = "A Culpa é das Estrelas", Autor = "John Green", Genero = "Romance", NumPaginas = 313, DataPublicacao = new DateOnly(2012, 1, 10), CorCapa = "#5DADE2" },
        new Livro { Titulo = "Harry Potter and the Prisoner of Azkaban", Autor = "J.K. Rowling", Genero = "Fantasia", NumPaginas = 317, DataPublicacao = new DateOnly(1999, 7, 8), CorCapa = "#3498DB" },
        new Livro { Titulo = "Ensaio sobre a Lucidez", Autor = "José Saramago", Genero = "Alegoria", NumPaginas = 328, DataPublicacao = new DateOnly(2004, 1, 1), CorCapa = "#D35400" },
        new Livro { Titulo = "Ensaio sobre a Cegueira", Autor = "José Saramago", Genero = "Alegoria", NumPaginas = 310, DataPublicacao = new DateOnly(1995, 1, 1), CorCapa = "#F2F3F4" }
    };

    public IActionResult Index()
    {
        var livrosOrdenados = _livrosFallback.OrderByDescending(l => l.DataPublicacao).ToList();
        return View(livrosOrdenados);
    }

    public IActionResult Livro(string titulo)
    {
        if (string.IsNullOrEmpty(titulo))
        {
            return RedirectToAction("Index");
        }

        var livro = _livrosFallback.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
        if (livro == null)
        {
            // Cria um livro dummy com os dados para mostrar caso não ache
            livro = new Livro { Titulo = titulo, Autor = "Autor Desconhecido", CorCapa = "#34495E", DataPublicacao = DateOnly.FromDateTime(DateTime.Now), Genero = "Desconhecido", NumPaginas = 0 };
        }
        return View(livro);
    }

    public IActionResult Autor(string nome)
    {
        if (string.IsNullOrEmpty(nome))
        {
            return RedirectToAction("Index");
        }

        var autor = new Autor
        {
            Nome = nome,
            Biografia = "Biografia não disponível.",
            DataNascimento = DateOnly.FromDateTime(DateTime.Now),
            Livros = _livrosFallback.Where(l => l.Autor.Equals(nome, StringComparison.OrdinalIgnoreCase)).ToList()
        };

        return View(autor);
    }

    public IActionResult CriarLivro()
    {
        return View();
    }
   
    [HttpGet]
    public IActionResult CriarAutor()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriarLivro(Livro livro)
    {
        if (ModelState.IsValid)
        {
            await _livroRepository.CriarLivroAsync(livro);
            return RedirectToAction("Index");
        }
        return View(livro);
    }

    [HttpPost]
    public IActionResult CriarAutor(Autor autor)
    {
        if (ModelState.IsValid)
        {
            _autorRepository.Add(autor);
            return RedirectToAction("Index");
        }
        return View(autor);
    }
}
