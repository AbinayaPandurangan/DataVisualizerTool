using Microsoft.AspNetCore.Http;

namespace Snow.DataVisualizer.API.Shared.Extensions
{
    public static class FileExtensions
    {
        public static List<string> GetFileDataByLine(this IFormFile file)
        {
            string name = file.FileName;
            List<string> dataLines = new List<string>();
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                
                    using (TextReader readline = new StreamReader(memoryStream))
                    {
                        String line;
                        while ((line = readline.ReadLine()) != null)
                        {
                            dataLines.Add(line);
                        }
                    }
                
            }
            return dataLines;
        }
    }
}
