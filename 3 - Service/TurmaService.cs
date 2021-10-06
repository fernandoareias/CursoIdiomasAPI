using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Turma.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Service.CursoServices {
    public class TurmaService : ITurmaService {
        private readonly IRepository<Turma> _repository;
        private readonly IRepository<CursoIdiomas.Domain.Entities.Professor> _professorRepository;
        public TurmaService(IRepository<Turma> repository, 
            IRepository<Professor> professorRepository
        ) {
            _repository = repository;
            _professorRepository = professorRepository;
        }

        public async Task<IEnumerable<Turma>> GetAll() {
            return await _repository.SelectAsync();
        }


        public async Task<Turma> Obter(long id) {
            return await _repository.SelectAsync(id);
        }

        public async Task<Turma> Registrar(long idProfessor, TurmaDTO model) {
            var professor = _professorRepository.SelectAsync(idProfessor);
            if (professor == null) return null;

            var _entity = new Turma(professor.Id, model.Turno);
            if (!_entity.IsValid)
                return null;

             var result = await _repository.InsertAsync(_entity);
            if (result == null) return null;

            return new Turma();
        }

        public async Task<Turma> Atualizar(long idTurma, TurmaDTO model) {
           // var _entity = new Turma(idCurso, model.Nome, (Domain.Enum.EDificuldade)model.Dificuldade, model.CargaHoraria);

          //  if (!_entity.IsValid)
          //      return null;

          ////  var result = await _repository.UpdateAsync(_entity);
          //  if (result == null)
          //      return null;

            return new Turma();

        }

        public async Task<bool> Remover(long idTurma) {
            return await _repository.DeleteAsync(idTurma);

        }


    }
}
