
using System.Threading.Tasks;
using mvc;

namespace Repository.Shared
{
    public interface IUserRepository : IRepository<User>
    {
        Task<object> LogIn(string email, string password);
        Task SignIn(User user);
    }
}