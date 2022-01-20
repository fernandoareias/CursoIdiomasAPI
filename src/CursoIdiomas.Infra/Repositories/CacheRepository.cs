using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Repositories
{
    public class CacheRepository<T> : ICacheRepository<T> where T : Entity
    {
        private readonly IDistributedCache _cache;
        
        public CacheRepository(IDistributedCache cache)
        {
            _cache = cache;
            
        }

        public async Task<T> GetByIdAsync(string key)
        {
            try
            {
                var redisEntity = await _cache.GetAsync(key);

                if (redisEntity == null)
                    return default;

                var entitySerialized = Encoding.UTF8.GetString(redisEntity);

                return JsonConvert.DeserializeObject<T>(entitySerialized);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public async Task PostAsync(T entity)
        {
            try
            {
                var entitySerialized = JsonConvert.SerializeObject(entity);

                var entityEncoded = Encoding.UTF8.GetBytes(entitySerialized);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                await _cache.SetAsync(entity.Id.ToString(), entityEncoded, options);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Remove(string id)
        {
            try
            {
                await _cache.RemoveAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Update(string id)
        {
            try
            {
                await _cache.RefreshAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
