using System;
using System.Collections.Generic;
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

        Assert.Equal(expectedChunks.Count, model.Chunks.Count);
        for (int i = 0; i < expectedChunks.Count; i++)
        {
            Assert.Equal(expectedChunks[i], model.Chunks[i]);
        }
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedResponse, model.Response);
        Assert.Equal(expectedSources.Count, model.Sources.Count);
        for (int i = 0; i < expectedSources.Count; i++)
        {
            Assert.Equal(expectedSources[i], model.Sources[i]);
        }
        Assert.Equal(expectedVaultID, model.VaultID);
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
}
