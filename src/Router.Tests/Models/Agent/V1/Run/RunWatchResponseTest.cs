using System.Text.Json;
using Router.Core;
using Router.Models.Agent.V1.Run;

namespace Router.Tests.Models.Agent.V1.Run;

public class RunWatchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RunWatchResponse { CallbackUrl = "callbackUrl", Ok = true };

        string expectedCallbackUrl = "callbackUrl";
        bool expectedOk = true;

        Assert.Equal(expectedCallbackUrl, model.CallbackUrl);
        Assert.Equal(expectedOk, model.Ok);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RunWatchResponse { CallbackUrl = "callbackUrl", Ok = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunWatchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RunWatchResponse { CallbackUrl = "callbackUrl", Ok = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunWatchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallbackUrl = "callbackUrl";
        bool expectedOk = true;

        Assert.Equal(expectedCallbackUrl, deserialized.CallbackUrl);
        Assert.Equal(expectedOk, deserialized.Ok);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RunWatchResponse { CallbackUrl = "callbackUrl", Ok = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RunWatchResponse { };

        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callbackUrl"));
        Assert.Null(model.Ok);
        Assert.False(model.RawData.ContainsKey("ok"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RunWatchResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RunWatchResponse
        {
            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            Ok = null,
        };

        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callbackUrl"));
        Assert.Null(model.Ok);
        Assert.False(model.RawData.ContainsKey("ok"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RunWatchResponse
        {
            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            Ok = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RunWatchResponse { CallbackUrl = "callbackUrl", Ok = true };

        RunWatchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
