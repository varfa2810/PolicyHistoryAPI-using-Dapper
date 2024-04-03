using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PolicyHistory_API_using_Dapper.Context;
using PolicyHistory_API_using_Dapper.Models;
using PolicyHistory_API_using_Dapper.Services;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PolicyHistory_API_using_Dapper.Repository
{
    public class EnterpriseManagerFB_Repository : IEnterpriseManagerFB_Interface
    {
        public readonly DapperContext _context;

        public EnterpriseManagerFB_Repository(DapperContext context)
        {
            _context = context;
        }


        public async Task<List<PolicyAgentList>> GetPolicyAgentList()
        {
            using(var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<PolicyAgentList>("usp_Select_tblFP_Agent_List", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<PlanBrandNameList>> GetPlanBrandList(string enterpriseID)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    StrEnterpriseID = enterpriseID
                };
                var result = await connection.QueryAsync<PlanBrandNameList>("usp_Select_tblFB_PlanBrandName_List", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<PolicyDeathList>> GetPolicyDeathList()
        {
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<PolicyDeathList>("usp_Select_tblFP_DeathCause_List", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<PolicyMemberTypeList>> GetMemberTypeList()
        {
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<PolicyMemberTypeList>("usp_Select_tblFP_MemberType_List", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<PolicyRelationshipList>> GetRelationshipList()
        {
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<PolicyRelationshipList>("usp_Select_tblFB_Relationship_List", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }


        public async Task<List<PolicyIDPPNumberList>> GetIDPPNumberList()
        {
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<PolicyIDPPNumberList>("usp_Select_tblFP_IDPPnumber_List", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }


        public async Task<List<PolicyAddOnDescriptionList>> GetAddOnDescriptionList()
        {
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<PolicyAddOnDescriptionList>("usp_Select_tblFP_AddoOnDescription_List", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }



        public async Task<List<PolicyStatusList>> GetPolicyStatusList()
        {
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<PolicyStatusList>("usp_Select_tblFP_AddOnStatus_List", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }



        public async Task<List<PolicyDetailsCorrespondingDetails>> GetPolicyDetailsCorrespondingDetails(int membertypeID, int profileID)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    intProfileID = profileID,
                    intMemberTypeID = membertypeID

                };
                var result = await connection.QueryAsync<PolicyDetailsCorrespondingDetails>("usp_select_tblFP_PolicyMemberExtraList", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }



        public async Task<int> InsertList (PolicyList policylist)
        {
            using(var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();



                return await connection.ExecuteAsync("usp_Insert_tblFP_Policy", parameters, commandType: CommandType.StoredProcedure);

            }

        }

        public async Task<int> UpdateList(string enterpriseID, int policyNum, PolicyList policylist)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    intPolicyNum = policyNum,
                    intPlanID = policylist.IntPlanID,
                    datDateOpened = policylist.DatDateOpened,
                    datInceptionDate  = policylist.DatInceptionDate,
                    datDateClosed  = policylist.DatDateClosed,
                    bitTnCAcceptedYN= policylist.BitTnCAcceptedYN,
                    strLastCapturer =policylist.StrLastCapturer,
                    datDateModified =policylist.DatDateModified
                };

                return await connection.ExecuteAsync("usp_Update_tblFP_Policy", parameters, commandType: CommandType.StoredProcedure);
            }
        }



        public async Task<int> Delete(string enterpriseID, int policyNum)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    StrEnterpriseID = enterpriseID,
                    IntPolicyNum = policyNum

                };
                var records = await connection.ExecuteAsync("usp_Delete_tblFP_Policy_byEP", parameters, commandType: CommandType.StoredProcedure);
                return records;

            }



        }

        public async Task<List<PolicyList>> GetList(string enterpriseID, int policyNum)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    intPolicyNum = policyNum,

                };

                var records = await connection.QueryAsync<PolicyList>("usp_Select_tblFP_Policy_List_byEPID", parameters, commandType: CommandType.StoredProcedure);


                return records.ToList();

            }
        }




        public async Task<int> InsertPolicyDetails(string enterpriseID, int policyNum, int planID, DateTime dateOpened, DateTime inceptionDate, DateTime dateClosed, bool tnCAcceptedYN, string lastCapturer, DateTime dateModified)
        {
            using(var connection = _context.CreateConnection()) {

                var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    intPolicyNum = policyNum,
                    intPlanID = planID,
                    datDateOpened = dateOpened,
                    datInceptionDate = inceptionDate,
                    datDateClosed = dateClosed,
                    bitTnCAcceptedYN = tnCAcceptedYN,
                    strLastCapturer = lastCapturer,
                    datDateModified = dateModified
                };
                return await connection.ExecuteAsync("usp_Insert_tblFP_Policy", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<List<PolicyDetails>> GetDetails(string enterpriseID)
        {
            using(var connection = _context.CreateConnection()) {
                var parameters = new
                {
                    StrEnterpriseID = enterpriseID
                };

                var result = await connection.QueryAsync < PolicyDetails > ("usp_Select_tblFP_Policy_byEID", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            
            }
        }


        public async Task<List<PolicyMembers>> GetPolicyMembers(string enterpriseID, int policyNum)
        {
            using(var connection = _context.CreateConnection())
            {
                 var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    intPolicyNum = policyNum
                };

                var result = await connection.QueryAsync<PolicyMembers>("usp_Select_tblFP_PolicyMember_byEPID", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList(); 
            }
        }

        public async Task<int> InsertPolicyMembers(PolicyMemberInsert policymemberinsert)
        {
            using(var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync("usp_Insert_tblFP_PolicyMember", policymemberinsert, commandType:CommandType.StoredProcedure);
            }
        }



        public async Task<List<PolicyHistory>> GetHistory(string enterpriseID, int policyNum, int historyID)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    intPolicyNum = policyNum,
                    intHistoryID = historyID
                };

                var records = await connection.QueryAsync<PolicyHistory>("usp_Select_tblFP_PolicyHistory_byEPHID", parameters, commandType: CommandType.StoredProcedure);


                return records.ToList();
            }
        }





        public async Task<int> EditValueAddedService(int policyNum, PolicyValueAddedService _policyValueAddedService)
        {
            using( var connection = _context.CreateConnection())
            {
                var parameters = new {
                    strEnterpriseID = _policyValueAddedService.StrEnterpriseID,
                    intPolicyNum = _policyValueAddedService.IntPolicyNum,
                    intAddOnID = _policyValueAddedService.IntAddOnID,
                    intAddOnQty = _policyValueAddedService.IntAddOnQty,
                    monAddOnPrice = _policyValueAddedService.MonAddOnPrice,
                    datStartDate = _policyValueAddedService.DatStartDate,
                    datEndDate = _policyValueAddedService.DatEndDate,
                    intAOStatusID = _policyValueAddedService.IntAOStatusID,
                    strLastCapturer = _policyValueAddedService.StrLastCapturer,
                    datDateModified = _policyValueAddedService.DatDateModified


                };
                 return await connection.ExecuteAsync("usp_Update_tblFP_PolicyAddOn", parameters, commandType: CommandType.StoredProcedure);
                
            }
        }

        public async Task<int> DeleteValueAddedService(string enterpriseID, int policyNum, int addonID)
        {
            using(var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    intPolicyNum = policyNum,
                    intAddOnID= addonID

                };
                return await connection.ExecuteAsync("usp_Delete_tblFP_PolicyAddOn_byEPAID", parameters, commandType: CommandType.StoredProcedure);
               
            }
        }

        public async Task<int> InsertValueAddedService(PolicyValueAddedServiceInsert policyValueAddedService)
        {
            using( var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync("usp_Insert_tblFP_PolicyAddOn", policyValueAddedService, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<List<PolicyValueAddedService>> GetValueAddedService(string enterpriseID, int policyNum){

            using(var connection = _context.CreateConnection()) {

                var parameters = new
                {
                    StrEnterpriseID = enterpriseID, IntPolicyNum = policyNum

                };

                var result = await connection.QueryAsync<PolicyValueAddedService>("usp_Select_tblFP_PolicyAddOn_byEPID", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();

            
            }
        }






                
       






        public async Task<int> EditInvoice(PolicyInvoice policyInvoice)
        {
            using (var connection = _context.CreateConnection())
            {
                

                return await connection.ExecuteAsync("usp_Update_tblFP_PolicyInvoice", policyInvoice, commandType: CommandType.StoredProcedure);
               
     
            }
        }


        public async Task<int> DeleteInvoice(string enterpriseID, int policyNum, int invoiceNum)
        {
           using(var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    intPolicyNum = policyNum,
                    intInvoiceNum = invoiceNum,

                };

                return await connection.ExecuteAsync("usp_Delete_tblFP_PolicyInvoice_byEPIID", parameters, commandType: CommandType.StoredProcedure);


            }
        }

        public async Task<int> InsertInvoice(PolicyInvoiceInsert policyInvoice)
        {
            using( var connection = _context.CreateConnection()) {

               return await connection.ExecuteAsync("usp_Insert_tblFP_PolicyInvoice", policyInvoice, commandType: CommandType.StoredProcedure);
            
            }
        }

        public async Task<List<PolicyInvoice>> GetInvoice(string enterpriseID, int policyNum)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    intPolicyNum = policyNum,
                    
                };

                var resultsFromStoredProcedure1 = await connection.QueryAsync<PolicyInvoice>("usp_Select_tblFP_PolicyInvoice_byEPID", parameters, commandType: CommandType.StoredProcedure);
                
                return (resultsFromStoredProcedure1.ToList());

            }

        }



        public async Task<List<PolicyPayments>> GetPayments(string enterpriseID, int policyNum, int invoiceNum)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    intPolicyNum = policyNum,
                    intInvoiceNum = invoiceNum
                };

                var resultsFromStoredProcedure1 = await connection.QueryAsync<PolicyPayments>("usp_Select_tblFP_PolicyPayment_byEPIID", parameters, commandType: CommandType.StoredProcedure);

                return (resultsFromStoredProcedure1.ToList());

            }

        }

        public async Task<int> EditPayments(string enterpriseID, int policyNum, int invoiceNum, PolicyPayments policyPayments)
        {
           using(var connection = _context.CreateConnection()) {

                var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    IntpolicyNum = policyNum,
                    IntinvoiceNum = invoiceNum
                };

                return await connection.ExecuteAsync("usp_Update_tblFP_PolicyPayment", parameters, commandType: CommandType.StoredProcedure);
            
            }
        }

        public async Task<int> DeletePayments(string enterpriseID, int policyNum, int invoiceNum)
        {
            using (var connection = _context.CreateConnection())
            {

                var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    IntpolicyNum = policyNum,
                    IntinvoiceNum = invoiceNum
                };

                return await connection.ExecuteAsync("usp_Delete_tblFP_PolicyPayment_byEPIID", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<int> InsertPayments(PolicyPaymentInsert policyPaymentInsert)
        {
            using (var connection = _context.CreateConnection())
            {

                return await connection.ExecuteAsync("usp_Insert_tblFP_PolicyPayment", policyPaymentInsert, commandType: CommandType.StoredProcedure);

            }
        }




        public async Task<List<PolicyClaim>> GetClaims(string enterpriseID, int policyNum)
        {

            using (var connection = _context.CreateConnection())
            {
                var parameters = new
                {
                    strEnterpriseID = enterpriseID,
                    intPolicyNum = policyNum,

                };

                var records = await connection.QueryAsync<PolicyClaim>("usp_Select_tblFP_PolicyMemberClaim_byEPID", parameters, commandType: CommandType.StoredProcedure);
                return records.ToList();
            }

        }


        public async Task<int> InsertClaims(PolicyClaimsInsert policyClaimsInsert)
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync("usp_Insert_tblFP_PolicyMemberClaim", policyClaimsInsert, commandType: CommandType.StoredProcedure);
            }
        }

      


        public async Task<List<CombinedPolicyClaims>> GetCombinedPolicyClaims(string enterpriseID, int policyNum)
        {
            var claims = await GetClaims(enterpriseID, policyNum);
            var members = await GetPolicyMembers(enterpriseID, policyNum);

            var combinedClaims = new List<CombinedPolicyClaims>();

            // Iterate through all members
            foreach (var member in members)
            {
                var claim = claims.FirstOrDefault(c =>
                    c.StrEnterpriseID == member.StrEnterpriseID &&
                    c.IntPolicyNum == member.IntPolicyNum &&
                    c.IntProfileID == member.IntProfileID);

                // Create CombinedPolicyClaims object even if no claim is found
                combinedClaims.Add(new CombinedPolicyClaims
                {
                    StrEnterpriseID = member.StrEnterpriseID,
                    IntPolicyNum = member.IntPolicyNum,
                    IntProfileID = member.IntProfileID,
                    DatClaimDate = claim?.DatClaimDate ?? DateTime.MinValue,
                    MonClaimAmt = claim?.MonClaimAmt ?? 0,
                    IntClaimMethodID = claim?.IntClaimMethodID ?? 0,
                    StrClaimMethod = claim?.StrClaimMethod ?? "",
                    IntDeathCauseID = claim?.IntDeathCauseID ?? 0,
                    StrDeathCause = claim?.StrDeathCause ?? "",
                    DatDeathDate = claim?.DatDeathDate ?? DateTime.MinValue,
                    BitDeathCertReceived = claim?.BitDeathCertReceived ?? false,
                    StrRefNum = claim?.StrRefNum ?? "",
                    BitApprovedYN = claim?.BitApprovedYN ?? false,
                    DatPayOutDate = claim?.DatPayOutDate ?? DateTime.MinValue,
                    StrLastCapturer = claim?.StrLastCapturer ?? "",
                    DatDateModified = claim?.DatDateModified ?? DateTime.MinValue,
                    CoverStatus = claim?.CoverStatus ?? "",

                    IntMemberTypeID = member.IntMemberTypeID,
                    StrMemberType = member.StrMemberType,
                    StrIDPPNum = member.StrIDPPNum,
                    StrMemberName = member.StrMemberName,
                    DatBirthDate = member.DatBirthDate,
                    IntRelationshipID = member.IntRelationshipID,
                    IntAge_Calc = member.IntAge_Calc,
                    IntAgeToday = member.IntAgeToday,
                    IntAgeYesterday = member.IntAgeYesterday,
                    MonPremiumAmt = member.MonPremiumAmt,
                    MonCoverAmt = member.MonCoverAmt,
                    DatDateEnrolled = member.DatDateEnrolled,
                    StrRelationshipToMainMember = member.StrRelationshipToMainMember,
                    IntBenProfileID = member.IntBenProfileID,
                    StrBeneficiaryNameID = member.StrBeneficiaryNameID,
                    IntBenRelationshipID = member.IntBenRelationshipID,
                    StrBenRelationshipToPolMember = member.StrBenRelationshipToPolMember,
                    BitConsentRecvdYN = member.BitConsentRecvdYN,
                    BitRemovedYN = member.BitRemovedYN
                });
            }

            return combinedClaims;
        }

       
    }








}