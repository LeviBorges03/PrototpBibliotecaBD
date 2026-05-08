using Biblioteca.Models;


namespace Biblioteca.Repositories;

public class LivroRepository :   ILivro.Repository

    readonly BibliotecaContext; _context;
publi LivroRepository( BibliotecaContext context)
{
    _context = context;
}

public async Task<List<Livro>> BuscarTodosLivros();
{
    return await _context. Livros.TolistAsync();
}


public async Task<bool> CriarLivroAsync (Livro livro)

{
    await _context.Livro.AddAsync(livro);
    await _context.SaveChanges

}