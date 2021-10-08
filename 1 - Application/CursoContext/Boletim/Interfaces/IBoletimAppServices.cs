using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.CursoContext.Boletim.DTOs;
using CursoIdiomas.Application.Cursos.DTO;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Boletim.Interfaces {
    public interface IBoletimAppServices {

        Task<GenericCommandsResults> Registrar(long idAluno, BoletimDTO model);
        Task<GenericCommandsResults> Atualizar(long idCurso, CursoDTO model);
        Task<GenericCommandsResults> Obter(long id);
        Task<GenericCommandsResults> Remover(long id);
        Task<GenericCommandsResults> GetAll();
    }
}
