using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFG_TCP_WCF_Service.Helpers
{
    public static class SessionStore
    {
        private static readonly ConcurrentDictionary<string, object> _store = new ConcurrentDictionary<string, object>();

        public static void Set(string key, object value)
        {
            _store[key] = value;
        }

        public static T Get<T>(string key)
        {
            return _store.TryGetValue(key, out var value) && value is T typedValue ? typedValue : default;
        }

        public static bool Exists(string key)
        {
            return _store.ContainsKey(key);
        }

        public static void Remove(string key)
        {
            _store.TryRemove(key, out _);
        }

        public static void Clear()
        {
            _store.Clear();
        }
    }
}
