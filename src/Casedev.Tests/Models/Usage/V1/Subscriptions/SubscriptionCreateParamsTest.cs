using System;
using System.Collections.Generic;
using Casedev.Models.Usage.V1.Subscriptions;

namespace Casedev.Tests.Models.Usage.V1.Subscriptions;

public class SubscriptionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            CallbackUrl = "https://example.com",
            EventTypes = ["string"],
            SigningSecret = "signingSecret",
        };

        string expectedCallbackUrl = "https://example.com";
        List<string> expectedEventTypes = ["string"];
        string expectedSigningSecret = "signingSecret";

        Assert.Equal(expectedCallbackUrl, parameters.CallbackUrl);
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedSigningSecret, parameters.SigningSecret);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionCreateParams { CallbackUrl = "https://example.com" };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.SigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("signingSecret"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            CallbackUrl = "https://example.com",

            // Null should be interpreted as omitted for these properties
            EventTypes = null,
            SigningSecret = null,
        };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.SigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("signingSecret"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionCreateParams parameters = new() { CallbackUrl = "https://example.com" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/usage/v1/subscriptions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            CallbackUrl = "https://example.com",
            EventTypes = ["string"],
            SigningSecret = "signingSecret",
        };

        SubscriptionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
