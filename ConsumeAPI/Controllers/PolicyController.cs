using ConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ConsumeAPI.Controllers
{
    public class PolicyController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:44359/api");
        private readonly HttpClient _client;

        public PolicyController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<PolicyViewModel> policies = new List<PolicyViewModel>();   
            HttpResponseMessage response = _client.GetAsync(baseAddress + "/EnterpriseManagerFB_ManagePolicy/GetAllHistory").Result;
            

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                policies = JsonConvert.DeserializeObject<List<PolicyViewModel>>(data);   
            }

            return View(policies);
        }
    }
}
