using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        
        Task<bool> DeleteAsync(long id);
        Task<T> SelectAsync(long id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(long id);
        
    }
}


