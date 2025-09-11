using Microsoft.EntityFrameworkCore;
using Task2.Infrastructure;

namespace Task2.API.Extensions
{
    /// <summary>
    /// Class with extension methods 
    /// </summary>
    public static class DatabaseExtension
    {
        /// <summary>
        /// Extension method which add DbContext instance in DI container
        /// </summary>
        /// <param name="builder">WebApplicationBuiled</param>
        public static void AddDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<Task2DbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(Task2DbContext)));
            });
        }
    }
}
