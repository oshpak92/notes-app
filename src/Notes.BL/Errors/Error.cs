namespace Notes.BL.Errors
{
    public class Error
    {
        public Error(string name, string message)
        {
            Name = name;
            Message = message;
        }

        public string? Name { get; set; }
        public string? Message { get; set; }
    }
}
