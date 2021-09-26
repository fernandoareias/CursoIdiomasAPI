using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IMatriculaService {

        Task<Matricula> Obter(Guid id);
        Task<IEnumerable<Matricula>> GetAll();
        Task<Matricula> Registrar(CursoDTO model);
        Task<Matricula> Atualizar(Guid id, CursoDTO model);
        Task<bool> Remover(Guid id);
    }
}
