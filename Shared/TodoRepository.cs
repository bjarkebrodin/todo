using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared
{
    public interface ITodoRepository : IDisposable
    {
        Task Add(string todo);
        Task Remove(string todo);
        Task<IEnumerable<string>> Read();
    }
}
