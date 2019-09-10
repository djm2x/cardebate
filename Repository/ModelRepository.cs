using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc;

namespace Repository.Shared
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        protected readonly CarDebateContext _context;
        public ModelRepository(CarDebateContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Model>> GetPageForModel(int idMarque, int startIndex, int pageSize)
        {
            return await _context.Models.OrderByDescending(o => o.Id)
                    .Where(e => e.IdMarque == idMarque)
                    // .Skip(startIndex)
                    // .Take(pageSize)
                    // .Include(e => e.Carburant)
                    // .Include(e => e.Transmission)
                    // .Include(e => e.TypeVoiture)
                    // .Include(e => e.ModelImgs)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Model>> GetAllForModel(int idMarque)
        {
            return await _context.Models.OrderByDescending(o => o.Id)
                    .Where(e => e.IdMarque == idMarque)
                    .Include(e => e.Carburant)
                    .Include(e => e.Transmission)
                    .Include(e => e.TypeVoiture)
                    .Include(e => e.Marque)
                    .Include(e => e.ModelImgs)
                    .ToListAsync();
        }

        
        public CarDebateContext MyContext
        {
            get { return Context as CarDebateContext; }
        }
    }
}