using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface ITurmaService {

        Task<Turma> Obter(long id);
        Task<IEnumerable<Turma>> GetAll();
        Task<Turma> Registrar(CursoDTO model);
        Task<Turma> Atualizar(long id, CursoDTO model);
        Task<bool> Remover(long id);
    }
}
