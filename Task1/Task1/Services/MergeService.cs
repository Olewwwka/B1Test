using System.Text;

namespace Task1.Services
{
    public class MergeService
    {
        private readonly string _mergedPath;

        public MergeService()
        {
            _mergedPath = Path.Combine(FilesConstants.DirectoryName, FilesConstants.MergedFileName);
        }

        public void MergeFiles(string? substring)
        {
            int countOfDeleted = 0;
            var files = Directory.GetFiles(FilesConstants.DirectoryName);

            using var writer = new StreamWriter(_mergedPath);
            var sb = new StringBuilder();

            foreach (var file in files)
            {
                foreach (var line in File.ReadLines(file, Encoding.UTF8))
                {
                    if (!string.IsNullOrEmpty(substring) && line.Contains(substring))
                    {
                        countOfDeleted++;
                        continue;
                    }

                    sb.AppendLine(line);

                    if (sb.Length > FilesConstants.BufferSize * 100)
                    {
                        writer.Write(sb.ToString());
                        sb.Clear();
                    }
                }
            }

            if (sb.Length > 0)
                writer.Write(sb.ToString());


            Console.WriteLine($"Count of deleted rows: {countOfDeleted}");
            Console.WriteLine($"New file: {_mergedPath}");
        }
    }
}
