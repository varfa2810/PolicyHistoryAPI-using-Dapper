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
    }
}
