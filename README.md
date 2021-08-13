# CursoIdiomasAPI

## Como usar

### Instalação
```
git clone https://github.com/fernandoareias/CursoIdiomasAPI.git
cd CursoIdiomasAPI
```

Documentação Completa Swagger => https://localhost:5001/swagger/index.html

## Exemplos

### Registrar Nova Turma

HTTP POST => https://localhost:5001/v1/cursos/professores/turmas

```
{
  "dataInicio": "11/12/2022",
  "dataFim": "15/06/2022",
  "professores": {
    "nome": "Bob",
    "email": "bob.bob@gmail.com"
  },
  "cursos": {
    "nome": "Inglês Básico",
    "cargaHoraria": 90
  }
}
```

### Novo Aluno

HTTPS POST => https://localhost:5001/v1/cursos/turmas/{turmaID}/alunos

```
{
  "nome": "Bob2",
  "email": "bob2.bob@gmail.com"
}
```

### Desativar uma matricula

HTTP PUT => https://localhost:5001/v1/cursos/turmas/alunos/matriculas/{matriculaId}

```
{
  "ativa": false
}
```
