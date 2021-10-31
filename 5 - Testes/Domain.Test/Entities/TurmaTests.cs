

using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.ValueObjects;
using Xunit;

namespace Domain.Test.Entities
{
    public class TurmaTests
    {

        [Fact]
        public void DeveCriarUmaTurmaValida()
        {
            var _turnoValido = new Turma(2, 1);
            Assert.Equal(0, _turnoValido.Notifications.Count);
        }

        [Fact]
        public void DeveCriarUmaTurmaComIdTurmaValido()
        {
            var _turnoValido = new Turma(2, 2, 1);
            Assert.Equal(0, _turnoValido.Notifications.Count);
        }

         [Fact]
        public void Na0DeveCriarUmaTurmaComIdTurmaInvalido()
        {
            var _turnoValido = new Turma(0, 2, 1);
            Assert.NotEqual(0, _turnoValido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmaTurmaInvalida()
        {
            var _turnoInvalido = new Turma(0, 0);
            Assert.NotEqual(0, _turnoInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmaTurmaComProfessorInvalido()
        {
            var _turnoValido = new Turma(0, 1);
            Assert.NotEqual(0, _turnoValido.Notifications.Count);
        }


        [Fact]
        public void NaoDeveCriarUmaTurmaComTurnoInvalido()
        {
            var _turnoValido = new Turma(2, 0);
            Assert.NotEqual(0, _turnoValido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmaTurmaComTurnoComValoresNegativos()
        {
            var _turnoValido = new Turma(-2, -3);
            Assert.Equal(2, _turnoValido.Notifications.Count);
        }

    }

}