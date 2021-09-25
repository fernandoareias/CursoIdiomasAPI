using CursoIdiomas.Application.Cursos.DTO;
using CursoIdiomas.Application.Cursos.Interfaces;
using CursoIdiomas.Application.Views;
using CursoIdiomas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Cursos.Services
{
    public class CursoAppServices : ICursoAppServices
    {
        private readonly ICursoService _cursoService;
        public CursoAppServices(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        public async Task<IEnumerable<CursoView>> GetAll()
        {
            var list = await _cursoService.GetAll();
            return await CursoView.Mapping(list);
        }

        public async Task<CursoView> ObterCurso(Guid id)
        {
            var curso = await _cursoService.ObterCurso(id);
            return new CursoView(curso);
        }

        public Task<bool> RegistrarCurso(CursoDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
