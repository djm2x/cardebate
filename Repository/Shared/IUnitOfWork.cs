using System;
using System.Threading.Tasks;

namespace Repository.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        IModelRepository Models { get; }
        Task<int> Complete();
    }
}