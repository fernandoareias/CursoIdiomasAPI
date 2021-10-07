using CursoIdiomas.Domain.Aluno.DTOs;
using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Service.CursoServices
{
    public class AlunosServices: IAlunoService
    {
        private readonly IRepository<Alunos> _repository;
 
        public AlunosServices(IRepository<Alunos> repository)
        {
            _repository = repository;
        
        }

        public async Task<IEnumerable<Alunos>> GetAll()
        {
            return await _repository.SelectAsync();
        }


        public async Task<Alunos> Obter(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<Alunos> Registrar(long idTurma, AlunoCreateDTO model)
        {
            var _entity = new Alunos(model.FirstName, model.LastName, model.Email, idTurma);
            if (!_entity.IsValid) return null;

            var result = await _repository.InsertAsync(_entity);
            if (result == null) return null;

            return _entity;
        }

        public async Task<Alunos> Atualizar(long idAluno, AlunoCreateDTO model) {
            var _entity = await _repository.SelectAsync(idAluno);
            if (_entity == null) return null;
            
            var nome = new Nome(model.FirstName, model.LastName);
            var email = new Email(model.Email);
            
            var _entityNew = new Alunos(nome, email);
            _entity.Update(_entityNew);
            


            var result = await _repository.UpdateAsync(_entity);
            if (result == null)
                return null;

            return new Alunos();

        }

        public async Task<bool> Remover(long idCurso) {
            return await _repository.DeleteAsync(idCurso);

        }


    }
}
