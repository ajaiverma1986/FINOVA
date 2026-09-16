using Microsoft.Extensions.Caching.Memory;

namespace FINOVA.Commonlib.Cache
{
    public static class MemoryCachingService
    {
        private static IMemoryCache? _memoryCache;

        public static void Initialize(IMemoryCache memoryCache)
        {
            if (memoryCache == null)
            {
                throw new ArgumentNullException(nameof(memoryCache));
            }

            _memoryCache = memoryCache;

            Console.WriteLine(">>> MemoryCachingService INITIALIZED");
        }

        private static IMemoryCache Cache
        {
            get
            {
                if (_memoryCache == null)
                {
                    throw new InvalidOperationException(
                        "MemoryCachingService has not been initialized.");
                }

                return _memoryCache;
            }
        }

        public static Task Clear(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                Cache.Remove(key);
            }

            return Task.CompletedTask;
        }

        public static Task<T?> Get<T>(
            string key,
            bool persistForMaxTime = false)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return Task.FromResult<T?>(default);
            }

            var value = Cache.Get<T>(key);

            return Task.FromResult(value);
        }

        public static Task Put<T>(
            string key,
            T value,
            bool persistForMaxTimeOut = false)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return Task.CompletedTask;
            }

            Cache.Set(
                key,
                value,
                new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(
                        TimeSpan.FromMinutes(15)));

            return Task.CompletedTask;
        }

        public static Task ClearAll()
        {
            // IMemoryCache doesn't expose ClearAll directly.
            return Task.CompletedTask;
        }
    }
}