using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IAlunoService {

        Task<Turma> Obter(Guid id);
        Task<IEnumerable<Turma>> GetAll();
        Task<Turma> Registrar(CursoDTO model);
        Task<Turma> Atualizar(Guid id, CursoDTO model);
        Task<bool> Remover(Guid id);
    }
}
