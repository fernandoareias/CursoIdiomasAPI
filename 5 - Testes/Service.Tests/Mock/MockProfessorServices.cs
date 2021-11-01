


using System.Collections.Generic;
using System.Threading.Tasks;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Professor.DTO;

namespace CursoIdiomas.Service.Tests.Mock {
    public class MockProfessorServices : IProfessorService
    {
        public async Task<Professor> Atualizar(long idProfessor, long idCurso, ProfessorDTO model)
        {
            return await Task.FromResult(new Professor(idProfessor, Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email(), Faker.RandomNumber.Next(2, 1000), idCurso));
        }

        public async Task<List<Professor>> GetAll()
        {   
            var lista = new List<Professor>();
            
            for (int i = 0; i < Faker.RandomNumber.Next(1, 20); i++)
            {
                lista.Add(new Professor(Faker.RandomNumber.Next(1, 10), Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email(), Faker.RandomNumber.Next(2, 1000), 0));
            }

            return await Task.FromResult(lista);
        }

        public async Task<Professor> Obter(long idProfessor)
        {
            return await Task.FromResult(new Professor(idProfessor, Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email(), Faker.RandomNumber.Next(2, 1000), Faker.RandomNumber.Next(1, 10)));    
        }

        public async Task<Professor> Registrar(long idCurso, ProfessorDTO model)
        {
            return await Task.FromResult(new Professor(model.FirstName, model.LastName, model.Email, model.Salario, idCurso));
        }

        public async Task<bool> Remover(long idProfessor)
        {
            return await Task.FromResult(idProfessor > 0);
        }
    }
}