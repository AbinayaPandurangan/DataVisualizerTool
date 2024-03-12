using Microsoft.AspNetCore.Http;
using Snow.DataVisualizer.API.Entities;
using Snow.DataVisualizer.API.Validators;

namespace Snow.DataVisualizer.API.Tests
{
    public class FluentValidationTests
    {
        [Fact]
        public void FileValidator_ValidData()
        {
            //Arrange
            var fileUpload = new FileOutputData
            {
                Hastag = '#',
                Name = "A",
                Color = "BLACK",
                Value = 5
            };

            //Act
            FileOutputDataValidator validator = new FileOutputDataValidator();
            var validationResult = validator.Validate(fileUpload);

            //Assert
            Assert.True(validationResult.IsValid);

        }
        [Fact]
        public void FileValidator_InValidData()
        {
            //Arrange
            var fileUpload = new FileOutputData
            {
                Hastag = '#',
                Name = "/A",
                Color = "BLACK",
                Value = 5
            };

            //Act
            FileOutputDataValidator validator = new FileOutputDataValidator();
            var validationResult = validator.Validate(fileUpload);

            //Assert
            Assert.False(validationResult.IsValid);

        }
        [Fact]
        public void ImportedFileValidatorTest_ReturnValid()
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
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            //Act
            FileValidator validator = new FileValidator();
            var validationResult = validator.Validate(file);

            //Assert
            Assert.True(validationResult.IsValid);

        }
        [Fact]
        public void ImportedFileValidatorTest_ReturnInValid()
        {
            //Setup mock file using a memory stream
            var content = "#B:GREEN:8";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            //Act
            FileValidator validator = new FileValidator();
            var validationResult = validator.Validate(file);

            //Assert
            Assert.False(validationResult.IsValid);

        }
        [Fact]
        public void ImportedFileValidatorTest_ReturnInValidEmptyData()
        {
            //Setup mock file using a memory stream
            var content = "";
            var fileName = "test.txt";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            //Act
            FileValidator validator = new FileValidator();
            var validationResult = validator.Validate(file);

            //Assert
            Assert.False(validationResult.IsValid);
        }
    }
}
