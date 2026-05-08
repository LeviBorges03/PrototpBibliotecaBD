using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly BibliotecaContext _context;

    public LivroRepository(BibliotecaContext context)
    {
        _context = context;
    }

    public async Task<List<Livro>> BuscarTodosLivrosAsync()
    {
        return await _context.Livros.ToListAsync();
    }

    public async Task<bool> CriarLivroAsync(Livro livro)
    {
        try
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}