using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.CursoContext.Professor.DTO;
using CursoIdiomas.Application.Cursos.DTO;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Boletim.Interfaces {
    public interface IProfessorAppServices {

        Task<GenericCommandsResults> Registrar(long idCurso, ProfessorDTO model);
        Task<GenericCommandsResults> Atualizar(long idCurso, ProfessorDTO model);
        Task<GenericCommandsResults> Obter(long id);
        Task<GenericCommandsResults> Remover(long id);
        Task<GenericCommandsResults> GetAll(long idCurso);
    }
}
