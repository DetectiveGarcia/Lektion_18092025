using Infrastructure.Interfaces;
using Infrastructure.Models;
using Moq;

namespace Infrastructure.Tests.Services;

public class FileService_Tests
{
    [Fact]
    public void SaveContentToFile_ShouldReturnTrue_WhenContentSaveToFile()
    {
        // Arrange

        var fileResult = new FileResult { Succeeded = true };

        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;

        fileServiceMock.Setup(fs => fs.SaveContentToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(fileResult);

        // Act

        var result = fileService.SaveContentToFile("", "");

        // Assert
        Assert.True(result.Succeeded);

    }

    [Fact]
    public void SaveContentToFile_ShouldReturnFalseWithError_WhenContentNotSavedToFile()
    {
        // Arrange

        var fileResult = new FileResult { Succeeded = false, Error = "Unable to save content" };

        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;

        fileServiceMock.Setup(fs => fs.SaveContentToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(fileResult);

        // Act

        var result = fileService.SaveContentToFile("", "");

        // Assert
        Assert.False(result.Succeeded);
        Assert.Equal("Unable to save content", result.Error);

    }

    [Fact]
    public void GetContentFromFile_ShouldReturnTrueAndContentAsJson_WhenFileFound()
    {
        // Arrange
        //var jsonContent = "[{ \"Id\": \"0f507586-9f35-45c6-9ef9-a1657af19b03\", \"Name\": \"Test Product\", \"Price\": 200 } ]";
        var jsonContent = "[{\"Id\":\"0f507586-9f35-45c6-9ef9-a1657af19b03\",\"Name\":\"Test Product\",\"Price\":200}]";


        var fileResult = new FileResult { Succeeded = false, Content = jsonContent };

        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;

        fileServiceMock.Setup(fs => fs.GetContentFromFile(It.IsAny<string>())).Returns(fileResult);


        //Act

        var result = fileService.GetContentFromFile("");


        // Assert
        Assert.True(result.Succeeded);
        Assert.Equal(jsonContent, result.Content);
    }

    [Fact]
    public void GetContentFromFile_ShouldReturnFalseWithError_WhenExceptionOccured()
    {
        // Arrange


        var fileResult = new FileResult { Succeeded = false, Error = "Something went wrong" };

        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;

        fileServiceMock.Setup(fs => fs.GetContentFromFile(It.IsAny<string>())).Returns(fileResult);


        //Act

        var result = fileService.GetContentFromFile("");


        // Assert
        Assert.False(result.Succeeded);
        Assert.False(string.IsNullOrEmpty(result.Error));
    }

}
