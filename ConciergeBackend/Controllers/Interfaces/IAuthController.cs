using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers
{
    public interface IAuthController
    {
        Task<ActionResult<UserResponseDTO>> Login(UserLoginDTO request);
        Task<ActionResult<UserResponseDTO>> Register(UserRegisterDTO request);
    }
}