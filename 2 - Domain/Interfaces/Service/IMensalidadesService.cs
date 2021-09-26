using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IMensalidadesService {

        Task<Mensalidade> Obter(Guid id);
        Task<IEnumerable<Mensalidade>> GetAll();
        Task<Mensalidade> Registrar(CursoDTO model);
        Task<Mensalidade> Atualizar(Guid id, CursoDTO model);
        Task<bool> Remover(Guid id);
    }
}
