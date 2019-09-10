
using System.Collections.Generic;
using System.Threading.Tasks;
using mvc;

namespace Repository.Shared
{
    public interface IModelRepository : IRepository<Model>
    {
        Task<IEnumerable<Model>> GetPageForModel(int idMarque, int startIndex, int pageSize);
        Task<IEnumerable<Model>> GetAllForModel(int idMarque);
    }
}