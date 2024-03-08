using System.ComponentModel.DataAnnotations;

namespace PolicyHistory_API_using_Dapper.Models
{
    public class PolicyAgentList
    {
        public PolicyAgentList()
        {
        }

        [Required]
        public string StrAgentID {  get; set; }

        public string StrAgentNameID { get; set; }

    }
}
