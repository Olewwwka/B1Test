namespace Task1
{
    /// <summary>
    /// Static class which contatins constants to working with files
    /// </summary>
    public static class FilesConstants
    {
        /// <summary>
        /// Default files directory name
        /// </summary>
        public const string DirectoryName = "Data";
        /// <summary>
        /// Count of lines in one file
        /// </summary>
        public const int CountOfLines = 100000;
        /// <summary>
        /// Count of generating files in directory
        /// </summary>
        public const int CountOfFiles = 100;
        /// <summary>
        /// Default name of merged file
        /// </summary>
        public const string MergedFileName = "merged.txt";
        /// <summary>
        /// Size of buffer to write rows in merged file
        /// </summary>
        public const int BufferSize = 10000;
        /// <summary>
        /// Size of buffer to import rows in database
        /// </summary>
        public const int RowsBuffer = 50000;
    }
}
