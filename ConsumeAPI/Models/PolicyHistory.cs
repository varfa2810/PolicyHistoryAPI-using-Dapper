using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ConsumeAPI.Models
{
    public class PolicyHistory : PageModel

    {
        public PolicyHistory()
        {

        }
        public string Message { get; set; }

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



        public void OnGet()
        {

            
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = new WebClient().DownloadString("https://raw.githubusercontent.com/aspsnippets/test/master/Customers.json");
            this.Message = json;
        }
    }
}
