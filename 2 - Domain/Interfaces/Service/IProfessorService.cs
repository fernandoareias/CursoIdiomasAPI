using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Professor;
using CursoIdiomas.Domain.Professor.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IProfessorService {

        Task<CursoIdiomas.Domain.Professor.Professor> Obter(Guid idProfessor);
        Task<IEnumerable<CursoIdiomas.Domain.Professor.Professor>> GetAll();
        Task<CursoIdiomas.Domain.Professor.Professor> Registrar(ProfessorDTO model);
        Task<CursoIdiomas.Domain.Professor.Professor> Atualizar(Guid idProfessor, ProfessorDTO model);
        Task<bool> Remover(Guid idProfessor);
    }
}
