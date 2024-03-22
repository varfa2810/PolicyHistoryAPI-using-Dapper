namespace ConsumeAPI.Models
{
    public class PolicyMemberInsert
    {
        public string strEnterpriseID { get; set; }
        public int intPolicyNum { get; set; }
        public int intProfileID { get; set; }
      /*  public string StrMemberType { get; set; }   */
        public int intMemberTypeID { get; set; }
        public decimal monPremiumAmt { get; set; }
        public decimal monCoverAmt { get; set; }
        public int intRelationshipID { get; set; }
        public int intAgeToday { get; set; }
     /*   public int IntAgeYesterday { get; set; }*/
        public DateTime datDateEnrolled { get; set; }
        public int intBenProfileID { get; set; }
        public bool bitConsentRecvdYN { get; set; }
        public int intBenRelationshipID { get; set; }
       /* public string StrLastCapturer { get; set; }*/
     /*   public DateTime DatDateModified { get; set; }*/
       /* public bool BitRemovedYN { get; set; }*/
    }
}
