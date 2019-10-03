using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Messaging.Api.Models
{
    public class CreateMessageModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field 'text' is required")]
        [MaxLength(250, ErrorMessage = "Text max length is 250 characteres")]
        public string Text { get; set; } = null!;
    }
}
