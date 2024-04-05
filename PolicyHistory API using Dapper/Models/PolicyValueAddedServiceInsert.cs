using System.ComponentModel.DataAnnotations;

namespace PolicyHistory_API_using_Dapper.Models
{
    public class PolicyValueAddedServiceInsert
    {

        public string StrEnterpriseID { get; set; }

        public int IntPolicyNum { get; set; }
        public int IntAddOnID { get; set; }

        public int IntAddOnQty { get; set; }
        public int MonAddOnPrice { get; set; }

        public DateTime DatStartDate { get; set; }
        public DateTime DatEndDate { get; set; }
        public int IntAOStatusID { get; set; }

        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; }
    }
}
