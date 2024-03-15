using ConsumeAPI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;




namespace ConsumeAPI.Controllers
{
    public class ManagePolicyController : Controller
    {
        private readonly HttpClient _httpClient;
        Uri baseAddress = new Uri("https://localhost:7227/api");

        public ManagePolicyController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress=baseAddress;
        }



     

        public IActionResult policyDetailsView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PolicyDetailsModel emp)
        {
            if (ModelState.IsValid)
            {
                TempData["emp"] = emp;
                return Redirect("/ManagePolicy/policyList");
            }
            else
            {
                return View(emp);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetPlanBrandList()
        {
            var enterpriseId = "aaaa";
            try
            {
                List<PlanBrandList> policies = new List<PlanBrandList>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPlanBrand?enterpriseID={enterpriseId}");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    policies = JsonConvert.DeserializeObject<List<PlanBrandList>>(data);
                }


                return Json(policies);
            }

            catch (Exception ex)
            {
                // Handle other types of exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }



        [HttpGet]
        public async Task<IActionResult> GetPolicyAgentList()
        {
           
            try
            {
                List<PolicyAgentList> policies = new List<PolicyAgentList>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyAgent");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    policies = JsonConvert.DeserializeObject<List<PolicyAgentList>>(data);
                }


                return Json(policies);
            }

            catch (Exception ex)
            {
                // Handle other types of exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Getpolicymembers()
        {
            var enterpriseId = "aaaa";
            var policyNum = 1;
            try
            {
                List<PolicyMembersModel> policies = new List<PolicyMembersModel>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyMembers?enterpriseId={enterpriseId}&policyNum={policyNum}");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    policies = JsonConvert.DeserializeObject<List<PolicyMembersModel>>(data);
                }


                return Json(policies);
            }

            catch (Exception ex)
            {
                // Handle other types of exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }



        [HttpPost]
        public async Task<IActionResult> Insertpolicymember([FromBody] PolicyMemberInsert policymemberinsert)
        {
            try
            {
               
                var json = JsonConvert.SerializeObject(policymemberinsert);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/InsertPolicyMember", content);

                
                if (response.IsSuccessStatusCode)
                {
                    return Ok("Policy member inserted successfully.");
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to insert policy member.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }



    }
}
