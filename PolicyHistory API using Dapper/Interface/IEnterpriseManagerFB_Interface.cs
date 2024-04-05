using Microsoft.AspNetCore.Mvc;
using PolicyHistory_API_using_Dapper.Models;

namespace PolicyHistory_API_using_Dapper.Services
{
    public interface IEnterpriseManagerFB_Interface
    {

        Task<List<PolicyAgentList>> GetPolicyAgentList();
        Task<List<PlanBrandNameList>> GetPlanBrandList(string enterpriseID);
        Task<List<PolicyDeathList>> GetPolicyDeathList();
        Task<List<PolicyMemberTypeList>> GetMemberTypeList();

        Task<List<PolicyRelationshipList>> GetRelationshipList();
        Task<List<PolicyIDPPNumberList>> GetIDPPNumberList();

        Task<List<PolicyAddOnDescriptionList>> GetAddOnDescriptionList();

        Task<List<PolicyStatusList>> GetPolicyStatusList();

        Task<List<PolicyPurposeList>> GetPolicyPurposeList();

        Task<List<PolicyDetailsCorrespondingDetails>> GetPolicyDetailsCorrespondingDetails( int membertypeID,int profileID);


        Task<int> InsertList(PolicyList policylist);
        Task<int> UpdateList(string enterpriseID, int policyNum, PolicyList policylist);

        Task<int> Delete(string enterpriseID, int policyNum);
        Task<List<PolicyList>> GetList(string enterpriseID, int policyNum);


        Task<int> InsertPolicyDetails(string enterpriseID,  int policyNum,int planID,DateTime dateOpened,DateTime inceptionDate, DateTime dateClosed, bool tnCAcceptedYN, string lastCapturer, DateTime dateModified);
        Task<List<PolicyDetails>> GetDetails(string enterpriseID);

        Task<List<PolicyMembers>> GetPolicyMembers(string enterpriseID, int policyNum);

        Task<int> InsertPolicyMembers(PolicyMemberInsert policyMembersinsert);

        Task<List<PolicyHistory>> GetHistory(string enterpriseID, int policyNum, int historyID);



        Task <int> EditValueAddedService( PolicyValueAddedServiceInsert valueAddedServiceInsert);
        Task<int> DeleteValueAddedService(string enterpriseID, int policyNum, int addonID);

        Task<int> InsertValueAddedService(PolicyValueAddedServiceInsert policyValueAddedService);
        Task<List<PolicyValueAddedService>> GetValueAddedService(string enterpriseID, int policyNum);





        Task<List<PolicyClaim>> GetClaims(string enterpriseID, int policyNum);


        Task<int> InsertClaims(PolicyClaimsInsert policyClaimsInsert);



        Task<int> EditInvoice(PolicyInvoiceUpdate policyInvoiceUpdate);

        Task<int> DeleteInvoice(string enterpriseID, int policyNum, int invoiceNum);
        Task<int> InsertInvoice(PolicyInvoiceInsert policyInvoice);


        Task<List<PolicyInvoice>> GetInvoice(string enterpriseID, int policyNum);



        Task<int> EditPayments(string enterpriseID, int policyNum, int invoiceNum, PolicyPayments policyPayments);

        Task<int> DeletePayments(string enterpriseID, int policyNum, int invoiceNum);

        Task<List<PolicyPayments>> GetPayments(string enterpriseID, int policyNum, int invoiceNum);


        Task<int> InsertPayments(PolicyPaymentInsert policyPaymentInsert);


        Task<List<CombinedPolicyClaims>> GetCombinedPolicyClaims(string enterpriseID, int policyNum);   


    }
}
