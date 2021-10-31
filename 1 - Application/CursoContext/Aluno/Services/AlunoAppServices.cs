using CursoIdiomas.Application.Aluno.Interfaces;
using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.CursoContext.Aluno.DTOs;
using CursoIdiomas.Application.CursoContext.Aluno.View;
using CursoIdiomas.Application.Cursos.DTO;
using CursoIdiomas.Application.Cursos.Interfaces;
using CursoIdiomas.Application.Views;
using CursoIdiomas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Cursos.Services {
    public class AlunoAppServices : IAlunoAppServices {
        private readonly IAlunoService _alunoService;
        public AlunoAppServices(IAlunoService alunoService) {
            _alunoService = alunoService;
        }


        public async Task<GenericCommandsResults> GetAll() {
            var result = await _alunoService.GetAll();
            if (result == null) {
                return new GenericCommandsResults(false, "Não há aluno registrado.", null);
            }
            var views = result.Select(a => new AlunoView(a));

            return new GenericCommandsResults(true, "Há cursos registrados!", views);

        }

        public async Task<GenericCommandsResults> Obter(long id) {
            var result = await _alunoService.Obter(id);
            
            if (result == null) return new GenericCommandsResults(false, "Não foi possível encontrar o Aluno", result);

            var view = new AlunoView(result);

            return new GenericCommandsResults(true, "Aluno encontrado!", view);
        }

        public async Task<GenericCommandsResults> Registrar(long idTurma, AlunoCreateDTO model) {
            var result = await _alunoService.Registrar(idTurma, model.ToDomain());

            if (!result.IsValid) {
                return new GenericCommandsResults(false, "Não foi possível registrar o aluno", result.Notifications);
            }
            var view = new AlunoView(result);

            return new GenericCommandsResults(true, "Aluno registrado com sucesso", view);

        }

        public async Task<GenericCommandsResults> Atualizar(long idAluno, AlunoCreateDTO model) {
            var result = await _alunoService.Atualizar(idAluno, model.ToDomain());

            if (!result.IsValid) {
                return new GenericCommandsResults(false, "Não foi possível atualizar o aluno", result.Notifications);
            }
            var view = new AlunoView(result);

            return new GenericCommandsResults(true, "Aluno atualizado com sucesso", view);

        }

        public async Task<GenericCommandsResults> Remover(long id) {
            var result = await _alunoService.Remover(id);

            return (result == true) ? 
                new GenericCommandsResults(true, "Aluno removido com sucesso", null) : 
                new GenericCommandsResults(false, "Não foi possível remover o aluno.", null); 
        }

    }
}
