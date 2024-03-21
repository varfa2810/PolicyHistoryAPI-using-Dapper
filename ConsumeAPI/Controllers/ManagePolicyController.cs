using ConsumeAPI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
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
        [ValidateAntiForgeryToken]
        public IActionResult policyDetailsView(PolicyDetailsModel policyDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Please fill in all required fields and correct any validation errors." });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePolicyMember(PolicyMemberInsert model)
        {
            if (!ModelState.IsValid)
            {
              
                return BadRequest(ModelState);
            }

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/InsertPolicyMembers", model);

                if (response.IsSuccessStatusCode)
                {
                   
                    return Ok("Policy member created successfully");
                }
                else
                {
                    
                    return StatusCode((int)response.StatusCode, $"An error occurred: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
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
        public async Task<IActionResult> GetPolicyDeathList()
        {

            try
            {
                List<PolicyDeathList> deathlist = new List<PolicyDeathList>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyDeathList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    deathlist = JsonConvert.DeserializeObject<List<PolicyDeathList>>(data);
                }


                return Json(deathlist);
            }

            catch (Exception ex)
            {
                // Handle other types of exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetMemberTypeList()
        {

            try
            {
                List<PolicyDetailsModel> deathlist = new List<PolicyDetailsModel>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetMemberTypeList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    deathlist = JsonConvert.DeserializeObject<List<PolicyDetailsModel>>(data);
                }


                return Json(deathlist);
            }

            catch (Exception ex)
            {
                // Handle other types of exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }



        [HttpGet]
        public async Task<IActionResult> GetRelationshipList()
        {

            try
            {
                List<PolicyDetailsModel> relationshiplist = new List<PolicyDetailsModel>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetRelationshipList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    relationshiplist = JsonConvert.DeserializeObject<List<PolicyDetailsModel>>(data);
                }


                return Json(relationshiplist);
            }

            catch (Exception ex)
            {
               
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }



        [HttpGet]
        public async Task<IActionResult> GetIDPPNumberList()
        {

            try
            {
                List<PolicyDetailsModel> IDPPList = new List<PolicyDetailsModel>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetIDPPNumberList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    IDPPList = JsonConvert.DeserializeObject<List<PolicyDetailsModel>>(data);
                }


                return Json(IDPPList);
            }

            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

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



     






        [HttpGet]
        public async Task<IActionResult> Getpolicyhistory()
        {
            //var enterpriseId = "aaaa";
            //var policyNum = 1;
            //var historyID = 1;
            try
            {
                List<PolicyHistoryModel> policies2 = new List<PolicyHistoryModel>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyHistory?enterpriseID=aaaa&policyNum=1&historyID=1");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    policies2 = JsonConvert.DeserializeObject<List<PolicyHistoryModel>>(data);
                }


                return Json(policies2);
            }

            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }



        [HttpGet]
        public async Task<IActionResult> Getpolicyvalueaddedservice()
        {
            try
            {
                List<PolicyValueAddedService> valueaddedservice = new List<PolicyValueAddedService>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetValueAddedService?enterpriseID=aaaa&policyNum=1&AddOnID=2");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    valueaddedservice = JsonConvert.DeserializeObject<List<PolicyValueAddedService>>(data);
                }


                return Json(valueaddedservice);
            }

            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }



        [HttpGet]
        public async Task<IActionResult> Getclaims()
        {
            
            try
            {
                List<PolicyClaim> policies2 = new List<PolicyClaim>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyDeathList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    policies2 = JsonConvert.DeserializeObject<List<PolicyClaim>>(data);
                }


                return Json(policies2);
            }

            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }


    }
}
