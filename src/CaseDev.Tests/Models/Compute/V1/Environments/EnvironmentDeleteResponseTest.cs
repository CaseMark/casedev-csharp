using System.Text.Json;
using CaseDev.Models.Compute.V1.Environments;

namespace CaseDev.Tests.Models.Compute.V1.Environments;

public class EnvironmentDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EnvironmentDeleteResponse
        {
            Message = "Environment 'litigation-processing' deleted",
            Success = true,
        };

        string expectedMessage = "Environment 'litigation-processing' deleted";
        bool expectedSuccess = true;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EnvironmentDeleteResponse
        {
            Message = "Environment 'litigation-processing' deleted",
            Success = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EnvironmentDeleteResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EnvironmentDeleteResponse
        {
            Message = "Environment 'litigation-processing' deleted",
            Success = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EnvironmentDeleteResponse>(json);
        Assert.NotNull(deserialized);

        string expectedMessage = "Environment 'litigation-processing' deleted";
        bool expectedSuccess = true;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EnvironmentDeleteResponse
        {
            Message = "Environment 'litigation-processing' deleted",
            Success = true,
        };

        model.Validate();
    }
}
