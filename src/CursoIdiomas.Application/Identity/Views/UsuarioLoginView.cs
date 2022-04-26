using System;
using System.Collections.Generic;
using System.Text;

namespace CursoIdiomas.Application.Identity.Views
{
    public class UsuarioLoginView
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenView UsuarioToken { get; set; }
    }
}
