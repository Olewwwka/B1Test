using Task2.Application.UseCases.Commands;
using Task2.Domen.Abstractions;
using Task2.Infrastructure.Repositories;
using Task2.Infrastructure.Services;

namespace Task2.API.Extensions
{
    /// <summary>
    /// Class with extension methods 
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method which add all services in DI container
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IExcelService, ExcelService>();

            services.AddMediatR(m =>
                m.RegisterServicesFromAssembly(typeof(UploadReportCommand).Assembly));
        }
    }
}
