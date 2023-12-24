using Microsoft.AspNetCore.Mvc;
using OfficeAdministrationTool.InterfacesBL;
using OfficeAdministrationTool.Entity;
using OfficeAdministrationTool.Models.Requests;

namespace OfficeAdministrationTool.API.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : Controller
    {
        private IUserBL _userBL;

        public AuthController(IUserBL userBL) 
        {
            _userBL = userBL;
        }

        public async Task<User> register(User user)
        {

        }

        public async Task<User> login([FromBody] LoginRequest requestBody)
        {
            var result = await _userBL.login(requestBody.email, requestBody.password);
        }
    }
}
