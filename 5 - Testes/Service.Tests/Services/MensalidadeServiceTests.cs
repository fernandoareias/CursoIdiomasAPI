using System.Linq;
using CursoIdiomas.Domain.Aluno.DTOs;
using CursoIdiomas.Domain.Boletim.DTO;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Mensalidades.DTOs;
using CursoIdiomas.Domain.Professor.DTO;
using CursoIdiomas.Domain.Turma.DTO;
using CursoIdiomas.Service.Tests.Mock;
using CursoIdiomas.Testes.Service.Testes.Mock;
using Xunit;

namespace Domain.Test.Entities
{
    public class MensalidadeServiceTests
    {

        private readonly IMensalidadesService _mensalidadesService;

        public MensalidadeServiceTests()
        {
            _mensalidadesService = new MockMensalidadeServices();
        }

        [Fact]
        public async void DeveRetornarUmaListaDeMensalidades()
        {
            var _mensalidades = await _mensalidadesService.GetAll();
            Assert.True(_mensalidades.Any());
        }

        [Fact]
        public async void DeveRetornarUmaMensalidadeValida()
        {
            var _mensalidade = await _mensalidadesService.Obter(Faker.RandomNumber.Next(1, 10));
            Assert.True(_mensalidade.IsValid);
        }

        
        [Fact]
        public async void DeveRegistrarUmaMensalidadeValida()
        {
            var dto = new MensalidadeDTO(){ 
                Vencimento = Faker.Finance.Maturity(),
                Valor = Faker.RandomNumber.Next(10),
                Uri = Faker.Internet.Url()
            };
            var _mensalidade = await _mensalidadesService.Registrar(Faker.RandomNumber.Next(1, 10), dto);
            Assert.True(_mensalidade.IsValid);
        }

        [Fact]
        public async void NaoDeveRegistrarUmaMensalidadeInvalida()
        { 
            var dto = new MensalidadeDTO(){ 
                Vencimento = System.DateTime.Now.AddDays(-10),
                Valor = 0,
                Uri = ""
            };
            var _mensalidade = await _mensalidadesService.Registrar(Faker.RandomNumber.Next(-1,-10), dto);
            Assert.False(_mensalidade.IsValid);
        }

       
    }
}