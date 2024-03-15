namespace ConsumeAPI.Models
{
    public class PolicyMemberInsert
    {
        public string StrEnterpriseID { get; set; }
        public int IntPolicyNum { get; set; }
        public int IntProfileID { get; set; }
        public int IntMemberTypeID { get; set; }
        public decimal MonPremiumAmt { get; set; }
        public decimal MonCoverAmt { get; set; }
        public int IntRelationshipID { get; set; }
        public int IntAgeToday { get; set; }
        public int IntAgeYesterday { get; set; }
        public DateTime DatDateEnrolled { get; set; }
        public int IntBenProfileID { get; set; }
        public bool BitConsentRecvdYN { get; set; }
        public int IntBenRelationshipID { get; set; }
        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; }
        public bool BitRemovedYN { get; set; }
    }
}
