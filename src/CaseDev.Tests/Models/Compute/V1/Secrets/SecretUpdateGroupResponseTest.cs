using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Compute.V1.Secrets;

namespace CaseDev.Tests.Models.Compute.V1.Secrets;

public class SecretUpdateGroupResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SecretUpdateGroupResponse
        {
            Created = 0,
            Group = "group",
            Message = "message",
            Success = true,
            Updated = 0,
        };

        double expectedCreated = 0;
        string expectedGroup = "group";
        string expectedMessage = "message";
        bool expectedSuccess = true;
        double expectedUpdated = 0;

        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedGroup, model.Group);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedUpdated, model.Updated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SecretUpdateGroupResponse
        {
            Created = 0,
            Group = "group",
            Message = "message",
            Success = true,
            Updated = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecretUpdateGroupResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SecretUpdateGroupResponse
        {
            Created = 0,
            Group = "group",
            Message = "message",
            Success = true,
            Updated = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecretUpdateGroupResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedCreated = 0;
        string expectedGroup = "group";
        string expectedMessage = "message";
        bool expectedSuccess = true;
        double expectedUpdated = 0;

        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedGroup, deserialized.Group);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedUpdated, deserialized.Updated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SecretUpdateGroupResponse
        {
            Created = 0,
            Group = "group",
            Message = "message",
            Success = true,
            Updated = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SecretUpdateGroupResponse { };

        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.Group);
        Assert.False(model.RawData.ContainsKey("group"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SecretUpdateGroupResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SecretUpdateGroupResponse
        {
            // Null should be interpreted as omitted for these properties
            Created = null,
            Group = null,
            Message = null,
            Success = null,
            Updated = null,
        };

        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.Group);
        Assert.False(model.RawData.ContainsKey("group"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SecretUpdateGroupResponse
        {
            // Null should be interpreted as omitted for these properties
            Created = null,
            Group = null,
            Message = null,
            Success = null,
            Updated = null,
        };

        model.Validate();
    }
}
