using System;
using Casedev.Models.Skills.Custom;

namespace Casedev.Tests.Models.Skills.Custom;

public class CustomListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomListParams
        {
            Cursor = "cursor",
            Limit = 1,
            Tag = "tag",
        };

        string expectedCursor = "cursor";
        long expectedLimit = 1;
        string expectedTag = "tag";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedTag, parameters.Tag);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Tag);
        Assert.False(parameters.RawQueryData.ContainsKey("tag"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
            Tag = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Tag);
        Assert.False(parameters.RawQueryData.ContainsKey("tag"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomListParams parameters = new()
        {
            Cursor = "cursor",
            Limit = 1,
            Tag = "tag",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/skills/custom?cursor=cursor&limit=1&tag=tag"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomListParams
        {
            Cursor = "cursor",
            Limit = 1,
            Tag = "tag",
        };

        CustomListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
