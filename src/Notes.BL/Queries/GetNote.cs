using CSharpFunctionalExtensions;
using MediatR;
using Notes.BL.Errors;
using Notes.BL.Models;
using Notes.Persistance;

namespace Notes.BL.Queries
{
    public class GetNote
    {
        public class Query : IRequest<Result<Note, Error>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Note, Error>>
        {
            private readonly INotesRepository _notesRepository;

            public Handler(INotesRepository notesRepository)
            {
                _notesRepository = notesRepository;
            }

            public async Task<Result<Note, Error>> Handle(Query request, CancellationToken cancellationToken)
            {
                var note = await _notesRepository.GetNote(request.Id);
                if (note == null)
                    return DomainErrors.NoteNotFoundError;

                return new Note()
                {
                    Id = note.Id,
                    Title = note.Title,
                    Text = note.Text,
                    ModifiedDate = note.ModifiedDate,
                    CreatedDate = DateTime.UtcNow,
                };
            }
        }
    }
}
