using Microsoft.AspNetCore.Mvc;

namespace ConsumeAPI.Controllers
{
    public class PolicyListController : Controller
    {
        public IActionResult Policylist()
        {
            return View();
        }
    }
}
