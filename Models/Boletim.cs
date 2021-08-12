
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoIdiomasAPI.Models
{

    [Table("Boletim")]
    public class Boletim
    {

        public Boletim()
        {
            DataPub = DateTime.Now.ToString();
        }

        [Key]
        public Guid Id { get; private set; }


        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public Guid MatriculaId { get; set; }
        public Matricula Matricula { get; private set; }

        public string DataPub { get; private set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public float Nota { get; set; }
    }
}