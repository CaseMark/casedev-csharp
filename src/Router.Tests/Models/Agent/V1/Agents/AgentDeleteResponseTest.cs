using System.Text.Json;
using Router.Core;
using Router.Models.Agent.V1.Agents;

namespace Router.Tests.Models.Agent.V1.Agents;

public class AgentDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentDeleteResponse { Ok = true };

        bool expectedOk = true;

        Assert.Equal(expectedOk, model.Ok);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentDeleteResponse { Ok = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentDeleteResponse { Ok = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedOk = true;

        Assert.Equal(expectedOk, deserialized.Ok);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentDeleteResponse { Ok = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentDeleteResponse { };

        Assert.Null(model.Ok);
        Assert.False(model.RawData.ContainsKey("ok"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            Ok = null,
        };

        Assert.Null(model.Ok);
        Assert.False(model.RawData.ContainsKey("ok"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            Ok = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentDeleteResponse { Ok = true };

        AgentDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
