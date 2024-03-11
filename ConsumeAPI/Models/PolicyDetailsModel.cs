namespace ConsumeAPI.Models
{
    public class PolicyDetailsModel
    {

        public string StrEnterpriseID { get; set; }
        public int IntPolicyNum { get; set; }
       
        public string StrPlanBrandName { get; set; }

        public string StrAgentNameID { get; set; }

        public decimal DecAgentCommRate { get; set; }
        public DateTime DatDateOpened { get; set; }
        public DateTime DatInceptionDate { get; set; }
        public DateTime DatDateClosed { get; set; }
       
        public string StrAgentID { get; set; }
       
      
    }
}
