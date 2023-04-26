using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers
{
    public interface IAuthController
    {
        ActionResult<string> Login(UserDTO request);
        ActionResult<User> Register(UserDTO request);
    }
}