# CursoIdiomasAPI

## Regras de negócio

- [x] Aluno deve ser cadastrado com turma;

```
var turma = await context.Turmas.AsNoTracking().FirstOrDefaultAsync(y => y.Id == idTurmas);
if(turma == null)
    return BadRequest("Não foi possível encontrar a turma");
...

context.Alunos.Add(model);
await context.SaveChangesAsync();
```

- [x] Matrícula do aluno não pode ser repetida;

```
[Key]
public int Id { get; private set; }
```

- [x] Uma turma não pode ter mais de 5 alunos;

```
var aluno = await context.Alunos.AsNoTracking().Where(x => x.TurmaId == idTurmas).ToListAsync();
if (aluno.ToArray().Length >= 5)
    return BadRequest(new { message = "Essa turma já está cheia, tente registrar o aluno em outra." });
```

- [x] Turma não pode ser excluída se possuir alunos;

```
var aluno = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.TurmaId == idTurma);
if (aluno != null)
    return BadRequest(new { message = "Não é possivel remover esta turma, pois existe alunos matriculados" });
```
