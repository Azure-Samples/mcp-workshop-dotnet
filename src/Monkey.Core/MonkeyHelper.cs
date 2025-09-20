using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monkey.Core.Models;

namespace Monkey.Core
{
    public static class MonkeyHelper
    {
        private static IMonkeyProvider? _provider;
        private static List<Monkey> _cache = new List<Monkey>();
        private static readonly Random _rng = new Random();
        private static int _randomAccessCount = 0;
        private static readonly object _lock = new object();

        public static void Initialize(IMonkeyProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public static async Task<IEnumerable<Monkey>> GetMonkeysAsync()
        {
            if (_provider == null) throw new InvalidOperationException("MonkeyHelper not initialized with a provider.");
            if (_cache.Count == 0)
            {
                var list = await _provider.GetMonkeysAsync();
                lock (_lock)
                {
                    _cache = list.ToList();
                }
            }
            return _cache;
        }

        public static async Task<Monkey?> GetMonkeyByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            var monkeys = await GetMonkeysAsync();
            return monkeys.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.InvariantCultureIgnoreCase));
        }

        public static async Task<Monkey?> GetRandomMonkeyAsync()
        {
            var monkeys = (await GetMonkeysAsync()).ToList();
            if (!monkeys.Any()) return null;
            lock (_lock)
            {
                _randomAccessCount++;
                return monkeys[_rng.Next(monkeys.Count)];
            }
        }

        public static int GetRandomAccessCount()
        {
            lock (_lock)
            {
                return _randomAccessCount;
            }
        }

        public static void ClearCache()
        {
            lock (_lock)
            {
                _cache.Clear();
            }
        }
    }
}
