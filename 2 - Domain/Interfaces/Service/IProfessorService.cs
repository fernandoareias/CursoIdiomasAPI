using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IProfessorService {

        Task<Professor> Obter(Guid id);
        Task<IEnumerable<Professor>> GetAll();
        Task<Professor> Registrar(CursoDTO model);
        Task<Professor> Atualizar(Guid id, CursoDTO model);
        Task<bool> Remover(Guid id);
    }
}
