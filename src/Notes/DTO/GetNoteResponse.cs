namespace Notes.DTO
{
    public record GetNoteResponse(int Id, string? Title, string? Text, DateTime CreatedDate, DateTime ModifiedDate);
}
