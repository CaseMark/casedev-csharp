using System;
using Casedev.Models.Memory.V1;

namespace Casedev.Tests.Models.Memory.V1;

public class V1SearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1SearchParams
        {
            Query = "query",
            Category = "category",
            Tag1 = "tag_1",
            Tag10 = "tag_10",
            Tag11 = "tag_11",
            Tag12 = "tag_12",
            Tag2 = "tag_2",
            Tag3 = "tag_3",
            Tag4 = "tag_4",
            Tag5 = "tag_5",
            Tag6 = "tag_6",
            Tag7 = "tag_7",
            Tag8 = "tag_8",
            Tag9 = "tag_9",
            TopK = 1,
        };

        string expectedQuery = "query";
        string expectedCategory = "category";
        string expectedTag1 = "tag_1";
        string expectedTag10 = "tag_10";
        string expectedTag11 = "tag_11";
        string expectedTag12 = "tag_12";
        string expectedTag2 = "tag_2";
        string expectedTag3 = "tag_3";
        string expectedTag4 = "tag_4";
        string expectedTag5 = "tag_5";
        string expectedTag6 = "tag_6";
        string expectedTag7 = "tag_7";
        string expectedTag8 = "tag_8";
        string expectedTag9 = "tag_9";
        long expectedTopK = 1;

        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedTag1, parameters.Tag1);
        Assert.Equal(expectedTag10, parameters.Tag10);
        Assert.Equal(expectedTag11, parameters.Tag11);
        Assert.Equal(expectedTag12, parameters.Tag12);
        Assert.Equal(expectedTag2, parameters.Tag2);
        Assert.Equal(expectedTag3, parameters.Tag3);
        Assert.Equal(expectedTag4, parameters.Tag4);
        Assert.Equal(expectedTag5, parameters.Tag5);
        Assert.Equal(expectedTag6, parameters.Tag6);
        Assert.Equal(expectedTag7, parameters.Tag7);
        Assert.Equal(expectedTag8, parameters.Tag8);
        Assert.Equal(expectedTag9, parameters.Tag9);
        Assert.Equal(expectedTopK, parameters.TopK);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1SearchParams { Query = "query" };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Tag1);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_1"));
        Assert.Null(parameters.Tag10);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_10"));
        Assert.Null(parameters.Tag11);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_11"));
        Assert.Null(parameters.Tag12);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_12"));
        Assert.Null(parameters.Tag2);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_2"));
        Assert.Null(parameters.Tag3);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_3"));
        Assert.Null(parameters.Tag4);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_4"));
        Assert.Null(parameters.Tag5);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_5"));
        Assert.Null(parameters.Tag6);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_6"));
        Assert.Null(parameters.Tag7);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_7"));
        Assert.Null(parameters.Tag8);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_8"));
        Assert.Null(parameters.Tag9);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_9"));
        Assert.Null(parameters.TopK);
        Assert.False(parameters.RawBodyData.ContainsKey("top_k"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1SearchParams
        {
            Query = "query",

            // Null should be interpreted as omitted for these properties
            Category = null,
            Tag1 = null,
            Tag10 = null,
            Tag11 = null,
            Tag12 = null,
            Tag2 = null,
            Tag3 = null,
            Tag4 = null,
            Tag5 = null,
            Tag6 = null,
            Tag7 = null,
            Tag8 = null,
            Tag9 = null,
            TopK = null,
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Tag1);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_1"));
        Assert.Null(parameters.Tag10);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_10"));
        Assert.Null(parameters.Tag11);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_11"));
        Assert.Null(parameters.Tag12);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_12"));
        Assert.Null(parameters.Tag2);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_2"));
        Assert.Null(parameters.Tag3);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_3"));
        Assert.Null(parameters.Tag4);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_4"));
        Assert.Null(parameters.Tag5);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_5"));
        Assert.Null(parameters.Tag6);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_6"));
        Assert.Null(parameters.Tag7);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_7"));
        Assert.Null(parameters.Tag8);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_8"));
        Assert.Null(parameters.Tag9);
        Assert.False(parameters.RawBodyData.ContainsKey("tag_9"));
        Assert.Null(parameters.TopK);
        Assert.False(parameters.RawBodyData.ContainsKey("top_k"));
    }

    [Fact]
    public void Url_Works()
    {
        V1SearchParams parameters = new() { Query = "query" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/memory/v1/search"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1SearchParams
        {
            Query = "query",
            Category = "category",
            Tag1 = "tag_1",
            Tag10 = "tag_10",
            Tag11 = "tag_11",
            Tag12 = "tag_12",
            Tag2 = "tag_2",
            Tag3 = "tag_3",
            Tag4 = "tag_4",
            Tag5 = "tag_5",
            Tag6 = "tag_6",
            Tag7 = "tag_7",
            Tag8 = "tag_8",
            Tag9 = "tag_9",
            TopK = 1,
        };

        V1SearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
