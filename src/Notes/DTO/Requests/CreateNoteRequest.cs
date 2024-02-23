using System.ComponentModel.DataAnnotations;

namespace Notes.DTO.Requests
{
    public record CreateNoteRequest([Required] string? Title, [Required] string? Text);
}
