# Instruções para o Banco de Dados (MySQL Workbench)

1. Abra o MySQL Workbench e conecte-se ao seu servidor local (usuário `root`, senha `teste123` - conforme configurado no `appsettings.json`). A porta configurada é `3306`.
2. Abra uma nova aba de query (SQL).
3. Execute o seguinte comando para criar o banco de dados:

```sql
CREATE DATABASE bibliotecadb;
```

4. No Entity Framework Core, as tabelas são criadas automaticamente usando Migrations. Para aplicar as migrations ao banco de dados que você acabou de criar, abra o terminal na pasta do projeto (`Biblioteca`) e execute:

```bash
dotnet ef database update
```

*(Observação: a ferramenta `dotnet ef` precisa estar instalada. Se não estiver, instale-a com `dotnet tool install --global dotnet-ef` e lembre-se de adicionar ao PATH conforme as instruções do comando. A migration InicialCreate já foi criada no projeto.)*
