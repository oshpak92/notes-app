using Notes.Persistance.Entities;

namespace Notes.Persistance
{
    public class NotesRepository : INotesRepository
    {
        private readonly List<NoteEntity> _notesStore;

        public NotesRepository(List<NoteEntity> store)
        {
            _notesStore = store;
        }

        public Task<int> AddNote(NoteEntity noteEntity)
        {
            noteEntity.Id = _notesStore.Select(x => x.Id)
                .DefaultIfEmpty()
                .Max() + 1;
            _notesStore.Add(noteEntity);

            return Task.FromResult(noteEntity.Id);
        }

        public Task DeleteNote(int id)
        {
            var itemToRemove = _notesStore.FirstOrDefault(x => x.Id == id);
            if (itemToRemove != null)
            {
                _notesStore.Remove(itemToRemove);
            }

            return Task.CompletedTask;
        }

        public Task<IEnumerable<NoteEntity>> GetAllNotes()
        {
            return Task.FromResult(_notesStore.AsEnumerable());
        }
    }
}
