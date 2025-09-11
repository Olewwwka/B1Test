using Task2.Domen.Models;

namespace Task2.Domen.Abstractions
{
    /// <summary>
    /// Contains methods to working with reports in database
    /// </summary>
    public interface IReportRepository
    {
        /// <summary>
        /// Add new report in database
        /// </summary>
        /// <param name="report">Report to save</param>
        /// <param name="cancellationToken">Token to cancel operation</param>
        /// <returns>Id of saved report</returns>
        Task<int> AddAsync(Report report, CancellationToken cancellationToken);
        /// <summary>
        /// Get all exising reports from database
        /// </summary>
        /// <param name="cancellationToken">Token to cancel operation</param>
        /// <returns>All collected reports</returns>
        Task<List<Report>> GetAllAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Get existing report by id
        /// </summary>
        /// <param name="id">id of report</param>
        /// <param name="cancellationToken">Token to cancel operation</param>
        /// <returns>Collected report</returns>
        Task<Report> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
