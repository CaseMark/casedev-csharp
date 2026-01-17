using System;
using CaseDev.Models.Compute.V1;

namespace CaseDev.Tests.Models.Compute.V1;

public class V1GetUsageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1GetUsageParams { Month = 3, Year = 2024 };

        long expectedMonth = 3;
        long expectedYear = 2024;

        Assert.Equal(expectedMonth, parameters.Month);
        Assert.Equal(expectedYear, parameters.Year);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1GetUsageParams { };

        Assert.Null(parameters.Month);
        Assert.False(parameters.RawQueryData.ContainsKey("month"));
        Assert.Null(parameters.Year);
        Assert.False(parameters.RawQueryData.ContainsKey("year"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1GetUsageParams
        {
            // Null should be interpreted as omitted for these properties
            Month = null,
            Year = null,
        };

        Assert.Null(parameters.Month);
        Assert.False(parameters.RawQueryData.ContainsKey("month"));
        Assert.Null(parameters.Year);
        Assert.False(parameters.RawQueryData.ContainsKey("year"));
    }

    [Fact]
    public void Url_Works()
    {
        V1GetUsageParams parameters = new() { Month = 3, Year = 2024 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/compute/v1/usage?month=3&year=2024"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1GetUsageParams { Month = 3, Year = 2024 };

        V1GetUsageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
