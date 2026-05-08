using Biblioteca.Models;

namespace Biblioteca.Repositories;

public interface ILivroRepository
{
    Task<List<Livro>> BuscarTodosLivrosAsync();
    Task<bool> CriarLivroAsync(Livro livro);
}
