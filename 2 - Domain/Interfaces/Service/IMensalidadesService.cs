using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IMensalidadesService {

        Task<Cobranca> Obter(long id);
        Task<IEnumerable<Cobranca>> GetAll();
        Task<Cobranca> Registrar(CursoDTO model);
        Task<Cobranca> Atualizar(long id, CursoDTO model);
        Task<bool> Remover(long id);
    }
}
