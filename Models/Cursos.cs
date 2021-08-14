using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoIdiomasAPI.Models
{
    [Table("Cursos")]
    public class Curso
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(80, ErrorMessage = "Esse campo deve conter até 120 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero")]
        public int CargaHoraria { get; set; }
        public void SetId(Guid id) => Id = id;

    }
}