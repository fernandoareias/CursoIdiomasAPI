using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoIdiomasAPI.Models
{

    public class Mensalidade
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public Guid MatriculaId { get; private set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Vencimento { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        public void SetId(Guid id) => Id = id;
        public void SetMatriculaId(Guid id) => MatriculaId = id;
    }
}