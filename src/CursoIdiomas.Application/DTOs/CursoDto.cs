using CursoIdiomas.Domain.Cursos.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace CursoIdiomas.Domain.Cursos.DTO
{
    public class CursoDto
    {
        [Required(ErrorMessage = "O nome do curso é requerido.")]
        [MaxLength(80, ErrorMessage = "O nome deve conter no máximo 80 carácteres.")]
        [MinLength(3, ErrorMessage = "O nome deve conter no mínimo 3 carácteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A dificuldade do curso é requerida.")]
        [EnumDataType(typeof(EDificuldade), ErrorMessage = "A dificuldade informada não é válida.")]
        public int Dificuldade { get; set; }

        [Required(ErrorMessage = "A carga horária do curso é requeida.")]
        [Range(10, 1300, ErrorMessage = "A carga horária informada é inválida.")]
        public int CargaHoraria { get; set; }

        [Required(ErrorMessage = "A data de inicio do curso é requerida.")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataTermino { get; set; }

    }
}
