using Task1.Generator;
using System.Text;

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
            for (int i = 0; i < FilesConstants.CountOfFiles; i++)
            {
                var stringBuiler = new StringBuilder();

                string path = Path.Combine(FilesConstants.DirectoryName, $"file{i:00}.txt");

                using var writer = new StreamWriter(path);

                for (int j = 0; j < FilesConstants.CountOfLines; j++)
                {
                    stringBuiler.AppendLine(_generator.GetString());

                    if ((j + 1) % FilesConstants.BufferSize == 0)
                    {
                        writer.Write(stringBuiler.ToString());
                        stringBuiler.Clear();
                    }
                }

                if (stringBuiler.Length > 0)
                {
                    writer.Write(stringBuiler.ToString());
                }

                Console.WriteLine("File created: " + path);
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
