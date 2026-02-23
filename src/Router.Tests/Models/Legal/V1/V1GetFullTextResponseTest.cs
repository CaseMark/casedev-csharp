using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Models.Legal.V1;

namespace Router.Tests.Models.Legal.V1;

public class V1GetFullTextResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1GetFullTextResponse
        {
            Author = "author",
            CharacterCount = 0,
            Highlights = ["string"],
            PublishedDate = "publishedDate",
            Summary = "summary",
            Text = "text",
            Title = "title",
            Url = "url",
        };

        string expectedAuthor = "author";
        long expectedCharacterCount = 0;
        List<string> expectedHighlights = ["string"];
        string expectedPublishedDate = "publishedDate";
        string expectedSummary = "summary";
        string expectedText = "text";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedAuthor, model.Author);
        Assert.Equal(expectedCharacterCount, model.CharacterCount);
        Assert.NotNull(model.Highlights);
        Assert.Equal(expectedHighlights.Count, model.Highlights.Count);
        for (int i = 0; i < expectedHighlights.Count; i++)
        {
            Assert.Equal(expectedHighlights[i], model.Highlights[i]);
        }
        Assert.Equal(expectedPublishedDate, model.PublishedDate);
        Assert.Equal(expectedSummary, model.Summary);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1GetFullTextResponse
        {
            Author = "author",
            CharacterCount = 0,
            Highlights = ["string"],
            PublishedDate = "publishedDate",
            Summary = "summary",
            Text = "text",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1GetFullTextResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1GetFullTextResponse
        {
            Author = "author",
            CharacterCount = 0,
            Highlights = ["string"],
            PublishedDate = "publishedDate",
            Summary = "summary",
            Text = "text",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1GetFullTextResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAuthor = "author";
        long expectedCharacterCount = 0;
        List<string> expectedHighlights = ["string"];
        string expectedPublishedDate = "publishedDate";
        string expectedSummary = "summary";
        string expectedText = "text";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedAuthor, deserialized.Author);
        Assert.Equal(expectedCharacterCount, deserialized.CharacterCount);
        Assert.NotNull(deserialized.Highlights);
        Assert.Equal(expectedHighlights.Count, deserialized.Highlights.Count);
        for (int i = 0; i < expectedHighlights.Count; i++)
        {
            Assert.Equal(expectedHighlights[i], deserialized.Highlights[i]);
        }
        Assert.Equal(expectedPublishedDate, deserialized.PublishedDate);
        Assert.Equal(expectedSummary, deserialized.Summary);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1GetFullTextResponse
        {
            Author = "author",
            CharacterCount = 0,
            Highlights = ["string"],
            PublishedDate = "publishedDate",
            Summary = "summary",
            Text = "text",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1GetFullTextResponse
        {
            Author = "author",
            PublishedDate = "publishedDate",
            Summary = "summary",
        };

        Assert.Null(model.CharacterCount);
        Assert.False(model.RawData.ContainsKey("characterCount"));
        Assert.Null(model.Highlights);
        Assert.False(model.RawData.ContainsKey("highlights"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1GetFullTextResponse
        {
            Author = "author",
            PublishedDate = "publishedDate",
            Summary = "summary",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1GetFullTextResponse
        {
            Author = "author",
            PublishedDate = "publishedDate",
            Summary = "summary",

            // Null should be interpreted as omitted for these properties
            CharacterCount = null,
            Highlights = null,
            Text = null,
            Title = null,
            Url = null,
        };

        Assert.Null(model.CharacterCount);
        Assert.False(model.RawData.ContainsKey("characterCount"));
        Assert.Null(model.Highlights);
        Assert.False(model.RawData.ContainsKey("highlights"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1GetFullTextResponse
        {
            Author = "author",
            PublishedDate = "publishedDate",
            Summary = "summary",

            // Null should be interpreted as omitted for these properties
            CharacterCount = null,
            Highlights = null,
            Text = null,
            Title = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1GetFullTextResponse
        {
            CharacterCount = 0,
            Highlights = ["string"],
            Text = "text",
            Title = "title",
            Url = "url",
        };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
        Assert.Null(model.PublishedDate);
        Assert.False(model.RawData.ContainsKey("publishedDate"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1GetFullTextResponse
        {
            CharacterCount = 0,
            Highlights = ["string"],
            Text = "text",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new V1GetFullTextResponse
        {
            CharacterCount = 0,
            Highlights = ["string"],
            Text = "text",
            Title = "title",
            Url = "url",

            Author = null,
            PublishedDate = null,
            Summary = null,
        };

        Assert.Null(model.Author);
        Assert.True(model.RawData.ContainsKey("author"));
        Assert.Null(model.PublishedDate);
        Assert.True(model.RawData.ContainsKey("publishedDate"));
        Assert.Null(model.Summary);
        Assert.True(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1GetFullTextResponse
        {
            CharacterCount = 0,
            Highlights = ["string"],
            Text = "text",
            Title = "title",
            Url = "url",

            Author = null,
            PublishedDate = null,
            Summary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1GetFullTextResponse
        {
            Author = "author",
            CharacterCount = 0,
            Highlights = ["string"],
            PublishedDate = "publishedDate",
            Summary = "summary",
            Text = "text",
            Title = "title",
            Url = "url",
        };

        V1GetFullTextResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
