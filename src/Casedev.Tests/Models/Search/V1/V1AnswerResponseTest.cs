using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Search.V1;

namespace Casedev.Tests.Models.Search.V1;

public class V1AnswerResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1AnswerResponse
        {
            Answer = "answer",
            Citations =
            [
                new()
                {
                    ID = "id",
                    PublishedDate = "publishedDate",
                    Text = "text",
                    Title = "title",
                    Url = "url",
                },
            ],
            Model = "model",
            SearchType = "searchType",
        };

        string expectedAnswer = "answer";
        List<Citation> expectedCitations =
        [
            new()
            {
                ID = "id",
                PublishedDate = "publishedDate",
                Text = "text",
                Title = "title",
                Url = "url",
            },
        ];
        string expectedModel = "model";
        string expectedSearchType = "searchType";

        Assert.Equal(expectedAnswer, model.Answer);
        Assert.NotNull(model.Citations);
        Assert.Equal(expectedCitations.Count, model.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], model.Citations[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedSearchType, model.SearchType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1AnswerResponse
        {
            Answer = "answer",
            Citations =
            [
                new()
                {
                    ID = "id",
                    PublishedDate = "publishedDate",
                    Text = "text",
                    Title = "title",
                    Url = "url",
                },
            ],
            Model = "model",
            SearchType = "searchType",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1AnswerResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1AnswerResponse
        {
            Answer = "answer",
            Citations =
            [
                new()
                {
                    ID = "id",
                    PublishedDate = "publishedDate",
                    Text = "text",
                    Title = "title",
                    Url = "url",
                },
            ],
            Model = "model",
            SearchType = "searchType",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1AnswerResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAnswer = "answer";
        List<Citation> expectedCitations =
        [
            new()
            {
                ID = "id",
                PublishedDate = "publishedDate",
                Text = "text",
                Title = "title",
                Url = "url",
            },
        ];
        string expectedModel = "model";
        string expectedSearchType = "searchType";

        Assert.Equal(expectedAnswer, deserialized.Answer);
        Assert.NotNull(deserialized.Citations);
        Assert.Equal(expectedCitations.Count, deserialized.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], deserialized.Citations[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedSearchType, deserialized.SearchType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1AnswerResponse
        {
            Answer = "answer",
            Citations =
            [
                new()
                {
                    ID = "id",
                    PublishedDate = "publishedDate",
                    Text = "text",
                    Title = "title",
                    Url = "url",
                },
            ],
            Model = "model",
            SearchType = "searchType",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1AnswerResponse { };

        Assert.Null(model.Answer);
        Assert.False(model.RawData.ContainsKey("answer"));
        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.SearchType);
        Assert.False(model.RawData.ContainsKey("searchType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1AnswerResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1AnswerResponse
        {
            // Null should be interpreted as omitted for these properties
            Answer = null,
            Citations = null,
            Model = null,
            SearchType = null,
        };

        Assert.Null(model.Answer);
        Assert.False(model.RawData.ContainsKey("answer"));
        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.SearchType);
        Assert.False(model.RawData.ContainsKey("searchType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1AnswerResponse
        {
            // Null should be interpreted as omitted for these properties
            Answer = null,
            Citations = null,
            Model = null,
            SearchType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1AnswerResponse
        {
            Answer = "answer",
            Citations =
            [
                new()
                {
                    ID = "id",
                    PublishedDate = "publishedDate",
                    Text = "text",
                    Title = "title",
                    Url = "url",
                },
            ],
            Model = "model",
            SearchType = "searchType",
        };

        V1AnswerResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CitationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Citation
        {
            ID = "id",
            PublishedDate = "publishedDate",
            Text = "text",
            Title = "title",
            Url = "url",
        };

        string expectedID = "id";
        string expectedPublishedDate = "publishedDate";
        string expectedText = "text";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedPublishedDate, model.PublishedDate);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Citation
        {
            ID = "id",
            PublishedDate = "publishedDate",
            Text = "text",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Citation>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Citation
        {
            ID = "id",
            PublishedDate = "publishedDate",
            Text = "text",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Citation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedPublishedDate = "publishedDate";
        string expectedText = "text";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedPublishedDate, deserialized.PublishedDate);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Citation
        {
            ID = "id",
            PublishedDate = "publishedDate",
            Text = "text",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Citation { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.PublishedDate);
        Assert.False(model.RawData.ContainsKey("publishedDate"));
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
        var model = new Citation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Citation
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            PublishedDate = null,
            Text = null,
            Title = null,
            Url = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.PublishedDate);
        Assert.False(model.RawData.ContainsKey("publishedDate"));
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
        var model = new Citation
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            PublishedDate = null,
            Text = null,
            Title = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Citation
        {
            ID = "id",
            PublishedDate = "publishedDate",
            Text = "text",
            Title = "title",
            Url = "url",
        };

        Citation copied = new(model);

        Assert.Equal(model, copied);
    }
}
