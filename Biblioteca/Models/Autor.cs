namespace Biblioteca.Models;

public class Autor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; set; }
    public string? Nacionalidade { get; set; }
    public string? Biografia { get; set; }
    public List<Livro> Livros { get; set; } = new List<Livro>();
}
