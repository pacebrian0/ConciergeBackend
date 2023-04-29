using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers
{
    public interface IAuthController
    {
        Task<ActionResult<User>> Login(UserLoginDTO request);
        Task<ActionResult<User>> Register(UserRegisterDTO request);
    }
}