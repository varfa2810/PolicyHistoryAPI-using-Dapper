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


        [Required(ErrorMessage = "Select Plan Brand")]
        public string? StrPlanBrandName { get; set; }

        public string StrAgentNameID { get; set; }

        public decimal DecAgentCommRate { get; set; }

        public DateTime DatDateOpened { get; set; } 

        [Required(ErrorMessage = "The Inception Date field is required.")]
        [DataType(DataType.Date)]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "The Inception Date field must be in the format yyyy-MM-dd.")]
        public DateTime DatInceptionDate { get; set; }



        [Required(ErrorMessage = "The Date closed field is required.")]
        [DataType(DataType.Date)]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "The Date close field must be in the format yyyy-MM-dd.")]
        public DateTime? DatDateClosed { get; set; }


        public string StrAgentID { get; set; }


        public int IntMemberTypeID { get; set; }
        public string StrMemberType { get; set; }


        public int IntRelationshipId { get; set; }
        public string StrRelationship { get; set; }


/*        FOR IDPP NUMBER LIST*/
        public int IntProfileID { get; set; }
        public string StrName { get; set; }
        public string StrIDPPNum { get; set; }




        public DateTime DatBirthDate { get; set; }
        public int IntAge_Calc { get; set; }
        public int MonPremiumAmt { get; set; }
        public int MonCoverAmt { get; set; }
    }

}
