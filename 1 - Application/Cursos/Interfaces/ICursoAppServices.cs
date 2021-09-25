using CursoIdiomas.Application.Cursos.DTO;
using CursoIdiomas.Application.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Cursos.Interfaces
{
    public interface ICursoAppServices
    {

        Task<bool> RegistrarCurso(CursoDTO model);
        Task<CursoView> ObterCurso(Guid id);
        Task<IEnumerable<CursoView>> GetAll();
    }
}
