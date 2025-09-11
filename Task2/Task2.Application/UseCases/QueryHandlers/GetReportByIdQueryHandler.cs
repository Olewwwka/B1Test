using MediatR;
using Task2.Application.UseCases.Queries;
using Task2.Domen.Abstractions;
using Task2.Domen.Models;

namespace Task2.Application.UseCases.QueryHandlers
{
    /// <summary>
    /// Handler which can return report from database by id
    /// </summary>
    public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, Report>
    {
        /// <summary>
        /// Repository with logic of working with reports from database
        /// </summary>
        private readonly IReportRepository _reportRepository;
        /// <summary>
        /// Constructor thats initialize new instance of handler with concrete repossitory
        /// </summary>
        /// <param name="reportRepository">Existing instance of repository</param>
        public GetReportByIdQueryHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        /// <summary>
        /// handler which returns report by id from database
        /// </summary>
        /// <param name="request">Request thats call this method with id of report</param>
        /// <param name="cancellationToken">Token to cancel operation</param>
        /// <returns>Collected report</returns>
        public async Task<Report> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
        {
            var report = await _reportRepository.GetByIdAsync(request.Id, cancellationToken);

            if(report is null)
            {
                throw new Exception($"Report with id {request.Id} not found");
            }

            return report;
        }

    }
}
