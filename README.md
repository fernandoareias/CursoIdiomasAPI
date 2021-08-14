## O que é 

É uma API para um curso de idiomas fictício.
  
## Instalação

```
git clone https://github.com/fernandoareias/CursoIdiomasAPI.git
```

### Gerando as tabelas

Configure a connection string em __appsettings.json__

```
 "connectionString" : "server=<HOST>,PORT;database=<DATABASE>;User ID=<USER>;Password=<PASSWORD>"
```

Exemplo:


```
  "connectionString" : "server=localhost,1433;database=CursoIdiomasAPI;User ID=sa;Password=kp#@lkpkpç12"
```

Dentro da pasta do repositório, execute os seguintes comandos para gerar as tabelas no SQL Server

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Documentação

Documentação Completa Swagger => https://localhost:5001/swagger/index.html

## Regras de negócio

- [X] [Aluno deve ser cadastrado com turma](https://github.com/fernandoareias/CursoIdiomasAPI/blob/main/Controllers/AlunosControllers.cs#L70-L110)
- [X] [Matrícula do aluno não pode ser repetida](https://github.com/fernandoareias/CursoIdiomasAPI/blob/main/Models/Matricula.cs#L12-L29)
- [X] [Uma turma não pode ter mais de 5 alunos](https://github.com/fernandoareias/CursoIdiomasAPI/blob/main/Controllers/AlunosControllers.cs#L82-#L87)
- [X] [Turma não pode ser excluída se possuir alunos](https://github.com/fernandoareias/CursoIdiomasAPI/blob/main/Controllers/TurmasController.cs#L137-L144)
