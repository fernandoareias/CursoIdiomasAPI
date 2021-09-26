using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.CursoContext.Professor.DTO;
using CursoIdiomas.Application.Cursos.DTO;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Boletim.Interfaces {
    public interface IProfessorAppServices {

        Task<GenericCommandsResults> Registrar(ProfessorDTO model);
        Task<GenericCommandsResults> Atualizar(System.Guid idCurso, ProfessorDTO model);
        Task<GenericCommandsResults> Obter(Guid id);
        Task<GenericCommandsResults> Remover(Guid id);
        Task<GenericCommandsResults> GetAll();
    }
}
