using Task1.Generator;
using Task1.Generators;
using Task1.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var filesGenerator = new FilesGenerator();

        filesGenerator.GenerateFiles();

        var mergeService = new MergeService();

        mergeService.MergeFiles("abc");
    }
}