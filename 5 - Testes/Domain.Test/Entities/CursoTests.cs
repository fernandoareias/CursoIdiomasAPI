using System;
using Xunit;
using CursoIdiomas.Domain.Cursos.Curso;
using CursoIdiomas.Domain.Cursos.Enum;

namespace Domain.Test.Entities
{
    public class CursoTestes
    {


        [Fact]
        public void DeveCriarUmCursoValido()
        {
            var _cursoValido = new Curso("Inglês", CursoIdiomas.Domain.Cursos.Enum.EDificuldade.Iniciante, 80, DateTime.Now.AddDays(2), DateTime.Now.AddDays(10));
            Assert.Equal(0, _cursoValido.Notifications.Count);
        }

        [Fact]
        public void DeveCriarUmCursoSemDataTermino()
        {
            var _cursoValido = new Curso("Inglês", CursoIdiomas.Domain.Cursos.Enum.EDificuldade.Iniciante, 80, DateTime.Now.AddDays(2));
            Assert.Equal(0, _cursoValido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmCursoInvalido()
        {
            var _cursoInvalido = new Curso("", 0, 0, DateTime.Now.AddDays(-22));
            Assert.NotEqual(0, _cursoInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmCursoComNomeInalido()
        {
            var _cursoInvalido = new Curso("", CursoIdiomas.Domain.Cursos.Enum.EDificuldade.Iniciante, 80, DateTime.Now.AddDays(2));
            Assert.NotEqual(0, _cursoInvalido.Notifications.Count);
        }

         [Fact]
        public void NaoDeveCriarUmCursoComDataInicioInvalida()
        {
            var _cursoInvalido = new Curso("Inglês", CursoIdiomas.Domain.Cursos.Enum.EDificuldade.Iniciante, 80, DateTime.Now.AddYears(-500));
            Assert.NotEqual(0, _cursoInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmCursoComDataTerminoInvalida()
        {
            var _cursoInvalido = new Curso("Inglês", CursoIdiomas.Domain.Cursos.Enum.EDificuldade.Iniciante, 80, DateTime.Now.AddDays(2),DateTime.Now.AddYears(-500));
            Assert.NotEqual(0, _cursoInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmCursoComDifuculdadeInvalida()
        {
            var _cursoInvalido = new Curso("Inglês", (EDificuldade)30, 80, DateTime.Now.AddDays(2));
            Assert.NotEqual(0, _cursoInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmCursoComCargaHorariaMenorQueZero()
        {
            var _cursoInvalido = new Curso("Inglês", EDificuldade.Iniciante, -80, DateTime.Now.AddDays(2));
            Assert.NotEqual(0, _cursoInvalido.Notifications.Count);
        }

    }
}