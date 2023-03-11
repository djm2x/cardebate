using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using mvc;

namespace Repository.Shared
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        Task<IEnumerable<UserRole>> GetPageForRole(int idUser, int startIndex, int pageSize, Expression<Func<UserRole, int>> predicate);
    }
}