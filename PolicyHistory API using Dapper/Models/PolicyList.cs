using System.ComponentModel.DataAnnotations;

namespace PolicyHistory_API_using_Dapper.Models
{
    public class PolicyList
    {
        public PolicyList()
        {
        }

        [Required]
        public int StrEnterpriseID { get; set; }

        [Required]
        public int IntPolicyNum { get; set; }
       public int IntPlanID { get; set; }
        public string StrPlanBrandName { get; set; }
        public DateTime DatDateOpened { get; set; }
        public DateTime DatInceptionDate { get; set; }

        public DateTime DatDateClosed { get; set; }
        public bool BitTnCAcceptedYN { get; set; }
        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; }

        public string StrInsurerName { get; set; }
        public string StrAgentID { get; set; }
        public string StrAgentName { get; set; }
        public decimal MonPremiumBal { get; set; }

        public string StrIDPPNum { get; set; }
        public int IntProfileID { get; set; }
        public string StrMainMemberName { get; set; }
        public int IntMembersOnPolicy { get; set; }
        public string StrPolicyStatus_Current { get; set; }



    }
}
