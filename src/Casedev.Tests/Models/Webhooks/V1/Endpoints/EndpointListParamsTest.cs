using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Webhooks.V1.Endpoints;

namespace Casedev.Tests.Models.Webhooks.V1.Endpoints;

public class EndpointListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EndpointListParams
        {
            Limit = 1,
            Status = EndpointListParamsStatus.Active,
        };

        long expectedLimit = 1;
        ApiEnum<string, EndpointListParamsStatus> expectedStatus = EndpointListParamsStatus.Active;

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EndpointListParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EndpointListParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Status = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        EndpointListParams parameters = new()
        {
            Limit = 1,
            Status = EndpointListParamsStatus.Active,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/webhooks/v1/endpoints?limit=1&status=active"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EndpointListParams
        {
            Limit = 1,
            Status = EndpointListParamsStatus.Active,
        };

        EndpointListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EndpointListParamsStatusTest : TestBase
{
    [Theory]
    [InlineData(EndpointListParamsStatus.Active)]
    [InlineData(EndpointListParamsStatus.Disabled)]
    [InlineData(EndpointListParamsStatus.AutoDisabled)]
    public void Validation_Works(EndpointListParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EndpointListParamsStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EndpointListParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EndpointListParamsStatus.Active)]
    [InlineData(EndpointListParamsStatus.Disabled)]
    [InlineData(EndpointListParamsStatus.AutoDisabled)]
    public void SerializationRoundtrip_Works(EndpointListParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EndpointListParamsStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EndpointListParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EndpointListParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EndpointListParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
