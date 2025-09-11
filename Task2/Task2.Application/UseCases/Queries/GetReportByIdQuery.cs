using MediatR;
using Task2.Domen.Models;

namespace Task2.Application.UseCases.Queries
{
    /// <summary>
    /// Query to get report by id
    /// </summary>
    /// <param name="Id">Id of report</param>
    public record GetReportByIdQuery(int Id) : IRequest<Report>
    {
    }
}
