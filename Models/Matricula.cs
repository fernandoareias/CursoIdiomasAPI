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
            TurmaId = turma;
            AlunoId = aluno;
        }

        [Key]
        // Poderia ser um int => YAGNI 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public bool Ativa { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public Guid AlunoId { get; private set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public Guid TurmaId { get; set; }
        //public Turma Turmas { get; private set; }


        public void SetId(Guid id) => Id = id;
        public void SetTurmaId(Guid id) => TurmaId = id;
        public void SetAlunoId(Guid id) => AlunoId = id;





    }
}