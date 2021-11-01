using System.Linq;
using CursoIdiomas.Domain.Aluno.DTOs;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Professor.DTO;
using CursoIdiomas.Service.Tests.Mock;
using Xunit;

namespace Domain.Test.Entities
{
    public class ProfessorServiceTests
    {

        private readonly IProfessorService _professorService;

        public ProfessorServiceTests()
        {
            _professorService = new MockProfessorServices();
        }

        [Fact]
        public async void DeveRetornarUmaListaDeProfessor()
        {
            var _professores = await _professorService.GetAll();
            Assert.True(_professores.Any());
        }

        [Fact]
        public async void DeveRetornarUmProfessorValido()
        {
            var _professor = await _professorService.Obter(Faker.RandomNumber.Next(1, 10));
            Assert.True(_professor.IsValid);
        }

        
        [Fact]
        public async void DeveRegistrarUmProfessorValido()
        {
            var dto = new ProfessorDTO(Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email(), Faker.RandomNumber.Next(1000));
            var _professor = await _professorService.Registrar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.True(_professor.IsValid);
        }

        [Fact]
        public async void NaoDeveRegistrarUmAProfessorInvalido()
        { 
            var dto = new ProfessorDTO("", "", "", 0);
            var aluno = await _professorService.Registrar(0, dto);
            Assert.False(aluno.IsValid);
        }

        [Fact]
        public async void DeveAtualizarUmProfessorValido()
        { 
            var dto = new ProfessorDTO(Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email(), Faker.RandomNumber.Next(1000));
            var _professor = await _professorService.Registrar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.True(_professor.IsValid);
        }

        [Fact]
        public async void NaoDeveAtualizarUmProfessorInvalido()
        { 
            var dto = new ProfessorDTO("", "", "", 0);
            var _professor = await _professorService.Atualizar(-10, -10, dto);
            Assert.False(_professor.IsValid);
        }


        [Fact]
        public async void DeveRemoverUmAluno()
        {            
            Assert.True(await _professorService.Remover(Faker.RandomNumber.Next(1, 10)));
        }

        [Fact]
        public async void NaoDeveRemoverUmAluno()
        {            
            Assert.False(await _professorService.Remover(Faker.RandomNumber.Next(-1, -10)));
        }
    }
}