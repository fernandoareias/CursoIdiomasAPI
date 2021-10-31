using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<bool> ExistAsync(long id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }
        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var result = await _dataset.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<T> InsertAsync(T item)
        {
            try
            {
                _dataset.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return item;
        }

        public virtual async Task<T> SelectAsync(long id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public virtual async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                // Select sem where.
                return await _dataset.ToListAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(item.Id));
                if (result == null)
                    return null;


                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

            return item;
        }


        //public async Task<T> UpdateAsync(System.Guid id, T item) {
        //    try {
        //        var result = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(item.Id));
        //        if (result == null)
        //            return null;


        //        _context.Entry(result).CurrentValues.SetValues(item);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception e) {

        //        throw e;
        //    }

        //    return item;
        //}
    }
}
