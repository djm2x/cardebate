using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mvc;

namespace Repository.Shared
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        protected readonly CarDebateContext _context;
        public UserRepository(CarDebateContext context) : base(context)
        {
            _context = context;
        }

        public async Task SignIn(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.UserRoles.AddAsync(new UserRole
            {
                IdRole = 1,
                IdUser = user.Id
            });
        }

        public async Task<object> LogIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

            // check if username exists
            if (user == null)
                return null;

            if (user.Password == password)
            {
                var role = await _context.UserRoles.FirstOrDefaultAsync(e => e.IdUser == user.Id);
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                // var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var key = Encoding.ASCII.GetBytes("this is the secret phrase");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    // new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, role.IdRole.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var createToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(createToken);
                
                // remove password before returning
                user.Password = "";
                return new { user, token, idRole = role.IdRole};
            }

            return null;
        }



        public CarDebateContext MyContext
        {
            get { return Context as CarDebateContext; }
        }


    }
}