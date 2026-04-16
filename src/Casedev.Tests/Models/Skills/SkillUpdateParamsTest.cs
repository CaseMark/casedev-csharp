using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Models.Skills;

namespace Casedev.Tests.Models.Skills;

public class SkillUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SkillUpdateParams
        {
            Slug = "slug",
            Content = "content",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            SlugValue = "slug",
            Summary = "summary",
            Tags = ["string"],
        };

        string expectedSlug = "slug";
        string expectedContent = "content";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";
        string expectedSlugValue = "slug";
        string expectedSummary = "summary";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedSlug, parameters.Slug);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSlugValue, parameters.SlugValue);
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
        var parameters = new SkillUpdateParams { Slug = "slug", Summary = "summary" };

        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.SlugValue);
        Assert.False(parameters.RawBodyData.ContainsKey("slug"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SkillUpdateParams
        {
            Slug = "slug",
            Summary = "summary",

            // Null should be interpreted as omitted for these properties
            Content = null,
            Metadata = null,
            Name = null,
            SlugValue = null,
            Tags = null,
        };

        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.SlugValue);
        Assert.False(parameters.RawBodyData.ContainsKey("slug"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SkillUpdateParams
        {
            Slug = "slug",
            Content = "content",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            SlugValue = "slug",
            Tags = ["string"],
        };

        Assert.Null(parameters.Summary);
        Assert.False(parameters.RawBodyData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SkillUpdateParams
        {
            Slug = "slug",
            Content = "content",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            SlugValue = "slug",
            Tags = ["string"],

            Summary = null,
        };

        Assert.Null(parameters.Summary);
        Assert.True(parameters.RawBodyData.ContainsKey("summary"));
    }

    [Fact]
    public void Url_Works()
    {
        SkillUpdateParams parameters = new() { Slug = "slug" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/skills/slug"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SkillUpdateParams
        {
            Slug = "slug",
            Content = "content",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            SlugValue = "slug",
            Summary = "summary",
            Tags = ["string"],
        };

        SkillUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
