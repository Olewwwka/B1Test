using Task1.Generator;
using Task1.Generators;

public class Program
{
    public static void Main(string[] args)
    {
        var filesGenerator = new FilesGenerator();

        filesGenerator.GenerateFiles();
    }
}