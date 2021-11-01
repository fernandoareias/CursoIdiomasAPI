using System.Linq;
using CursoIdiomas.Domain.Aluno.DTOs;
using CursoIdiomas.Domain.Boletim.DTO;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Professor.DTO;
using CursoIdiomas.Domain.Turma.DTO;
using CursoIdiomas.Service.Tests.Mock;
using CursoIdiomas.Testes.Service.Testes.Mock;
using Xunit;

namespace Domain.Test.Entities
{
    public class BoletimServiceTests
    {

        private readonly IBoletimService _boletimService;

        public BoletimServiceTests()
        {
            _boletimService = new MockBoletimService();
        }

        [Fact]
        public async void DeveRetornarUmaListaDeBoletins()
        {
            var _boletins = await _boletimService.GetAll();
            Assert.True(_boletins.Any());
        }

        [Fact]
        public async void DeveRetornarUmBoletimValido()
        {
            var _boletim = await _boletimService.Obter(Faker.RandomNumber.Next(1, 10));
            Assert.True(_boletim.IsValid);
        }

        
        [Fact]
        public async void DeveRegistrarUmBoletimValido()
        {
            var dto = new BoletimDTO(){ Nota = Faker.RandomNumber.Next(1, 10) };
            var _boletim = await _boletimService.Registrar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.True(_boletim.IsValid);
        }

        [Fact]
        public async void NaoDeveRegistrarUmBoletimInvalido()
        { 
            var dto = new BoletimDTO(){ Nota = Faker.RandomNumber.Next(-1, -10) };
            var _boletim = await _boletimService.Atualizar(Faker.RandomNumber.Next(-1,-10), dto);
            Assert.False(_boletim.IsValid);
        }

        [Fact]
        public async void DeveAtualizarUmBoletimValido()
        { 
            var dto = new BoletimDTO(){ Nota = Faker.RandomNumber.Next(1, 10) };
            var _boletim = await _boletimService.Atualizar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.True(_boletim.IsValid);
        }

        [Fact]
        public async void NaoDeveAtualizarUmBoletimInvalido()
        { 
            var dto = new BoletimDTO(){ Nota = Faker.RandomNumber.Next(-1, -10) };
            var _boletim = await _boletimService.Atualizar(Faker.RandomNumber.Next(-1, -10), dto);
            Assert.False(_boletim.IsValid);
        }


        [Fact]
        public async void DeveRemoverUmBoletimValido()
        {            
            Assert.True(await _boletimService.Remover(Faker.RandomNumber.Next(1, 10)));
        }

        [Fact]
        public async void NaoDeveRemoverUmBoletimInvalido()
        {            
            Assert.False(await _boletimService.Remover(Faker.RandomNumber.Next(-1, -10)));
        }
    }
}