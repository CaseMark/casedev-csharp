using System;
using System.Collections.Generic;
using Router.Models.Vault.Events.Subscriptions;

namespace Router.Tests.Models.Vault.Events.Subscriptions;

public class SubscriptionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            ID = "id",
            SubscriptionID = "subscriptionId",
            CallbackUrl = "https://example.com",
            ClearSigningSecret = true,
            EventTypes = ["string"],
            IsActive = true,
            ObjectIds = ["string"],
            SigningSecret = "signingSecret",
        };

        string expectedID = "id";
        string expectedSubscriptionID = "subscriptionId";
        string expectedCallbackUrl = "https://example.com";
        bool expectedClearSigningSecret = true;
        List<string> expectedEventTypes = ["string"];
        bool expectedIsActive = true;
        List<string> expectedObjectIds = ["string"];
        string expectedSigningSecret = "signingSecret";

        Assert.Equal(expectedID, parameters.ID);
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
        var parameters = new SubscriptionUpdateParams
        {
            ID = "id",
            SubscriptionID = "subscriptionId",
        };

        Assert.Null(parameters.CallbackUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("callbackUrl"));
        Assert.Null(parameters.ClearSigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("clearSigningSecret"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
        Assert.Null(parameters.ObjectIds);
        Assert.False(parameters.RawBodyData.ContainsKey("objectIds"));
        Assert.Null(parameters.SigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("signingSecret"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            ID = "id",
            SubscriptionID = "subscriptionId",

            // Null should be interpreted as omitted for these properties
            CallbackUrl = null,
            ClearSigningSecret = null,
            EventTypes = null,
            IsActive = null,
            ObjectIds = null,
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
        Assert.Null(parameters.ObjectIds);
        Assert.False(parameters.RawBodyData.ContainsKey("objectIds"));
        Assert.Null(parameters.SigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("signingSecret"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionUpdateParams parameters = new()
        {
            ID = "id",
            SubscriptionID = "subscriptionId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/vault/id/events/subscriptions/subscriptionId"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionUpdateParams
        {
            ID = "id",
            SubscriptionID = "subscriptionId",
            CallbackUrl = "https://example.com",
            ClearSigningSecret = true,
            EventTypes = ["string"],
            IsActive = true,
            ObjectIds = ["string"],
            SigningSecret = "signingSecret",
        };

        SubscriptionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
