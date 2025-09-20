using System.Collections.Generic;
using System.Threading.Tasks;
using Monkey.Core.Models;

namespace Monkey.Core
{
    public interface IMonkeyProvider
    {
        Task<IEnumerable<Monkey>> GetMonkeysAsync();
        Task<Monkey?> GetMonkeyByNameAsync(string name);
    }
}
