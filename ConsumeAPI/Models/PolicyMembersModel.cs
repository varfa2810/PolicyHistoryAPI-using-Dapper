namespace ConsumeAPI.Models
{
    public class PolicyMembersModel
    {
        public int IntMemberTypeID { get; set; }
        public string StrIDPPNum { get; set; }
        public string StrMemberName { get; set; }
        public DateTime DatBirthDate { get; set; }

        public int IntAgeToday { get; set; }
        public decimal MonPremiumAmt { get; set; }

        public decimal MonCoverAmt { get; set; }




        public DateTime DatDateEnrolled { get; set; }
        public string CoverStatus { get; set; }
        public string StrRelationshipToMainMember { get; set; }
        public string StrBeneficiaryNameID { get; set; }
        public string StrBenRelationshipToPolMember { get; set; }
        public bool BitConsentRecvdYN { get; set; }
    }
}
