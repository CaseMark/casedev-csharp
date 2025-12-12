using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultSearchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultSearchResponse
        {
            Chunks =
            [
                new()
                {
                    Score = 0,
                    Source = "source",
                    Text = "text",
                },
            ],
            Method = "method",
            Query = "query",
            Response = "response",
            Sources =
            [
                new()
                {
                    ID = "id",
                    ChunkCount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filename = "filename",
                    IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PageCount = 0,
                    TextLength = 0,
                },
            ],
            VaultID = "vault_id",
        };

        List<Chunk> expectedChunks =
        [
            new()
            {
                Score = 0,
                Source = "source",
                Text = "text",
            },
        ];
        string expectedMethod = "method";
        string expectedQuery = "query";
        string expectedResponse = "response";
        List<Source> expectedSources =
        [
            new()
            {
                ID = "id",
                ChunkCount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filename = "filename",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PageCount = 0,
                TextLength = 0,
            },
        ];
        string expectedVaultID = "vault_id";

        Assert.NotNull(model.Chunks);
        Assert.Equal(expectedChunks.Count, model.Chunks.Count);
        for (int i = 0; i < expectedChunks.Count; i++)
        {
            Assert.Equal(expectedChunks[i], model.Chunks[i]);
        }
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedResponse, model.Response);
        Assert.NotNull(model.Sources);
        Assert.Equal(expectedSources.Count, model.Sources.Count);
        for (int i = 0; i < expectedSources.Count; i++)
        {
            Assert.Equal(expectedSources[i], model.Sources[i]);
        }
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultSearchResponse
        {
            Chunks =
            [
                new()
                {
                    Score = 0,
                    Source = "source",
                    Text = "text",
                },
            ],
            Method = "method",
            Query = "query",
            Response = "response",
            Sources =
            [
                new()
                {
                    ID = "id",
                    ChunkCount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filename = "filename",
                    IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PageCount = 0,
                    TextLength = 0,
                },
            ],
            VaultID = "vault_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VaultSearchResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultSearchResponse
        {
            Chunks =
            [
                new()
                {
                    Score = 0,
                    Source = "source",
                    Text = "text",
                },
            ],
            Method = "method",
            Query = "query",
            Response = "response",
            Sources =
            [
                new()
                {
                    ID = "id",
                    ChunkCount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filename = "filename",
                    IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PageCount = 0,
                    TextLength = 0,
                },
            ],
            VaultID = "vault_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VaultSearchResponse>(json);
        Assert.NotNull(deserialized);

        List<Chunk> expectedChunks =
        [
            new()
            {
                Score = 0,
                Source = "source",
                Text = "text",
            },
        ];
        string expectedMethod = "method";
        string expectedQuery = "query";
        string expectedResponse = "response";
        List<Source> expectedSources =
        [
            new()
            {
                ID = "id",
                ChunkCount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filename = "filename",
                IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PageCount = 0,
                TextLength = 0,
            },
        ];
        string expectedVaultID = "vault_id";

        Assert.NotNull(deserialized.Chunks);
        Assert.Equal(expectedChunks.Count, deserialized.Chunks.Count);
        for (int i = 0; i < expectedChunks.Count; i++)
        {
            Assert.Equal(expectedChunks[i], deserialized.Chunks[i]);
        }
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedQuery, deserialized.Query);
        Assert.Equal(expectedResponse, deserialized.Response);
        Assert.NotNull(deserialized.Sources);
        Assert.Equal(expectedSources.Count, deserialized.Sources.Count);
        for (int i = 0; i < expectedSources.Count; i++)
        {
            Assert.Equal(expectedSources[i], deserialized.Sources[i]);
        }
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultSearchResponse
        {
            Chunks =
            [
                new()
                {
                    Score = 0,
                    Source = "source",
                    Text = "text",
                },
            ],
            Method = "method",
            Query = "query",
            Response = "response",
            Sources =
            [
                new()
                {
                    ID = "id",
                    ChunkCount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filename = "filename",
                    IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PageCount = 0,
                    TextLength = 0,
                },
            ],
            VaultID = "vault_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultSearchResponse { };

        Assert.Null(model.Chunks);
        Assert.False(model.RawData.ContainsKey("chunks"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Response);
        Assert.False(model.RawData.ContainsKey("response"));
        Assert.Null(model.Sources);
        Assert.False(model.RawData.ContainsKey("sources"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultSearchResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultSearchResponse
        {
            // Null should be interpreted as omitted for these properties
            Chunks = null,
            Method = null,
            Query = null,
            Response = null,
            Sources = null,
            VaultID = null,
        };

        Assert.Null(model.Chunks);
        Assert.False(model.RawData.ContainsKey("chunks"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Response);
        Assert.False(model.RawData.ContainsKey("response"));
        Assert.Null(model.Sources);
        Assert.False(model.RawData.ContainsKey("sources"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultSearchResponse
        {
            // Null should be interpreted as omitted for these properties
            Chunks = null,
            Method = null,
            Query = null,
            Response = null,
            Sources = null,
            VaultID = null,
        };

        model.Validate();
    }
}

public class ChunkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Chunk
        {
            Score = 0,
            Source = "source",
            Text = "text",
        };

        double expectedScore = 0;
        string expectedSource = "source";
        string expectedText = "text";

        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Chunk
        {
            Score = 0,
            Source = "source",
            Text = "text",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Chunk>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Chunk
        {
            Score = 0,
            Source = "source",
            Text = "text",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Chunk>(json);
        Assert.NotNull(deserialized);

        double expectedScore = 0;
        string expectedSource = "source";
        string expectedText = "text";

        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Chunk
        {
            Score = 0,
            Source = "source",
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Chunk { };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Chunk { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Chunk
        {
            // Null should be interpreted as omitted for these properties
            Score = null,
            Source = null,
            Text = null,
        };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Chunk
        {
            // Null should be interpreted as omitted for these properties
            Score = null,
            Source = null,
            Text = null,
        };

        model.Validate();
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Source
        {
            ID = "id",
            ChunkCount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageCount = 0,
            TextLength = 0,
        };

        string expectedID = "id";
        long expectedChunkCount = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFilename = "filename";
        DateTimeOffset expectedIngestionCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        long expectedPageCount = 0;
        long expectedTextLength = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChunkCount, model.ChunkCount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedIngestionCompletedAt, model.IngestionCompletedAt);
        Assert.Equal(expectedPageCount, model.PageCount);
        Assert.Equal(expectedTextLength, model.TextLength);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Source
        {
            ID = "id",
            ChunkCount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageCount = 0,
            TextLength = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Source>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Source
        {
            ID = "id",
            ChunkCount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageCount = 0,
            TextLength = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Source>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedChunkCount = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFilename = "filename";
        DateTimeOffset expectedIngestionCompletedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        long expectedPageCount = 0;
        long expectedTextLength = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChunkCount, deserialized.ChunkCount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedIngestionCompletedAt, deserialized.IngestionCompletedAt);
        Assert.Equal(expectedPageCount, deserialized.PageCount);
        Assert.Equal(expectedTextLength, deserialized.TextLength);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Source
        {
            ID = "id",
            ChunkCount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "filename",
            IngestionCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PageCount = 0,
            TextLength = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Source { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ChunkCount);
        Assert.False(model.RawData.ContainsKey("chunkCount"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.IngestionCompletedAt);
        Assert.False(model.RawData.ContainsKey("ingestionCompletedAt"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.TextLength);
        Assert.False(model.RawData.ContainsKey("textLength"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Source { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Source
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            ChunkCount = null,
            CreatedAt = null,
            Filename = null,
            IngestionCompletedAt = null,
            PageCount = null,
            TextLength = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ChunkCount);
        Assert.False(model.RawData.ContainsKey("chunkCount"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.IngestionCompletedAt);
        Assert.False(model.RawData.ContainsKey("ingestionCompletedAt"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.TextLength);
        Assert.False(model.RawData.ContainsKey("textLength"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Source
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            ChunkCount = null,
            CreatedAt = null,
            Filename = null,
            IngestionCompletedAt = null,
            PageCount = null,
            TextLength = null,
        };

        model.Validate();
    }
}
