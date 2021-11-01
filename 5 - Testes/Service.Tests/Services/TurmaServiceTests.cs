using System.Linq;
using CursoIdiomas.Domain.Aluno.DTOs;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Professor.DTO;
using CursoIdiomas.Domain.Turma.DTO;
using CursoIdiomas.Service.Tests.Mock;
using CursoIdiomas.Testes.Service.Testes.Mock;
using Xunit;

namespace Domain.Test.Entities
{
    public class TurmaServiceTests
    {

        private readonly ITurmaService _turmaService;

        public TurmaServiceTests()
        {
            _turmaService = new MockTurmaServices();
        }

        [Fact]
        public async void DeveRetornarUmaListaDeTurmas()
        {
            var _turmas = await _turmaService.GetAll();
            Assert.True(_turmas.Any());
        }

        [Fact]
        public async void DeveRetornarUmTurmaValida()
        {
            var _turma = await _turmaService.Obter(Faker.RandomNumber.Next(1, 10));
            Assert.True(_turma.IsValid);
        }

        
        [Fact]
        public async void DeveRegistrarUmTurmaValida()
        {
            var dto = new TurmaDTO(){ Turno = Faker.RandomNumber.Next(10) };
            var _turma = await _turmaService.Registrar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.True(_turma.IsValid);
        }

        [Fact]
        public async void NaoDeveRegistrarUmaTurmaInvalida()
        { 
            var dto = new TurmaDTO(){ Turno = Faker.RandomNumber.Next(-10) };
            var _turma = await _turmaService.Registrar(Faker.RandomNumber.Next(-1,-10), dto);
            Assert.False(_turma.IsValid);
        }

        [Fact]
        public async void DeveAtualizarUmaTurmaValida()
        { 
            var dto = new TurmaDTO(){ Turno = Faker.RandomNumber.Next(10) };
            var _turma = await _turmaService.Atualizar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.True(_turma.IsValid);
        }

        [Fact]
        public async void NaoDeveAtualizarUmaTurmaInvalida()
        { 
            var dto = new TurmaDTO(){ Turno = Faker.RandomNumber.Next(-10) };
            var _turma = await _turmaService.Atualizar(Faker.RandomNumber.Next(-1, -10), dto);
            Assert.False(_turma.IsValid);
        }


        [Fact]
        public async void DeveRemoverUmaTurmaValida()
        {            
            Assert.True(await _turmaService.Remover(Faker.RandomNumber.Next(1, 10)));
        }

        [Fact]
        public async void NaoDeveRemoverUmaTurmaInvalida()
        {            
            Assert.False(await _turmaService.Remover(Faker.RandomNumber.Next(-1, -10)));
        }
    }
}