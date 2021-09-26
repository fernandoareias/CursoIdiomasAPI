using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Service.CursoServices
{
    public class CursoServices: ICursoService
    {
        private readonly IRepository<Curso> _repository;
 
        public CursoServices(IRepository<Curso> repository)
        {
            _repository = repository;
        
        }

        public async Task<IEnumerable<Curso>> GetAll()
        {
            return await _repository.SelectAsync();
        }


        public async Task<Curso> Obter(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<Curso> Registrar(CursoDTO model)
        {
            var _entity = new Curso(model.Nome, (CursoIdiomas.Domain.Cursos.Enum.EDificuldade)model.Dificuldade, model.CargaHoraria);
            if (!_entity.IsValid)
                return null;

            var result = await _repository.InsertAsync(_entity);
            if(result == null)
                return null;

            return result;
        }

        public async Task<Curso> Atualizar(Guid idCurso, CursoDTO model) {
            var _entity = new Curso(idCurso, model.Nome, (CursoIdiomas.Domain.Cursos.Enum.EDificuldade)model.Dificuldade, model.CargaHoraria);

            if (!_entity.IsValid)
                return null;

            var result = await _repository.UpdateAsync(_entity);
            if (result == null)
                return null;

            return result;

        }

        public async Task<bool> Remover(Guid idCurso) {
            return await _repository.DeleteAsync(idCurso);

        }


    }
}
