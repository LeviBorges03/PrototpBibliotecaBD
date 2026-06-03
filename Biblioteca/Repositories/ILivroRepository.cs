using Biblioteca.Models;

namespace Biblioteca.Repositories;

public interface ILivroRepository
{
    Task<List<Livro>> BuscarTodosLivros();
    Task<bool> CriarLivroAsync(Livro livro);
}
