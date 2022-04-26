using System;
using System.Collections.Generic;
using System.Text;

namespace CursoIdiomas.Application.Identity.Views
{
    public class UsuarioTokenView
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClaimViews> Claims { get; set; }
    }
}
