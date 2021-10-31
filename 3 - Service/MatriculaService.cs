using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Service.CursoServices {
    public class MatriculaService : IMatriculaService {
        private readonly IRepository<Matricula> _repository;

        public MatriculaService(IRepository<Matricula> repository) {
            _repository = repository;

        }

        public async Task<IEnumerable<Matricula>> GetAll() {
            return await _repository.SelectAsync();
        }


        public async Task<Matricula> Obter(long id) {
            return await _repository.SelectAsync(id);
        }

        public async Task<Matricula> Registrar(CursoDTO model) {
            //var _entity = new Turma(model.Nome, (Domain.Enum.EDificuldade)model.Dificuldade, model.CargaHoraria);
            //if (!_entity.IsValid)
            //    return null;

            //var result = await _repository.InsertAsync(_entity);
            //if (result == null)
            //    return null;

            return new Matricula();
        }

        public async Task<Matricula> Atualizar(long idCurso, CursoDTO model) {
            //var _entity = new Turma(idCurso, model.Nome, (Domain.Enum.EDificuldade)model.Dificuldade, model.CargaHoraria);

            //if (!_entity.IsValid)
            //    return null;

            //var result = await _repository.UpdateAsync(_entity);
            //if (result == null)
            //    return null;

            return new Matricula();

        }

        public async Task<bool> Remover(long idCurso) {
            return await _repository.DeleteAsync(idCurso);

        }


    }
}
