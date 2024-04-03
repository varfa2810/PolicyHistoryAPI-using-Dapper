using Humanizer.Localisation.TimeToClockNotation;

namespace ConsumeAPI.Models
{
    public class PolicyClaim
    {
        public PolicyClaim()
        {
        }

        public string StrEnterpriseID { get; set; }
        public int IntPolicyNum { get; set; }
        public int IntProfileID { get; set; }
       
       
       
       
        public DateTime DatClaimDate { get; set; }
        public decimal MonClaimAmt { get; set; }
        public int IntClaimMethodID { get; set; }
        public string StrClaimMethod { get; set; }
        public int IntDeathCauseID { get; set; }
        public string StrDeathCause { get; set; }
        public DateTime DatDeathDate { get; set; }
        public bool BitDeathCertReceived { get; set; }
        public string StrRefNum { get; set; }
        public bool BitApprovedYN { get; set; }
        public DateTime DatPayOutDate { get; set; }
        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; }
        public string? CoverStatus { get; set; }


    }
}
