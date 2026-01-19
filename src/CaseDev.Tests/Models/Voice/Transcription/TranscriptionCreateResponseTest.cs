using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Voice.Transcription;

namespace CaseDev.Tests.Models.Voice.Transcription;

public class TranscriptionCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TranscriptionCreateResponse
        {
            ID = "id",
            SourceObjectID = "source_object_id",
            Status = Status.Queued,
            VaultID = "vault_id",
        };

        string expectedID = "id";
        string expectedSourceObjectID = "source_object_id";
        ApiEnum<string, Status> expectedStatus = Status.Queued;
        string expectedVaultID = "vault_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSourceObjectID, model.SourceObjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TranscriptionCreateResponse
        {
            ID = "id",
            SourceObjectID = "source_object_id",
            Status = Status.Queued,
            VaultID = "vault_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TranscriptionCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TranscriptionCreateResponse
        {
            ID = "id",
            SourceObjectID = "source_object_id",
            Status = Status.Queued,
            VaultID = "vault_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TranscriptionCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSourceObjectID = "source_object_id";
        ApiEnum<string, Status> expectedStatus = Status.Queued;
        string expectedVaultID = "vault_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSourceObjectID, deserialized.SourceObjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TranscriptionCreateResponse
        {
            ID = "id",
            SourceObjectID = "source_object_id",
            Status = Status.Queued,
            VaultID = "vault_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TranscriptionCreateResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.SourceObjectID);
        Assert.False(model.RawData.ContainsKey("source_object_id"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TranscriptionCreateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TranscriptionCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            SourceObjectID = null,
            Status = null,
            VaultID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.SourceObjectID);
        Assert.False(model.RawData.ContainsKey("source_object_id"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TranscriptionCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            SourceObjectID = null,
            Status = null,
            VaultID = null,
        };

        model.Validate();
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Queued)]
    [InlineData(Status.Processing)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Error)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Queued)]
    [InlineData(Status.Processing)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Error)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
