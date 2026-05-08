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
            }
        };

        var livrosOrdenados = l1.OrderByDescending(l => l.DataPublicacao).ToList();
        return View(livrosOrdenados);
    }

    public IActionResult Livro()
    {
        return View();
    }

    public IActionResult Autor()
    {
        return View();
    }

    public IActionResult CriarLivro()
    {
        return View();
    }

    public IActionResult CriarAutor()
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
