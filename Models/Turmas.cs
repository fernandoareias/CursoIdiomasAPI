


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoIdiomasAPI.Models
{

    [Table("Turmas")]
    public class Turma
    {

        public Turma() { }

        public Turma(Guid cursoId, Guid professorId)
        {
            CursoId = cursoId;
            ProfessorId = professorId;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }


        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public Guid ProfessorId { get; private set; }
        public Professor Professor { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public Guid CursoId { get; private set; }

        public virtual Curso Curso { get; set; }
        public void setId(Guid id) => Id = id;
        public void setCursoId(string cursoURL) => Curso.SetId(Guid.Parse(cursoURL));
        public void setProfessorId(string professorId) => ProfessorId = Guid.Parse(professorId);
    }
}