using System;
using CaseDev.Models.Templates.V1;

namespace CaseDev.Tests.Models.Templates.V1;

public class V1ListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ListParams
        {
            Category = "category",
            Limit = 1,
            Offset = 0,
            Published = true,
            SubCategory = "sub_category",
            Type = "type",
        };

        string expectedCategory = "category";
        long expectedLimit = 1;
        long expectedOffset = 0;
        bool expectedPublished = true;
        string expectedSubCategory = "sub_category";
        string expectedType = "type";

        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedPublished, parameters.Published);
        Assert.Equal(expectedSubCategory, parameters.SubCategory);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ListParams { };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawQueryData.ContainsKey("published"));
        Assert.Null(parameters.SubCategory);
        Assert.False(parameters.RawQueryData.ContainsKey("sub_category"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ListParams
        {
            // Null should be interpreted as omitted for these properties
            Category = null,
            Limit = null,
            Offset = null,
            Published = null,
            SubCategory = null,
            Type = null,
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawQueryData.ContainsKey("published"));
        Assert.Null(parameters.SubCategory);
        Assert.False(parameters.RawQueryData.ContainsKey("sub_category"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ListParams parameters = new()
        {
            Category = "category",
            Limit = 1,
            Offset = 0,
            Published = true,
            SubCategory = "sub_category",
            Type = "type",
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/templates/v1?category=category&limit=1&offset=0&published=true&sub_category=sub_category&type=type"
            ),
            url
        );
    }
}
