using AdventureWorks.Core.Abstractions;
using AdventureWorks.Core.Abstractions.Operations;
using AdventureWorks.Core.BusinessModels;
using AdventureWorks.Core.Entities;
using AdventureWorks.Core.Enum;
using AdventureWorks.Core.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdventureWorks.BLL.Operations
{
    public class UserOperations : IUserOperations
    {
        private readonly IRepositoryManager _repositories;
        public UserOperations(IRepositoryManager repositories)
        {
            _repositories = repositories;
        }
        public async Task Login(LoginModel model, HttpContext context)
        {
            User user = _repositories.Users.GetSingle(u => u.Email == model.Email && u.Password == model.Password)
                ?? throw new LogicException("Wrong username or password");
            await Authenticate(user, context);  
        }
        public async Task Logout(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        public async Task Register(RegisterModel model, HttpContext context)
        {
            User user = _repositories.Users.GetSingle(u => u.Email == model.Email);
            if (user == null)
            {
                user = new User
                {
                    Email = model.Email,
                    Password = model.Password,
                    Role = Role.User
                };
                _repositories.Users.Add(user);
                await _repositories.SaveChangesAsync();

                await Authenticate(user, context);
            }
            else
            {
                throw new LogicException("User already exists");
            }
        }
        private async Task Authenticate(User user, HttpContext context)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
