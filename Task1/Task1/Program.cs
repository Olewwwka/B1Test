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

        var filesGenerator = new FilesGenerator();

        filesGenerator.GenerateFiles();

        var mergeService = new MergeService();

        mergeService.MergeFiles("abc");

        var importService = new ImportService(dbContext);

        await importService.ImportFileAsync(FilesConstants.MergedFileName);
    }
}