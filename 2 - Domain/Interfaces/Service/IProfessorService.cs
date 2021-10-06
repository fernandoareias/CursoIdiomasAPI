using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Professor;
using CursoIdiomas.Domain.Professor.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IProfessorService {

        Task<CursoIdiomas.Domain.Entities.Professor> Obter(long idProfessor);
        Task<List<CursoIdiomas.Domain.Entities.Professor>> GetAll(long idCurso);
        Task<CursoIdiomas.Domain.Entities.Professor> Registrar(ProfessorDTO model);
        Task<CursoIdiomas.Domain.Entities.Professor> Atualizar(long idProfessor, ProfessorDTO model);
        Task<bool> Remover(long idProfessor);
    }
}
