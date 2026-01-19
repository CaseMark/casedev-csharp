using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using Objects = CaseDev.Models.Vault.Objects;

namespace CaseDev.Tests.Models.Vault.Objects;

public class ObjectListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Objects::ObjectListResponse
        {
            Count = 0,
            Objects =
            [
                new()
                {
                    ID = "id",
                    ChunkCount = 0,
                    ContentType = "contentType",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filename = "filename",
                    IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IngestionStatus = "ingestionStatus",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    PageCount = 0,
                    Path = "path",
                    SizeBytes = 0,
                    Tags = ["string"],
                    TextLength = 0,
                    VectorCount = 0,
                },
            ],
            VaultID = "vaultId",
        };

        double expectedCount = 0;
        List<Objects::Object> expectedObjects =
        [
            new()
            {
                ID = "id",
                ChunkCount = 0,
                ContentType = "contentType",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filename = "filename",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IngestionStatus = "ingestionStatus",
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                PageCount = 0,
                Path = "path",
                SizeBytes = 0,
                Tags = ["string"],
                TextLength = 0,
                VectorCount = 0,
            },
        ];
        string expectedVaultID = "vaultId";

        Assert.Equal(expectedCount, model.Count);
        Assert.NotNull(model.Objects);
        Assert.Equal(expectedObjects.Count, model.Objects.Count);
        for (int i = 0; i < expectedObjects.Count; i++)
        {
            Assert.Equal(expectedObjects[i], model.Objects[i]);
        }
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Objects::ObjectListResponse
        {
            Count = 0,
            Objects =
            [
                new()
                {
                    ID = "id",
                    ChunkCount = 0,
                    ContentType = "contentType",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filename = "filename",
                    IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IngestionStatus = "ingestionStatus",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    PageCount = 0,
                    Path = "path",
                    SizeBytes = 0,
                    Tags = ["string"],
                    TextLength = 0,
                    VectorCount = 0,
                },
            ],
            VaultID = "vaultId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Objects::ObjectListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Objects::ObjectListResponse
        {
            Count = 0,
            Objects =
            [
                new()
                {
                    ID = "id",
                    ChunkCount = 0,
                    ContentType = "contentType",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filename = "filename",
                    IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IngestionStatus = "ingestionStatus",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    PageCount = 0,
                    Path = "path",
                    SizeBytes = 0,
                    Tags = ["string"],
                    TextLength = 0,
                    VectorCount = 0,
                },
            ],
            VaultID = "vaultId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Objects::ObjectListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedCount = 0;
        List<Objects::Object> expectedObjects =
        [
            new()
            {
                ID = "id",
                ChunkCount = 0,
                ContentType = "contentType",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filename = "filename",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IngestionStatus = "ingestionStatus",
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                PageCount = 0,
                Path = "path",
                SizeBytes = 0,
                Tags = ["string"],
                TextLength = 0,
                VectorCount = 0,
            },
        ];
        string expectedVaultID = "vaultId";

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.NotNull(deserialized.Objects);
        Assert.Equal(expectedObjects.Count, deserialized.Objects.Count);
        for (int i = 0; i < expectedObjects.Count; i++)
        {
            Assert.Equal(expectedObjects[i], deserialized.Objects[i]);
        }
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Objects::ObjectListResponse
        {
            Count = 0,
            Objects =
            [
                new()
                {
                    ID = "id",
                    ChunkCount = 0,
                    ContentType = "contentType",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filename = "filename",
                    IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IngestionStatus = "ingestionStatus",
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    PageCount = 0,
                    Path = "path",
                    SizeBytes = 0,
                    Tags = ["string"],
                    TextLength = 0,
                    VectorCount = 0,
                },
            ],
            VaultID = "vaultId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Objects::ObjectListResponse { };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Objects);
        Assert.False(model.RawData.ContainsKey("objects"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vaultId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Objects::ObjectListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Objects::ObjectListResponse
        {
            // Null should be interpreted as omitted for these properties
            Count = null,
            Objects = null,
            VaultID = null,
        };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Objects);
        Assert.False(model.RawData.ContainsKey("objects"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vaultId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Objects::ObjectListResponse
        {
            // Null should be interpreted as omitted for these properties
            Count = null,
            Objects = null,
            VaultID = null,
        };

        model.Validate();
    }
}

public class ObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Objects::Object
        {
            ID = "id",
            ChunkCount = 0,
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            Path = "path",
            SizeBytes = 0,
            Tags = ["string"],
            TextLength = 0,
            VectorCount = 0,
        };

        string expectedID = "id";
        double expectedChunkCount = 0;
        string expectedContentType = "contentType";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFilename = "filename";
        DateTimeOffset expectedIngestionCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedIngestionStatus = "ingestionStatus";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        double expectedPageCount = 0;
        string expectedPath = "path";
        double expectedSizeBytes = 0;
        List<string> expectedTags = ["string"];
        double expectedTextLength = 0;
        double expectedVectorCount = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChunkCount, model.ChunkCount);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedIngestionCompletedAt, model.IngestionCompletedAt);
        Assert.Equal(expectedIngestionStatus, model.IngestionStatus);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedPageCount, model.PageCount);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedTextLength, model.TextLength);
        Assert.Equal(expectedVectorCount, model.VectorCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Objects::Object
        {
            ID = "id",
            ChunkCount = 0,
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            Path = "path",
            SizeBytes = 0,
            Tags = ["string"],
            TextLength = 0,
            VectorCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Objects::Object>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Objects::Object
        {
            ID = "id",
            ChunkCount = 0,
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            Path = "path",
            SizeBytes = 0,
            Tags = ["string"],
            TextLength = 0,
            VectorCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Objects::Object>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedChunkCount = 0;
        string expectedContentType = "contentType";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFilename = "filename";
        DateTimeOffset expectedIngestionCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedIngestionStatus = "ingestionStatus";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        double expectedPageCount = 0;
        string expectedPath = "path";
        double expectedSizeBytes = 0;
        List<string> expectedTags = ["string"];
        double expectedTextLength = 0;
        double expectedVectorCount = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChunkCount, deserialized.ChunkCount);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedIngestionCompletedAt, deserialized.IngestionCompletedAt);
        Assert.Equal(expectedIngestionStatus, deserialized.IngestionStatus);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedPageCount, deserialized.PageCount);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedTextLength, deserialized.TextLength);
        Assert.Equal(expectedVectorCount, deserialized.VectorCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Objects::Object
        {
            ID = "id",
            ChunkCount = 0,
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            Path = "path",
            SizeBytes = 0,
            Tags = ["string"],
            TextLength = 0,
            VectorCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Objects::Object { Path = "path" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ChunkCount);
        Assert.False(model.RawData.ContainsKey("chunkCount"));
        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("contentType"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.IngestionCompletedAt);
        Assert.False(model.RawData.ContainsKey("ingestionCompletedAt"));
        Assert.Null(model.IngestionStatus);
        Assert.False(model.RawData.ContainsKey("ingestionStatus"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.TextLength);
        Assert.False(model.RawData.ContainsKey("textLength"));
        Assert.Null(model.VectorCount);
        Assert.False(model.RawData.ContainsKey("vectorCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Objects::Object { Path = "path" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Objects::Object
        {
            Path = "path",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ChunkCount = null,
            ContentType = null,
            CreatedAt = null,
            Filename = null,
            IngestionCompletedAt = null,
            IngestionStatus = null,
            Metadata = null,
            PageCount = null,
            SizeBytes = null,
            Tags = null,
            TextLength = null,
            VectorCount = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ChunkCount);
        Assert.False(model.RawData.ContainsKey("chunkCount"));
        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("contentType"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.IngestionCompletedAt);
        Assert.False(model.RawData.ContainsKey("ingestionCompletedAt"));
        Assert.Null(model.IngestionStatus);
        Assert.False(model.RawData.ContainsKey("ingestionStatus"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.TextLength);
        Assert.False(model.RawData.ContainsKey("textLength"));
        Assert.Null(model.VectorCount);
        Assert.False(model.RawData.ContainsKey("vectorCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Objects::Object
        {
            Path = "path",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ChunkCount = null,
            ContentType = null,
            CreatedAt = null,
            Filename = null,
            IngestionCompletedAt = null,
            IngestionStatus = null,
            Metadata = null,
            PageCount = null,
            SizeBytes = null,
            Tags = null,
            TextLength = null,
            VectorCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Objects::Object
        {
            ID = "id",
            ChunkCount = 0,
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            SizeBytes = 0,
            Tags = ["string"],
            TextLength = 0,
            VectorCount = 0,
        };

        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Objects::Object
        {
            ID = "id",
            ChunkCount = 0,
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            SizeBytes = 0,
            Tags = ["string"],
            TextLength = 0,
            VectorCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Objects::Object
        {
            ID = "id",
            ChunkCount = 0,
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            SizeBytes = 0,
            Tags = ["string"],
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
        var model = new Objects::Object
        {
            ID = "id",
            ChunkCount = 0,
            ContentType = "contentType",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PageCount = 0,
            SizeBytes = 0,
            Tags = ["string"],
            TextLength = 0,
            VectorCount = 0,

            Path = null,
        };

        model.Validate();
    }
}
