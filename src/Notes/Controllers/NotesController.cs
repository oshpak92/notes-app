using Common.System;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Notes.BL.Commands;
using Notes.BL.Queries;
using Notes.DTO;
using Notes.DTO.Requests;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(WebServiceError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateNote([FromBody] CreateNoteRequest request)
        {
            return this.Result(await _mediator.Send(new CreateNote.Command() { Text = request.Text, Title = request.Title }));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(WebServiceError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteNote([FromRoute] int id)
        {
            return this.Result(await _mediator.Send(new DeleteNote.Command() { Id = id}));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(WebServiceError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<GetNoteResponse>>> GetNotes()
        {
            var result = await _mediator.Send(new GetNotes.Query());

            return this.Result(
                result.Map(
                    r => r.Notes.Select(x => new GetNoteResponse()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Text = x.Text,
                        CreatedDate = x.CreatedDate,
                        ModifiedDate = x.ModifiedDate
                    }).ToList()));
        }
    }
}
