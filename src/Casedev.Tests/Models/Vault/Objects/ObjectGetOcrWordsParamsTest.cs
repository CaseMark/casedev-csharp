using System;
using Casedev.Models.Vault.Objects;

namespace Casedev.Tests.Models.Vault.Objects;

public class ObjectGetOcrWordsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ObjectGetOcrWordsParams
        {
            ID = "id",
            ObjectID = "objectId",
            Page = 0,
            WordEnd = 0,
            WordStart = 0,
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        long expectedPage = 0;
        long expectedWordEnd = 0;
        long expectedWordStart = 0;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedWordEnd, parameters.WordEnd);
        Assert.Equal(expectedWordStart, parameters.WordStart);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ObjectGetOcrWordsParams { ID = "id", ObjectID = "objectId" };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.WordEnd);
        Assert.False(parameters.RawQueryData.ContainsKey("wordEnd"));
        Assert.Null(parameters.WordStart);
        Assert.False(parameters.RawQueryData.ContainsKey("wordStart"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ObjectGetOcrWordsParams
        {
            ID = "id",
            ObjectID = "objectId",

            // Null should be interpreted as omitted for these properties
            Page = null,
            WordEnd = null,
            WordStart = null,
        };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.WordEnd);
        Assert.False(parameters.RawQueryData.ContainsKey("wordEnd"));
        Assert.Null(parameters.WordStart);
        Assert.False(parameters.RawQueryData.ContainsKey("wordStart"));
    }

    [Fact]
    public void Url_Works()
    {
        ObjectGetOcrWordsParams parameters = new()
        {
            ID = "id",
            ObjectID = "objectId",
            Page = 0,
            WordEnd = 0,
            WordStart = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/vault/id/objects/objectId/ocr-words?page=0&wordEnd=0&wordStart=0"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ObjectGetOcrWordsParams
        {
            ID = "id",
            ObjectID = "objectId",
            Page = 0,
            WordEnd = 0,
            WordStart = 0,
        };

        ObjectGetOcrWordsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
