namespace PolicyHistory_API_using_Dapper.Models
{
    public class PolicyPaymentInsert
    {
        public string StrEnterpriseID { get; set; }
        public int IntPolicyNum { get; set; }
        public int IntInvoiceNum { get; set; }
        public decimal MonAmtPaid { get; set; }
        public DateTime DatDatePaid { get; set; } // Assuming this is a string for date format 'yyyyMMdd'
        public string StrRefNum { get; set; }
        public int IntPayMethodID { get; set; }
        public int IntMonthID { get; set; }
        public string StrComment { get; set; }
        public int IntProviderID { get; set; }
        public string StrStatusCode { get; set; }
        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; } 

      
       

    }
}
