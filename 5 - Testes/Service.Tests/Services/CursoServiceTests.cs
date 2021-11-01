using System.Linq;
using CursoIdiomas.Domain.Aluno.DTOs;
using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Service.Tests.Mock;
using Xunit;

namespace Domain.Test.Entities
{
    public class CursoServiceTests
    {

        private readonly ICursoService _cursoService;

        public CursoServiceTests()
        {
            _cursoService = new MockCursoServices();
        }

        [Fact]
        public async void DeveRetornarUmaListaDeCursos()
        {
            var _cursos = await _cursoService.GetAll();
            Assert.True(_cursos.Any());
        }

        [Fact]
        public async void DeveRetornarUmACursoValido()
        {
            var _cursos = await _cursoService.Obter(Faker.RandomNumber.Next(1, 10));
            Assert.True(_cursos.IsValid);
        }   

        
        [Fact]
        public async void DeveRegistrarUmCursoValido()
        { 
            var dto = new CursoDTO(){ 
                Nome = Faker.Name.First(),
                Dificuldade = Faker.RandomNumber.Next(1, 3),
                CargaHoraria = Faker.RandomNumber.Next(1, 20),
                DataInicio = Faker.Finance.Maturity()
            };
            var _curso = await _cursoService.Registrar(dto);
            Assert.True(_curso.IsValid);
        }

        [Fact]
        public async void NaoDeveRegistrarUmCursoInvalido()
        { 
            var dto = new CursoDTO(){ 
                Nome = "",
                Dificuldade = 0,
                CargaHoraria = 0,
                DataInicio = System.DateTime.Now
            };
            var _curso = await _cursoService.Registrar(dto);
            Assert.False(_curso.IsValid);
        }

        [Fact]
        public async void DeveAtualizarUmCursoValido()
        { 
            var dto = new CursoDTO(){ 
                Nome = Faker.Name.First(),
                Dificuldade = Faker.RandomNumber.Next(1, 3),
                CargaHoraria = Faker.RandomNumber.Next(1, 20),
                DataInicio = Faker.Finance.Maturity()
            };

            var _curso = await _cursoService.Atualizar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.True(_curso.IsValid);
        }

        [Fact]
        public async void NaoDeveAtualizarUmCursoInvalido()
        { 
            var dto = new CursoDTO(){ 
                Nome = "",
                Dificuldade = 0,
                CargaHoraria = 0,
                DataInicio = System.DateTime.Now
            };
            var _curso = await _cursoService.Atualizar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.False(_curso.IsValid);
        }


        [Fact]
        public async void DeveRemoverUmCurso()
        {            
            Assert.True(await _cursoService.Remover(Faker.RandomNumber.Next(1, 10)));
        }

        [Fact]
        public async void NaoDeveRemoverUmCurso()
        {            
            Assert.False(await _cursoService.Remover(Faker.RandomNumber.Next(-1, -10)));
        }
    }
}