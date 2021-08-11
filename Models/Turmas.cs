


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
        public int Id { get; private set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public int ProfessoresId { get; set; }

        public Professores Professores { get; private set; }
    }
}