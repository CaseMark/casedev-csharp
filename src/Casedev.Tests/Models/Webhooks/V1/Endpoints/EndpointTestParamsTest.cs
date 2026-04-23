using System;
using System.Text.Json;
using Casedev.Models.Webhooks.V1.Endpoints;

namespace Casedev.Tests.Models.Webhooks.V1.Endpoints;

public class EndpointTestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EndpointTestParams
        {
            ID = "id",
            EventType = "eventType",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedID = "id";
        string expectedEventType = "eventType";
        JsonElement expectedPayload = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.NotNull(parameters.Payload);
        Assert.True(JsonElement.DeepEquals(expectedPayload, parameters.Payload.Value));
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EndpointTestParams { ID = "id" };

        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawBodyData.ContainsKey("eventType"));
        Assert.Null(parameters.Payload);
        Assert.False(parameters.RawBodyData.ContainsKey("payload"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EndpointTestParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            EventType = null,
            Payload = null,
        };

        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawBodyData.ContainsKey("eventType"));
        Assert.Null(parameters.Payload);
        Assert.False(parameters.RawBodyData.ContainsKey("payload"));
    }

    [Fact]
    public void Url_Works()
    {
        EndpointTestParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/webhooks/v1/endpoints/id/test"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EndpointTestParams
        {
            ID = "id",
            EventType = "eventType",
            Payload = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        EndpointTestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
