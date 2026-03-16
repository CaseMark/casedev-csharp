using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Models.Skills;

namespace Casedev.Tests.Models.Skills;

public class SkillCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SkillCreateParams
        {
            Content = "x",
            Name = "x",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
        };

        string expectedContent = "x";
        string expectedName = "x";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedSlug = "slug";
        string expectedSummary = "summary";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.Equal(expectedSlug, parameters.Slug);
        Assert.Equal(expectedSummary, parameters.Summary);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SkillCreateParams { Content = "x", Name = "x" };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Slug);
        Assert.False(parameters.RawBodyData.ContainsKey("slug"));
        Assert.Null(parameters.Summary);
        Assert.False(parameters.RawBodyData.ContainsKey("summary"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SkillCreateParams
        {
            Content = "x",
            Name = "x",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Slug = null,
            Summary = null,
            Tags = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Slug);
        Assert.False(parameters.RawBodyData.ContainsKey("slug"));
        Assert.Null(parameters.Summary);
        Assert.False(parameters.RawBodyData.ContainsKey("summary"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        SkillCreateParams parameters = new() { Content = "x", Name = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/skills"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SkillCreateParams
        {
            Content = "x",
            Name = "x",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
        };

        SkillCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
