using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Vault.Objects;

namespace CaseDev.Tests.Models.Vault.Objects;

public class ObjectGetTextResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectGetTextResponse
        {
            Metadata = new()
            {
                ChunkCount = 0,
                Filename = "filename",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Length = 0,
                ObjectID = "object_id",
                VaultID = "vault_id",
            },
            Text = "text",
        };

        ObjectGetTextResponseMetadata expectedMetadata = new()
        {
            ChunkCount = 0,
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
        };
        string expectedText = "text";

        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectGetTextResponse
        {
            Metadata = new()
            {
                ChunkCount = 0,
                Filename = "filename",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Length = 0,
                ObjectID = "object_id",
                VaultID = "vault_id",
            },
            Text = "text",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetTextResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectGetTextResponse
        {
            Metadata = new()
            {
                ChunkCount = 0,
                Filename = "filename",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Length = 0,
                ObjectID = "object_id",
                VaultID = "vault_id",
            },
            Text = "text",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetTextResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ObjectGetTextResponseMetadata expectedMetadata = new()
        {
            ChunkCount = 0,
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
        };
        string expectedText = "text";

        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectGetTextResponse
        {
            Metadata = new()
            {
                ChunkCount = 0,
                Filename = "filename",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Length = 0,
                ObjectID = "object_id",
                VaultID = "vault_id",
            },
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectGetTextResponse { };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectGetTextResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ObjectGetTextResponse
        {
            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Text = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectGetTextResponse
        {
            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Text = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectGetTextResponse
        {
            Metadata = new()
            {
                ChunkCount = 0,
                Filename = "filename",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Length = 0,
                ObjectID = "object_id",
                VaultID = "vault_id",
            },
            Text = "text",
        };

        ObjectGetTextResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ObjectGetTextResponseMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            ChunkCount = 0,
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
        };

        long expectedChunkCount = 0;
        string expectedFilename = "filename";
        DateTimeOffset expectedIngestionCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        long expectedLength = 0;
        string expectedObjectID = "object_id";
        string expectedVaultID = "vault_id";

        Assert.Equal(expectedChunkCount, model.ChunkCount);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedIngestionCompletedAt, model.IngestionCompletedAt);
        Assert.Equal(expectedLength, model.Length);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            ChunkCount = 0,
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetTextResponseMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            ChunkCount = 0,
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetTextResponseMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedChunkCount = 0;
        string expectedFilename = "filename";
        DateTimeOffset expectedIngestionCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        long expectedLength = 0;
        string expectedObjectID = "object_id";
        string expectedVaultID = "vault_id";

        Assert.Equal(expectedChunkCount, deserialized.ChunkCount);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedIngestionCompletedAt, deserialized.IngestionCompletedAt);
        Assert.Equal(expectedLength, deserialized.Length);
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            ChunkCount = 0,
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectGetTextResponseMetadata { };

        Assert.Null(model.ChunkCount);
        Assert.False(model.RawData.ContainsKey("chunk_count"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.IngestionCompletedAt);
        Assert.False(model.RawData.ContainsKey("ingestion_completed_at"));
        Assert.Null(model.Length);
        Assert.False(model.RawData.ContainsKey("length"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("object_id"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectGetTextResponseMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            // Null should be interpreted as omitted for these properties
            ChunkCount = null,
            Filename = null,
            IngestionCompletedAt = null,
            Length = null,
            ObjectID = null,
            VaultID = null,
        };

        Assert.Null(model.ChunkCount);
        Assert.False(model.RawData.ContainsKey("chunk_count"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.IngestionCompletedAt);
        Assert.False(model.RawData.ContainsKey("ingestion_completed_at"));
        Assert.Null(model.Length);
        Assert.False(model.RawData.ContainsKey("length"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("object_id"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            // Null should be interpreted as omitted for these properties
            ChunkCount = null,
            Filename = null,
            IngestionCompletedAt = null,
            Length = null,
            ObjectID = null,
            VaultID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            ChunkCount = 0,
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
        };

        ObjectGetTextResponseMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
