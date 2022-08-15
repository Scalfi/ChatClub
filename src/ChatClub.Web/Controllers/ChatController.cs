using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatClub.Web.Controllers
{
    public class ChatController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {            
            return View();
        }
    }
}
