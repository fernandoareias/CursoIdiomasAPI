using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Professor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IProfessorService {

        Task<CursoIdiomas.Domain.Professor.Professor> Obter(Guid id);
        Task<IEnumerable<CursoIdiomas.Domain.Professor.Professor>> GetAll();
        Task<CursoIdiomas.Domain.Professor.Professor> Registrar(CursoDTO model);
        Task<CursoIdiomas.Domain.Professor.Professor> Atualizar(Guid id, CursoDTO model);
        Task<bool> Remover(Guid id);
    }
}
