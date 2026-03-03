using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Skills;

namespace Casedev.Tests.Models.Skills;

public class SkillReadResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SkillReadResponse
        {
            AuthorName = "author_name",
            Content = "content",
            License = "license",
            Name = "name",
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
            Version = "version",
        };

        string expectedAuthorName = "author_name";
        string expectedContent = "content";
        string expectedLicense = "license";
        string expectedName = "name";
        string expectedSlug = "slug";
        string expectedSummary = "summary";
        List<string> expectedTags = ["string"];
        string expectedVersion = "version";

        Assert.Equal(expectedAuthorName, model.AuthorName);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedLicense, model.License);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSlug, model.Slug);
        Assert.Equal(expectedSummary, model.Summary);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SkillReadResponse
        {
            AuthorName = "author_name",
            Content = "content",
            License = "license",
            Name = "name",
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillReadResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SkillReadResponse
        {
            AuthorName = "author_name",
            Content = "content",
            License = "license",
            Name = "name",
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillReadResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAuthorName = "author_name";
        string expectedContent = "content";
        string expectedLicense = "license";
        string expectedName = "name";
        string expectedSlug = "slug";
        string expectedSummary = "summary";
        List<string> expectedTags = ["string"];
        string expectedVersion = "version";

        Assert.Equal(expectedAuthorName, deserialized.AuthorName);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedLicense, deserialized.License);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSlug, deserialized.Slug);
        Assert.Equal(expectedSummary, deserialized.Summary);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SkillReadResponse
        {
            AuthorName = "author_name",
            Content = "content",
            License = "license",
            Name = "name",
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SkillReadResponse { };

        Assert.Null(model.AuthorName);
        Assert.False(model.RawData.ContainsKey("author_name"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.License);
        Assert.False(model.RawData.ContainsKey("license"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SkillReadResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SkillReadResponse
        {
            // Null should be interpreted as omitted for these properties
            AuthorName = null,
            Content = null,
            License = null,
            Name = null,
            Slug = null,
            Summary = null,
            Tags = null,
            Version = null,
        };

        Assert.Null(model.AuthorName);
        Assert.False(model.RawData.ContainsKey("author_name"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.License);
        Assert.False(model.RawData.ContainsKey("license"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SkillReadResponse
        {
            // Null should be interpreted as omitted for these properties
            AuthorName = null,
            Content = null,
            License = null,
            Name = null,
            Slug = null,
            Summary = null,
            Tags = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SkillReadResponse
        {
            AuthorName = "author_name",
            Content = "content",
            License = "license",
            Name = "name",
            Slug = "slug",
            Summary = "summary",
            Tags = ["string"],
            Version = "version",
        };

        SkillReadResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
