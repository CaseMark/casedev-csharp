using System;
using Router.Models.Search.V1;

namespace Router.Tests.Models.Search.V1;

public class V1RetrieveResearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1RetrieveResearchParams
        {
            ID = "id",
            Events = "events",
            Stream = true,
        };

        string expectedID = "id";
        string expectedEvents = "events";
        bool expectedStream = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEvents, parameters.Events);
        Assert.Equal(expectedStream, parameters.Stream);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1RetrieveResearchParams { ID = "id" };

        Assert.Null(parameters.Events);
        Assert.False(parameters.RawQueryData.ContainsKey("events"));
        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawQueryData.ContainsKey("stream"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1RetrieveResearchParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Events = null,
            Stream = null,
        };

        Assert.Null(parameters.Events);
        Assert.False(parameters.RawQueryData.ContainsKey("events"));
        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawQueryData.ContainsKey("stream"));
    }

    [Fact]
    public void Url_Works()
    {
        V1RetrieveResearchParams parameters = new()
        {
            ID = "id",
            Events = "events",
            Stream = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/search/v1/research/id?events=events&stream=true"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1RetrieveResearchParams
        {
            ID = "id",
            Events = "events",
            Stream = true,
        };

        V1RetrieveResearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
