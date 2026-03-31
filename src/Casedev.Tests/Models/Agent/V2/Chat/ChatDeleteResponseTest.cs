using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Agent.V2.Chat;

namespace Casedev.Tests.Models.Agent.V2.Chat;

public class ChatDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            Provider = "provider",
            RuntimeID = "runtimeId",
            RuntimeMs = 0,
            Status = "status",
        };

        string expectedID = "id";
        double expectedCost = 0;
        string expectedProvider = "provider";
        string expectedRuntimeID = "runtimeId";
        long expectedRuntimeMs = 0;
        string expectedStatus = "status";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedRuntimeID, model.RuntimeID);
        Assert.Equal(expectedRuntimeMs, model.RuntimeMs);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            Provider = "provider",
            RuntimeID = "runtimeId",
            RuntimeMs = 0,
            Status = "status",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            Provider = "provider",
            RuntimeID = "runtimeId",
            RuntimeMs = 0,
            Status = "status",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedCost = 0;
        string expectedProvider = "provider";
        string expectedRuntimeID = "runtimeId";
        long expectedRuntimeMs = 0;
        string expectedStatus = "status";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedRuntimeID, deserialized.RuntimeID);
        Assert.Equal(expectedRuntimeMs, deserialized.RuntimeMs);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            Provider = "provider",
            RuntimeID = "runtimeId",
            RuntimeMs = 0,
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatDeleteResponse { Provider = "provider", RuntimeID = "runtimeId" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.RuntimeMs);
        Assert.False(model.RawData.ContainsKey("runtimeMs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatDeleteResponse { Provider = "provider", RuntimeID = "runtimeId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatDeleteResponse
        {
            Provider = "provider",
            RuntimeID = "runtimeId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Cost = null,
            RuntimeMs = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.RuntimeMs);
        Assert.False(model.RawData.ContainsKey("runtimeMs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatDeleteResponse
        {
            Provider = "provider",
            RuntimeID = "runtimeId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Cost = null,
            RuntimeMs = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            Status = "status",
        };

        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.RuntimeID);
        Assert.False(model.RawData.ContainsKey("runtimeId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            Status = "status",

            Provider = null,
            RuntimeID = null,
        };

        Assert.Null(model.Provider);
        Assert.True(model.RawData.ContainsKey("provider"));
        Assert.Null(model.RuntimeID);
        Assert.True(model.RawData.ContainsKey("runtimeId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            Status = "status",

            Provider = null,
            RuntimeID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            Provider = "provider",
            RuntimeID = "runtimeId",
            RuntimeMs = 0,
            Status = "status",
        };

        ChatDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
