using CursoIdiomas.Application.Views.Aluno;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoIdiomas.Application.Views
{
    public class AlunoView
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<AlunoMatriculaView> Matriculas { get; set; }
        //public List<AlunoMensalidadeView> Mensalidades { get; set; }
        //public List<AlunoBoletimView> Boletins { get; set; }

        public AlunoView(Alunos aluno)
        {
            Id = aluno.Id;
            Nome = aluno.ObtemNomeCompleto();
            Email = aluno.Email.Address;

            Matriculas = aluno.Matriculas.Select(m => new AlunoMatriculaView(m)).ToList();
            // Mensalidades = aluno.Mensalidades.Select(m => new AlunoMensalidadeView(m)).ToList();
            // Boletins = aluno.Boletins.Select(b => new AlunoBoletimView(b)).ToList();
        }
    }
}
