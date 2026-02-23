using System;
using System.Text.Json;
using Router.Core;
using Router.Models.Vault.Objects;

namespace Router.Tests.Models.Vault.Objects;

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
                Length = 0,
                ObjectID = "object_id",
                VaultID = "vault_id",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Text = "text",
        };

        ObjectGetTextResponseMetadata expectedMetadata = new()
        {
            ChunkCount = 0,
            Filename = "filename",
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                Length = 0,
                ObjectID = "object_id",
                VaultID = "vault_id",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                Length = 0,
                ObjectID = "object_id",
                VaultID = "vault_id",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                Length = 0,
                ObjectID = "object_id",
                VaultID = "vault_id",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Text = "text",
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
                Length = 0,
                ObjectID = "object_id",
                VaultID = "vault_id",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        long expectedChunkCount = 0;
        string expectedFilename = "filename";
        long expectedLength = 0;
        string expectedObjectID = "object_id";
        string expectedVaultID = "vault_id";
        DateTimeOffset expectedIngestionCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedChunkCount, model.ChunkCount);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedLength, model.Length);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedVaultID, model.VaultID);
        Assert.Equal(expectedIngestionCompletedAt, model.IngestionCompletedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            ChunkCount = 0,
            Filename = "filename",
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetTextResponseMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedChunkCount = 0;
        string expectedFilename = "filename";
        long expectedLength = 0;
        string expectedObjectID = "object_id";
        string expectedVaultID = "vault_id";
        DateTimeOffset expectedIngestionCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedChunkCount, deserialized.ChunkCount);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedLength, deserialized.Length);
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
        Assert.Equal(expectedIngestionCompletedAt, deserialized.IngestionCompletedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            ChunkCount = 0,
            Filename = "filename",
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            ChunkCount = 0,
            Filename = "filename",
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
        };

        Assert.Null(model.IngestionCompletedAt);
        Assert.False(model.RawData.ContainsKey("ingestion_completed_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            ChunkCount = 0,
            Filename = "filename",
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            ChunkCount = 0,
            Filename = "filename",
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",

            // Null should be interpreted as omitted for these properties
            IngestionCompletedAt = null,
        };

        Assert.Null(model.IngestionCompletedAt);
        Assert.False(model.RawData.ContainsKey("ingestion_completed_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectGetTextResponseMetadata
        {
            ChunkCount = 0,
            Filename = "filename",
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",

            // Null should be interpreted as omitted for these properties
            IngestionCompletedAt = null,
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
            Length = 0,
            ObjectID = "object_id",
            VaultID = "vault_id",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ObjectGetTextResponseMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
