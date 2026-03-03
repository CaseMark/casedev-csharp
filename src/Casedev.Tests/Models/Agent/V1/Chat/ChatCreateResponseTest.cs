using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Agent.V1.Chat;

namespace Casedev.Tests.Models.Agent.V1.Chat;

public class ChatCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IdleTimeoutMs = 0,
            Status = "status",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedIdleTimeoutMs = 0;
        string expectedStatus = "status";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIdleTimeoutMs, model.IdleTimeoutMs);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IdleTimeoutMs = 0,
            Status = "status",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IdleTimeoutMs = 0,
            Status = "status",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedIdleTimeoutMs = 0;
        string expectedStatus = "status";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIdleTimeoutMs, deserialized.IdleTimeoutMs);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IdleTimeoutMs = 0,
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatCreateResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.IdleTimeoutMs);
        Assert.False(model.RawData.ContainsKey("idleTimeoutMs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatCreateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            IdleTimeoutMs = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.IdleTimeoutMs);
        Assert.False(model.RawData.ContainsKey("idleTimeoutMs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            IdleTimeoutMs = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IdleTimeoutMs = 0,
            Status = "status",
        };

        ChatCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
