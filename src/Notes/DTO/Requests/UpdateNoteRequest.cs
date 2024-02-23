using System.ComponentModel.DataAnnotations;

namespace Notes.DTO.Requests
{
    public record UpdateNoteRequest([Required] int Id, [Required] string? Title, [Required] string? Text);
}
