

using System.Collections.Generic;
using System.Threading.Tasks;
using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Mensalidades.DTOs;

namespace CursoIdiomas.Testes.Service.Testes.Mock {
    public class MockMensalidadeServices : IMensalidadesService
    {
        public async Task<Mensalidade> Atualizar(long id, CursoDTO model)
        {
            return await Task.FromResult(new Mensalidade(Faker.Finance.Maturity(), Faker.Finance.Coupon(), Faker.Internet.Url(), Faker.RandomNumber.Next(1, 20)));
        }

        public  async Task<IEnumerable<Mensalidade>> GetAll()
        {
           var lista = new List<Mensalidade>();
            
            for (int i = 0; i < Faker.RandomNumber.Next(1, 20); i++)
            {
                lista.Add(new Mensalidade(Faker.Finance.Maturity(), Faker.Finance.Coupon(), Faker.Internet.Url(), Faker.RandomNumber.Next(1, 20)));
            }

            return await Task.FromResult(lista);
        }

        public  async Task<Mensalidade> Obter(long id)
        {
            return await Task.FromResult(new Mensalidade(Faker.Finance.Maturity(), Faker.Finance.Coupon(), Faker.Internet.Url(), Faker.RandomNumber.Next(1, 20)));
        }

        public  async Task<Mensalidade> Registrar(long idAluno, MensalidadeDTO model)
        {
            return await Task.FromResult(new Mensalidade(model.Vencimento, model.Valor, model.Uri, idAluno));
        }

        public  async Task<bool> Remover(long id)
        {
            return await Task.FromResult(id > 0);
        }
    }
}