using System.ComponentModel.DataAnnotations;

namespace PolicyHistory_API_using_Dapper.Models
{
    public class PolicyValueAddedService
    {
        public PolicyValueAddedService()
        {
        }

        [Required]
        public string StrEnterpriseID { get; set; }

        [Required]
        public int IntPolicyNum { get; set; }


        [Required]
        public int IntAddOnID { get; set; }
        public string StrAddOnDescription { get; set; }
        public int IntAddOnQty { get; set; }
        public decimal MonAddOnPrice { get; set; }
        public decimal MonLineTotal { get; set; }
        public DateTime DatStartDate { get; set; }
        public DateTime DatEndDate { get; set; }
        public int IntAOStatusID { get; set; }
        public string StrAddOnStatus { get; set; }
        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; }
    }
}
