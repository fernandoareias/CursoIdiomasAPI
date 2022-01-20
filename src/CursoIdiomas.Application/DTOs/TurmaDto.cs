using CursoIdiomas.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace CursoIdiomas.Domain.Turma.DTO
{
    public class TurmaDto
    {

        [Required(ErrorMessage = "O turno da turma é requerida.")]
        [EnumDataType(typeof(ETurno), ErrorMessage = "O turno informado não é válido.")]
        public object Turno { get; set; }

        [Required(ErrorMessage = "O ID do professor é requerido.")]
        public Guid ProfessorId { get; set; }
    }
}
