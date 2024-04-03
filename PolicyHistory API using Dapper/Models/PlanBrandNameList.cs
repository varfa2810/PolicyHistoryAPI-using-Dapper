using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace PolicyHistory_API_using_Dapper.Models
{
    public class PlanBrandNameList
    {
        public PlanBrandNameList() { }

        public int IntPlanID { get; set; }
        public string StrPlanBrandName { get; set; }    

    }
}
