using Snow.DataVisualizer.API.Shared.Utils;

namespace Snow.DataVisualizer.API.Tests
{
    public class UtilsTests
    {
        [Theory]
        [InlineData("BLACK", "#000000")]
        [InlineData("WHITE", "#FFFFFF")]
        public void GetColorCode_ReturnColorHex(string colorname,string expectedColorHex)
        {
            var result = Utils.GetColorCode(colorname);
            Assert.Equal(expectedColorHex, result);
        }
        [Fact]
        public void GetColorCode_ReturnWrongColorHex()
        {
            //Arrange
            var colorname = "BLACK";
            //Act
            var result = Utils.GetColorCode(colorname);
            //Assert
            Assert.NotEqual("#FFFFFF", result);
        }
    }
}