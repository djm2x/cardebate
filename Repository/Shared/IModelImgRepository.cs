using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using mvc;

namespace Repository.Shared
{
    public interface IModelImgRepository : IRepository<ModelImg>
    {
        Task<IEnumerable<ModelImg>> GetPageForModelImg(
            string idModel, 
            int startIndex, 
            int pageSize, 
            Expression<Func<ModelImg, int>> predicate
            );
    }
}