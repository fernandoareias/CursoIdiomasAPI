using CursoIdiomas.Domain.Cursos.Curso;
using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Professor;
using CursoIdiomas.Domain.Professor.DTO;
using CursoIdiomas.Domain.Repositories;
using CursoIdiomas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.Service.CursoServices {
    public class ProfessorService : IProfessorService {
        private readonly IProfessorRepository _repository;
        private readonly IRepository<Curso> _cursoRepository; 
        public ProfessorService(
            IProfessorRepository repository,
            IRepository<Curso> cursoRepository
        ) {
            _repository = repository;
            _cursoRepository = cursoRepository;
        }

        public async Task<List<CursoIdiomas.Domain.Entities.Professor>> GetAll(long idCurso) {
            
            return _repository.SelectAsync().Result.ToList();
        }


        public async Task<CursoIdiomas.Domain.Entities.Professor> Obter(long idProfessor) {
            return await _repository.SelectAsync(idProfessor);
        }

        public async Task<CursoIdiomas.Domain.Entities.Professor> Registrar(long idCurso, ProfessorDTO model) {
            var curso = await _cursoRepository.SelectAsync(idCurso);

            if (curso == null) return null;
            var _entity = new CursoIdiomas.Domain.Entities.Professor(model.FirstName, model.LastName, model.Email, model.Salario, curso.Id);
            if (!_entity.IsValid)
                return null;

            var result = await _repository.InsertAsync(_entity);
           
            return result;
        }

        

        public async Task<CursoIdiomas.Domain.Entities.Professor> Atualizar(long idProfessor, ProfessorDTO model) {
            var atualEntity = await Obter(idProfessor);

            if (atualEntity == null) return null;
            //VO
            var nome = new Nome(model.FirstName, model.LastName);

            var email = new Email(model.Email);

            var _entity = new CursoIdiomas.Domain.Entities.Professor(idProfessor, nome, email, atualEntity.CursoId);

            atualEntity.Update(_entity);
            if (!atualEntity.IsValid)
                return null;

            var result = await _repository.UpdateAsync(atualEntity);
            if (result == null)
                return null;

            return new CursoIdiomas.Domain.Entities.Professor(result.Id, result.Professor_Nome, result.Professor_Email);

        }

        public async Task<bool> Remover(long idProfessor) {
            return await _repository.DeleteAsync(idProfessor);

        }


    }
}
