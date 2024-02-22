using CSharpFunctionalExtensions;
using MediatR;
using Notes.BL.Errors;
using Notes.Persistance;

namespace Notes.BL.Queries
{
    public class GetNotes
    {
        public class Query : IRequest<Result<Data, Error>>
        {
        }

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

                return new Data()
                {
                    Notes = notes.Select(x => new Models.Note()
                    {
                        Id = x.Id,
                        Text = x.Text,
                        Title = x.Title,
                        ModifiedDate = x.ModifiedDate,
                        CreatedDate = x.CreatedDate,
                    }).ToList(),
                    Count = notes.Count()
                };
            }
        }

        public class Data
        {
            public IList<Models.Note>? Notes { get; set; }
            public int Count { get; set; }
        }
    }
}
