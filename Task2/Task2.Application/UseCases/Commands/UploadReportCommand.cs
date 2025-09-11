using MediatR;
using Microsoft.AspNetCore.Http;
using Task2.Domen.Models;

namespace Task2.Application.UseCases.Commands
{
    /// <summary>
    /// Command for mediator to save excel data in database
    /// </summary>
    /// <param name="File"></param>
    public record UploadReportCommand(IFormFile File) : IRequest<Report> { }
}
