using System;
using System.Collections.Generic;
using CaseDev.Models.Webhooks.V1;

namespace CaseDev.Tests.Models.Webhooks.V1;

public class V1CreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1CreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Events = ["string"],
            IsActive = true,
            Secret = "secret",
            URL = "url",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        List<string> expectedEvents = ["string"];
        bool expectedIsActive = true;
        string expectedSecret = "secret";
        string expectedURL = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedSecret, model.Secret);
        Assert.Equal(expectedURL, model.URL);
    }
}
