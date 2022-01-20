using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Cache;
using CursoIdiomas.Domain.Repositories;
using CursoIdiomas.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        private readonly ICacheRepository<Alunos> _cacheRepository;
        
        public AlunoRepository(
            ApplicationDbContext context, 
            ILogger<AlunoRepository> logger, 
            ICacheRepository<Alunos> cacheRepository
        )
        {
            _context = context;
            _logger = logger;
            _cacheRepository = cacheRepository;
        }

        public async Task<Alunos> Create(Alunos aluno)
        {
            try
            {
                _context.Alunos.Add(aluno);
                await _context.SaveChangesAsync();
                return aluno;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Alunos>> GetAll()
        {
            try
            {
                return await _context.Alunos.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Alunos> GetById(Guid id)
        {
            var aluno = new Alunos();
            try
            {

                aluno = await _cacheRepository.GetByIdAsync("Inglês");
                
                if(aluno == null)
                {
                    aluno = await _context.Alunos
                        .Include(a => a.Matriculas)
                        .Include(a => a.Mensalidades)
                        .Include(a => a.Boletims)
                        .FirstOrDefaultAsync(a => a.Id == id);

                    if(aluno != null)
                    {
                        await _cacheRepository.PostAsync(aluno);
                    }
                }

                return aluno;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Alunos> GetByMatricula(Guid matriculaId)
        {
            try
            {
                return await _context.Alunos
                .Include(a => a.Matriculas)
                .Include(a => a.Mensalidades)
                .Include(a => a.Boletims)
                .FirstOrDefaultAsync(
                    a => a.Matriculas.Any(m => m.Id == matriculaId)
                 );
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Alunos> Remove(Alunos aluno)
        {
            try
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
                await _cacheRepository.Remove(aluno.Id.ToString());
                return aluno;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<Alunos> Update(Alunos aluno)
        {
            try
            {
                _context.Alunos.Update(aluno);
                await _context.SaveChangesAsync();
                await _cacheRepository.Remove(aluno.Id.ToString());
                return aluno;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return null;
            }
        }
    }
}
