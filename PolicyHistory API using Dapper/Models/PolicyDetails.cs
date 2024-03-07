using System.ComponentModel.DataAnnotations;

namespace PolicyHistory_API_using_Dapper.Models
{
    public class PolicyDetails
    {
        public PolicyDetails()
        {
        }

        [Required] 
        public string StrEnterpriseID { get; set; }
        public int IntPolicyNum { get; set; }
        public int IntPlanID { get; set; }
        public string StrPlanBrandName { get; set; }
        public DateTime DatDateOpened { get; set; }
        public DateTime DatInceptionDate { get; set; }
        public DateTime DatDateClosed { get; set; }
        public bool BitTnCAcceptedYN { get; set; }
        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; }
        public string StrAgentID { get; set; }
        public decimal DecAgentCommRate { get; set; }
        public DateTime DatCommExpiryDate { get; set; }
        public string StrAgentNameID { get; set; }
    }
}
