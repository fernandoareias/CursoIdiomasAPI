

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoIdiomasAPI.Models
{

    [Table("Professores")]
    public class Professores
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Esse campo deve conter até 60 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(120, ErrorMessage = "Esse campo deve conter até 120 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal ValorHora { get; set; }

        //   [Required(ErrorMessage = "Esse campo é obrigatório")]
        // public List<Turma> Turmas { get; set; }

    }
}