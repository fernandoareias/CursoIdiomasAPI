using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Turma.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface ITurmaService {

        Task<CursoIdiomas.Domain.Entities.Turma> Obter(long id);

        Task<IEnumerable<CursoIdiomas.Domain.Entities.Turma>> GetAll();
        Task<IEnumerable<CursoIdiomas.Domain.Entities.Turma>> GetAllByProfessor(long idProfessor);
        Task<CursoIdiomas.Domain.Entities.Turma> Registrar(long idProfessor, TurmaDTO model);
        Task<CursoIdiomas.Domain.Entities.Turma> Atualizar(long id, TurmaDTO model);
        Task<bool> Remover(long id);
    }
}
