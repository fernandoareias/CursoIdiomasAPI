

using System.Collections.Generic;
using System.Threading.Tasks;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Turma.DTO;

namespace CursoIdiomas.Testes.Service.Testes.Mock {
    public class MockTurmaServices : ITurmaService
    {
        public async Task<Turma> Atualizar(long id, TurmaDTO model)
        {
            return await Task.FromResult(new Turma(id, model.Turno));
        }

        public async Task<IEnumerable<Turma>> GetAll()
        {
            var lista = new List<Turma>();
            for (int i = 0; i < Faker.RandomNumber.Next(1, 20); i++)
            {
                lista.Add(new Turma(i + 1, Faker.RandomNumber.Next(1,10)));
            }

            return await Task.FromResult(lista);
        }

        public async Task<IEnumerable<Turma>> GetAllByProfessor(long idProfessor)
        {
            var lista = new List<Turma>();
            for (int i = 0; i < Faker.RandomNumber.Next(1, 20); i++)
            {
                lista.Add(new Turma(i + 1, idProfessor, Faker.RandomNumber.Next(1,10)));
            }

            return await Task.FromResult(lista);
        }

        public async Task<Turma> Obter(long id)
        {
            return await Task.FromResult(new Turma(id, Faker.RandomNumber.Next(1, 10)));
        }

        public async Task<Turma> Registrar(long idProfessor, TurmaDTO model)
        {
            return await Task.FromResult(new Turma(idProfessor, model.Turno));
        }

        public async Task<bool> Remover(long id)
        {
            return await Task.FromResult(id > 0);
        }
    }
}