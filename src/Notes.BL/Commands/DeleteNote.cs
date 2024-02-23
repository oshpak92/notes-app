using CSharpFunctionalExtensions;
using MediatR;
using Notes.BL.Errors;
using Notes.Persistence;

namespace Notes.BL.Commands
{
    public class DeleteNote
    {
        public record Command(int Id) : IRequest<Result<Unit, Error>> { }

        public class Handler : IRequestHandler<Command, Result<Unit, Error>>
        {
            private readonly INotesRepository _notesRepository;

            public Handler(INotesRepository notesRepository)
            {
                _notesRepository = notesRepository;
            }

            public async Task<Result<Unit, Error>> Handle(Command request, CancellationToken cancellationToken)
            {
                await _notesRepository.DeleteNote(request.Id);

                return Unit.Value;
            }
        }
    }
}
