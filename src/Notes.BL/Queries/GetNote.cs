using Common.System;
using CSharpFunctionalExtensions;
using MediatR;
using Notes.BL.Errors;
using Notes.BL.Models;
using Notes.Persistence;

namespace Notes.BL.Queries
{
    public class GetNote
    {
        public record Query(int Id) : IRequest<Result<Note, Error>> { }

        public class Handler : IRequestHandler<Query, Result<Note, Error>>
        {
            private readonly INotesRepository _notesRepository;
            private readonly IDateTimeProvider _dateTimeProvider;

            public Handler(INotesRepository notesRepository, IDateTimeProvider dateTimeProvider)
            {
                _notesRepository = notesRepository;
                _dateTimeProvider = dateTimeProvider;
            }

            public async Task<Result<Note, Error>> Handle(Query request, CancellationToken cancellationToken)
            {
                var note = await _notesRepository.GetNote(request.Id);
                if (note == null)
                    return DomainErrors.NoteNotFoundError;

                return new Note(note.Id, note.Title, note.Text, note.ModifiedDate, _dateTimeProvider.UtcNow());
            }
        }
    }
}
