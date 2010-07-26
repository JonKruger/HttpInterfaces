using System;
using System.Web.Caching;

namespace HttpInterfaces
{
    public interface ICache
    {
        int Count { get; }
        
        long EffectivePrivateBytesLimit { get; }
        
        long EffectivePercentagePhysicalMemoryLimit { get; }
        
        object Get(string key);
        
        void Insert(string key, object value);
        
        void Insert(string key, object value, CacheDependency dependencies);
        
        void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration);
        
        void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);
        
        object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);
        
        object Remove(string key);
    }

    public class CacheProxy : ICache
    {
        private readonly Cache _cache;

        public CacheProxy(Cache cache)
        {
            _cache = cache;
        }

        public int Count
        {
            get { return _cache.Count; }
        }

        public long EffectivePrivateBytesLimit
        {
            get { return _cache.EffectivePrivateBytesLimit; }
        }

        public long EffectivePercentagePhysicalMemoryLimit
        {
            get { return _cache.EffectivePercentagePhysicalMemoryLimit; }
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Insert(string key, object value)
        {
            _cache.Insert(key, value);
        }

        public void Insert(string key, object value, CacheDependency dependencies)
        {
            _cache.Insert(key, value, dependencies);
        }

        public void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            _cache.Insert(key, value, dependencies, absoluteExpiration, slidingExpiration);
        }

        public void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            _cache.Insert(key, value, dependencies, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);
        }

        public object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            return _cache.Add(key, value, dependencies, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);
        }

        public object Remove(string key)
        {
            return _cache.Remove(key);
        }
    }
}
