using Infrastructure.Helpers;

namespace Infrastructure.Tests.Helpers;

public class UniqueIdGenerator_Tests
{
    [Fact]
    public void Generate_ShouldReturnGuidAsString_WhenSuccessful()
    {

        // Arrange

        //Act

        var result = UniqueIdGenerator.Generate();

        // Assert
        //Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.True(Guid.TryParse(result, out _)); //out = det genereade värdet. _ = Discard
        //Assert.True(Guid.TryParse(result, out Guid id));
        //Assert.IsType<string>(id.ToString());

    }
}
