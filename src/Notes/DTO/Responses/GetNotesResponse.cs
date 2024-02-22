namespace Notes.DTO.Responses
{
    public class GetNotesResponse
    {
        public List<GetNoteResponse> Notes { get; set; }
        public int Count { get; set; }
    }
}
