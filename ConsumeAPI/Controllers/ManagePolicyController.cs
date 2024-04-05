using ConsumeAPI.Models;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PolicyHistory_API_using_Dapper.Models;
using System.Net;
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
            _httpClient.BaseAddress = baseAddress;
        }


        public IActionResult policylistview()
        {
            return View();
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
        public async Task<IActionResult> CreatePolicyMember()
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
                    PolicyMemberInsert obj = JsonConvert.DeserializeObject<PolicyMemberInsert>(body);

                    PolicyMemberInsert policyMember = new PolicyMemberInsert()
                    {
                        strEnterpriseID = "aaaa",
                        intPolicyNum = 1,
                        intProfileID = obj.intProfileID,
                        intMemberTypeID = obj.intMemberTypeID,
                        monPremiumAmt = obj.monPremiumAmt,
                        monCoverAmt = obj.monCoverAmt,
                        intRelationshipID = obj.intRelationshipID,
                        intAgeToday = 35,
                        IntAgeYesterday = 34,
                        datDateEnrolled = obj.datDateEnrolled,
                        intBenProfileID = 2107,
                        bitConsentRecvdYN = true,
                        intBenRelationshipID = 2,
                        strLastCapturer = "my last capturer",
                        datDateModified = DateTime.Now,
                        bitRemovedYN = true,
                    };

                    string jsonData = JsonConvert.SerializeObject(policyMember);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await _httpClient.PostAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/InsertPolicyMembers", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string data1 = await response.Content.ReadAsStringAsync();
                        var createdRecord = JsonConvert.DeserializeObject<PolicyMemberInsert>(data1);
                        return Json(policyMember);
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
        //public async Task<IActionResult> DeletePolicyMember()
        //{
        //    try
        //    {

        //        HttpResponseMessage response = await _httpClient.DeleteAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/DeletePolicyMember?");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return Ok("Policy member deleted successfully");
        //        }
        //        else if (response.StatusCode == HttpStatusCode.NotFound)
        //        {
        //            return NotFound("Policy member not found");
        //        }
        //        else
        //        {
        //            return StatusCode((int)response.StatusCode, $"An error occurred: {response.ReasonPhrase}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}


        [HttpGet]
        public async Task<IActionResult> GetPolicyPurposeList()
        {

            try
            {
                List<PolicyPurposeList> policies = new List<PolicyPurposeList>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyPurposeList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    policies = JsonConvert.DeserializeObject<List<PolicyPurposeList>>(data);
                }


                return Json(policies);
            }

            catch (Exception ex)
            {
               
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }






        [HttpGet]
        public async Task<IActionResult> GetPlanBrandList()
        {
           
            try
            {
                List<PlanBrandList> policies = new List<PlanBrandList>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPlanBrand?enterpriseID=aaaa");

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
                List<PolicyMemberTypeList> deathlist = new List<PolicyMemberTypeList>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetMemberTypeList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    deathlist = JsonConvert.DeserializeObject<List<PolicyMemberTypeList>>(data);
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
                List<PolicyRelationshipList> relationshiplist = new List<PolicyRelationshipList>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetRelationshipList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    relationshiplist = JsonConvert.DeserializeObject<List<PolicyRelationshipList>>(data);
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
                List<PolicyIDPPNumberList> IDPPList = new List<PolicyIDPPNumberList>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetIDPPNumberList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    IDPPList = JsonConvert.DeserializeObject<List<PolicyIDPPNumberList>>(data);
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
                List<PolicyAddOnDescriptionList> Addondescriptionlist = new List<PolicyAddOnDescriptionList>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetAddOnDescriptionList");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    Addondescriptionlist = JsonConvert.DeserializeObject<List<PolicyAddOnDescriptionList>>(data);
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
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetValueAddedService?enterpriseID=aaaa&policyNum=1");

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
                        IntAddOnID = obj.IntAddOnID,
                        IntAddOnQty = obj.IntAddOnQty,
                        MonAddOnPrice = obj.MonAddOnPrice,
                        DatStartDate = obj.DatStartDate,
                        DatEndDate = obj.DatEndDate,
                        IntAOStatusID = obj.IntAOStatusID,
                        StrLastCapturer = "latest capturer",
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


        [HttpDelete]
        public async Task<IActionResult> DeleteValueAddedService(int addonID) // Modify the parameter
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/DeleteValueAddedService?enterpriseID=aaaa&policyNum=1&addonID={addonID}");

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
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




        [HttpPut]
        public async Task<IActionResult> EditValueAddedService()
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
                        IntAddOnID = obj.IntAddOnID,
                        IntAddOnQty = obj.IntAddOnQty,
                        MonAddOnPrice = obj.MonAddOnPrice,
                        DatStartDate = obj.DatStartDate,
                        DatEndDate = obj.DatEndDate,
                        IntAOStatusID = obj.IntAOStatusID,
                        StrLastCapturer = "latest capturer",
                        DatDateModified = DateTime.Now
                    };

                    string jsonData = JsonConvert.SerializeObject(policyValueAddedService);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    
                    HttpResponseMessage response = await _httpClient.PutAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/EditValueAddedService", content);

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





        [HttpGet]
        public async Task<IActionResult> Getpolicyinvoice()
        {
            try
            {
                List<PolicyInvoice> valueaddedservice = new List<PolicyInvoice>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyInvoice?enterpriseID=aaaa&policyNum=1");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    valueaddedservice = JsonConvert.DeserializeObject<List<PolicyInvoice>>(data);
                }


                return Json(valueaddedservice);
            }

            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }


        [HttpPut]
        public async Task<IActionResult> EditPolicyInvoice()
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
                    PolicyInvoiceUpdate obj = JsonConvert.DeserializeObject<PolicyInvoiceUpdate>(body);

                    PolicyInvoiceUpdate policyInvoiceUpdate = new PolicyInvoiceUpdate()
                    {
                        StrEnterpriseID = "aaaa",
                        IntPolicyNum = 1,
                        IntInvoiceNum = obj.IntInvoiceNum,
                        DatInvoiceDate = DateTime.Now,
                        MonInvoiceTotal = obj.MonInvoiceTotal,
                        DatDueByDate = obj.DatInvoiceDate,
                        IntPurposeID = obj.IntPurposeID,    
                        IntYearID = obj.IntYearID,
                        IntMonthID = obj.IntMonthID,
                        DatDateModified = DateTime.Now,
                        StrLastCapturer = "my last capturer"
                    };

                    string jsonData = JsonConvert.SerializeObject(policyInvoiceUpdate);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await _httpClient.PutAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/EditInvoice", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string data1 = await response.Content.ReadAsStringAsync();
                        var createdRecord = JsonConvert.DeserializeObject<PolicyInvoiceUpdate>(data1);
                        return Json(policyInvoiceUpdate);
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





        [HttpGet]
        public async Task<IActionResult> Getpolicypayments(int intInvoiceNum)
        {
            try
            {
                List<PolicyPayments> valueaddedservice = new List<PolicyPayments>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyPayments?enterpriseID=aaaa&policyNum=1&invoiceNum={intInvoiceNum}");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    valueaddedservice = JsonConvert.DeserializeObject<List<PolicyPayments>>(data);
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
        public async Task<IActionResult> Getpolicyclaims(int policyNum)
        {
            try
            {
                List<PolicyClaim> policyclaims = new List<PolicyClaim>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetPolicyClaims?enterpriseID=aaaa&policyNum={policyNum}");

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




        [HttpPost]
        public async Task<IActionResult> InsertPolicyClaims()
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
                    PolicyClaimsInsert obj = JsonConvert.DeserializeObject<PolicyClaimsInsert>(body);

                    PolicyClaimsInsert policycaliminsert = new PolicyClaimsInsert()
                    {
                        StrEnterpriseID = "aaaa",
                        IntPolicyNum = 1,
                        IntProfileID = 2052,
                        IntMemberTypeID =1,
                        DatClaimDate = obj.DatClaimDate,
                        MonClaimAmt = 5000,
                        IntClaimMethodID =1,
                        IntDeathCauseID = 2,
                        DatDeathDate = obj.DatDeathDate,
                        BitDeathCertReceived = obj.BitDeathCertReceived,
                        StrRefNum = "1",
                        BitApprovedYN = obj.BitApprovedYN,
                        DatPayOutDate = obj.DatPayOutDate,  
                        StrLastCapturer = "my last capturer",
                        DatDateModified = DateTime.Now


                       
                    };

                    string jsonData = JsonConvert.SerializeObject(policycaliminsert);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await _httpClient.PostAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/InsertClaims", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string data1 = await response.Content.ReadAsStringAsync();
                        var createdRecord = JsonConvert.DeserializeObject<PolicyClaimsInsert>(data1);
                        return Json(policycaliminsert);
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


        [HttpGet]
        public async Task<IActionResult> GetCombinedPolicyClaims()
        {

            try
            {
                List<CombinedPolicyClaims> combinedPolicyClaims = new List<CombinedPolicyClaims>();
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/EnterpriseManagerFB_ManagePolicy/GetCombinedPolicyClaims?enterpriseId=aaaa&policyNum=1");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    combinedPolicyClaims = JsonConvert.DeserializeObject<List<CombinedPolicyClaims>>(data);
                }


                return Json(combinedPolicyClaims);
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

