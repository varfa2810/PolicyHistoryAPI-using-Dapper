using ConsumeAPI.Models;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;


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
        public async Task<IActionResult> GetPolicyStatusList()
        {

            try
            {
                List<PolicyStatusList> policystatus = new List<PolicyStatusList>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyStatusList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    policystatus = JsonConvert.DeserializeObject<List<PolicyStatusList>>(data);
                }


                return Json(policystatus);
            }

            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }





        [HttpGet]
        public async Task<IActionResult> GetCorrespondingData(int memberTypeID, int profileID)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyDetailsCorrespondingDetails?membertypeID={memberTypeID}&profileID={profileID}");
                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();
                List<CorrespondingDataModel> data = JsonConvert.DeserializeObject<List<CorrespondingDataModel>>(responseData);

                return Json(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
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
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string body = await reader.ReadToEndAsync();

                if (string.IsNullOrEmpty(body))
                {
                    return Json(new { success = false, message = "Request body is empty." });
                }

                try
                {
                    PolicyValueAddedServiceInsert obj = JsonConvert.DeserializeObject<PolicyValueAddedServiceInsert>(body);

                    PolicyValueAddedServiceInsert policyValueAddedService = new PolicyValueAddedServiceInsert()
                    {
                        StrEnterpriseID = "aaaa",
                        IntPolicyNum = 1,
                        IntAddOnID = 4,
                        IntAddOnQty = 5,
                        MonAddOnPrice = 5,
                        DatStartDate = obj.DatStartDate,
                        DatEndDate = obj.DatEndDate,
                        IntAOStatusID = 2,
                        StrLastCapturer = "hello from here 3",
                        DatDateModified = DateTime.Now
                    };

                    string jsonData = JsonConvert.SerializeObject(policyValueAddedService);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await _httpClient.PostAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/InsertValueAddedService", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string data1 = await response.Content.ReadAsStringAsync();
                        var createdRecord = JsonConvert.DeserializeObject<PolicyValueAddedServiceInsert>(data1);
                        return Json(policyValueAddedService);
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
        }



        //[HttpDelete]
        //public async Task<IActionResult> DeleteValueAddedService(int addonID)
        //{

        //}




        [HttpGet]
        public async Task<IActionResult> Getpolicyclaims()
        {

            try
            {
                List<PolicyClaim> policyclaims= new List<PolicyClaim>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyClaims?enterpriseID=aaaa&policyNum=1&profileID=2019");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    policyclaims = JsonConvert.DeserializeObject<List<PolicyClaim>>(data);
                }


                return Json(policyclaims);
            }

            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }


            }
        }

