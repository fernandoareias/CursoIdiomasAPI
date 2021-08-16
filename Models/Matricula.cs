using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CursoIdiomasAPI.Models
{

    [Table("Matriculas")]
    public class Matricula
    {
        public Matricula()
        {
            Ativa = true;
            Id = Guid.NewGuid();
        }

        public Matricula(Guid turma, Guid aluno)
        {
            Ativa = true;
            Id = Guid.NewGuid();
            TurmasId = turma;
            AlunosId = aluno;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public bool Ativa { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [ForeignKey("Aluno")]
        public Guid AlunosId { get; private set; }
        public Aluno Alunos { get; private set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]


        [ForeignKey("Turma")]

        public Guid TurmasId { get; set; }
        public Turma Turmas { get; private set; }

        public void SetId(Guid id) => Id = id;
        public void SetTurmaId(Guid id) => TurmasId = id;
        public void SetAlunoId(Guid id) => AlunosId = id;
    }
}
