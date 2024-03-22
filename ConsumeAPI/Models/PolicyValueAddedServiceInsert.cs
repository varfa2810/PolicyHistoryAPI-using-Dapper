namespace ConsumeAPI.Models
{
    public class PolicyValueAddedServiceInsert
    {
        public string strEnterpriseID { get; set; }
        public int intPolicyNum { get; set; }
        public int intAddOnID { get; set; }
        public string strAddOnDescription { get; set; }
        public int intAddOnQty { get; set; }
        public decimal monAddOnPrice { get; set; }
        public DateTime datStartDate { get; set; }
        public DateTime datEndDate { get; set; }
        public int intAOStatusID { get; set; }
        public string strLastCapturer { get; set; }
        public DateTime datDateModified { get; set; }
    }
}
