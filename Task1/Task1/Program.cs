using Task1;
using Task1.Generators;
using Task1.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static async Task Main(string[] args)
    {
        using var dbContext = new Task1Context();
        dbContext.Database.Migrate();

        while (true)
        {
            Console.WriteLine("1 - Generate files");
            Console.WriteLine("2 - Merge files");
            Console.WriteLine("3 - Import file");
            Console.WriteLine("4 - Get statistics");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var filesGenerator = new FilesGenerator();

                    filesGenerator.GenerateFiles();

                    break;

                case "2":
                    var mergeService = new MergeService();

                    Console.Write("Input pattern(ex: abc)");
                    var pattern = Console.ReadLine();

                    mergeService.MergeFiles(pattern);

                    break;

                case "3":
                    var importService = new ImportService(dbContext);

                    Console.Write("File name: ");
                    var fileName = Console.ReadLine();

                    fileName = string.IsNullOrEmpty(fileName) ? FilesConstants.MergedFileName : fileName;

                    await importService.ImportFileAsync(fileName);

                    break;

                case "4":
                    var statsService = new StatisticsService(dbContext);
                    await statsService.GetStatistics();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
