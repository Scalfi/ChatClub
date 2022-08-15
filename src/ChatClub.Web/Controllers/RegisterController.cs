using ChatClub.Domain.Dto;
using ChatClub.Domain.Entities;
using ChatClub.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatClub.Web.Controllers
{
    public class RegisterController : Controller
    {
        private IRegisterService _register;

        public RegisterController(IRegisterService register)
        {
            _register = register;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Register([FromBody] UserDto user)
        {
            try
            {
                await _register.RegisterAsync(user);
                return Json(new { Status = "Success", Message = "User created successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new  { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
           
        }
    }
}
