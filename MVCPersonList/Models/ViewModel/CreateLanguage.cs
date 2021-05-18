using System.ComponentModel.DataAnnotations;

namespace MVCPersonList.Models.ViewModel
{
    public class CreateLanguage
    {

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        public CreateLanguage()             // Model binding in controller need a Zero constructor to be present 
        {

        }
    }
}