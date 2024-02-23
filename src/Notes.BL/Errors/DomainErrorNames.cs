namespace Notes.BL.Errors
{
    public class DomainErrorNames
    {
        public const string BadRequest = "Bad Request";
        public const string NotFound = "Not Found";
    }

    public class DomainErrors
    {
        //not found errors
        public const string NOTE_NOT_FOUND = "Note was not found.";
        public static readonly Error NoteNotFoundError = new Error(DomainErrorNames.BadRequest, NOTE_NOT_FOUND);
    }
}
