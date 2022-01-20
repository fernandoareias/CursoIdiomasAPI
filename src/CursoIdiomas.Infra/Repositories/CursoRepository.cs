using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Cache;
using CursoIdiomas.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly ICacheRepository<Curso> _cacheRepository;

        public CursoRepository(
            ApplicationDbContext context, 
            ILogger<CursoRepository> logger, 
            ICacheRepository<Curso> cacheRepository
        )
        {
            _context = context;
            _logger = logger;
            _cacheRepository = cacheRepository;
        }

        public async Task<IEnumerable<Curso>> GetAll()
        {
            try
            {
                return await _context.Curso.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Curso> GetById(Guid id)
        {
            var curso = new Curso();
            try
            {
                //curso = await _cacheRepository.GetByIdAsync(id.ToString());

                if (curso == null)
                {

                    curso = await _context.Curso
                            .Include(c => c.Professores)
                            .FirstOrDefaultAsync(c => c.Id == id);

                    //if (curso != null)
                    //{
                    //    await _cacheRepository.PostAsync(curso);
                    //}
                }

                return curso;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Curso> Remove(Curso curso)
        {
            try
            {
                _context.Curso.Remove(curso);
                await _context.SaveChangesAsync();
                //await _cacheRepository.Remove(curso.Id.ToString());
                return curso;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Curso> Update(Curso curso)
        {
            try
            {
                _context.Curso.Update(curso);
                await _context.SaveChangesAsync();
                //await _cacheRepository.Update(curso.Id.ToString());
                return curso;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Curso> Create(Curso curso)
        {
            try
            {
                _context.Curso.Add(curso);
                await _context.SaveChangesAsync();
                return curso;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }
    }
}
