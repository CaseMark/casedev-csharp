using System;
using System.Collections.Generic;
using Casedev.Models.Vault.Memory;

namespace Casedev.Tests.Models.Vault.Memory;

public class MemoryUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryUpdateParams
        {
            ID = "id",
            EntryID = "entryId",
            Content = "content",
            Source = "source",
            Tags = ["string"],
        };

        string expectedID = "id";
        string expectedEntryID = "entryId";
        string expectedContent = "content";
        string expectedSource = "source";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEntryID, parameters.EntryID);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedSource, parameters.Source);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemoryUpdateParams
        {
            ID = "id",
            EntryID = "entryId",
            Source = "source",
        };

        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemoryUpdateParams
        {
            ID = "id",
            EntryID = "entryId",
            Source = "source",

            // Null should be interpreted as omitted for these properties
            Content = null,
            Tags = null,
        };

        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemoryUpdateParams
        {
            ID = "id",
            EntryID = "entryId",
            Content = "content",
            Tags = ["string"],
        };

        Assert.Null(parameters.Source);
        Assert.False(parameters.RawBodyData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MemoryUpdateParams
        {
            ID = "id",
            EntryID = "entryId",
            Content = "content",
            Tags = ["string"],

            Source = null,
        };

        Assert.Null(parameters.Source);
        Assert.True(parameters.RawBodyData.ContainsKey("source"));
    }

    [Fact]
    public void Url_Works()
    {
        MemoryUpdateParams parameters = new() { ID = "id", EntryID = "entryId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/vault/id/memory/entryId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemoryUpdateParams
        {
            ID = "id",
            EntryID = "entryId",
            Content = "content",
            Source = "source",
            Tags = ["string"],
        };

        MemoryUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
