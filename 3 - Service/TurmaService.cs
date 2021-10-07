using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Repositories;
using CursoIdiomas.Domain.Turma.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Service.CursoServices {
    public class TurmaService : ITurmaService {
        private readonly ITurmaRepository _repository;
        private readonly IRepository<Professor> _professor;

        public TurmaService(
            ITurmaRepository repository,
            IProfessorRepository professorRepository
        ) {
            _repository = repository;
            _professor = professorRepository;
        }

        public async Task<IEnumerable<Turma>> GetAll() {
            return await _repository.SelectAsync();
        }

        public async Task<IEnumerable<Turma>> GetAllByProfessor(long idProfessor) {
            var professor = await _professor.ExistAsync(idProfessor);
            if (professor == false) return null;

            return await _repository.SelectByProfessor(idProfessor);
        }

        public async Task<Turma> Obter(long id) {
            return await _repository.SelectAsync(id);
        }

        public async Task<Turma> Registrar(long idProfessor, TurmaDTO model) {
            
            var professor = await _professor.SelectAsync(idProfessor);


            if (professor == null) return null;

            var _entity = new Turma(professor.Id, model.Turno);
            if (!_entity.IsValid)
                return null;

             var result = await _repository.InsertAsync(_entity);
            if (result == null) return null;

            return _entity;
        }

        public async Task<Turma> Atualizar(long idTurma, TurmaDTO model) {
            var _entityBase = await _repository.SelectAsync(idTurma);
            if (_entityBase == null) return null;

            var _entityNova = new Turma(model.Turno);
            if (!_entityNova.IsValid) return null;

            _entityBase.Update(_entityNova);

            var result = await _repository.UpdateAsync(_entityBase);
            if (result == null) return null;

            return result;
        }

        public async Task<bool> Remover(long idTurma) {
            return await _repository.DeleteAsync(idTurma);

        }

        
    }
}
