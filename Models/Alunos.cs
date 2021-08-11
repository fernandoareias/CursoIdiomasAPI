using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CursoIdiomasAPI.Models
{
    [Table("Alunos")]
    public class Aluno
    {

        public Aluno()
        {
            // Matrícula do aluno não pode ser repetida
            Matricula = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }
        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Matricula { get; private set; }


        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(80, ErrorMessage = "Esse campo deve conter até 60 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(80, ErrorMessage = "Esse campo deve conter até 60 caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(120, ErrorMessage = "Esse campo deve conter até 120 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Esse campo deve conter até 20 caracteres")]
        public string Telefone { get; set; }


        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public int TurmaId { get; set; }
        public Turma Turma { get; private set; }


    }
}