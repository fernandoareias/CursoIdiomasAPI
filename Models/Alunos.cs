using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CursoIdiomasAPI.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(80, ErrorMessage = "Esse campo deve conter até 60 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(120, ErrorMessage = "Esse campo deve conter até 120 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Esse campo deve conter até 20 caracteres")]
        public string Telefone { get; set; }




        // FK da tabela Matricula
        [Required(ErrorMessage = "Esse campo é requerido")]
        public int IdTurma { get; set; }
        [ForeignKey("IdTurma")]
        public Turma Turma { get; set; }


    }
}