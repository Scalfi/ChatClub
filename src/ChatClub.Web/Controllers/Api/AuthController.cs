using ChatClub.Domain.Dto;
using ChatClub.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatClub.Web.Controllers.Api
{
    public class AuthController : ControllerBase
    {
        private IAuthService _auth;
        private IUserService _user;

        public AuthController(IAuthService auth, IUserService user)
        {
            _auth = auth;
            _user = user;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserDto user)
        {

            try
            {
                var login = await _auth.LoginAsync(user);

                if( login != null)
                {
                     HttpContext.Response.Cookies.Append(
                        "x-token",
                        login.Token!
                    );
                    return Ok(login);

                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }

        }
    }
}
