using System;
using System.Collections.Generic;
using Casedev.Models.Usage.V1.Subscriptions;

namespace Casedev.Tests.Models.Usage.V1.Subscriptions;

public class SubscriptionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscriptionId",
            CallbackUrl = "https://example.com",
            ClearSigningSecret = true,
            EventTypes = ["string"],
            IsActive = true,
            SigningSecret = "signingSecret",
        };

        string expectedSubscriptionID = "subscriptionId";
        string expectedCallbackUrl = "https://example.com";
        bool expectedClearSigningSecret = true;
        List<string> expectedEventTypes = ["string"];
        bool expectedIsActive = true;
        string expectedSigningSecret = "signingSecret";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedCallbackUrl, parameters.CallbackUrl);
        Assert.Equal(expectedClearSigningSecret, parameters.ClearSigningSecret);
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, parameters.IsActive);
        Assert.Equal(expectedSigningSecret, parameters.SigningSecret);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateParams { SubscriptionID = "subscriptionId" };

        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callbackUrl"));
        Assert.Null(parameters.ClearSigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("clearSigningSecret"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
        Assert.Null(parameters.SigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("signingSecret"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscriptionId",

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            ClearSigningSecret = null,
            EventTypes = null,
            IsActive = null,
            SigningSecret = null,
        };

        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callbackUrl"));
        Assert.Null(parameters.ClearSigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("clearSigningSecret"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
        Assert.Null(parameters.SigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("signingSecret"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionUpdateParams parameters = new() { SubscriptionID = "subscriptionId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/usage/v1/subscriptions/subscriptionId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            SubscriptionID = "subscriptionId",
            CallbackUrl = "https://example.com",
            ClearSigningSecret = true,
            EventTypes = ["string"],
            IsActive = true,
            SigningSecret = "signingSecret",
        };

        SubscriptionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
