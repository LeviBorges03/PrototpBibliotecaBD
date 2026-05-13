import re

with open('Biblioteca/Controllers/BibliotecaController.cs', 'r') as f:
    content = f.read()

# Try catch for _livroRepository.BuscarTodosLivros() and _autorRepository.GetAll()
content = content.replace(
    'var dbLivros = await _livroRepository.BuscarTodosLivros();',
    'List<Livro> dbLivros = null;\n        try { dbLivros = await _livroRepository.BuscarTodosLivros(); } catch { }'
)
content = content.replace(
    'var dbAutores = _autorRepository.GetAll();',
    'IEnumerable<Autor> dbAutores = null;\n            try { dbAutores = _autorRepository.GetAll(); } catch { }'
)

with open('Biblioteca/Controllers/BibliotecaController.cs', 'w') as f:
    f.write(content)
