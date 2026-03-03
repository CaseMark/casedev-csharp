using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Skills;

namespace Casedev.Tests.Models.Skills;

public class SkillResolveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SkillResolveResponse
        {
            MethodsUsed = ["string"],
            Results =
            [
                new()
                {
                    Name = "name",
                    Score = 0,
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                },
            ],
        };

        List<string> expectedMethodsUsed = ["string"];
        List<Result> expectedResults =
        [
            new()
            {
                Name = "name",
                Score = 0,
                Slug = "slug",
                Summary = "summary",
                Tags = ["string"],
            },
        ];

        Assert.NotNull(model.MethodsUsed);
        Assert.Equal(expectedMethodsUsed.Count, model.MethodsUsed.Count);
        for (int i = 0; i < expectedMethodsUsed.Count; i++)
        {
            Assert.Equal(expectedMethodsUsed[i], model.MethodsUsed[i]);
        }
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
        var model = new SkillResolveResponse
        {
            MethodsUsed = ["string"],
            Results =
            [
                new()
                {
                    Name = "name",
                    Score = 0,
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillResolveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SkillResolveResponse
        {
            MethodsUsed = ["string"],
            Results =
            [
                new()
                {
                    Name = "name",
                    Score = 0,
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillResolveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedMethodsUsed = ["string"];
        List<Result> expectedResults =
        [
            new()
            {
                Name = "name",
                Score = 0,
                Slug = "slug",
                Summary = "summary",
                Tags = ["string"],
            },
        ];

        Assert.NotNull(deserialized.MethodsUsed);
        Assert.Equal(expectedMethodsUsed.Count, deserialized.MethodsUsed.Count);
        for (int i = 0; i < expectedMethodsUsed.Count; i++)
        {
            Assert.Equal(expectedMethodsUsed[i], deserialized.MethodsUsed[i]);
        }
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
        var model = new SkillResolveResponse
        {
            MethodsUsed = ["string"],
            Results =
            [
                new()
                {
                    Name = "name",
                    Score = 0,
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SkillResolveResponse { };

        Assert.Null(model.MethodsUsed);
        Assert.False(model.RawData.ContainsKey("methods_used"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SkillResolveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SkillResolveResponse
        {
            // Null should be interpreted as omitted for these properties
            MethodsUsed = null,
            Results = null,
        };

        Assert.Null(model.MethodsUsed);
        Assert.False(model.RawData.ContainsKey("methods_used"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SkillResolveResponse
        {
            // Null should be interpreted as omitted for these properties
            MethodsUsed = null,
            Results = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SkillResolveResponse
        {
            MethodsUsed = ["string"],
            Results =
            [
                new()
                {
                    Name = "name",
                    Score = 0,
                    Slug = "slug",
                    Summary = "summary",
                    Tags = ["string"],
                },
            ],
        };

        SkillResolveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            Name = "name",
            Score = 0,
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
        };

        string expectedName = "name";
        double expectedScore = 0;
        string expectedSlug = "slug";
        string expectedSummary = "summary";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedSlug, model.Slug);
        Assert.Equal(expectedSummary, model.Summary);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            Name = "name",
            Score = 0,
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            Name = "name",
            Score = 0,
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedName = "name";
        double expectedScore = 0;
        string expectedSlug = "slug";
        string expectedSummary = "summary";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedSlug, deserialized.Slug);
        Assert.Equal(expectedSummary, deserialized.Summary);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            Name = "name",
            Score = 0,
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result { };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
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
            Name = null,
            Score = null,
            Slug = null,
            Summary = null,
            Tags = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            Score = null,
            Slug = null,
            Summary = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Result
        {
            Name = "name",
            Score = 0,
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
        };

        Result copied = new(model);

        Assert.Equal(model, copied);
    }
}
