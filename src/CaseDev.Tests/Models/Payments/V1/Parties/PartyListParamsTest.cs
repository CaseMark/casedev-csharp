using System;
using CaseDev.Models.Payments.V1.Parties;

namespace CaseDev.Tests.Models.Payments.V1.Parties;

public class PartyListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PartyListParams
        {
            Limit = 0,
            Offset = 0,
            Role = "role",
            Type = "type",
        };

        long expectedLimit = 0;
        long expectedOffset = 0;
        string expectedRole = "role";
        string expectedType = "type";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedRole, parameters.Role);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PartyListParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Role);
        Assert.False(parameters.RawQueryData.ContainsKey("role"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PartyListParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
            Role = null,
            Type = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Role);
        Assert.False(parameters.RawQueryData.ContainsKey("role"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        PartyListParams parameters = new()
        {
            Limit = 0,
            Offset = 0,
            Role = "role",
            Type = "type",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/payments/v1/parties?limit=0&offset=0&role=role&type=type"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PartyListParams
        {
            Limit = 0,
            Offset = 0,
            Role = "role",
            Type = "type",
        };

        PartyListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
