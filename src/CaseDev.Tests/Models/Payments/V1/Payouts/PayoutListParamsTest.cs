using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Payments.V1.Payouts;

namespace CaseDev.Tests.Models.Payments.V1.Payouts;

public class PayoutListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PayoutListParams
        {
            FromAccountID = "from_account_id",
            Limit = 0,
            Offset = 0,
            PartyID = "party_id",
            Status = Status.Pending,
        };

        string expectedFromAccountID = "from_account_id";
        long expectedLimit = 0;
        long expectedOffset = 0;
        string expectedPartyID = "party_id";
        ApiEnum<string, Status> expectedStatus = Status.Pending;

        Assert.Equal(expectedFromAccountID, parameters.FromAccountID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedPartyID, parameters.PartyID);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PayoutListParams { };

        Assert.Null(parameters.FromAccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("from_account_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.PartyID);
        Assert.False(parameters.RawQueryData.ContainsKey("party_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PayoutListParams
        {
            // Null should be interpreted as omitted for these properties
            FromAccountID = null,
            Limit = null,
            Offset = null,
            PartyID = null,
            Status = null,
        };

        Assert.Null(parameters.FromAccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("from_account_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.PartyID);
        Assert.False(parameters.RawQueryData.ContainsKey("party_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        PayoutListParams parameters = new()
        {
            FromAccountID = "from_account_id",
            Limit = 0,
            Offset = 0,
            PartyID = "party_id",
            Status = Status.Pending,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/payments/v1/payouts?from_account_id=from_account_id&limit=0&offset=0&party_id=party_id&status=pending"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PayoutListParams
        {
            FromAccountID = "from_account_id",
            Limit = 0,
            Offset = 0,
            PartyID = "party_id",
            Status = Status.Pending,
        };

        PayoutListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Processing)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Cancelled)]
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
    [InlineData(Status.Processing)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Cancelled)]
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
