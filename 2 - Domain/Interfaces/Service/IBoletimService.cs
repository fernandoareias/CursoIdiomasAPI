using CursoIdiomas.Domain.Boletim.DTO;
using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IBoletimService {

        Task<Domain.Entities.Boletim> Obter(long id);
        Task<IEnumerable<Domain.Entities.Boletim>> GetAll();
        Task<Domain.Entities.Boletim> Registrar(long idAluno, BoletimDTO model);
        Task<Domain.Entities.Boletim> Atualizar(long id, CursoDTO model);
        Task<bool> Remover(long id);
    }
}
