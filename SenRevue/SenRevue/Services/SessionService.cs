using SenRevue.Business;
using System;
using System.Runtime.Caching;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenRevue.Services
{
    /// <summary>
    /// Service de gestion des sessions
    /// </summary>
    public static class SessionService
    {
        public static T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = HttpContext.Current.Session[cacheKey] as T;
            if (item == null)
            {
                item = getItemCallback();
                HttpContext.Current.Session[cacheKey] = item;
            }
            return item;
        }

        public static T Get<T>(string cacheKey) where T : class
        {
            return HttpContext.Current.Session[cacheKey] as T;
        }

        public static T Set<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = getItemCallback();
            HttpContext.Current.Session[cacheKey] = item;
            return item;
        }
    }
}