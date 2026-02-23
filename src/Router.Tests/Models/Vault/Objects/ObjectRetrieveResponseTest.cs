using System;
using System.Text.Json;
using Router.Core;
using Router.Models.Vault.Objects;

namespace Router.Tests.Models.Vault.Objects;

public class ObjectRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            ChunkCount = 0,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            Path = "path",
            SizeBytes = 0,
            TextLength = 0,
            VectorCount = 0,
        };

        string expectedID = "id";
        string expectedContentType = "contentType";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDownloadUrl = "downloadUrl";
        long expectedExpiresIn = 0;
        string expectedFilename = "filename";
        string expectedIngestionStatus = "ingestionStatus";
        string expectedVaultID = "vaultId";
        long expectedChunkCount = 0;
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedPageCount = 0;
        string expectedPath = "path";
        long expectedSizeBytes = 0;
        long expectedTextLength = 0;
        long expectedVectorCount = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDownloadUrl, model.DownloadUrl);
        Assert.Equal(expectedExpiresIn, model.ExpiresIn);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedIngestionStatus, model.IngestionStatus);
        Assert.Equal(expectedVaultID, model.VaultID);
        Assert.Equal(expectedChunkCount, model.ChunkCount);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedPageCount, model.PageCount);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.Equal(expectedTextLength, model.TextLength);
        Assert.Equal(expectedVectorCount, model.VectorCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            ChunkCount = 0,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            Path = "path",
            SizeBytes = 0,
            TextLength = 0,
            VectorCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            ChunkCount = 0,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            Path = "path",
            SizeBytes = 0,
            TextLength = 0,
            VectorCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedContentType = "contentType";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDownloadUrl = "downloadUrl";
        long expectedExpiresIn = 0;
        string expectedFilename = "filename";
        string expectedIngestionStatus = "ingestionStatus";
        string expectedVaultID = "vaultId";
        long expectedChunkCount = 0;
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedPageCount = 0;
        string expectedPath = "path";
        long expectedSizeBytes = 0;
        long expectedTextLength = 0;
        long expectedVectorCount = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDownloadUrl, deserialized.DownloadUrl);
        Assert.Equal(expectedExpiresIn, deserialized.ExpiresIn);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedIngestionStatus, deserialized.IngestionStatus);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
        Assert.Equal(expectedChunkCount, deserialized.ChunkCount);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedPageCount, deserialized.PageCount);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.Equal(expectedTextLength, deserialized.TextLength);
        Assert.Equal(expectedVectorCount, deserialized.VectorCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            ChunkCount = 0,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            Path = "path",
            SizeBytes = 0,
            TextLength = 0,
            VectorCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            Path = "path",
        };

        Assert.Null(model.ChunkCount);
        Assert.False(model.RawData.ContainsKey("chunkCount"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
        Assert.Null(model.TextLength);
        Assert.False(model.RawData.ContainsKey("textLength"));
        Assert.Null(model.VectorCount);
        Assert.False(model.RawData.ContainsKey("vectorCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            Path = "path",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            Path = "path",

            // Null should be interpreted as omitted for these properties
            ChunkCount = null,
            Metadata = null,
            PageCount = null,
            SizeBytes = null,
            TextLength = null,
            VectorCount = null,
        };

        Assert.Null(model.ChunkCount);
        Assert.False(model.RawData.ContainsKey("chunkCount"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
        Assert.Null(model.TextLength);
        Assert.False(model.RawData.ContainsKey("textLength"));
        Assert.Null(model.VectorCount);
        Assert.False(model.RawData.ContainsKey("vectorCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            Path = "path",

            // Null should be interpreted as omitted for these properties
            ChunkCount = null,
            Metadata = null,
            PageCount = null,
            SizeBytes = null,
            TextLength = null,
            VectorCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            ChunkCount = 0,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            SizeBytes = 0,
            TextLength = 0,
            VectorCount = 0,
        };

        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            ChunkCount = 0,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            SizeBytes = 0,
            TextLength = 0,
            VectorCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            ChunkCount = 0,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            SizeBytes = 0,
            TextLength = 0,
            VectorCount = 0,

            Path = null,
        };

        Assert.Null(model.Path);
        Assert.True(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            ChunkCount = 0,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            SizeBytes = 0,
            TextLength = 0,
            VectorCount = 0,

            Path = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectRetrieveResponse
        {
            ID = "id",
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "downloadUrl",
            ExpiresIn = 0,
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            VaultID = "vaultId",
            ChunkCount = 0,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            Path = "path",
            SizeBytes = 0,
            TextLength = 0,
            VectorCount = 0,
        };

        ObjectRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
