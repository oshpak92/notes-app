using Notes.Persistence.Entities;

namespace Notes.Persistence
{
    public interface INotesRepository
    {
        Task<int> AddNote(NoteEntity noteEntity);

        Task<IEnumerable<NoteEntity>> GetAllNotes();

        Task<NoteEntity?> GetNote(int id);

        Task DeleteNote(int id);
    }
}
