using System;
using System.Text.Json;
using Casedev.Models.Webhooks.V1.Deliveries;

namespace Casedev.Tests.Models.Webhooks.V1.Deliveries;

public class DeliveryReplayParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeliveryReplayParams
        {
            ID = "id",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedID = "id";
        JsonElement expectedPayload = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.Payload);
        Assert.True(JsonElement.DeepEquals(expectedPayload, parameters.Payload.Value));
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DeliveryReplayParams { ID = "id" };

        Assert.Null(parameters.Payload);
        Assert.False(parameters.RawBodyData.ContainsKey("payload"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DeliveryReplayParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Payload = null,
        };

        Assert.Null(parameters.Payload);
        Assert.False(parameters.RawBodyData.ContainsKey("payload"));
    }

    [Fact]
    public void Url_Works()
    {
        DeliveryReplayParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/webhooks/v1/deliveries/id/replay"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeliveryReplayParams
        {
            ID = "id",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        DeliveryReplayParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
