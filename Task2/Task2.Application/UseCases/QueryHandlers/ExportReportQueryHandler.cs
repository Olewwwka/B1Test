using MediatR;
using Task2.Application.UseCases.Queries;
using Task2.Domen.Abstractions;

namespace Task2.Application.UseCases.QueryHandlers
{
    /// <summary>
    /// Class thats contains logic to export data to excel file from database
    /// </summary>
    public class ExportReportQueryHandler : IRequestHandler<ExportReportQuery, byte[]>
    {
        /// <summary>
        /// Instance of service to working with excel files
        /// </summary>
        private readonly IExcelService _excelService;
        /// <summary>
        /// Constructor thats initialize new instance of handler with concrete Excel service
        /// </summary>
        /// <param name="excelService">Service to parsing excel</param>
        public ExportReportQueryHandler(IExcelService excelService)
        {
            _excelService = excelService;
        }
        /// <summary>
        /// Handler thats exports data to excel file
        /// </summary>
        /// <param name="request">request with id of report</param>
        /// <param name="cancellationToken">token to cancell operations</param>
        /// <returns>saved data</returns>
        public async Task<byte[]> Handle(ExportReportQuery request, CancellationToken cancellationToken)
        {
            var stream = await _excelService.ExportReportAsync(request.reportId, cancellationToken);

            return stream.ToArray();

        }
    }
}
