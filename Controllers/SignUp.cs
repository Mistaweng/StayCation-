using Microsoft.AspNetCore.Mvc;

namespace StayCation.Controllers
{
    public class SignUp:Controller
    {
        public IActionResult Signing_up()
        {
            return View();
        }
    }
}
