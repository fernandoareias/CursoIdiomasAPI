using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoIdiomasAPI.Models
{
    [Table("Cursos")]
    public class Curso
    {
        public Curso()
        {
            Id = Guid.NewGuid();
            URL = Id.ToString("N");
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public string URL { get; private set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(80, ErrorMessage = "Esse campo deve conter até 120 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero")]
        public int CargaHoraria { get; set; }

    }
}