

using CursoIdiomas.Domain.Entities;
using Xunit;

namespace Domain.Test.Entities
{
    public class BoletimTests
    {

        [Fact]
        public void DeveCriarUmBoletimValido()
        {
            var _alunoValido = new Boletim(2, 3);
            Assert.Equal(0, _alunoValido.Notifications.Count);
        }
        

        [Fact]
        public void NaoDeveCriarUmBoletimInvalido()
        {
            var _alunoInvalido = new Boletim(0, 0);
            Assert.NotEqual(0, _alunoInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmBoletimComAlunoInvalido()
        {
            var _alunoInvalido = new Boletim(7.0, 0);
            Assert.NotEqual(0, _alunoInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmBoletimComNotaInvalido()
        {
            var _alunoInvalido = new Boletim(0, 2);
            Assert.NotEqual(0, _alunoInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmBoletimComNotaMaiorQueDez()
        {
            var _alunoInvalido = new Boletim(11, 2);
            Assert.NotEqual(0, _alunoInvalido.Notifications.Count);
        }

         [Fact]
        public void NaoDeveCriarUmBoletimComNotaMenorQueZero()
        {
            var _alunoInvalido = new Boletim(-1, 2);
            Assert.NotEqual(0, _alunoInvalido.Notifications.Count);
        }
    }
}