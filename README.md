# 🚗 Projeto NeohConcessionaria
Este projeto é um sistema de gerenciamento de concessionárias desenvolvido em **ASP.NET MVC**.

## 📌 Pré-requisitos

Antes de rodar o projeto, certifique-se de ter instalado:

- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) ou [SQL Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-editions-express)
- [Visual Studio](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

---

## 🚀 Rodando no Visual Studio

1. **Clone o repositório**
   ```sh
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd seu-repositorio
   ```
2. **Abra o projeto no Visual Studio**
   - Abra o `Visual Studio`.
   - No menu, clique em **"Abrir um projeto ou solução"**.
   - Selecione o arquivo `.sln` do projeto.

3. **Configure a string de conexão** 	
   - No arquivo `appsettings.json`, configure sua `ConnectionString` corretamente (mesma configuração mencionada acima).
   - Caso tenha o sqlser instalado basta rodar as migrations
	
4. **Rodar as Migrations** 
   ```sh
   dotnet ef database update
   ```

5. **Executar o projeto**
   - Pressione `F5` ou clique em `Iniciar` no Visual Studio.

---

## ⚡ Rodando no VS Code

1. **Clone o repositório**
   ```sh
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd seu-repositorio
   ```

2. **Abra o projeto no VS Code**
   ```sh
   code .
   ```

3. **Instale a extensão C#** (se ainda não tiver)
   - No VS Code, vá para `Extensões (Ctrl + Shift + X)` e instale a extensão `C# (Omnisharp)`.

4. **Configure a string de conexão**
   - No arquivo `appsettings.json`, configure sua `ConnectionString` corretamente (mesma configuração mencionada acima).

5. **Rodar as Migrations**
   ```sh
   dotnet ef database update
   ```

6. **Executar o projeto**
   ```sh
   dotnet run --project NeohConcessionaria.MVC
   ```

---

## 📚 Mais informações
- [Documentação do ASP.NET MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [C# e .NET](https://learn.microsoft.com/en-us/dotnet/csharp/)

---

✍️ **Autor:** Murilo Cavalcanti  
