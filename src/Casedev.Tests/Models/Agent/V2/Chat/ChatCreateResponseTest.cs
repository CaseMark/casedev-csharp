using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Agent.V2.Chat;

namespace Casedev.Tests.Models.Agent.V2.Chat;

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
            Provider = Provider.Daytona,
            RuntimeState = "runtimeState",
            Status = "status",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedIdleTimeoutMs = 0;
        ApiEnum<string, Provider> expectedProvider = Provider.Daytona;
        string expectedRuntimeState = "runtimeState";
        string expectedStatus = "status";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIdleTimeoutMs, model.IdleTimeoutMs);
        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedRuntimeState, model.RuntimeState);
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
            Provider = Provider.Daytona,
            RuntimeState = "runtimeState",
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
            Provider = Provider.Daytona,
            RuntimeState = "runtimeState",
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
        ApiEnum<string, Provider> expectedProvider = Provider.Daytona;
        string expectedRuntimeState = "runtimeState";
        string expectedStatus = "status";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIdleTimeoutMs, deserialized.IdleTimeoutMs);
        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedRuntimeState, deserialized.RuntimeState);
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
            Provider = Provider.Daytona,
            RuntimeState = "runtimeState",
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
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.RuntimeState);
        Assert.False(model.RawData.ContainsKey("runtimeState"));
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
            Provider = null,
            RuntimeState = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.IdleTimeoutMs);
        Assert.False(model.RawData.ContainsKey("idleTimeoutMs"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.RuntimeState);
        Assert.False(model.RawData.ContainsKey("runtimeState"));
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
            Provider = null,
            RuntimeState = null,
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
            Provider = Provider.Daytona,
            RuntimeState = "runtimeState",
            Status = "status",
        };

        ChatCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProviderTest : TestBase
{
    [Theory]
    [InlineData(Provider.Daytona)]
    public void Validation_Works(Provider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Provider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Provider.Daytona)]
    public void SerializationRoundtrip_Works(Provider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Provider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Provider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
