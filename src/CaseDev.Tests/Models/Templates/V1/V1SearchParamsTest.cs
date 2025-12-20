using CaseDev.Models.Templates.V1;

namespace CaseDev.Tests.Models.Templates.V1;

public class V1SearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1SearchParams
        {
            Query = "query",
            Category = "category",
            Limit = 1,
        };

        string expectedQuery = "query";
        string expectedCategory = "category";
        long expectedLimit = 1;

        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1SearchParams { Query = "query" };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1SearchParams
        {
            Query = "query",

            // Null should be interpreted as omitted for these properties
            Category = null,
            Limit = null,
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
    }
}
