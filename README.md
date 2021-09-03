## O que é

É uma API data driven para um curso de idiomas fictício.

### Observação
Atualmente está utilizando modelo anêmico, na V2 será implementado modelo rico e testes.

## Instalação

```
git clone https://github.com/fernandoareias/CursoIdiomasAPI.git
```

### Gerando as tabelas

Configure a connection string em **appsettings.json**

```
 "connectionString" : "server=<HOST>,<PORT>;database=<DATABASE>;User ID=<USER>;Password=<PASSWORD>"
```

Exemplo:

```
  "connectionString" : "server=localhost,1433;database=CursoIdiomasAPI;User ID=sa;Password=kp#@lkpkpç12"
```

Dentro da pasta do repositório, execute os seguintes comandos para gerar as tabelas no SQL Server

```
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Documentação

Documentação Completa Swagger => https://localhost:5001/swagger/index.html

## Regras de negócio

- [x] [Aluno deve ser cadastrado com turma](https://github.com/fernandoareias/CursoIdiomasAPI/blob/main/Controllers/AlunosControllers.cs#L106-L146)
- [x] [Matrícula do aluno não pode ser repetida](https://github.com/fernandoareias/CursoIdiomasAPI/blob/main/Models/Matricula.cs#L12-L29)
- [x] [Uma turma não pode ter mais de 5 alunos](https://github.com/fernandoareias/CursoIdiomasAPI/blob/main/Controllers/AlunosControllers.cs#L117-#L123)
- [x] [Turma não pode ser excluída se possuir alunos](https://github.com/fernandoareias/CursoIdiomasAPI/blob/main/Controllers/TurmasController.cs#L98-L103)
