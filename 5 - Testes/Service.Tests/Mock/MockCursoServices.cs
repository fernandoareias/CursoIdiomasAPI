using System.Collections.Generic;
using System.Threading.Tasks;
using CursoIdiomas.Domain.Cursos.Curso;
using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Cursos.Enum;
using CursoIdiomas.Domain.Interfaces.Service;



namespace CursoIdiomas.Service.Tests.Mock {
    public class MockCursoServices : ICursoService
    {
        public async Task<Curso> Atualizar(long idCurso, CursoDTO model)
        {
            return await Task.FromResult(new Curso(idCurso, model.Nome, (EDificuldade)model.Dificuldade, model.CargaHoraria, model.DataInicio, model.DataTermino));
        }

        public async Task<IEnumerable<Curso>> GetAll()
        {
            var lista = new List<Curso>();
            
            for (int i = 0; i < Faker.RandomNumber.Next(1, 20); i++)
            {
                lista.Add(new Curso(Faker.Name.First(), (EDificuldade)Faker.RandomNumber.Next(1, 3), Faker.RandomNumber.Next(1,80)));
            }

            return await Task.FromResult(lista);
        }

        public async Task<Curso> Obter(long id)
        {
            return await Task.FromResult(new Curso(id, Faker.Name.First(), (EDificuldade)Faker.RandomNumber.Next(1, 3), Faker.RandomNumber.Next(80), Faker.Finance.Maturity()));
        } 

        public async Task<Curso> Registrar(CursoDTO model)
        {
            return await Task.FromResult(new Curso(model.Nome, (EDificuldade)model.Dificuldade, model.CargaHoraria));
        }

        public async Task<bool> Remover(long idCurso)
        {
            return await Task.FromResult(idCurso > 0 );
        }
    }
}