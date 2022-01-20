using CursoIdiomas.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public TurmaRepository(ApplicationDbContext context, ILogger<TurmaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Entities.Turma> Create(Entities.Turma turma)
        {
            try
            {
                _context.Turmas.Add(turma);
                await _context.SaveChangesAsync();
                return turma;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Entities.Turma> Delete(Entities.Turma turma)
        {
            try
            {
                _context.Turmas.Remove(turma);
                await _context.SaveChangesAsync();
                return turma;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Entities.Turma> GetById(Guid id)
        {
            try
            {
                return await _context.Turmas
                    .Include(t => t.Matriculas)
                    .Include(t => t.Professor)
                    .Include(t => t.Matriculas)
                    .Include(t => t.Matriculas.Select(m => m.Aluno))
                    .FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<List<Entities.Turma>> GetByProfessorId(Guid idProfessor)
        {
            try
            {
                return await _context.Turmas
                    .Where(t => t.ProfessorId == idProfessor)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Entities.Turma> Update(Entities.Turma turma)
        {
            try
            {
                _context.Turmas.Update(turma);
                await _context.SaveChangesAsync();
                return turma;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }
    }
}
