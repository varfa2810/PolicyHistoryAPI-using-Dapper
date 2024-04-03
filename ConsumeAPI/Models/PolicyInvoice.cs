namespace ConsumeAPI.Models
{
    public class PolicyInvoice
    {
        public PolicyInvoice()
        {
        }

        public string StrEnterpriseID { get; set; }

        
        public int IntPolicyNum { get; set; }

        
        public int IntInvoiceNum { get; set; }
        public DateTime DatInvoiceDate { get; set; }
        public decimal MonInvoiceTotal { get; set; }
        public DateTime DatDueByDate { get; set; }
        public int IntPurposeID { get; set; }
        public string StrPurpose { get; set; }
        public int IntYearID { get; set; }
        public int IntMonthID { get; set; }
        public string StrLastCapturer { get; set; }
        public DateTime DatDateModified { get; set; }
        public int IntAltRowID { get; set; }
        public string StrCurrentStatus { get; set; }

    }
}
