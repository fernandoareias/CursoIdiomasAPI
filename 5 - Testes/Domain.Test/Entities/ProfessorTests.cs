using Xunit;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.ValueObjects;

namespace Domain.Test.Entities
{
    public class ProfessorTests
    {
        [Fact]
        public void DeveCriarUmProfessorValido()
        {
            var _professorValido = new Professor(new Nome("Fox", "Bobson"), new Email("fox@bobson.com"), 1700, 2);
            Assert.Equal(0, _professorValido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmProfessorInvalido()
        {
            var _professorInvalido = new Professor(null, null, 0, 0);
            Assert.NotEqual(0, _professorInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmProfessorComNomeNull()
        {
            var _professorInvalido = new Professor(null, new Email("fox@bobson.com"), 1700, 2);
            Assert.NotEqual(0, _professorInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmProfessorComNomeInvalido()
        {
            var _professorInvalido = new Professor(new Nome(null, null), new Email("fox@bobson.com"), 1700, 2);
            Assert.NotEqual(0, _professorInvalido.Professor_Nome.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmProfessorComFirstNomeNull()
        {
            var _professorInvalido = new Professor(new Nome(null, "Bobson"), new Email("fox@bobson.com"), 1700, 2);
            Assert.NotEqual(0, _professorInvalido.Professor_Nome.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmProfessorComLastNomeNull()
        {
            var _professorInvalido = new Professor(new Nome("Bob", null), new Email("fox@bobson.com"), 1700, 2);
            Assert.NotEqual(0, _professorInvalido.Professor_Nome.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmProfessorComFirstNomeVazio()
        {
            var _professorInvalido = new Professor(new Nome("", "Bobson"), new Email("fox@bobson.com"), 1700, 2);
            Assert.NotEqual(0, _professorInvalido.Professor_Nome.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmProfessorComLastNomeVazio()
        {
            var _professorInvalido = new Professor(new Nome("Bob", ""), new Email("fox@bobson.com"), 1700, 2);
            Assert.NotEqual(0, _professorInvalido.Professor_Nome.Notifications.Count);
        }


        [Fact]
        public void NaoDeveCriarUmProfessorComEmailNull()
        {
            var _professorInvalido = new Professor(new Nome("Fox", "Bobson"), null, 1700, 2);
            Assert.NotEqual(0, _professorInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmProfessorComSalariolInvalido()
        {
            var _professorInvalido = new Professor(new Nome("Fox", "Bobson"), new Email("fox@bobson.com.br"), 0, 2);
            Assert.NotEqual(0, _professorInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmProfessorComIdCursoInvalido()
        {
            var _professorInvalido = new Professor(new Nome("Fox", "Bobson"), new Email("fox@bobson.com.br"), 1700, 0);
            Assert.NotEqual(0, _professorInvalido.Notifications.Count);
        }
    }
}