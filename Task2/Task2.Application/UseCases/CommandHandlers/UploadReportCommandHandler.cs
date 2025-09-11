using MediatR;
using Task2.Application.UseCases.Commands;
using Task2.Domen.Abstractions;
using Task2.Domen.Models;

namespace Task2.Application.UseCases.CommandHandlers
{
    /// <summary>
    /// Handler of UploadReport Command
    /// </summary>
    public class UploadReportCommandHandler : IRequestHandler<UploadReportCommand, Report>
    {
        /// <summary>
        /// Instance of service to working with excel files
        /// </summary>
        private readonly IExcelService _excelService;
        /// <summary>
        /// Constructor thats initialize new instance of handler with concrete Excel service
        /// </summary>
        /// <param name="excelService">Service to parsing excel</param>
        public UploadReportCommandHandler(IExcelService excelService)
        {
            _excelService = excelService;
        }
        /// <summary>
        /// Handler to process UploadReport Command and saving data in database
        /// </summary>
        /// <param name="request">Contains Excel file to saving in database</param>
        /// <param name="cancellationToken">Token to cancel the operation</param>
        /// <returns>Saved report</returns>
        /// <exception cref="ArgumentException">Throws if file invalid</exception>
        public async Task<Report> Handle(UploadReportCommand request, CancellationToken cancellationToken)
        {
            if (request.File == null || request.File.Length == 0)
            {
                throw new ArgumentException("Invalid file");
            }

            using var stream = request.File.OpenReadStream();

            var report = await _excelService.ParseReportAsync(stream, cancellationToken);

            return report;
        }
    }
}
