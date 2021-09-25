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
        
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        
    }
}


