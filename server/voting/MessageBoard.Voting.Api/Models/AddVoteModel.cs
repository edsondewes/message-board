using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Voting.Api.Models
{
    public class AddVoteModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field 'optionName' is required")]
        public string OptionName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Field 'subjectId' is required")]
        public string SubjectId { get; set; }
    }
}
