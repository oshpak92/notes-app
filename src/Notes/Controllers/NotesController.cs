using Common.System;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Notes.BL.Commands;
using Notes.BL.Queries;
using Notes.DTO;
using Notes.DTO.Requests;
using Notes.DTO.Responses;
using Notes.Extensions;

namespace Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AdminCorsPolicy")]
    public class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private readonly IMediator _mediator;

        public NotesController(ILogger<NotesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UpdateNoteResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(WebServiceError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdateNoteResponse>> UpdateNote([FromBody] UpdateNoteRequest request)
        {
            var result = await _mediator.Send(new UpdateNote.Command(request.Id, request.Title, request.Text));

            return this.Result(result.Map(r => new UpdateNoteResponse(request.Id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CreateNoteResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(WebServiceError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateNoteResponse>> CreateNote([FromBody] CreateNoteRequest request)
        {
            var result = await _mediator.Send(new CreateNote.Command(request.Title, request.Text));

            return this.Result(result.Map(x => new CreateNoteResponse(x)));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(WebServiceError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteNote([FromRoute] int id)
        {
            return this.Result(await _mediator.Send(new DeleteNote.Command(id)));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<GetNoteResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(WebServiceError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<GetNoteResponse>>> GetNotes()
        {
            var result = await _mediator.Send(new GetNotes.Query());

            return this.Result(
                result.Map(r 
                    => r.Notes!.Select(x 
                        => new GetNoteResponse(x.Id, x.Title, x.Text, x.CreatedDate, x.ModifiedDate)).ToList()));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(WebServiceError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<GetNoteResponse>>> GetNote([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetNote.Query(id));

            return this.Result(
                result.Map(r
                    => new GetNoteResponse(r.Id, r.Title, r.Text, r.CreatedDate, r.ModifiedDate)));
        }
    }
}
