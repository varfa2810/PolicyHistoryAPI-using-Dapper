using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyHistory_API_using_Dapper.Models;
using PolicyHistory_API_using_Dapper.Services;

namespace PolicyHistory_API_using_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseManagerFB_ManagePolicyController : ControllerBase
    {
        public readonly IEnterpriseManagerFB_Interface _repo;


        public EnterpriseManagerFB_ManagePolicyController(IEnterpriseManagerFB_Interface repo)
        {
            _repo = repo;
        }


        [HttpGet("GetPolicyAgent")]
        public async Task<IActionResult> GetPolicyAgentList()
        {
            try
            {
                var result = await _repo.GetPolicyAgentList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet("GetPlanBrand")]
        public async Task<IActionResult> GetPlanBrandList(string enterpriseID)
        {
            try
            {
                var result = await _repo.GetPlanBrandList(enterpriseID);
                return Ok(result);
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("GetPolicyDeathList")]
        public async Task<IActionResult> GetPolicyDeathList()
        {
            try
            {
                var result = await _repo.GetPolicyDeathList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("GetMemberTypeList")]
        public async Task<IActionResult> GetMemberTypeList()
        {
            try
            {
                var result = await _repo.GetMemberTypeList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetRelationshipList")]
        public async Task<IActionResult> GetRelationshipList()
        {
            try
            {
                var result = await _repo.GetRelationshipList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet("GetIDPPNumberList")]
        public async Task<IActionResult> GetIDPPNumberList()
        {
            try
            {
                var result = await _repo.GetIDPPNumberList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("GetAddOnDescriptionList")]
        public async Task<IActionResult> GetAddOnDescriptionList()
        {
            try
            {
                var result = await _repo.GetAddOnDescriptionList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("InsertPolicy")]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyList policy)
                {
                    try
                    {
                        await _repo.InsertList(policy);
                        return Ok("Policy created successfully.");
                    }
                    catch (Exception ex)
                    {

                        return BadRequest(ex.Message);  
                    }
                }

        [HttpPut("UpdatePolicy")]
        public async Task<IActionResult> UpdateList(string enterpriseID, int policyNum,[FromBody] PolicyList policylist)
                {
                    try
                    {
                        int affectedRows = await _repo.UpdateList(enterpriseID, policyNum, policylist);
              
                        if (affectedRows > 0)
                        {
                            return Ok(new { Message = "List of policies updated successfully" });
                        }
                        else
                        {
                            return NotFound(new { Message = "List of policies not found or not updated" });
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        return StatusCode(500, new { Message = "Internal server error" });
                    }
                }


        [HttpDelete("DeletePolicy")]
        public async Task<IActionResult> DeletePol(string enterpriseID, int policyNum)
        {
            try
            {
                await _repo.Delete(enterpriseID, policyNum);
                return Ok("Deleted policy succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("GetPolicyList")]
        public async Task<IActionResult> GetList(string enterpriseID, int policyNum)
        {
            try
            {
                var result = await _repo.GetList(enterpriseID, policyNum);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




        [HttpPost("InsertPolicyDetails")]
        public async Task<IActionResult> InsertPolicyDetails(string enterpriseID, int policyNum, int planID, DateTime dateOpened, DateTime inceptionDate, DateTime dateClosed, bool tnCAcceptedYN, string lastCapturer, DateTime dateModified)
        {
            try
            {
                int affectedRows = await _repo.InsertPolicyDetails(enterpriseID, policyNum,planID, dateOpened,inceptionDate,dateClosed,tnCAcceptedYN,lastCapturer,dateModified);

                if (affectedRows > 0)
                {
                    return Ok(new { Message = "Policy details inserted successfully" });
                }
                else
                {
                    return NotFound(new { Message = "policy details not found or not updated" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetPolicyDetails")]
        public async Task<IActionResult> GetDetails(string enterpriseId)
        {
            try
            {
                var result = await _repo.GetDetails(enterpriseId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }



        [HttpGet("GetPolicyMembers")]
        public async Task<IActionResult> GetPolicyMembers(string enterpriseId, int policyNum)
        {
            try
            {
                var result = await _repo.GetPolicyMembers(enterpriseId, policyNum);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }


        [HttpPost("InsertPolicyMembers")]
        public async Task<IActionResult> InsertPolicyMembers( [FromBody] PolicyMemberInsert policymemberinsert)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _repo.InsertPolicyMembers(policymemberinsert);
                if (result > 0)
                {

                    return Ok(new { Message = "Member inserted successfully." });
                }
                else
                {

                    return NotFound(new { Message = "No such member found Added Service not found." });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("GetPolicyHistory")]
        public async Task<IActionResult> GetHistory(string enterpriseID, int policyNum, int historyID)
        {
            try
            {
                var result = await _repo.GetHistory(enterpriseID, policyNum, historyID);
                return Ok(result);
            }
            catch( Exception ex) {
                return BadRequest(ex.Message);
            
            
            }
            
        }



        [HttpPut("EditValueAddedService")]
        public async Task<IActionResult> EditValueAddedService(int policyNum, [FromBody]PolicyValueAddedService policyValueAddedService)
        {
         
            try
            {
                var result =  await _repo.EditValueAddedService(policyNum, policyValueAddedService);
                return Ok(result);
                
            }
            catch(Exception ex)
            {
                return BadRequest($"Error in editing value added service refer this given error message /n {ex.Message}");
            }
        }

        [HttpDelete("DeleteValueAddedService")]
        public async Task<IActionResult> DeleteValueAddedService(string enterpriseID, int policyNum)
        {
            try
            {
                var result = await _repo.DeleteValueAddedService(enterpriseID, policyNum);
                if (result > 0) 
                {
                  
                    return Ok(new { Message = "Value Added Service deleted successfully." });
                }
                else
                {
                    
                    return NotFound(new { Message = "Value Added Service not found." });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertValueAddedService")]
        public async Task<IActionResult> InsertValueAddedService( [FromBody] PolicyValueAddedServiceInsert policyValueAddedService) 
        {
            try
            {
                var result = await _repo.InsertValueAddedService(policyValueAddedService);
                if (result > 0)
                {

                    return Ok(new { Message = "Value Added Service inserted successfully." });
                }
                else
                {

                    return NotFound(new { Message = "Value Added Service not found." });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetValueAddedService")]
        public async Task<IActionResult> GetValueAddedService(string enterpriseID, int policyNum)
        {
            try
            {
                var result = await _repo.GetValueAddedService(enterpriseID, policyNum);
                return Ok(result);  
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);   
            }
        }



       
       [HttpGet("GetPolicyClaims")]
       public async Task<IActionResult> GetClaims(string enterpriseID, int policyNum,int policyID)
       {
            try
            {
                var result = await _repo.GetClaims(enterpriseID, policyNum, policyID);
                return Ok(result);
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
       }







        [HttpPut("EditInvoice")]
        public async Task<IActionResult> EditInvoice( [FromBody]PolicyInvoice policyInvoice)
        {
         
            try
            {
                int affectedRows = await _repo.EditInvoice(policyInvoice);

                if (affectedRows > 0)
                {
                    return Ok(new { Message = "Invoice edited successfully" });
                }
                else
                {
                    return NotFound(new { Message = "Invoice not found or not updated" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpDelete("DeleteInvoice")]
        public async Task<IActionResult> DeleteInvoice(string enterpriseID, int policyNum, int invoiceNum)
        {
            try
            {
                int affectedRows = await _repo.DeleteInvoice( enterpriseID,  policyNum ,invoiceNum);

                if (affectedRows > 0)
                {
                    return Ok(new { Message = "Invoice edited successfully" });
                }
                else
                {
                    return NotFound(new { Message = "Invoice not found or not updated" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        
        [HttpPost("InsertInvoice")]
        public async Task<IActionResult> InsertInvoice([FromBody]PolicyInvoice policyInvoice)
        {
            try
            {
                var result = await _repo.InsertInvoice(policyInvoice);
                if (result > 0)
                {

                    return Ok(new { Message = "Invoice inserted successfully." });
                }
                else
                {

                    return NotFound(new { Message = "Invoice insertion failed." });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetPolicyInvoice")]
        public async Task<IActionResult> GetInvoice(string enterpriseID, int policyNum, int invoiceNum)
        {
            try
            {
                var result = await _repo.GetInvoice(enterpriseID, policyNum, invoiceNum);
                return Ok(result);
            }
            catch (Exception ex) 
            { 
              return BadRequest(ex.Message);
            }
           

        }






        [HttpPut("EditPayment")]
        public async Task<IActionResult> EditPayment(string enterpriseID, int policyNum, int invoiceNum,[FromBody] PolicyPayments policypayments)
        {

            try
            {
                int affectedRows = await _repo.EditPayments( enterpriseID,  policyNum,  invoiceNum, policypayments);

                if (affectedRows > 0)
                {
                    return Ok(new { Message = "Invoice edited successfully" });
                }
                else
                {
                    return NotFound(new { Message = "Invoice not found or not updated" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpDelete("DeletePayment")]
        public async Task<IActionResult> DeletePayments(string enterpriseID, int policyNum, int invoiceNum)
        {
            try
            {
                int affectedRows = await _repo.DeletePayments(enterpriseID, policyNum, invoiceNum);

                if (affectedRows > 0)
                {
                    return Ok(new { Message = "Payment deleted successfully" });
                }
                else
                {
                    return NotFound(new { Message = "Payment not found or not updated" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("GetPolicyPayments")]
        public async Task<IActionResult> GetPayments(string enterpriseID, int policyNum, int invoiceNum)
        {
            try
            {
                var result = await _repo.GetPayments(enterpriseID, policyNum, invoiceNum);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }






    }

}
