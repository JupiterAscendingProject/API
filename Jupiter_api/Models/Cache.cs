using Microsoft.Extensions.Caching.Memory;

namespace Jupiter_api.Models
{
    public class Cache
    {
        private static IMemoryCache _cache;

        public Cache(IMemoryCache cache)
        {
            _cache = cache;
        }
        public List<T> ConfigSetting<T>(List<T> values)
        {
            var CacheKeys = "Module";


            if (!_cache.TryGetValue(CacheKeys, out List<T> Modules))
            {
                Modules = values;  // Get the data from database
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    SlidingExpiration = TimeSpan.FromSeconds(30),
                    Priority = CacheItemPriority.High,
                };
                _cache.Set(CacheKeys, Modules, cacheEntryOptions);
                
            }
            var result=_cache.Get<List<T>>(CacheKeys);
            return result;
           
        }

       



    }
}
