using Task1.Generator;

namespace Task1.Generators
{
    public class FilesGenerator
    {
        private StringGenerator _generator { get; set; }

        public FilesGenerator()
        {
            var generatorOfVariables = new GeneratorOfVariables();
            _generator = new(generatorOfVariables);

            CheckDirectory();
        }

        public void GenerateFiles()
        {
            for(int i = 0; i < FilesConstants.CountOfFiles; i++)
            {
                string path = Path.Combine(FilesConstants.DirectoryName, $"file{i:00}.txt");

                using var writer = new StreamWriter(path);

                for(int j = 0; j < FilesConstants.CountOfLines; j++)
                {
                    writer.WriteLine(_generator.GetString());
                }

                Console.WriteLine(path + " success");
            }
        }

        private void CheckDirectory()
        {
            if (Directory.Exists(FilesConstants.DirectoryName))
            {
                Directory.Delete(FilesConstants.DirectoryName, recursive: true);
            }

            Directory.CreateDirectory(FilesConstants.DirectoryName);
        }
    }
}
