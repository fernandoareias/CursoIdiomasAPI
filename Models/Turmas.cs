


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoIdiomasAPI.Models
{

    [Table("Turmas")]
    public class Turma
    {

        [Key]
        public int Id { get; set; }


        // FK da tabela Curso
        [Required(ErrorMessage = "Esse campo é requerido")]
        public int IdCurso { get; set; }

        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }


        // FK da tabela Professor
        [Required(ErrorMessage = "Esse campo é requerido")]
        public int IdProfessor { get; set; }
        [ForeignKey("IdProfessor")]
        public Professores Professor { get; set; }



        // Datas de Inicio e fim da turma
        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }
    }
}