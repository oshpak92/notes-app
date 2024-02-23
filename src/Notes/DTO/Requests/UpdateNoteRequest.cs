using System.ComponentModel.DataAnnotations;

namespace Notes.DTO.Requests
{
    public class UpdateNoteRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Text { get; set; }
    }
}
