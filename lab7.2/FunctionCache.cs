using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7._2
{
    internal class FunctionCache<TKey, TResult>
    {
        private Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();
        private readonly object lockObject = new object();

        public delegate TResult Func<TKey, TResult>(TKey key);

        public TResult GetOrAdd(TKey key, Func<TKey, TResult> func, TimeSpan expirationTime)
        {
            lock (lockObject)
            {
                if (cache.TryGetValue(key, out var cacheItem) && !IsExpired(cacheItem, expirationTime))
                {
                    Console.WriteLine($"Результат отриманий з кешу для ключа '{key}': {cacheItem.Result}");

                    return cacheItem.Result;
                }

                TResult result = func(key);
                cache[key] = new CacheItem(result, DateTime.Now.Add(expirationTime));

                return result;
            }
        }

        private bool IsExpired(CacheItem cacheItem, TimeSpan expirationTime)
        {
            return DateTime.Now > cacheItem.ExpirationTime;
        }

        private class CacheItem
        {
            public TResult Result { get; }
            public DateTime ExpirationTime { get; }

            public CacheItem(TResult result, DateTime expirationTime)
            {
                Result = result;
                ExpirationTime = expirationTime;
            }
        }
    }
}
