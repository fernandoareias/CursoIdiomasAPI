using System;
using System.ComponentModel.DataAnnotations;

namespace CursoIdiomas.Domain.Professor.DTO
{
    public class ProfessorDto
    {

        [Required(ErrorMessage = "O nome do professor é requerido.")]
        [MaxLength(80, ErrorMessage = "O nome deve conter no máximo 80 carácteres.")]
        [MinLength(3, ErrorMessage = "O nome deve conter no mínimo 3 carácteres.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O sobrenome é requerido.")]
        [MaxLength(80, ErrorMessage = "O sobrenome deve conter no máximo 80 carácteres.")]
        [MinLength(3, ErrorMessage = "O sobrenome deve conter no mínimo 3 carácteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O email do professor é requerido.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O salário do professor é requerido.")]
        [Range(1, 30000)]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "O curso do professor é requerido.")]
        public System.Guid CursoId { get; set; }
    }
}
