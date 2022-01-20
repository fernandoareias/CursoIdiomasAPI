using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Infra.Context;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public MatriculaRepository(ApplicationDbContext context, ILogger<MatriculaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Matricula> Atualizar(Matricula matricula)
        {
            try
            {
                _context.Matriculas.Update(matricula);
                await _context.SaveChangesAsync();
                return matricula;
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Matricula> Matricular(Matricula matricula)
        {
            try
            {
                _context.Matriculas.Add(matricula);
                await _context.SaveChangesAsync();
                return matricula;
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }
    }
}
