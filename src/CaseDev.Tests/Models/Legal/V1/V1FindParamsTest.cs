using System;
using CaseDev.Models.Legal.V1;

namespace CaseDev.Tests.Models.Legal.V1;

public class V1FindParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1FindParams
        {
            Query = "xxx",
            Jurisdiction = "jurisdiction",
            NumResults = 1,
        };

        string expectedQuery = "xxx";
        string expectedJurisdiction = "jurisdiction";
        long expectedNumResults = 1;

        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedJurisdiction, parameters.Jurisdiction);
        Assert.Equal(expectedNumResults, parameters.NumResults);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1FindParams { Query = "xxx" };

        Assert.Null(parameters.Jurisdiction);
        Assert.False(parameters.RawBodyData.ContainsKey("jurisdiction"));
        Assert.Null(parameters.NumResults);
        Assert.False(parameters.RawBodyData.ContainsKey("numResults"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1FindParams
        {
            Query = "xxx",

            // Null should be interpreted as omitted for these properties
            Jurisdiction = null,
            NumResults = null,
        };

        Assert.Null(parameters.Jurisdiction);
        Assert.False(parameters.RawBodyData.ContainsKey("jurisdiction"));
        Assert.Null(parameters.NumResults);
        Assert.False(parameters.RawBodyData.ContainsKey("numResults"));
    }

    [Fact]
    public void Url_Works()
    {
        V1FindParams parameters = new() { Query = "xxx" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/find"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1FindParams
        {
            Query = "xxx",
            Jurisdiction = "jurisdiction",
            NumResults = 1,
        };

        V1FindParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
