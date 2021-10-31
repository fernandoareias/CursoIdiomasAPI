using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Mensalidades.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Service.CursoServices {
    public class MensalidadeService : IMensalidadesService {
        private readonly IRepository<Mensalidade> _repository;

        public MensalidadeService(IRepository<Mensalidade> repository) {
            _repository = repository;

        }

        public async Task<IEnumerable<Mensalidade>> GetAll() {
            return await _repository.SelectAsync();
        }


        public async Task<Mensalidade> Obter(long id) {
            return await _repository.SelectAsync(id);
        }

        public async Task<Mensalidade> Registrar(long idAluno, MensalidadeDTO model) {
            var _entity = new Mensalidade(model.Vencimento, model.Valor, model.Uri, idAluno);
            if (!_entity.IsValid || _entity == null) return null;

            var result = await _repository.InsertAsync(_entity);
            if (result == null) return null;

            return _entity;
        }

        public async Task<Mensalidade> Atualizar(long idCurso, CursoDTO model) {
            //var _entity = new Turma(idCurso, model.Nome, (Domain.Enum.EDificuldade)model.Dificuldade, model.CargaHoraria);

            //if (!_entity.IsValid)
            //    return null;

            //var result = await _repository.UpdateAsync(_entity);
            //if (result == null)
            //    return null;

            return new Mensalidade();

        }

        public async Task<bool> Remover(long idCurso) {
            return await _repository.DeleteAsync(idCurso);

        }


    }
}
