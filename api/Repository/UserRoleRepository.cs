using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc;

namespace Repository.Shared
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        protected readonly CarDebateContext _context;
        public UserRoleRepository(CarDebateContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserRole>> GetPageForRole(
            int idUser, 
            int startIndex, 
            int pageSize, 
            Expression<Func<UserRole, int>> predicate
            )
        {
            return await _context.UserRoles.OrderByDescending(predicate)
                    .Where(e => e.IdUser == idUser)
                    .Skip(startIndex)
                    .Take(pageSize)
                    .Include(e => e.User)
                    .Include(e => e.Role)
                    .ToListAsync();
        }

        public CarDebateContext MyContext
        {
            get { return Context as CarDebateContext; }
        }
    }
}