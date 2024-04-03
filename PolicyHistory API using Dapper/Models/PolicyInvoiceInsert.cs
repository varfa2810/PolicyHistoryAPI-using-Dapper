using System.ComponentModel.DataAnnotations;

namespace PolicyHistory_API_using_Dapper.Models
{
    public class PolicyInvoiceInsert
    {
        
        public string StrEnterpriseID { get; set; }

     
        public int IntPolicyNum { get; set; }

        
       
        public DateTime DatInvoiceDate { get; set; }
        public decimal MonInvoiceTotal { get; set; }
        public DateTime DatDueByDate { get; set; }
        public int IntPurposeID { get; set; }
       
        public int IntYearID { get; set; }
        public int IntMonthID { get; set; }
        public DateTime DatDateModified { get; set; }
        public string StrLastCapturer { get; set; }
       
        
    }
}
