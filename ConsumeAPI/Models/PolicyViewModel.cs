using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsumeAPI.Models
{
    public class PolicyViewModel
    {

        
        [DisplayName("EnterpriseID")]
        public string StrEnterpriseID { get; set; }

        [DisplayName("PolicyNum")]
        public int IntPolicyNum { get; set; }

        [DisplayName("HistoryID")]
        public int IntHistoryID { get; set; }

        [DisplayName("PolicyStatusID")]
        public int IntPolStatusID { get; set; }

        [DisplayName("StartDate")]
        public DateTime DatStartDate { get; set; }

        [DisplayName("EndDate")]
        public DateTime DatEndDate { get; set; }

        [DisplayName("StartDescription")]
        public string StrStartDescr { get; set; }

        [DisplayName("EndDescription")]
        public string StrEndDescr { get; set; }

        [DisplayName("EnterpriseID")]
        public string StrLastCapturer { get; set; }

        [DisplayName("DateModified")]
        public DateTime DatDateModified { get; set; }

        [DisplayName("CurrentStatus")]
        public string CurrentStatusYN { get; set; }
    }
}
