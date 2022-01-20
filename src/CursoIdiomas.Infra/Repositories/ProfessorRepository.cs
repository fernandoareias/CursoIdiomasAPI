using CursoIdiomas.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public ProfessorRepository(ApplicationDbContext context, ILogger<ProfessorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Entities.Professor> Atualizar(Entities.Professor professor)
        {
            try
            {
                _context.Professors.Update(professor);
                await _context.SaveChangesAsync();
                return professor;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Entities.Professor> Cadastrar(Entities.Professor professor)
        {
            try
            {
                _context.Professors.Add(professor);
                await _context.SaveChangesAsync();
                return professor;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Entities.Professor>> GetByCourseId(Guid courseId)
        {
            try
            {
                return await _context.Professors
                    .Where(p => p.CursoId == courseId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Entities.Professor> GetById(Guid id)
        {
            try
            {
                return await _context.Professors
                    .Include(p => p.Curso)
                    .Include(p => p.Turmas)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {

                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Entities.Professor> Remover(Entities.Professor professor)
        {
            try
            {
                _context.Professors.Remove(professor);
                await _context.SaveChangesAsync();
                return professor;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }
    }
}
