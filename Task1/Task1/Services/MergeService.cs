using System.Text;

namespace Task1.Services
{
    /// <summary>
    /// Service wich merge generated files in one file
    /// </summary>
    public class MergeService
    {
        /// <summary>
        /// Path to merged file
        /// </summary>
        private readonly string _mergedPath;

        /// <summary>
        /// Constructor thats create instance of class and create path to merged file
        /// </summary>
        public MergeService()
        {
            _mergedPath = Path.Combine(FilesConstants.DirectoryName, FilesConstants.MergedFileName);
        }

        /// <summary>
        /// Read all files from directory and merge them in one file
        /// Using buffer to optimize process of merging and write lines in parts
        /// </summary>
        /// <param name="substring">Pattern (substrings wthts will be delete from lines)</param>
        public void MergeFiles(string? substring)
        {
            if(File.Exists(_mergedPath))
            {
                File.Delete(_mergedPath);
            }

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
