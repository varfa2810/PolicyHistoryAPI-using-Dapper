using Microsoft.AspNetCore.Mvc;
using PolicyHistory_API_using_Dapper.Models;

namespace PolicyHistory_API_using_Dapper.Services
{
    public interface IEnterpriseManagerFB_Interface
    {



            Task<int> InsertList(PolicyList policylist);
            Task<int> UpdateList(string enterpriseID, int policyNum, PolicyList policylist);

            Task<int> Delete(string enterpriseID, int policyNum);

        Task<List<PolicyList>> GetList(string enterpriseID, int policyNum);


        Task<int> InsertPolicyDetails(string enterpriseID,  int policyNum,int planID,DateTime dateOpened,DateTime inceptionDate, DateTime dateClosed, bool tnCAcceptedYN, string lastCapturer, DateTime dateModified);
        Task<List<PolicyDetails>> GetDetails(string enterpriseID);



        Task<List<PolicyHistory>> GetHistory(string enterpriseID, int policyNum, int historyID);



        Task <int> EditValueAddedService(int policyNum, PolicyValueAddedService _policyValueAddedService);
        Task<int> DeleteValueAddedService(string enterpriseID, int policyNum);

        Task<int> InsertValueAddedService(PolicyValueAddedService policyValueAddedService);
        Task<List<PolicyValueAddedService>> GetValueAddedService(string enterpriseID, int policyNum, int AddOnID);





        Task<List<PolicyClaim>> GetClaims(string enterpriseID, int policyNum, int profileID);





        Task<int> EditInvoice(PolicyInvoice policyInvoice);

        Task<int> DeleteInvoice(string enterpriseID, int policyNum, int invoiceNum);
        Task<int> InsertInvoice(PolicyInvoice policyInvoice);


        Task<List<PolicyInvoice>> GetInvoice(string enterpriseID, int policyNum, int invoiceNum);



        Task<int> EditPayments(string enterpriseID, int policyNum, int invoiceNum, PolicyPayments policyPayments);

        Task<int> DeletePayments(string enterpriseID, int policyNum, int invoiceNum);

        Task<List<PolicyPayments>> GetPayments(string enterpriseID, int policyNum, int invoiceNum);






    }
}
