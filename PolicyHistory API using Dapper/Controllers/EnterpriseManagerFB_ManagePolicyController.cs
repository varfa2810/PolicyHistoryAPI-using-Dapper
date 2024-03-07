﻿using Microsoft.AspNetCore.Http;
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




        /*
                [HttpPost("Policy_List_Insert")]
                public async Task<IActionResult> CreatePolicy([FromQuery] PolicyList policy)
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

                [HttpPut("Policy_List_Update")]
                public async Task<IActionResult> UpdateList([FromQuery] PolicyList policy)
                {
                    try
                    {
                        await _repo.UpdateList(policy);
                        return Ok("Policy updated successfully.");
                    }
                    catch(Exception ex) { 

                    return BadRequest(ex.Message);
                    }
                }


                [HttpDelete("Policy_List_Delete")]
                public async Task<IActionResult> DeletePol(string enterpriseID, int policyNum)
                {
                    try
                    {
                        await _repo.Delete(enterpriseID, policyNum);
                        return Ok("Deleted policy succesfully");
                    }
                    catch(Exception e) 
                    {
                        return BadRequest(e.Message);
                    }
                }
        */
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



        [HttpGet("GetValueAddedService")]
        public async Task<IActionResult> GetValueAddedService(string enterpriseID, int policyNum, int AddOnID)
        {
            try
            {
                var result = await _repo.GetValueAddedService(enterpriseID, policyNum, AddOnID);
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



        [HttpGet("Policy_InvoiceandPayments")]
        public async Task<IActionResult> GetInvoiceandPayments(string enterpriseID, int policyNum, int invoiceNum)
        {
            try
            {
                var result = await _repo.GetInvoiceandPayments(enterpriseID, policyNum, invoiceNum);
                return Ok(result);
            }
            catch (Exception ex) 
            { 
              return BadRequest(ex.Message);
            }
           

        }
       

    }

}
