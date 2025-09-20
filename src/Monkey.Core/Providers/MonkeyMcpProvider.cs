using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Monkey.Core.Models;

namespace Monkey.Core.Providers
{
    public class MonkeyMcpProvider : IMonkeyProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public MonkeyMcpProvider(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }

        public async Task<IEnumerable<Monkey>> GetMonkeysAsync()
        {
            var res = await _httpClient.GetAsync(_endpoint);
            res.EnsureSuccessStatusCode();
            var stream = await res.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Monkey>>(stream) ?? Array.Empty<Monkey>();
        }

        public async Task<Monkey?> GetMonkeyByNameAsync(string name)
        {
            var monkeys = await GetMonkeysAsync();
            foreach (var m in monkeys)
            {
                if (string.Equals(m.Name, name, StringComparison.InvariantCultureIgnoreCase))
                    return m;
            }
            return null;
        }
    }
}
