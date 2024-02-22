using Notes.Persistance.Entities;

namespace Notes.Persistance
{
    public interface INotesRepository
    {
        Task<int> AddNote(NoteEntity noteEntity);

        Task<IEnumerable<NoteEntity>> GetAllNotes();

        Task DeleteNote(int id);
    }
}
