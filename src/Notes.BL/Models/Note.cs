namespace Notes.BL.Models
{
    public record Note(int Id, string? Title, string? Text, DateTime CreatedDate, DateTime ModifiedDate);
}
