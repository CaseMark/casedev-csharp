using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1ContentsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ContentsResponse
        {
            Results =
            [
                new()
                {
                    Highlights = ["string"],
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Summary = "summary",
                    Text = "text",
                    Title = "title",
                    URL = "url",
                },
            ],
        };

        List<Result> expectedResults =
        [
            new()
            {
                Highlights = ["string"],
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Summary = "summary",
                Text = "text",
                Title = "title",
                URL = "url",
            },
        ];

        Assert.NotNull(model.Results);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1ContentsResponse
        {
            Results =
            [
                new()
                {
                    Highlights = ["string"],
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Summary = "summary",
                    Text = "text",
                    Title = "title",
                    URL = "url",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ContentsResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ContentsResponse
        {
            Results =
            [
                new()
                {
                    Highlights = ["string"],
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Summary = "summary",
                    Text = "text",
                    Title = "title",
                    URL = "url",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1ContentsResponse>(json);
        Assert.NotNull(deserialized);

        List<Result> expectedResults =
        [
            new()
            {
                Highlights = ["string"],
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                Summary = "summary",
                Text = "text",
                Title = "title",
                URL = "url",
            },
        ];

        Assert.NotNull(deserialized.Results);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1ContentsResponse
        {
            Results =
            [
                new()
                {
                    Highlights = ["string"],
                    Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Summary = "summary",
                    Text = "text",
                    Title = "title",
                    URL = "url",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ContentsResponse { };

        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ContentsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ContentsResponse
        {
            // Null should be interpreted as omitted for these properties
            Results = null,
        };

        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1ContentsResponse
        {
            // Null should be interpreted as omitted for these properties
            Results = null,
        };

        model.Validate();
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            Highlights = ["string"],
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Summary = "summary",
            Text = "text",
            Title = "title",
            URL = "url",
        };

        List<string> expectedHighlights = ["string"];
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedSummary = "summary";
        string expectedText = "text";
        string expectedTitle = "title";
        string expectedURL = "url";

        Assert.NotNull(model.Highlights);
        Assert.Equal(expectedHighlights.Count, model.Highlights.Count);
        for (int i = 0; i < expectedHighlights.Count; i++)
        {
            Assert.Equal(expectedHighlights[i], model.Highlights[i]);
        }
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedSummary, model.Summary);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedURL, model.URL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            Highlights = ["string"],
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Summary = "summary",
            Text = "text",
            Title = "title",
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            Highlights = ["string"],
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Summary = "summary",
            Text = "text",
            Title = "title",
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(json);
        Assert.NotNull(deserialized);

        List<string> expectedHighlights = ["string"];
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedSummary = "summary";
        string expectedText = "text";
        string expectedTitle = "title";
        string expectedURL = "url";

        Assert.NotNull(deserialized.Highlights);
        Assert.Equal(expectedHighlights.Count, deserialized.Highlights.Count);
        for (int i = 0; i < expectedHighlights.Count; i++)
        {
            Assert.Equal(expectedHighlights[i], deserialized.Highlights[i]);
        }
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedSummary, deserialized.Summary);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedURL, deserialized.URL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            Highlights = ["string"],
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Summary = "summary",
            Text = "text",
            Title = "title",
            URL = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result { };

        Assert.Null(model.Highlights);
        Assert.False(model.RawData.ContainsKey("highlights"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.URL);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Result
        {
            // Null should be interpreted as omitted for these properties
            Highlights = null,
            Metadata = null,
            Summary = null,
            Text = null,
            Title = null,
            URL = null,
        };

        Assert.Null(model.Highlights);
        Assert.False(model.RawData.ContainsKey("highlights"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.URL);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            // Null should be interpreted as omitted for these properties
            Highlights = null,
            Metadata = null,
            Summary = null,
            Text = null,
            Title = null,
            URL = null,
        };

        model.Validate();
    }
}
