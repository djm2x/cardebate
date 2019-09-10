using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc;

namespace Repository.Shared
{
    public class ModelImgRepository : Repository<ModelImg>, IModelImgRepository
    {
        protected readonly CarDebateContext _context;
        public ModelImgRepository(CarDebateContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ModelImg>> GetPageForModelImg(
            string idModel, 
            int startIndex, 
            int pageSize, 
            Expression<Func<ModelImg, int>> predicate
            )
        {
            return await _context.ModelImgs.OrderByDescending(predicate)
                    .Where(e => e.IdModel == idModel)
                    .Skip(startIndex)
                    .Take(pageSize)
                    .Include(e => e.Model)
                    .ToListAsync();
        }

        public CarDebateContext MyContext
        {
            get { return Context as CarDebateContext; }
        }
    }
}