using System;
using System.Collections.Generic;
using Casedev.Models.Vault.Memory;

namespace Casedev.Tests.Models.Vault.Memory;

public class MemorySearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemorySearchParams
        {
            ID = "id",
            Query = "query",
            Limit = 1,
            Tags = ["string"],
            Types = ["string"],
        };

        string expectedID = "id";
        string expectedQuery = "query";
        long expectedLimit = 1;
        List<string> expectedTags = ["string"];
        List<string> expectedTypes = ["string"];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
        Assert.NotNull(parameters.Types);
        Assert.Equal(expectedTypes.Count, parameters.Types.Count);
        for (int i = 0; i < expectedTypes.Count; i++)
        {
            Assert.Equal(expectedTypes[i], parameters.Types[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemorySearchParams { ID = "id", Query = "query" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.Types);
        Assert.False(parameters.RawBodyData.ContainsKey("types"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemorySearchParams
        {
            ID = "id",
            Query = "query",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Tags = null,
            Types = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.Types);
        Assert.False(parameters.RawBodyData.ContainsKey("types"));
    }

    [Fact]
    public void Url_Works()
    {
        MemorySearchParams parameters = new() { ID = "id", Query = "query" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/vault/id/memory/search"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemorySearchParams
        {
            ID = "id",
            Query = "query",
            Limit = 1,
            Tags = ["string"],
            Types = ["string"],
        };

        MemorySearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
