using AdventureWorks.Core.BusinessModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AdventureWorks.Core.Abstractions.Operations
{
    public interface IUserOperations
    {
        Task Logout(HttpContext context);
        Task Register(RegisterModel model, HttpContext context);
        Task Login(LoginModel model, HttpContext context);
    }
}
