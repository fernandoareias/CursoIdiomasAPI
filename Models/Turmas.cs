


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoIdiomasAPI.Models
{

    [Table("Turmas")]
    public class Turma
    {

        public Turma()
        {
            Id = Guid.NewGuid();
            URL = Id.ToString("N");
        }

        public Turma(Guid cursoId, Guid professorId)
        {
            Id = Guid.Parse(Guid.NewGuid().ToString("N").ToLower());
            System.Console.WriteLine(Id);
            URL = Id.ToString();
            CursosId = cursoId;
            ProfessoresId = professorId;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public string URL { get; private set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }


        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public Guid ProfessoresId { get; private set; }
        //public int ProfessoresId { get; set; }
        public Professores Professores { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public Guid CursosId { get; private set; }
        public Curso Cursos { get; set; }


        public void setCursoId(string cursoURL)
        {
            CursosId = Guid.Parse(cursoURL);
        }
        public void setProfessorId(string professorId)
        {
            ProfessoresId = Guid.Parse(professorId);
        }
    }
}