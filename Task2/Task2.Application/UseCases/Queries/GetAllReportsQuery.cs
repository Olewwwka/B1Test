using MediatR;
using Task2.Domen.Models;

namespace Task2.Application.UseCases.Queries
{
    /// <summary>
    /// Query to get all saved reports
    /// </summary>
    public record GetAllReportsQuery : IRequest<List<Report>>
    {
    }
}
