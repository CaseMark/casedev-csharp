using System;
using Casedev.Models.Mail.V1.Inboxes;

namespace Casedev.Tests.Models.Mail.V1.Inboxes;

public class InboxCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboxCreateParams { Address = "address", DisplayName = "displayName" };

        string expectedAddress = "address";
        string expectedDisplayName = "displayName";

        Assert.Equal(expectedAddress, parameters.Address);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboxCreateParams { };

        Assert.Null(parameters.Address);
        Assert.False(parameters.RawBodyData.ContainsKey("address"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboxCreateParams
        {
            // Null should be interpreted as omitted for these properties
            Address = null,
            DisplayName = null,
        };

        Assert.Null(parameters.Address);
        Assert.False(parameters.RawBodyData.ContainsKey("address"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
    }

    [Fact]
    public void Url_Works()
    {
        InboxCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/mail/v1/inboxes"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboxCreateParams { Address = "address", DisplayName = "displayName" };

        InboxCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
