using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CursoIdiomas.Application.Identity.DTOs
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(maximumLength: 120, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {3} caractéres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(maximumLength: 120, MinimumLength = 6, ErrorMessage = "O campo {0} precisa ter entre {2} e {3} caractéres.")]
        public string Senha { get; set; }

    }
}
