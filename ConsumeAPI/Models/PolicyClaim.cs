using Humanizer.Localisation.TimeToClockNotation;

namespace ConsumeAPI.Models
{
    public class PolicyClaim
    {
      

      
        public DateTime? DatDeathDate { get; set; }

        public decimal MonClaimAmt { get; set; }
        public DateTime DatClaimDate { get; set; }
        public string StrClaimMethod { get; set; }
        public bool BitDeathCertReceived { get; set; }
        public string StrRefNum { get; set; }
        public bool BitApprovedYN { get; set; }
        public DateTime? DatPayOutDate { get; set; }



    }
}
