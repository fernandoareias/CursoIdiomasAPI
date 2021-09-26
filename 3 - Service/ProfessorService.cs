using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Professor;
using CursoIdiomas.Domain.Professor.DTO;
using CursoIdiomas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Service.CursoServices {
    public class ProfessorService : IProfessorService {
        private readonly IRepository<Professor> _repository;

        public ProfessorService(IRepository<Professor> repository) {
            _repository = repository;

        }

        public async Task<IEnumerable<Professor>> GetAll() {
            return await _repository.SelectAsync();
        }


        public async Task<Professor> Obter(Guid idProfessor) {
            return await _repository.SelectAsync(idProfessor);
        }

        public async Task<Professor> Registrar(ProfessorDTO model) {
            var _entity = new Professor(model.FirstName, model.LastName, model.Email);
            if (!_entity.IsValid)
                return null;

            var result = await _repository.InsertAsync(_entity);
           
            return result;
        }

        public async Task<Professor> Atualizar(Guid idProfessor, ProfessorDTO model) {
            //VO
            var nome = new Nome(model.FirstName, model.LastName);
            var email = new Email(model.Email);
            var _entity = new Professor(idProfessor, nome, email);

            if (!_entity.IsValid)
                return null;

            var result = await _repository.UpdateAsync(_entity);
            if (result == null)
                return null;

            return new Professor(result.Id, result.Professor_Nome, result.Professor_Email);

        }

        public async Task<bool> Remover(Guid idProfessor) {
            return await _repository.DeleteAsync(idProfessor);

        }


    }
}
