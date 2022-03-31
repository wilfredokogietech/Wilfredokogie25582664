namespace TextAnalyzer
{
    public static class FileReader
    {
        /// <summary>
        /// Reads the text in a file
        /// </summary>
        /// <returns></returns>
        public static string? ReadTextFile()
        {
            try
            {
                var sr = File.ReadAllLines(@"TextFile.txt");
                
                return string.Join("", sr);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

                throw;
            }
        }
    }
}
