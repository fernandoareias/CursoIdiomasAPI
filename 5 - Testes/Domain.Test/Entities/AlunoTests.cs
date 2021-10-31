using System;
using Xunit;
using CursoIdiomas.Domain.Cursos.Curso;
using CursoIdiomas.Domain.ValueObjects;
using CursoIdiomas.Domain.Entities;

namespace Domain.Test.Entities
{
    public class AlunoTests
    {

        [Fact]
        public void DeveCriarUmAlunoValido()
        {
            var _alunoValido = new Alunos(new Nome("Bob", "Bobson"), new Email("bob@bobson.com.br"));
            Assert.Equal(0, _alunoValido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmAlunoNull()
        {
            var _alunoInvalido = new Alunos(null, null);
            Assert.NotEqual(0, _alunoInvalido.Notifications.Count);
        }

         [Fact]
        public void NaoDeveCriarUmAlunoComNomeInvalido()
        {
            var _alunoInvalido = new Alunos(null, new Email("bob@bobson.com.br"));
            Assert.NotEqual(0, _alunoInvalido.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmAlunoComFirstNomeNull()
        {
            var _alunoInvalido = new Alunos(new Nome(null, "Bobson"), new Email("bob@bobson.com.br"));
            Assert.NotEqual(0, _alunoInvalido.Nome.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmAlunoComLastNomeNull()
        {
            var _alunoInvalido = new Alunos(new Nome("Fox", null), new Email("bob@bobson.com.br"));
            Assert.NotEqual(0, _alunoInvalido.Nome.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmAlunoComEmailNull()
        {
            var _alunoInvalido = new Alunos(new Nome("Fox", "Bobson"), null);
            Assert.NotEqual(0, _alunoInvalido.Notifications.Count);
        }


        [Fact]
        public void NaoDeveCriarUmAlunoComEmailInvalido()
        {
            var _alunoInvalido = new Alunos(new Nome("Fox", "Bobson"), new Email(""));
            Assert.NotEqual(0, _alunoInvalido.Email.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmAlunoComFirstNomeVazio()
        {
            var _alunoInvalido = new Alunos(new Nome("", "Bobson"), new Email("bob@bobson.com"));
            Assert.NotEqual(0, _alunoInvalido.Nome.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmAlunoComLastNomeVazio()
        {
            var _alunoInvalido = new Alunos(new Nome("Fox", ""), new Email("bob@bobson.com"));
            Assert.NotEqual(0, _alunoInvalido.Nome.Notifications.Count);
        }

         [Fact]
        public void NaoDeveCriarUmAlunoComEmailVazio()
        {
            var _alunoInvalido = new Alunos(new Nome("Fox", "Bobson"), new Email(""));
            Assert.NotEqual(0, _alunoInvalido.Email.Notifications.Count);
        }
    }
}