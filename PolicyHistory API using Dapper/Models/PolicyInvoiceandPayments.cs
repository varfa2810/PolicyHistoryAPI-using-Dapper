using System.ComponentModel.DataAnnotations;

namespace PolicyHistory_API_using_Dapper.Models
{
    public class PolicyInvoiceandPayments
    {
        public PolicyInvoiceandPayments() { }



        [Required] 
        public string StrEnterpriseID { get; set; }

        [Required]
        public int IntPolicyNum { get; set; }

        [Required]
        public int IntInvoiceNum { get; set; }
        public int IntReceiptNum { get; set; }
        public decimal MonAmtPaid { get; set; }
        public DateTime DatDatePaid { get; set; }
        public string StrRefNum { get; set; }
        public int IntPayMethodID { get; set; }
        public int IntMonthID { get; set; }
        public string StrComment { get; set; }
        public int IntProviderID { get; set; }
        public string StrStatusCode { get; set; }
        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; }
        public int IntAltRowID { get; set; }

    }
}
