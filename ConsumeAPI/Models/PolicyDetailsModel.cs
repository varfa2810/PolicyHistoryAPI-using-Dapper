using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsumeAPI.Models
{
    public class PolicyDetailsModel
    {
        public string StrEnterpriseID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Policy Number")]
        [Range(1, 3, ErrorMessage = "Enter a valid Policy Number")]
        public int IntPolicyNum { get; set; }

        public string StrPlanBrandName { get; set; }

        public string StrAgentNameID { get; set; }

        public decimal DecAgentCommRate { get; set; }

        public DateTime DatDateOpened { get; set; } 

        [Required(ErrorMessage = "The Inception Date field is required.")]
        [DataType(DataType.Date)]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "The Inception Date field must be in the format yyyy-MM-dd.")]
        public DateTime DatInceptionDate { get; set; }

        public DateTime DatDateClosed { get; set; }

        public string StrAgentID { get; set; }
    }

}
