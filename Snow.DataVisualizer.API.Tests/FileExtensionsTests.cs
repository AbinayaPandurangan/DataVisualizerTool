using Microsoft.AspNetCore.Http;
using Snow.DataVisualizer.API.Shared.Extensions;

namespace Snow.DataVisualizer.API.Tests
{
    public class FileExtensionsTests
    {
        [Fact]
        public void GetFileDataByLine_ReturnLines()
        {
            //Setup mock file using a memory stream
            var content = "#B:GREEN:8";
            var fileName = "test.txt";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "file", fileName);

            //Act
            var result = file.GetFileDataByLine();

            //Assert
            Assert.True(result.Count > 0);
            Assert.True(result[0] == content);
        }
    }
}
