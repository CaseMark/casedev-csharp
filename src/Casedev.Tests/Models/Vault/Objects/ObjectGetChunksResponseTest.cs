using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Vault.Objects;

namespace Casedev.Tests.Models.Vault.Objects;

public class ObjectGetChunksResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectGetChunksResponse
        {
            Chunks =
            [
                new()
                {
                    Index = 0,
                    PageEnd = 0,
                    PageStart = 0,
                    Text = "text",
                    WordEndIndex = 0,
                    WordStartIndex = 0,
                },
            ],
            ObjectID = "object_id",
            TotalChunks = 0,
            VaultID = "vault_id",
        };

        List<Chunk> expectedChunks =
        [
            new()
            {
                Index = 0,
                PageEnd = 0,
                PageStart = 0,
                Text = "text",
                WordEndIndex = 0,
                WordStartIndex = 0,
            },
        ];
        string expectedObjectID = "object_id";
        long expectedTotalChunks = 0;
        string expectedVaultID = "vault_id";

        Assert.Equal(expectedChunks.Count, model.Chunks.Count);
        for (int i = 0; i < expectedChunks.Count; i++)
        {
            Assert.Equal(expectedChunks[i], model.Chunks[i]);
        }
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedTotalChunks, model.TotalChunks);
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectGetChunksResponse
        {
            Chunks =
            [
                new()
                {
                    Index = 0,
                    PageEnd = 0,
                    PageStart = 0,
                    Text = "text",
                    WordEndIndex = 0,
                    WordStartIndex = 0,
                },
            ],
            ObjectID = "object_id",
            TotalChunks = 0,
            VaultID = "vault_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetChunksResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectGetChunksResponse
        {
            Chunks =
            [
                new()
                {
                    Index = 0,
                    PageEnd = 0,
                    PageStart = 0,
                    Text = "text",
                    WordEndIndex = 0,
                    WordStartIndex = 0,
                },
            ],
            ObjectID = "object_id",
            TotalChunks = 0,
            VaultID = "vault_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGetChunksResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Chunk> expectedChunks =
        [
            new()
            {
                Index = 0,
                PageEnd = 0,
                PageStart = 0,
                Text = "text",
                WordEndIndex = 0,
                WordStartIndex = 0,
            },
        ];
        string expectedObjectID = "object_id";
        long expectedTotalChunks = 0;
        string expectedVaultID = "vault_id";

        Assert.Equal(expectedChunks.Count, deserialized.Chunks.Count);
        for (int i = 0; i < expectedChunks.Count; i++)
        {
            Assert.Equal(expectedChunks[i], deserialized.Chunks[i]);
        }
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedTotalChunks, deserialized.TotalChunks);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectGetChunksResponse
        {
            Chunks =
            [
                new()
                {
                    Index = 0,
                    PageEnd = 0,
                    PageStart = 0,
                    Text = "text",
                    WordEndIndex = 0,
                    WordStartIndex = 0,
                },
            ],
            ObjectID = "object_id",
            TotalChunks = 0,
            VaultID = "vault_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectGetChunksResponse
        {
            Chunks =
            [
                new()
                {
                    Index = 0,
                    PageEnd = 0,
                    PageStart = 0,
                    Text = "text",
                    WordEndIndex = 0,
                    WordStartIndex = 0,
                },
            ],
            ObjectID = "object_id",
            TotalChunks = 0,
            VaultID = "vault_id",
        };

        ObjectGetChunksResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChunkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Chunk
        {
            Index = 0,
            PageEnd = 0,
            PageStart = 0,
            Text = "text",
            WordEndIndex = 0,
            WordStartIndex = 0,
        };

        long expectedIndex = 0;
        long expectedPageEnd = 0;
        long expectedPageStart = 0;
        string expectedText = "text";
        long expectedWordEndIndex = 0;
        long expectedWordStartIndex = 0;

        Assert.Equal(expectedIndex, model.Index);
        Assert.Equal(expectedPageEnd, model.PageEnd);
        Assert.Equal(expectedPageStart, model.PageStart);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedWordEndIndex, model.WordEndIndex);
        Assert.Equal(expectedWordStartIndex, model.WordStartIndex);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Chunk
        {
            Index = 0,
            PageEnd = 0,
            PageStart = 0,
            Text = "text",
            WordEndIndex = 0,
            WordStartIndex = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Chunk>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Chunk
        {
            Index = 0,
            PageEnd = 0,
            PageStart = 0,
            Text = "text",
            WordEndIndex = 0,
            WordStartIndex = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Chunk>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedIndex = 0;
        long expectedPageEnd = 0;
        long expectedPageStart = 0;
        string expectedText = "text";
        long expectedWordEndIndex = 0;
        long expectedWordStartIndex = 0;

        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.Equal(expectedPageEnd, deserialized.PageEnd);
        Assert.Equal(expectedPageStart, deserialized.PageStart);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedWordEndIndex, deserialized.WordEndIndex);
        Assert.Equal(expectedWordStartIndex, deserialized.WordStartIndex);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Chunk
        {
            Index = 0,
            PageEnd = 0,
            PageStart = 0,
            Text = "text",
            WordEndIndex = 0,
            WordStartIndex = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Chunk
        {
            Index = 0,
            PageEnd = 0,
            PageStart = 0,
            Text = "text",
            WordEndIndex = 0,
            WordStartIndex = 0,
        };

        Chunk copied = new(model);

        Assert.Equal(model, copied);
    }
}
