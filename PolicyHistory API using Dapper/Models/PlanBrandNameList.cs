using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace PolicyHistory_API_using_Dapper.Models
{
    public class PlanBrandNameList
    {
        public PlanBrandNameList() { }

        [Required]
        public string StrEnterpriseId { get; set; }
        public string StrPlanBrandName { get; set; }    

    }
}
