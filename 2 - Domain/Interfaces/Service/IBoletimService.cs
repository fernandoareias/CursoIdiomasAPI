using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IBoletimService {

        Task<Boletim> Obter(Guid id);
        Task<IEnumerable<Boletim>> GetAll();
        Task<Boletim> Registrar(CursoDTO model);
        Task<Boletim> Atualizar(Guid id, CursoDTO model);
        Task<bool> Remover(Guid id);
    }
}
