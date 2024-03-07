using Microsoft.AspNetCore.Mvc;

namespace ConsumeAPI.Controllers
{
    public class PolicyController : Controller
    {

        Uri baseAddress = new Uri("");
        HttpClient client;

        public PolicyController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
