using Microsoft.AspNetCore.Mvc;
using PolicyHistory_API_using_Dapper.Models;

namespace PolicyHistory_API_using_Dapper.Services
{
    public interface IEnterpriseManagerFB_Interface
    {

       
        Task<List<PolicyHistory>> GetAllHistory();
        Task<List<PolicyHistory>> GetHistory(string enterpriseID, int policyNum, int historyID);




        Task<int> InsertList( PolicyList policylist);
        Task<int> UpdateList( PolicyList policylist);

        Task<int> Delete(string enterpriseID, int policyNum);

        Task<List<PolicyList>> GetList(string enterpriseID, int policyNum);
        






        Task<List<PolicyClaim>> GetClaims(string enterpriseID, int policyNum, int profileID);




        

        Task<List<PolicyInvoiceandPayments>> GetInvoiceandPayments(string enterpriseID, int policyNum, int invoiceNum);
                                                                               
       



    }
}
