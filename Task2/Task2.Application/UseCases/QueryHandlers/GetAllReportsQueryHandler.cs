using MediatR;
using Task2.Application.UseCases.Queries;
using Task2.Domen.Abstractions;
using Task2.Domen.Models;

namespace Task2.Application.UseCases.QueryHandlers
{
    /// <summary>
    /// Class thats contains logic get all reports from database
    /// </summary>
    public class GetAllReportsQueryHandler : IRequestHandler<GetAllReportsQuery, List<Report>>
    {
        /// <summary>
        /// Repository with logic of working with reports from database
        /// </summary>
        private readonly IReportRepository _reportRepository;
        /// <summary>
        /// Constructor thats initialize new instance of handler with concrete repossitory
        /// </summary>
        /// <param name="reportRepository">Existing instance of repository</param>
        public GetAllReportsQueryHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        /// <summary>
        /// handler which returns all reports from database
        /// </summary>
        /// <param name="request">Request thats call this method</param>
        /// <param name="cancellationToken">Token to cancel operation</param>
        /// <returns>Collected reports</returns>
        public async Task<List<Report>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
        {
            var reports = await _reportRepository.GetAllAsync(cancellationToken);

            return reports;
        }
    }
}
