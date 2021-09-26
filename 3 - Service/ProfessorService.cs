using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Service.CursoServices {
    public class ProfessorService : IProfessorService {
        private readonly IRepository<Turma> _repository;

        public ProfessorService(IRepository<Turma> repository) {
            _repository = repository;

        }

        public async Task<IEnumerable<Turma>> GetAll() {
            return await _repository.SelectAsync();
        }


        public async Task<Turma> Obter(Guid id) {
            return await _repository.SelectAsync(id);
        }

        public async Task<Turma> Registrar(CursoDTO model) {
            var _entity = new Turma(model.Nome, (Domain.Enum.EDificuldade)model.Dificuldade, model.CargaHoraria);
            if (!_entity.IsValid)
                return null;

            var result = await _repository.InsertAsync(_entity);
            if (result == null)
                return null;

            return result;
        }

        public async Task<Turma> Atualizar(Guid idCurso, CursoDTO model) {
            var _entity = new Turma(idCurso, model.Nome, (Domain.Enum.EDificuldade)model.Dificuldade, model.CargaHoraria);

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
