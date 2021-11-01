using System.Collections.Generic;
using System.Threading.Tasks;
using CursoIdiomas.Domain.Cursos.Curso;
using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Cursos.Enum;
using CursoIdiomas.Domain.Interfaces.Service;



namespace CursoIdiomas.Service.Tests.Mock {
    public class MockCursoServices : ICursoService
    {
        public async Task<Curso> Atualizar(long idCurso, CursoDTO model)
        {
            return await Task.FromResult(new Curso(idCurso, model.Nome, (EDificuldade)model.Dificuldade, model.CargaHoraria));
        }

        public async Task<IEnumerable<Curso>> GetAll()
        {
            return await Task.FromResult(new List<Curso>());
        }

        public async Task<Curso> Obter(long id)
        {
            return await Task.FromResult(new Curso(id));
        }

        public async Task<Curso> Registrar(CursoDTO model)
        {
            return await Task.FromResult(new Curso(model.Nome, (EDificuldade)model.Dificuldade, model.CargaHoraria));
        }

        public async Task<bool> Remover(long idCurso)
        {
            return await Task.FromResult(idCurso > 0 );
        }
    }
}