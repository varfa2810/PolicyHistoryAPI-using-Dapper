namespace ConsumeAPI.Models
{
    public class PolicyHistoryModel
    {
        public PolicyHistoryModel()
        {
        }

       /* public int StrEnterpriseID { get; set; }
        public int IntPolicyNum { get; set; }
        public int IntHistoryID { get; set; }*/
        public string StrPolicyStatus { get; set; }
        public DateTime DatStartDate { get; set; }
        public string StrStartDescr { get; set; }
        public DateTime DatEndDate { get; set; }
        public string StrEndDescr { get; set; }
        public string CurrentStatusYN { get; set; }
    }
}
