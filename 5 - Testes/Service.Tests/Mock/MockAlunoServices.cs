

using System.Collections.Generic;
using System.Threading.Tasks;
using CursoIdiomas.Domain.Aluno.DTOs;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Service;

namespace CursoIdiomas.Service.Tests.Mock {
    public class MockAlunoServices : IAlunoService
    {
        public async Task<Alunos> Atualizar(long idAluno, AlunoCreateDTO model)
        {
            return await Task.FromResult(new Alunos(idAluno, model.FirstName, model.LastName, model.Email, Faker.RandomNumber.Next(1, 20)));
        }

        public async Task<IEnumerable<Alunos>> GetAll()
        {
            var lista = new List<Alunos>();
            
            for (int i = 0; i < Faker.RandomNumber.Next(1, 20); i++)
            {
                lista.Add(new Alunos(Faker.RandomNumber.Next(1, 10), Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email(), Faker.RandomNumber.Next(2, 1000)));
            }

            return await Task.FromResult(lista);
        }

        public async Task<Alunos> Obter(long id)
        {
            return await Task.FromResult(new Alunos(id, Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email(), Faker.RandomNumber.Next(1, 20)));
        }

        public async Task<Alunos> Registrar(long idTurma, AlunoCreateDTO model)
        {
            return await Task.FromResult(new Alunos(model.FirstName, model.LastName, model.Email, idTurma));
        }

        public async Task<bool> Remover(long id)
        {
            return await Task.FromResult(id > 0);
        }
    }
}