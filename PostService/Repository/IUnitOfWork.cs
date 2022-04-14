using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
