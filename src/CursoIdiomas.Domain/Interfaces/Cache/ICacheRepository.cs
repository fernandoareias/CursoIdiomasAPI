using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Cache
{
    public interface ICacheRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(string key);
        Task PostAsync(T entity);
        Task Update(string id);
        Task Remove(string id);
    }
}
