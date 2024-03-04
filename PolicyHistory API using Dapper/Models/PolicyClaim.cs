using System.ComponentModel.DataAnnotations;

namespace PolicyHistory_API_using_Dapper.Models
{
    public class PolicyClaim
    {
        public PolicyClaim() { }

        [Required]
        public string StrEnterpriseID { get; set; }

        [Required]
        public int IntPolicyNum { get; set; }
        public int IntProfileID { get; set; }
        public int IntMemberTypeID { get; set; }
        public DateTime DatClaimDate { get; set; }
        public decimal MonClaimAmt { get; set; }
        public int IntClaimMethodID { get; set; }
        public int IntDeathCauseID { get; set; }
        public DateTime? DatDeathDate { get; set; }
        public bool BitDeathCertReceived { get; set; }
        public string StrRefNum { get; set; }
        public bool BitApprovedYN { get; set; }
        public DateTime? DatPayOutDate { get; set; }
        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; }

    }
}
