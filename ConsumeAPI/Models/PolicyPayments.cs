namespace ConsumeAPI.Models
{
    public class PolicyPayments
    {
        public string StrEnterpriseID { get; set; }
        public int IntPolicyNum { get; set; }
        public int IntInvoiceNum { get; set; }
        public int IntReceiptNum { get; set; }
        public decimal MonAmtPaid { get; set; }
        public string DatDatePaid { get; set; }
        public string StrRefNum { get; set; }
        public int IntPayMethodID { get; set; }
        public string StrPayMenthod { get; set; }
        public int IntMonthID { get; set; }
        public string StrMonth { get; set; }
        public string StrComment { get; set; }
        public int IntProviderID { get; set; }
        public string StrProvider { get; set; }
        public string StrStatusCode { get; set; }
        public string StrPGResult { get; set; }
        public string StrLastCapturer { get; set; }
        public string DatDateModified { get; set; }
        public int IntAltRowID { get; set; }
    }
}
