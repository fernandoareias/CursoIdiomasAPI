using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Mensalidades.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service {
    public interface IMensalidadesService {

        Task<Mensalidade> Obter(long id);
        Task<IEnumerable<Mensalidade>> GetAll();
        Task<Mensalidade> Registrar(long idAluno, MensalidadeDTO model);
        Task<Mensalidade> Atualizar(long id, CursoDTO model);
        Task<bool> Remover(long id);
    }
}
