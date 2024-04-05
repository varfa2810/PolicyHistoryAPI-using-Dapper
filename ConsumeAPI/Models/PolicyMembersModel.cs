namespace ConsumeAPI.Models
{
    public class PolicyMembersModel
    {
        public string StrEnterpriseID { get; set; }
        public int IntPolicyNum { get; set; }
        public int IntProfileID { get; set; }
        public int IntMemberTypeID { get; set; }
        public string StrMemberType { get; set; }
        public string StrIDPPNum { get; set; }
        public string StrMemberName { get; set; }
        public DateTime DatBirthDate { get; set; }
        public int IntRelationshipID { get; set; }
        public int IntAge_Calc { get; set; }
        public int IntAgeToday { get; set; }
        public int IntAgeYesterday { get; set; }
        public decimal MonPremiumAmt { get; set; }
        public decimal MonCoverAmt { get; set; }
        public DateTime DatDateEnrolled { get; set; }
        public string CoverStatus { get; set; }
        public string StrRelationshipToMainMember { get; set; }
        public int IntBenProfileID { get; set; }
        public string StrBeneficiaryNameID { get; set; }
        public int IntBenRelationshipID { get; set; }
        public string StrBenRelationshipToPolMember { get; set; }
        public bool BitConsentRecvdYN { get; set; }
        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; }
        public bool BitRemovedYN { get; set; }



    }
}
