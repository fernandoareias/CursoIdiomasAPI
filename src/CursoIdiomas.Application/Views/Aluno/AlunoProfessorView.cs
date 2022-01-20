using CursoIdiomas.Domain.Entities;
using System;

namespace CursoIdiomas.Application.Views.Aluno
{
    public class AlunoProfessorView
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public AlunoProfessorCursoView Curso { get; set; }
        public AlunoProfessorView(Professor professor)
        {
            Id = professor.Id;
            Nome = professor.Nome.ToString();
            Curso = new AlunoProfessorCursoView(professor.Curso);
        }
    }
}
