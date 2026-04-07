using System;
using Casedev.Models.Usage.V1.Subscriptions;

namespace Casedev.Tests.Models.Usage.V1.Subscriptions;

public class SubscriptionDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionDeleteParams { SubscriptionID = "subscriptionId" };

        string expectedSubscriptionID = "subscriptionId";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionDeleteParams parameters = new() { SubscriptionID = "subscriptionId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/usage/v1/subscriptions/subscriptionId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionDeleteParams { SubscriptionID = "subscriptionId" };

        SubscriptionDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
