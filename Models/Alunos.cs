using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CursoIdiomasAPI.Models
{
    [Table("Alunos")]
    public class Aluno
    {

        // public Aluno() => Id = Guid.NewGuid();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(80, ErrorMessage = "Esse campo deve conter até 60 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(120, ErrorMessage = "Esse campo deve conter até 120 caracteres")]
        public string Email { get; set; }


        // Shadow FK
        public Matricula Matricula { get; private set; }

    }
}