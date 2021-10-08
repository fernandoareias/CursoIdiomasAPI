using CursoIdiomas.Domain.Boletim.DTO;
using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Service.CursoServices
{
    public class BoletimService: IBoletimService
    {
        private readonly IRepository<Boletim> _repository;
 
        public BoletimService(IRepository<Boletim> repository)
        {
            _repository = repository;
        
        }

        public async Task<IEnumerable<Boletim>> GetAll()
        {
            return await _repository.SelectAsync();
        }


        public async Task<Boletim> Obter(long id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<Boletim> Registrar(long idAluno, BoletimDTO model)
        {
            var _entity = new Boletim(model.Nota, idAluno);
            if (!_entity.IsValid) return null;

            var result = await _repository.InsertAsync(_entity);
            if (result == null) return null;

            return _entity;
        }

        public async Task<Boletim> Atualizar(long idCurso, CursoDTO model) {
            //var _entity = new Turma(idCurso, model.Nome, (Domain.Enum.EDificuldade)model.Dificuldade, model.CargaHoraria);

            //if (!_entity.IsValid)
            //    return null;

            //var result = await _repository.UpdateAsync(_entity);
            //if (result == null)
            //    return null;

            return new Boletim();

        }

        public async Task<bool> Remover(long idCurso) {
            return await _repository.DeleteAsync(idCurso);

        }


    }
}
