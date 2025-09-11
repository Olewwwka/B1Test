using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task2.Application.UseCases.Commands;
using Task2.Application.UseCases.Queries;

namespace Task2.API.Controllers
{
    /// <summary>
    /// Controller with main endpoints 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, CancellationToken cancellationToken)
        {
            var command = new UploadReportCommand(file);

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllReportsQuery();

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetReportByIdQuery(id);

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id:int}/export")]
        public async Task<IActionResult> Export(int id, CancellationToken cancellationToken)
        {
            var query = new ExportReportQuery(id);

            var result = await _mediator.Send(query, cancellationToken);

            return File(result,
                   "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                   $"Report_{id}.xlsx");
        }
    }
}
