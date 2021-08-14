
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoIdiomasAPI.Models
{

    [Table("Boletim")]
    public class Boletim
    {

        public Boletim() { }
        public Boletim(Boletim model, string matriculaId)
        {
            Id = model.Id;
            DataPub = DateTime.Now.ToString("dd/MM/yyyy");
            UltimaAtualizacao = DateTime.Now.ToString("dd/MM/yyyy");
            Nota = model.Nota;
            MatriculaId = System.Guid.Parse(matriculaId);
        }

        [Key]
        public Guid Id { get; private set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        public Guid MatriculaId { get; private set; }

        public string DataPub { get; private set; }
        public string UltimaAtualizacao { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, 10, ErrorMessage = "A nota do aluno deve estar entre 1 - 10")]
        public float Nota { get; set; }

        public void setId(Guid id) => Id = id;
        public void setMatriculaId(Guid id) => MatriculaId = id;
        public void setDate(string date) => DataPub = date;
        public void setAtualizacao() => UltimaAtualizacao = DateTime.Now.ToString();
    }
}