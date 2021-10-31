using CursoIdiomas.Domain.Entities;
using Xunit;

namespace Domain.Test.Entities
{
    public class MensalidadeTests
    {

        [Fact]
        public void DeveCriarUmaMensalidadeValida()
        {
            var _mensalidadeValida = new Mensalidade(System.DateTime.Now.AddDays(2),1600, "https://fatura.com.br", 3);
            Assert.Equal(0, _mensalidadeValida.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmaMensalidadeInvalida()
        {
            var _mensalidadeInvalida = new Mensalidade(System.DateTime.Now.AddDays(-2), 0, null, 0);
            Assert.NotEqual(0, _mensalidadeInvalida.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmaMensalidadeComVencimentoInvalido()
        {
            var _mensalidadeInvalida = new Mensalidade(System.DateTime.Now.AddDays(-2),1600, "https://fatura.com.br", 3);
            Assert.NotEqual(0, _mensalidadeInvalida.Notifications.Count);
        }

         [Fact]
        public void NaoDeveCriarUmaMensalidadeComValorInvalido()
        {
            var _mensalidadeInvalida = new Mensalidade(System.DateTime.Now.AddDays(2),-1600, "https://fatura.com.br", 3);
            Assert.NotEqual(0, _mensalidadeInvalida.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmaMensalidadeComURLVazia()
        {
            var _mensalidadeInvalida = new Mensalidade(System.DateTime.Now.AddDays(2),1600, "", 3);
            Assert.NotEqual(0, _mensalidadeInvalida.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmaMensalidadeComURLNull()
        {
            var _mensalidadeInvalida = new Mensalidade(System.DateTime.Now.AddDays(2),1600, null, 3);
            Assert.NotEqual(0, _mensalidadeInvalida.Notifications.Count);
        }

        [Fact]
        public void NaoDeveCriarUmaMensalidadeComAlunoInvalido()
        {
            var _mensalidadeInvalida = new Mensalidade(System.DateTime.Now.AddDays(2),1600, "https://fatura.com.br", -2);
            Assert.NotEqual(0, _mensalidadeInvalida.Notifications.Count);
        }
    }
}