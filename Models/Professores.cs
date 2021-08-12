using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoIdiomasAPI.Models
{

    [Table("Professores")]
    public class Professores
    {
        public Professores()
        {
            Id = Guid.NewGuid();
            URL = Id.ToString("N");
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public string URL { get; private set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Esse campo deve conter até 60 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(120, ErrorMessage = "Esse campo deve conter até 120 caracteres")]
        public string Email { get; set; }



    }
}