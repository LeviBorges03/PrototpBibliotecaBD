# Instruções para configurar o Banco de Dados no MySQL Workbench

Como você instalou recentemente o MySQL Workbench, o passo a passo para colocar as informações do banco de dados funcionando com o seu projeto é o seguinte:

1. Abra o **MySQL Workbench** e conecte-se na sua instância local (`Local instance 3306`).
   - A senha pedida provavelmente é a que você criou ao instalar, ou se quiser seguir igual ao seu projeto, a senha no código está `teste123` e o usuário `root`.
   - Se a sua senha no MySQL for diferente, modifique a configuração em `appsettings.json` na linha `"DefaultConnection": "server=localhost;port=3306;uid=root;pwd=SuaSenhaAqui;database=bibliotecadb"`.

2. Você não precisa criar a database e as tabelas na mão através de código SQL. O próprio Entity Framework Core cuida disso pra você utilizando o recurso de **Migrations**!

3. Abra o terminal na pasta raiz do projeto (`Biblioteca`, onde está o arquivo `Biblioteca.csproj`).

4. Para criar o banco de dados e aplicar as tabelas (já baseadas nas suas classes de Livro e Autor), rode o seguinte comando no terminal:
   ```bash
   dotnet ef database update
   ```
   **Dica:** Caso ele reclame que a ferramenta do Entity Framework não está instalada, instale rodando `dotnet tool install --global dotnet-ef` antes.

5. Após isso, você pode voltar ao **MySQL Workbench**, na aba `Schemas`, e recarregar (botão direito > `Refresh All`). Verá a database `bibliotecadb` criada e as tabelas `Livros` e `Autores` prontas para receber seus dados da aplicação MVC!
