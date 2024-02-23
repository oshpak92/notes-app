using CSharpFunctionalExtensions;
using MediatR;
using Notes.BL.Errors;
using Notes.Persistence;

namespace Notes.BL.Queries
{
    public class GetNotes
    {
        public record Query : IRequest<Result<Data, Error>>;

        public class Handler : IRequestHandler<Query, Result<Data, Error>>
        {
            private readonly INotesRepository _notesRepository;

            public Handler(INotesRepository notesRepository)
            {
                _notesRepository = notesRepository;
            }

            public async Task<Result<Data, Error>> Handle(Query request, CancellationToken cancellationToken)
            {
                var notes = await _notesRepository.GetAllNotes();

                return new Data(notes
                    .Select(x => new Models.Note(x.Id, x.Title, x.Text, x.ModifiedDate, x.CreatedDate))
                    .ToList(),
                    notes.Count());
            }
        }

        public record Data(IList<Models.Note>? Notes, int Count);
    }
}
