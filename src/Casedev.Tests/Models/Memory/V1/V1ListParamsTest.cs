using System;
using Casedev.Models.Memory.V1;

namespace Casedev.Tests.Models.Memory.V1;

public class V1ListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ListParams
        {
            Category = "category",
            Limit = 0,
            Offset = 0,
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
        };

        string expectedCategory = "category";
        long expectedLimit = 0;
        long expectedOffset = 0;
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

        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
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
        Assert.Null(parameters.Tag1);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_1"));
        Assert.Null(parameters.Tag10);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_10"));
        Assert.Null(parameters.Tag11);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_11"));
        Assert.Null(parameters.Tag12);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_12"));
        Assert.Null(parameters.Tag2);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_2"));
        Assert.Null(parameters.Tag3);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_3"));
        Assert.Null(parameters.Tag4);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_4"));
        Assert.Null(parameters.Tag5);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_5"));
        Assert.Null(parameters.Tag6);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_6"));
        Assert.Null(parameters.Tag7);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_7"));
        Assert.Null(parameters.Tag8);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_8"));
        Assert.Null(parameters.Tag9);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_9"));
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
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Tag1);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_1"));
        Assert.Null(parameters.Tag10);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_10"));
        Assert.Null(parameters.Tag11);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_11"));
        Assert.Null(parameters.Tag12);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_12"));
        Assert.Null(parameters.Tag2);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_2"));
        Assert.Null(parameters.Tag3);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_3"));
        Assert.Null(parameters.Tag4);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_4"));
        Assert.Null(parameters.Tag5);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_5"));
        Assert.Null(parameters.Tag6);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_6"));
        Assert.Null(parameters.Tag7);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_7"));
        Assert.Null(parameters.Tag8);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_8"));
        Assert.Null(parameters.Tag9);
        Assert.False(parameters.RawQueryData.ContainsKey("tag_9"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ListParams parameters = new()
        {
            Category = "category",
            Limit = 0,
            Offset = 0,
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
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/memory/v1?category=category&limit=0&offset=0&tag_1=tag_1&tag_10=tag_10&tag_11=tag_11&tag_12=tag_12&tag_2=tag_2&tag_3=tag_3&tag_4=tag_4&tag_5=tag_5&tag_6=tag_6&tag_7=tag_7&tag_8=tag_8&tag_9=tag_9"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1ListParams
        {
            Category = "category",
            Limit = 0,
            Offset = 0,
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
        };

        V1ListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
