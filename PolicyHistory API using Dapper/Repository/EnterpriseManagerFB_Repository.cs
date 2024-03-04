using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PolicyHistory_API_using_Dapper.Context;
using PolicyHistory_API_using_Dapper.Models;
using PolicyHistory_API_using_Dapper.Services;
using System.Data;

namespace PolicyHistory_API_using_Dapper.Repository
{
    public class EnterpriseManagerFB_Repository : IEnterpriseManagerFB_Interface
    {
        public readonly DapperContext _context;

        public EnterpriseManagerFB_Repository(DapperContext context)
        {
            _context = context;
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





        public async Task<int> InsertList (PolicyList policylist)
        {
            using(var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("strEnterpriseID", policylist.StrEnterpriseID);
                parameters.Add("intPolicyNum", policylist.IntPolicyNum);
                parameters.Add("intPlanID", policylist.IntPlanID);
                parameters.Add("datDateOpened", policylist.DatDateOpened);
                parameters.Add("datInceptionDate", policylist.DatInceptionDate);
                parameters.Add("datDateClosed", policylist.DatDateClosed);
                parameters.Add("bitTnCAcceptedYN", policylist.BitTnCAcceptedYN);
                parameters.Add("strLastCapturer", policylist.StrLastCapturer);
                parameters.Add("datDateModified", policylist.DatDateModified);

                return await connection.ExecuteAsync("usp_Insert_tblFP_Policy", parameters, commandType: CommandType.StoredProcedure);

            }
            
        }

        public async Task<int> UpdateList(PolicyList policylist)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("strEnterpriseID", policylist.StrEnterpriseID);
                parameters.Add("intPolicyNum", policylist.IntPolicyNum);
                parameters.Add("intPlanID", policylist.IntPlanID);
                parameters.Add("datDateOpened", policylist.DatDateOpened);
                parameters.Add("datInceptionDate", policylist.DatInceptionDate);
                parameters.Add("datDateClosed", policylist.DatDateClosed);
                parameters.Add("bitTnCAcceptedYN", policylist.BitTnCAcceptedYN);
                parameters.Add("strLastCapturer", policylist.StrLastCapturer);
                parameters.Add("datDateModified", policylist.DatDateModified);

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

                 var records = await connection.QueryAsync<PolicyList>("usp_Select_tblFP_Policy_List_TODO", parameters, commandType: CommandType.StoredProcedure);


                    return records.ToList();

                }
            }





                
        public async Task<List<PolicyClaim>> GetClaims(string enterpriseID, int policyNum, int profileID)
           {
      
               using (var connection = _context.CreateConnection())
               {
                   var parameters = new
                   {
                       strEnterpriseID = enterpriseID,
                       intPolicyNum = policyNum,
                       intProfileID = profileID
                   };
      
                   var records = await connection.QueryAsync<PolicyClaim>("usp_Select_tblFP_PolicyMemberClaim_byEPPID",  parameters,commandType:   CommandType.StoredProcedure);
                   return records.ToList();
               }
      
           }



        public async Task<List<PolicyInvoiceandPayments>> GetInvoiceandPayments(string enterpriseID, int policyNum, int invoiceNum)
        {
            using (var connection = _context.CreateConnection())
            {
                var param = new
                {
                    strEnterpriseID = enterpriseID,
                    intPolicyNum = policyNum,
                    intInvoiceNum = invoiceNum
                };

                
                    var resultsFromStoredProcedure1 = await connection.QueryAsync<PolicyInvoiceandPayments>("usp_Select_tblFP_PolicyInvoice_byEPIID", param, commandType: CommandType.StoredProcedure);
                    var resultsFromStoredProcedure2 = await connection.QueryAsync<PolicyInvoiceandPayments>("usp_Select_tblFP_PolicyPayment_byEPIID", param, commandType: CommandType.StoredProcedure);

                    return MergeResults(resultsFromStoredProcedure1.ToList(), resultsFromStoredProcedure2.ToList());
                
             
            }
        }

        private List<PolicyInvoiceandPayments> MergeResults(List<PolicyInvoiceandPayments> results1, List<PolicyInvoiceandPayments> results2)
        {
            var mergedResults = results1.Concat(results2).ToList();
            return mergedResults;
        }



    }

}