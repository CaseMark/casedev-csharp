using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Usage.V1;

namespace Casedev.Tests.Models.Usage.V1;

public class V1RetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1RetrieveParams
        {
            Granularity = Granularity.Summary,
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, Granularity> expectedGranularity = Granularity.Summary;
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedGranularity, parameters.Granularity);
        Assert.Equal(expectedPeriodEnd, parameters.PeriodEnd);
        Assert.Equal(expectedPeriodStart, parameters.PeriodStart);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1RetrieveParams { };

        Assert.Null(parameters.Granularity);
        Assert.False(parameters.RawQueryData.ContainsKey("granularity"));
        Assert.Null(parameters.PeriodEnd);
        Assert.False(parameters.RawQueryData.ContainsKey("periodEnd"));
        Assert.Null(parameters.PeriodStart);
        Assert.False(parameters.RawQueryData.ContainsKey("periodStart"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1RetrieveParams
        {
            // Null should be interpreted as omitted for these properties
            Granularity = null,
            PeriodEnd = null,
            PeriodStart = null,
        };

        Assert.Null(parameters.Granularity);
        Assert.False(parameters.RawQueryData.ContainsKey("granularity"));
        Assert.Null(parameters.PeriodEnd);
        Assert.False(parameters.RawQueryData.ContainsKey("periodEnd"));
        Assert.Null(parameters.PeriodStart);
        Assert.False(parameters.RawQueryData.ContainsKey("periodStart"));
    }

    [Fact]
    public void Url_Works()
    {
        V1RetrieveParams parameters = new()
        {
            Granularity = Granularity.Summary,
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.case.dev/usage/v1?granularity=summary&periodEnd=2019-12-27T18%3a11%3a19.117%2b00%3a00&periodStart=2019-12-27T18%3a11%3a19.117%2b00%3a00"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1RetrieveParams
        {
            Granularity = Granularity.Summary,
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        V1RetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class GranularityTest : TestBase
{
    [Theory]
    [InlineData(Granularity.Summary)]
    [InlineData(Granularity.Daily)]
    public void Validation_Works(Granularity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Granularity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Granularity.Summary)]
    [InlineData(Granularity.Daily)]
    public void SerializationRoundtrip_Works(Granularity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Granularity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
