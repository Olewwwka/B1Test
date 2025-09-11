using MediatR;

namespace Task2.Application.UseCases.Queries
{
    /// <summary>
    /// Query to save data from database in excel file
    /// </summary>
    /// <param name="reportId">Id of report to save</param>
    public record ExportReportQuery(int reportId) : IRequest<byte[]>
    {
    }
}
