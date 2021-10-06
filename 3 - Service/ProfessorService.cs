using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Professor;
using CursoIdiomas.Domain.Professor.DTO;
using CursoIdiomas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.Service.CursoServices {
    public class ProfessorService : IProfessorService {
        private readonly IRepository<CursoIdiomas.Domain.Entities.Professor> _repository;

        public ProfessorService(IRepository<CursoIdiomas.Domain.Entities.Professor> repository) {
            _repository = repository;

        }

        public async Task<List<CursoIdiomas.Domain.Entities.Professor>> GetAll(long idCurso) {
            var teachers = await _repository.SelectAsync();
            return teachers.Where(x => x.IdCurso.Equals(idCurso)).ToList();
        }


        public async Task<CursoIdiomas.Domain.Entities.Professor> Obter(long idProfessor) {
            return await _repository.SelectAsync(idProfessor);
        }

        public async Task<CursoIdiomas.Domain.Entities.Professor> Registrar(ProfessorDTO model) {
            var _entity = new CursoIdiomas.Domain.Entities.Professor(model.FirstName, model.LastName, model.Email, model.Salario, 1);
            if (!_entity.IsValid)
                return null;

            var result = await _repository.InsertAsync(_entity);
           
            return result;
        }

        public async Task<CursoIdiomas.Domain.Entities.Professor> Atualizar(long idProfessor, ProfessorDTO model) {
            //VO
            var nome = new Nome(model.FirstName, model.LastName);
            var email = new Email(model.Email);
            var _entity = new CursoIdiomas.Domain.Entities.Professor(idProfessor, nome, email);

            if (!_entity.IsValid)
                return null;

            var result = await _repository.UpdateAsync(_entity);
            if (result == null)
                return null;

            return new CursoIdiomas.Domain.Entities.Professor(result.Id, result.Professor_Nome, result.Professor_Email);

        }

        public async Task<bool> Remover(long idProfessor) {
            return await _repository.DeleteAsync(idProfessor);

        }


    }
}
