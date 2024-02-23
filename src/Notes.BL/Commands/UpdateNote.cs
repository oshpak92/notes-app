using Common.System;
using CSharpFunctionalExtensions;
using MediatR;
using Notes.BL.Errors;
using Notes.Persistence;

namespace Notes.BL.Commands
{
    public class UpdateNote
    {
        public record Command(int Id, string? Title, string? Text) : IRequest<Result<Unit, Error>> { }

        public class Handler : IRequestHandler<Command, Result<Unit, Error>>
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

            public async Task<Result<Unit, Error>> Handle(Command request, CancellationToken cancellationToken)
            {
                var noteEntity = await _notesRepository.GetNote(request.Id);
                if (noteEntity == null)
                    return DomainErrors.NoteNotFoundError;

                noteEntity.Title = request.Title;
                noteEntity.Text = request.Text;
                noteEntity.ModifiedDate = _dateTimeProvider.UtcNow();

                return Unit.Value;
            }
        }
    }
}
