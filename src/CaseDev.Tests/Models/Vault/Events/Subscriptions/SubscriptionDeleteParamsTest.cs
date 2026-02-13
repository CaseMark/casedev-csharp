using System;
using CaseDev.Models.Vault.Events.Subscriptions;

namespace CaseDev.Tests.Models.Vault.Events.Subscriptions;

public class SubscriptionDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionDeleteParams
        {
            ID = "id",
            SubscriptionID = "subscriptionId",
        };

        string expectedID = "id";
        string expectedSubscriptionID = "subscriptionId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionDeleteParams parameters = new()
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
        var parameters = new SubscriptionDeleteParams
        {
            ID = "id",
            SubscriptionID = "subscriptionId",
        };

        SubscriptionDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
