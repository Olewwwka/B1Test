using Task2.Domen.Models;

namespace Task2.Domen.Abstractions
{
    /// <summary>
    /// Interface which provides methods to Excel service
    /// </summary>
    public interface IExcelService
    {
        /// <summary>
        /// method which parse data from excel file and save it in database
        /// </summary>
        /// <param name="excelStream">Stream to excel file</param>
        /// <param name="cancellationToken">Token to cancel operation</param>
        /// <returns>Saves report</returns>
        Task<Report> ParseReportAsync(Stream excelStream, CancellationToken cancellationToken);
        Task<MemoryStream> ExportReportAsync(int reportId, CancellationToken cancellationToken);
    }
}
