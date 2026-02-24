using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1SimilarResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1SimilarResponse
        {
            Found = 0,
            Hint = "hint",
            Jurisdiction = "jurisdiction",
            SimilarSources =
            [
                new()
                {
                    PublishedDate = "publishedDate",
                    Snippet = "snippet",
                    Source = "source",
                    Title = "title",
                    Url = "url",
                },
            ],
            SourceUrl = "sourceUrl",
        };

        long expectedFound = 0;
        string expectedHint = "hint";
        string expectedJurisdiction = "jurisdiction";
        List<SimilarSource> expectedSimilarSources =
        [
            new()
            {
                PublishedDate = "publishedDate",
                Snippet = "snippet",
                Source = "source",
                Title = "title",
                Url = "url",
            },
        ];
        string expectedSourceUrl = "sourceUrl";

        Assert.Equal(expectedFound, model.Found);
        Assert.Equal(expectedHint, model.Hint);
        Assert.Equal(expectedJurisdiction, model.Jurisdiction);
        Assert.NotNull(model.SimilarSources);
        Assert.Equal(expectedSimilarSources.Count, model.SimilarSources.Count);
        for (int i = 0; i < expectedSimilarSources.Count; i++)
        {
            Assert.Equal(expectedSimilarSources[i], model.SimilarSources[i]);
        }
        Assert.Equal(expectedSourceUrl, model.SourceUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1SimilarResponse
        {
            Found = 0,
            Hint = "hint",
            Jurisdiction = "jurisdiction",
            SimilarSources =
            [
                new()
                {
                    PublishedDate = "publishedDate",
                    Snippet = "snippet",
                    Source = "source",
                    Title = "title",
                    Url = "url",
                },
            ],
            SourceUrl = "sourceUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1SimilarResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1SimilarResponse
        {
            Found = 0,
            Hint = "hint",
            Jurisdiction = "jurisdiction",
            SimilarSources =
            [
                new()
                {
                    PublishedDate = "publishedDate",
                    Snippet = "snippet",
                    Source = "source",
                    Title = "title",
                    Url = "url",
                },
            ],
            SourceUrl = "sourceUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1SimilarResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedFound = 0;
        string expectedHint = "hint";
        string expectedJurisdiction = "jurisdiction";
        List<SimilarSource> expectedSimilarSources =
        [
            new()
            {
                PublishedDate = "publishedDate",
                Snippet = "snippet",
                Source = "source",
                Title = "title",
                Url = "url",
            },
        ];
        string expectedSourceUrl = "sourceUrl";

        Assert.Equal(expectedFound, deserialized.Found);
        Assert.Equal(expectedHint, deserialized.Hint);
        Assert.Equal(expectedJurisdiction, deserialized.Jurisdiction);
        Assert.NotNull(deserialized.SimilarSources);
        Assert.Equal(expectedSimilarSources.Count, deserialized.SimilarSources.Count);
        for (int i = 0; i < expectedSimilarSources.Count; i++)
        {
            Assert.Equal(expectedSimilarSources[i], deserialized.SimilarSources[i]);
        }
        Assert.Equal(expectedSourceUrl, deserialized.SourceUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1SimilarResponse
        {
            Found = 0,
            Hint = "hint",
            Jurisdiction = "jurisdiction",
            SimilarSources =
            [
                new()
                {
                    PublishedDate = "publishedDate",
                    Snippet = "snippet",
                    Source = "source",
                    Title = "title",
                    Url = "url",
                },
            ],
            SourceUrl = "sourceUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1SimilarResponse { };

        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.Hint);
        Assert.False(model.RawData.ContainsKey("hint"));
        Assert.Null(model.Jurisdiction);
        Assert.False(model.RawData.ContainsKey("jurisdiction"));
        Assert.Null(model.SimilarSources);
        Assert.False(model.RawData.ContainsKey("similarSources"));
        Assert.Null(model.SourceUrl);
        Assert.False(model.RawData.ContainsKey("sourceUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1SimilarResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1SimilarResponse
        {
            // Null should be interpreted as omitted for these properties
            Found = null,
            Hint = null,
            Jurisdiction = null,
            SimilarSources = null,
            SourceUrl = null,
        };

        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.Hint);
        Assert.False(model.RawData.ContainsKey("hint"));
        Assert.Null(model.Jurisdiction);
        Assert.False(model.RawData.ContainsKey("jurisdiction"));
        Assert.Null(model.SimilarSources);
        Assert.False(model.RawData.ContainsKey("similarSources"));
        Assert.Null(model.SourceUrl);
        Assert.False(model.RawData.ContainsKey("sourceUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1SimilarResponse
        {
            // Null should be interpreted as omitted for these properties
            Found = null,
            Hint = null,
            Jurisdiction = null,
            SimilarSources = null,
            SourceUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1SimilarResponse
        {
            Found = 0,
            Hint = "hint",
            Jurisdiction = "jurisdiction",
            SimilarSources =
            [
                new()
                {
                    PublishedDate = "publishedDate",
                    Snippet = "snippet",
                    Source = "source",
                    Title = "title",
                    Url = "url",
                },
            ],
            SourceUrl = "sourceUrl",
        };

        V1SimilarResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SimilarSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SimilarSource
        {
            PublishedDate = "publishedDate",
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        string expectedPublishedDate = "publishedDate";
        string expectedSnippet = "snippet";
        string expectedSource = "source";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedPublishedDate, model.PublishedDate);
        Assert.Equal(expectedSnippet, model.Snippet);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SimilarSource
        {
            PublishedDate = "publishedDate",
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SimilarSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SimilarSource
        {
            PublishedDate = "publishedDate",
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SimilarSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPublishedDate = "publishedDate";
        string expectedSnippet = "snippet";
        string expectedSource = "source";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedPublishedDate, deserialized.PublishedDate);
        Assert.Equal(expectedSnippet, deserialized.Snippet);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SimilarSource
        {
            PublishedDate = "publishedDate",
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SimilarSource { PublishedDate = "publishedDate" };

        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SimilarSource { PublishedDate = "publishedDate" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SimilarSource
        {
            PublishedDate = "publishedDate",

            // Null should be interpreted as omitted for these properties
            Snippet = null,
            Source = null,
            Title = null,
            Url = null,
        };

        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SimilarSource
        {
            PublishedDate = "publishedDate",

            // Null should be interpreted as omitted for these properties
            Snippet = null,
            Source = null,
            Title = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SimilarSource
        {
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        Assert.Null(model.PublishedDate);
        Assert.False(model.RawData.ContainsKey("publishedDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SimilarSource
        {
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SimilarSource
        {
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",

            PublishedDate = null,
        };

        Assert.Null(model.PublishedDate);
        Assert.True(model.RawData.ContainsKey("publishedDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SimilarSource
        {
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",

            PublishedDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SimilarSource
        {
            PublishedDate = "publishedDate",
            Snippet = "snippet",
            Source = "source",
            Title = "title",
            Url = "url",
        };

        SimilarSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
