namespace Common.System
{
    public class WebServiceError
    {
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? Message { get; set; }
        public Dictionary<string, string[]>? Details { get; set; }
    }
}
