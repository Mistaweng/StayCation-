using Microsoft.AspNetCore.Mvc;

namespace StayCation.Controllers
{
    public class Login : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }
    }
}
