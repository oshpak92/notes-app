using System.ComponentModel.DataAnnotations;

namespace Notes.DTO.Requests
{
    public class CreateNoteRequest
    {
        [Required]
        public string? Title { get; set; }

        public string? Text { get; set; }
    }
}
