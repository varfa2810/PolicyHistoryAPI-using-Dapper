using ConsumeAPI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
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





        public IActionResult policyList()
        {
            return View();
        }



        public async Task<IActionResult> policyDetails()
        {
            var enterpriseId1 = "aaaa";
            try
            {
                List<PolicyDetailsModel> policies = new List<PolicyDetailsModel>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyDetails?enterpriseId={enterpriseId1}");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    policies = JsonConvert.DeserializeObject<List<PolicyDetailsModel>>(data);
                }
                return View(policies);
            }

            catch (JsonException ex)
            {

                Console.WriteLine($"JSON Deserialization failed: {ex.Message}");
                return StatusCode(500, "Error processing data from the external service.");
            }
            catch (Exception ex)
            {
                // Handle other types of exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }




    }
}
