using Snow.DataVisualizer.API.Controllers;
using Snow.DataVisualizer.API.Repositories.Interface;
using Moq;
using Snow.DataVisualizer.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Snow.DataVisualizer.API.Tests
{
    public class FileUploadControllerTests
    {
        FileUploadController _controller;

        [Fact]
        public void DataRandomizerTest()
        {
            var repoMock = new Mock<IDataVisualizerRepository>();
            var loggerMock = new Mock<ILogger<FileUploadController>>();

            _controller = new FileUploadController(repoMock.Object, loggerMock.Object);
            var result = _controller.DataRandomizer();

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            Assert.IsType<List<FileOutputData>>(okResult.Value);

            var list = okResult.Value as List<FileOutputData>;
            Assert.NotNull(list);
            Assert.True(list.Count > 0);
        }

        [Fact]
        public void FileUploadTest()
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

            FileOutputData fileOutputData = new FileOutputData();
            var loggerMock = new Mock<ILogger<FileUploadController>>();
            var repoMock = new Mock<IDataVisualizerRepository>();
            repoMock.Setup(x => x.AddAsync(fileOutputData)).Returns(Task.CompletedTask);
            repoMock.Setup(x => x.DeleteAsync()).Returns(Task.CompletedTask);

            _controller = new FileUploadController(repoMock.Object, loggerMock.Object);
            var result = _controller.ImportFile(file);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            Assert.IsType<List<FileOutputData>>(okResult.Value);

            var list = okResult.Value as List<FileOutputData>;
            Assert.NotNull(list);
            Assert.True(list.Count > 0);
        }
    }

}
