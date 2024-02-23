using Common.System;
using CSharpFunctionalExtensions;
using MediatR;
using Notes.BL.Errors;
using Notes.Persistence;
using Notes.Persistence.Entities;

namespace Notes.BL.Commands
{
    public class CreateNote
    {
        public record Command(string? Title, string? Text) : IRequest<Result<int, Error>> { }

        public class Handler : IRequestHandler<Command, Result<int, Error>>
        {
            private readonly INotesRepository _notesRepository;
            private readonly IDateTimeProvider _dateTimeProvider;

            public Handler(
                INotesRepository notesRepository,
                IDateTimeProvider dateTimeProvider)
            {
                _notesRepository = notesRepository;
                _dateTimeProvider = dateTimeProvider;
            }

            public async Task<Result<int, Error>> Handle(Command request, CancellationToken cancellationToken)
            {
                var note = new NoteEntity()
                {
                    Title = request.Title,
                    Text = request.Text,
                    CreatedDate = _dateTimeProvider.UtcNow(),
                    ModifiedDate = _dateTimeProvider.UtcNow()
                };

                return await _notesRepository.AddNote(note);
            }
        }
    }
}
