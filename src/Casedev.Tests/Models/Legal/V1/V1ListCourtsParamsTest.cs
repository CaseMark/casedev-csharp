using System;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1ListCourtsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ListCourtsParams
        {
            InUseOnly = true,
            Jurisdiction = "jurisdiction",
            Limit = 1,
            Offset = 0,
            Query = "xx",
        };

        bool expectedInUseOnly = true;
        string expectedJurisdiction = "jurisdiction";
        long expectedLimit = 1;
        long expectedOffset = 0;
        string expectedQuery = "xx";

        Assert.Equal(expectedInUseOnly, parameters.InUseOnly);
        Assert.Equal(expectedJurisdiction, parameters.Jurisdiction);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedQuery, parameters.Query);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ListCourtsParams { };

        Assert.Null(parameters.InUseOnly);
        Assert.False(parameters.RawBodyData.ContainsKey("inUseOnly"));
        Assert.Null(parameters.Jurisdiction);
        Assert.False(parameters.RawBodyData.ContainsKey("jurisdiction"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawBodyData.ContainsKey("query"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ListCourtsParams
        {
            // Null should be interpreted as omitted for these properties
            InUseOnly = null,
            Jurisdiction = null,
            Limit = null,
            Offset = null,
            Query = null,
        };

        Assert.Null(parameters.InUseOnly);
        Assert.False(parameters.RawBodyData.ContainsKey("inUseOnly"));
        Assert.Null(parameters.Jurisdiction);
        Assert.False(parameters.RawBodyData.ContainsKey("jurisdiction"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawBodyData.ContainsKey("query"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ListCourtsParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/courts"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1ListCourtsParams
        {
            InUseOnly = true,
            Jurisdiction = "jurisdiction",
            Limit = 1,
            Offset = 0,
            Query = "xx",
        };

        V1ListCourtsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
