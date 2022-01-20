using System.ComponentModel.DataAnnotations;

namespace CursoIdiomas.Domain.Aluno.DTOs
{
    public class AlunoDto
    {

        [Required(ErrorMessage = "O nome do aluno é obrigatório.")]
        [MaxLength(70, ErrorMessage = "O nome deve conter no máixmo 70 carácteres.")]
        [MinLength(3, ErrorMessage = "O nome deve conter no minimo 3 carácteres.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O nome do aluno é obrigatório.")]
        [MaxLength(70, ErrorMessage = "O sobrenome deve conter no máixmo 70 carácteres.")]
        [MinLength(4, ErrorMessage = "O sobrenome deve conter no minimo 4 carácteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado é inválido.")]
        public string Email { get; set; }
    }
}
