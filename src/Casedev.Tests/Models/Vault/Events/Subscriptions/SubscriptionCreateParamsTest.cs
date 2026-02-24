using System;
using System.Collections.Generic;
using Casedev.Models.Vault.Events.Subscriptions;

namespace Casedev.Tests.Models.Vault.Events.Subscriptions;

public class SubscriptionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            ID = "id",
            CallbackUrl = "https://example.com",
            EventTypes = ["string"],
            ObjectIds = ["string"],
            SigningSecret = "signingSecret",
        };

        string expectedID = "id";
        string expectedCallbackUrl = "https://example.com";
        List<string> expectedEventTypes = ["string"];
        List<string> expectedObjectIds = ["string"];
        string expectedSigningSecret = "signingSecret";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCallbackUrl, parameters.CallbackUrl);
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.NotNull(parameters.ObjectIds);
        Assert.Equal(expectedObjectIds.Count, parameters.ObjectIds.Count);
        for (int i = 0; i < expectedObjectIds.Count; i++)
        {
            Assert.Equal(expectedObjectIds[i], parameters.ObjectIds[i]);
        }
        Assert.Equal(expectedSigningSecret, parameters.SigningSecret);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            ID = "id",
            CallbackUrl = "https://example.com",
        };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.ObjectIds);
        Assert.False(parameters.RawBodyData.ContainsKey("objectIds"));
        Assert.Null(parameters.SigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("signingSecret"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            ID = "id",
            CallbackUrl = "https://example.com",

            // Null should be interpreted as omitted for these properties
            EventTypes = null,
            ObjectIds = null,
            SigningSecret = null,
        };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.ObjectIds);
        Assert.False(parameters.RawBodyData.ContainsKey("objectIds"));
        Assert.Null(parameters.SigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("signingSecret"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionCreateParams parameters = new()
        {
            ID = "id",
            CallbackUrl = "https://example.com",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/events/subscriptions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            ID = "id",
            CallbackUrl = "https://example.com",
            EventTypes = ["string"],
            ObjectIds = ["string"],
            SigningSecret = "signingSecret",
        };

        SubscriptionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
