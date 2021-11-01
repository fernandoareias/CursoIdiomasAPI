using System.Linq;
using CursoIdiomas.Domain.Aluno.DTOs;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Service.Tests.Mock;
using Xunit;

namespace Domain.Test.Entities
{
    public class AlunoServiceTests
    {

        private readonly IAlunoService _alunoService;

        public AlunoServiceTests()
        {
            _alunoService = new MockAlunoServices();
        }

        [Fact]
        public async void DeveRetornarUmaListaDeAlunos()
        {
            var alunos = await _alunoService.GetAll();
            Assert.True(alunos.Any());
        }

        [Fact]
        public async void DeveRetornarUmAlunoValido()
        {
            var aluno = await _alunoService.Obter(Faker.RandomNumber.Next(1, 10));
            Assert.True(aluno.IsValid);
        }

        
        [Fact]
        public async void DeveRegistrarUmAlunoValido()
        { 
            var dto = new AlunoCreateDTO(){ 
                FirstName = Faker.Name.First(), 
                LastName = Faker.Name.Last(), 
                Email = Faker.Internet.Email()
            };
            var aluno = await _alunoService.Registrar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.True(aluno.IsValid);
        }

        [Fact]
        public async void NaoDeveRegistrarUmAlunoInvalido()
        { 
            var dto = new AlunoCreateDTO(){ 
                FirstName = "", 
                LastName = "", 
                Email = ""
            };
            var aluno = await _alunoService.Registrar(0, dto);
            Assert.False(aluno.IsValid);
        }

        [Fact]
        public async void DeveAtualizarUmAlunoValido()
        { 
            var dto = new AlunoCreateDTO(){ 
                FirstName = Faker.Name.First(), 
                LastName = Faker.Name.Last(), 
                Email = Faker.Internet.Email()
            };
            var aluno = await _alunoService.Registrar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.True(aluno.IsValid);
        }

        [Fact]
        public async void NaoDeveAtualizarUmAlunoInvalido()
        { 
            var dto = new AlunoCreateDTO(){ 
                FirstName = "", 
                LastName = "", 
                Email = ""
            };
            var aluno = await _alunoService.Registrar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.False(aluno.IsValid);
        }


        [Fact]
        public async void DeveRemoverUmAluno()
        {            
            Assert.True(await _alunoService.Remover(Faker.RandomNumber.Next(1, 10)));
        }

        [Fact]
        public async void NaoDeveRemoverUmAluno()
        {            
            Assert.False(await _alunoService.Remover(Faker.RandomNumber.Next(-1, -10)));
        }
    }
}