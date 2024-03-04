using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PolicyHistory_API_using_Dapper.Models
{
    public class PolicyHistory
    {
        public PolicyHistory()
        {
            
        }

        [Required]
        public string StrEnterpriseID { get; set; }

        [Required]
        public int IntPolicyNum { get; set; }

        [Required]
        public int IntHistoryID { get; set; }

   
        public int IntPolStatusID { get; set; }
        public DateTime DatStartDate { get; set; }
        public DateTime DatEndDate { get; set; }
        public string StrStartDescr { get; set; }
        public string StrEndDescr { get; set; }
        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; }
        public string CurrentStatusYN { get; set; } 
    }
}