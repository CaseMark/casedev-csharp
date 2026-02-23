using System;
using System.Collections.Generic;
using System.Text.Json;
using Router.Models.Vault.Events.Subscriptions;

namespace Router.Tests.Models.Vault.Events.Subscriptions;

public class SubscriptionTestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionTestParams
        {
            ID = "id",
            SubscriptionID = "subscriptionId",
            EventType = "eventType",
            ObjectID = "objectId",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedID = "id";
        string expectedSubscriptionID = "subscriptionId";
        string expectedEventType = "eventType";
        string expectedObjectID = "objectId";
        Dictionary<string, JsonElement> expectedPayload = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.NotNull(parameters.Payload);
        Assert.Equal(expectedPayload.Count, parameters.Payload.Count);
        foreach (var item in expectedPayload)
        {
            Assert.True(parameters.Payload.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Payload[item.Key]));
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionTestParams
        {
            ID = "id",
            SubscriptionID = "subscriptionId",
        };

        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawBodyData.ContainsKey("eventType"));
        Assert.Null(parameters.ObjectID);
        Assert.False(parameters.RawBodyData.ContainsKey("objectId"));
        Assert.Null(parameters.Payload);
        Assert.False(parameters.RawBodyData.ContainsKey("payload"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionTestParams
        {
            ID = "id",
            SubscriptionID = "subscriptionId",

            // Null should be interpreted as omitted for these properties
            EventType = null,
            ObjectID = null,
            Payload = null,
        };

        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawBodyData.ContainsKey("eventType"));
        Assert.Null(parameters.ObjectID);
        Assert.False(parameters.RawBodyData.ContainsKey("objectId"));
        Assert.Null(parameters.Payload);
        Assert.False(parameters.RawBodyData.ContainsKey("payload"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionTestParams parameters = new() { ID = "id", SubscriptionID = "subscriptionId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/vault/id/events/subscriptions/subscriptionId/test"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionTestParams
        {
            ID = "id",
            SubscriptionID = "subscriptionId",
            EventType = "eventType",
            ObjectID = "objectId",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        SubscriptionTestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
