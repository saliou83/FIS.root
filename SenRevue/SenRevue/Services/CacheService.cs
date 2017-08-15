using SenRevue.Business;
using System;
using System.Runtime.Caching;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenRevue.Services
{
    /// <summary>
    /// Service de gestion du cache
    /// </summary>
    public static class CacheService
    {
        public static T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(10));
            }
            return item;
        }

        public static T Get<T>(string cacheKey) where T : class
        {
            return MemoryCache.Default.Get(cacheKey) as T;
        }

        public static T Set<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = getItemCallback();
            MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(10));
            return item;
        }
    }
}