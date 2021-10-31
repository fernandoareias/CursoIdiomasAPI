using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace CursoIdiomas.Domain.Entities
{
    public class Matricula : Entity
    {
       
        public long AlunoId { get;  set; }
        public  Alunos Aluno { get;  set; }
        public long TurmaId { get;   set; }
        public  Turma Turma { get;  set; }

    }
}
