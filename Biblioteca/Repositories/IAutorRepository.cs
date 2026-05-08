using Biblioteca.Models;

namespace Biblioteca.Repositories;

public interface IAutorRepository
{
    Task<List<Autor>> BuscarTodosAutoresAsync();
    Task<bool> CriarAutorAsync(Autor autor);
}
