using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IAlunoService {

        Task<Alunos> Obter(Guid id);
        Task<IEnumerable<Alunos>> GetAll();
        Task<Alunos> Registrar(CursoDTO model);
        Task<Alunos> Atualizar(Guid id, CursoDTO model);
        Task<bool> Remover(Guid id);
    }
}
