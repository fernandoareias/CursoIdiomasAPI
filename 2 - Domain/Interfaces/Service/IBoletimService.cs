using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IBoletimService {

        Task<Boletim> Obter(long id);
        Task<IEnumerable<Boletim>> GetAll();
        Task<Boletim> Registrar(CursoDTO model);
        Task<Boletim> Atualizar(long id, CursoDTO model);
        Task<bool> Remover(long id);
    }
}
