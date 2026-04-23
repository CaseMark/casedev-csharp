using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Webhooks.V1.Deliveries;

namespace Casedev.Tests.Models.Webhooks.V1.Deliveries;

public class DeliveryListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeliveryListParams
        {
            EndpointID = "endpoint_id",
            Limit = 1,
            Status = Status.Pending,
        };

        string expectedEndpointID = "endpoint_id";
        long expectedLimit = 1;
        ApiEnum<string, Status> expectedStatus = Status.Pending;

        Assert.Equal(expectedEndpointID, parameters.EndpointID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DeliveryListParams { };

        Assert.Null(parameters.EndpointID);
        Assert.False(parameters.RawQueryData.ContainsKey("endpoint_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DeliveryListParams
        {
            // Null should be interpreted as omitted for these properties
            EndpointID = null,
            Limit = null,
            Status = null,
        };

        Assert.Null(parameters.EndpointID);
        Assert.False(parameters.RawQueryData.ContainsKey("endpoint_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        DeliveryListParams parameters = new()
        {
            EndpointID = "endpoint_id",
            Limit = 1,
            Status = Status.Pending,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.case.dev/webhooks/v1/deliveries?endpoint_id=endpoint_id&limit=1&status=pending"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeliveryListParams
        {
            EndpointID = "endpoint_id",
            Limit = 1,
            Status = Status.Pending,
        };

        DeliveryListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Delivered)]
    [InlineData(Status.Failed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Delivered)]
    [InlineData(Status.Failed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
