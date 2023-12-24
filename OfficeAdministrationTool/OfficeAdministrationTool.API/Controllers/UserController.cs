using Microsoft.AspNetCore.Mvc;
using OfficeAdministrationTool.Entity;
using OfficeAdministrationTool.InterfacesBL;
using System.Runtime.InteropServices;

namespace OfficeAdministrationTool.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        [HttpGet]
        [Route("get")]
        public async Task<String> getUserName()
        {
            return await _userBL.getName();
        }

        [HttpGet]
        [Route("")]
        public async Task<List<User>> GetUsersAsync()
        {
            return await _userBL.getAllUsers();
        }
        

    }
}
