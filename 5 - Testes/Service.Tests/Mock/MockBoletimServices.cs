


using System.Collections.Generic;
using System.Threading.Tasks;
using CursoIdiomas.Domain.Boletim.DTO;
using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Service;

namespace CursoIdiomas.Testes.Service.Testes.Mock {
    public class BoletimService : IBoletimService
    {
        public async Task<Boletim> Atualizar(long id, CursoDTO model)
        {
            return await Task.FromResult(new Boletim(Faker.RandomNumber.Next(0, 10), Faker.RandomNumber.Next(1, 10)));
        }

        public async Task<IEnumerable<Boletim>> GetAll()
        {
             var lista = new List<Boletim>();
            
            for (int i = 0; i < Faker.RandomNumber.Next(1, 20); i++)
            {
                lista.Add(new Boletim(Faker.RandomNumber.Next(0, 10), Faker.RandomNumber.Next(1, 10)));
            }

            return await Task.FromResult(lista);
        }

        public async Task<Boletim> Obter(long id)
        {
            return await Task.FromResult(new Boletim(Faker.RandomNumber.Next(0, 10), Faker.RandomNumber.Next(1, 10)));
        }

        public async Task<Boletim> Registrar(long idAluno, BoletimDTO model)
        {
            return await Task.FromResult(new Boletim(model.Nota, idAluno));
        }

        public async Task<bool> Remover(long id)
        {
            return await Task.FromResult(id > 0);
        }
    }
}