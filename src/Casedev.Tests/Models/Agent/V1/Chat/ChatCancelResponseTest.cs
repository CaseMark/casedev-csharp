using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Agent.V1.Chat;

namespace Casedev.Tests.Models.Agent.V1.Chat;

public class ChatCancelResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCancelResponse { ID = "id", Ok = true };

        string expectedID = "id";
        bool expectedOk = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedOk, model.Ok);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCancelResponse { ID = "id", Ok = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCancelResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCancelResponse { ID = "id", Ok = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCancelResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedOk = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedOk, deserialized.Ok);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCancelResponse { ID = "id", Ok = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCancelResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Ok);
        Assert.False(model.RawData.ContainsKey("ok"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCancelResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatCancelResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Ok = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Ok);
        Assert.False(model.RawData.ContainsKey("ok"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCancelResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Ok = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCancelResponse { ID = "id", Ok = true };

        ChatCancelResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
