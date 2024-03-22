using ConsumeAPI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
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
                var errors = ModelState.Values
               .SelectMany(v => v.Errors)
               .Select(e => e.ErrorMessage);
                return Json(new { success = false, errors = errors });
            }

            PolicyMemberInsert policyMember = new PolicyMemberInsert()
            {
                strEnterpriseID = "aaaa",
                intPolicyNum = 1,
                intProfileID = model.intProfileID,
                intMemberTypeID = model.intMemberTypeID,
                monPremiumAmt = 0,
                monCoverAmt = model.monCoverAmt,
                intRelationshipID = model.intRelationshipID,
                intAgeToday = model.intAgeToday,
                datDateEnrolled = model.datDateEnrolled,
                intBenProfileID = model.intBenProfileID,
                bitConsentRecvdYN = model.bitConsentRecvdYN,
                intBenRelationshipID = model.intBenRelationshipID
            };

            try
            {
                string data = JsonConvert.SerializeObject(policyMember);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/InsertPolicyMembers", content);

                if (response.IsSuccessStatusCode)
                {
                    string data_list = response.Content.ReadAsStringAsync().Result;
                    var MemberBasic = JsonConvert.DeserializeObject<PolicyMemberInsert>(data_list);


                    return Json(MemberBasic);
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



        //[HttpPost]
        //public async Task<IActionResult> CreatePolicyMember([FromBody] PolicyMemberInsert model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values
        //                       .SelectMany(v => v.Errors)
        //                       .Select(e => e.ErrorMessage);
        //        return BadRequest(new { success = false, errors = errors });
        //    }

        //    try
        //    {
        //        HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/InsertPolicyMembers", model);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Data posted successfully
        //            return Ok(new { success = true, message = "Data posted successfully" });
        //        }
        //        else
        //        {
        //            // API call failed
        //            string errorMessage = await response.Content.ReadAsStringAsync();
        //            return StatusCode((int)response.StatusCode, new { success = false, message = errorMessage });
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        // HTTP request failed
        //        return StatusCode(500, new { success = false, message = "HTTP request failed", error = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        // Other exceptions
        //        return StatusCode(500, new { success = false, message = "An error occurred", error = ex.Message });
        //    }
        //}



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



       [HttpGet]
        public async Task<IActionResult> GetAddOnDescriptionList()
        {

            try
            {
                List<PolicyValueAddedService> Addondescriptionlist = new List<PolicyValueAddedService>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetAddOnDescriptionList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    Addondescriptionlist = JsonConvert.DeserializeObject<List<PolicyValueAddedService>>(data);
                }


                return Json(Addondescriptionlist);
            }

            catch (Exception ex)
            {

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




        [HttpPost]
        public async Task<IActionResult> CreateValueAddedService()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return Json(new { success = false, errors = errors });
            }

            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string body = await reader.ReadToEndAsync();

                Console.WriteLine($"Request body: {body}");

                if (!string.IsNullOrEmpty(body))
                {
                    try
                    {
                        PolicyValueAddedServiceInsert obj = JsonConvert.DeserializeObject<PolicyValueAddedServiceInsert>(body);
                        PolicyValueAddedServiceInsert policyValueAddedService = new PolicyValueAddedServiceInsert()
                        {
                            strEnterpriseID = "aaaa",
                            intPolicyNum = 1,
                            intAddOnID = 3,
                            intAddOnQty = obj.intAddOnQty,
                            monAddOnPrice = obj.monAddOnPrice,
                            datStartDate = obj.datStartDate,
                            datEndDate = obj.datEndDate,
                            intAOStatusID = 1,
                            strLastCapturer = "hello from here",
                            datDateModified = DateTime.Now
                        };
                        string jsonData = JsonConvert.SerializeObject(policyValueAddedService);
                        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await _httpClient.PostAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/InsertValueAddedService", content);

                        if (response.IsSuccessStatusCode)
                        {
                            string data1 = await response.Content.ReadAsStringAsync();
                            var createdRecord = JsonConvert.DeserializeObject<PolicyValueAddedServiceInsert>(data1);
                            return Json(createdRecord);
                        }
                        else
                        {
                            // Return an appropriate error response if the request fails
                            return StatusCode((int)response.StatusCode, $"An error occurred: {response.ReasonPhrase}");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Return an appropriate error response if an exception occurs
                        return StatusCode(500, $"An error occurred: {ex.Message}");
                    }
                }
            }

            // Return a default response if none of the conditional blocks are executed
            return StatusCode(500, "An unexpected error occurred.");
        }



        //[HttpPost]
        //public async Task<IActionResult> CreateValueAddedService([FromBody] PolicyValueAddedServiceInsert model)
        //{
        //    try
        //    {
        //        // You can access the properties of 'model' directly here
        //        model.strEnterpriseID = "aaaa";
        //        model.intPolicyNum = 1;
        //        model.intAOStatusID = 1;
                
        //        model.strLastCapturer = "hello from here";
        //        model.datDateModified = DateTime.Now;

                
        //        string jsonData = JsonConvert.SerializeObject(model);


        //        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await _httpClient.PostAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/InsertValueAddedService", content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string data1 = await response.Content.ReadAsStringAsync();
        //            var createdRecord = JsonConvert.DeserializeObject<PolicyValueAddedServiceInsert>(data1);
        //            return Json(createdRecord);
        //        }
        //        else
        //        {
        //            // Return an appropriate error response if the request fails
        //            return StatusCode((int)response.StatusCode, $"An error occurred: {response.ReasonPhrase}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Return an appropriate error response if an exception occurs
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}








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

