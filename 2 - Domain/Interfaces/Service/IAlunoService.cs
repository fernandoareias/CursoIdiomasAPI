using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IAlunoService {

        Task<Alunos> Obter(long id);
        Task<IEnumerable<Alunos>> GetAll();
        Task<Alunos> Registrar(CursoDTO model);
        Task<Alunos> Atualizar(long id, CursoDTO model);
        Task<bool> Remover(long id);
    }
}
