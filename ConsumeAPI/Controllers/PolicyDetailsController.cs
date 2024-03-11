using Microsoft.AspNetCore.Mvc;

namespace ConsumeAPI.Controllers
{
    public class PolicyDetailsController : Controller
    {

      
        public IActionResult policyDetails()
        {
            return View();
        }
    }
}
