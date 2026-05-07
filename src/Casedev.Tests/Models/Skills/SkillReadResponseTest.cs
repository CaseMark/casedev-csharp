using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
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
            Bundle = new UnionMember0()
            {
                Files =
                [
                    new()
                    {
                        Path = "path",
                        Slug = "slug",
                        ContentType = "content_type",
                        Name = "name",
                    },
                ],
                Role = Role.Root,
            },
            Content = "content",
            License = "license",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Source = Source.Curated,
            Summary = "summary",
            Tags = ["string"],
            Version = "version",
        };

        string expectedAuthorName = "author_name";
        Bundle expectedBundle = new UnionMember0()
        {
            Files =
            [
                new()
                {
                    Path = "path",
                    Slug = "slug",
                    ContentType = "content_type",
                    Name = "name",
                },
            ],
            Role = Role.Root,
        };
        string expectedContent = "content";
        string expectedLicense = "license";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";
        string expectedSlug = "slug";
        ApiEnum<string, Source> expectedSource = Source.Curated;
        string expectedSummary = "summary";
        List<string> expectedTags = ["string"];
        string expectedVersion = "version";

        Assert.Equal(expectedAuthorName, model.AuthorName);
        Assert.Equal(expectedBundle, model.Bundle);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedLicense, model.License);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSlug, model.Slug);
        Assert.Equal(expectedSource, model.Source);
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
            Bundle = new UnionMember0()
            {
                Files =
                [
                    new()
                    {
                        Path = "path",
                        Slug = "slug",
                        ContentType = "content_type",
                        Name = "name",
                    },
                ],
                Role = Role.Root,
            },
            Content = "content",
            License = "license",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Source = Source.Curated,
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
            Bundle = new UnionMember0()
            {
                Files =
                [
                    new()
                    {
                        Path = "path",
                        Slug = "slug",
                        ContentType = "content_type",
                        Name = "name",
                    },
                ],
                Role = Role.Root,
            },
            Content = "content",
            License = "license",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Source = Source.Curated,
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
        Bundle expectedBundle = new UnionMember0()
        {
            Files =
            [
                new()
                {
                    Path = "path",
                    Slug = "slug",
                    ContentType = "content_type",
                    Name = "name",
                },
            ],
            Role = Role.Root,
        };
        string expectedContent = "content";
        string expectedLicense = "license";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";
        string expectedSlug = "slug";
        ApiEnum<string, Source> expectedSource = Source.Curated;
        string expectedSummary = "summary";
        List<string> expectedTags = ["string"];
        string expectedVersion = "version";

        Assert.Equal(expectedAuthorName, deserialized.AuthorName);
        Assert.Equal(expectedBundle, deserialized.Bundle);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedLicense, deserialized.License);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSlug, deserialized.Slug);
        Assert.Equal(expectedSource, deserialized.Source);
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
            Bundle = new UnionMember0()
            {
                Files =
                [
                    new()
                    {
                        Path = "path",
                        Slug = "slug",
                        ContentType = "content_type",
                        Name = "name",
                    },
                ],
                Role = Role.Root,
            },
            Content = "content",
            License = "license",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Source = Source.Curated,
            Summary = "summary",
            Tags = ["string"],
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SkillReadResponse
        {
            Bundle = new UnionMember0()
            {
                Files =
                [
                    new()
                    {
                        Path = "path",
                        Slug = "slug",
                        ContentType = "content_type",
                        Name = "name",
                    },
                ],
                Role = Role.Root,
            },
        };

        Assert.Null(model.AuthorName);
        Assert.False(model.RawData.ContainsKey("author_name"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.License);
        Assert.False(model.RawData.ContainsKey("license"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
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
        var model = new SkillReadResponse
        {
            Bundle = new UnionMember0()
            {
                Files =
                [
                    new()
                    {
                        Path = "path",
                        Slug = "slug",
                        ContentType = "content_type",
                        Name = "name",
                    },
                ],
                Role = Role.Root,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SkillReadResponse
        {
            Bundle = new UnionMember0()
            {
                Files =
                [
                    new()
                    {
                        Path = "path",
                        Slug = "slug",
                        ContentType = "content_type",
                        Name = "name",
                    },
                ],
                Role = Role.Root,
            },

            // Null should be interpreted as omitted for these properties
            AuthorName = null,
            Content = null,
            License = null,
            Metadata = null,
            Name = null,
            Slug = null,
            Source = null,
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
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
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
            Bundle = new UnionMember0()
            {
                Files =
                [
                    new()
                    {
                        Path = "path",
                        Slug = "slug",
                        ContentType = "content_type",
                        Name = "name",
                    },
                ],
                Role = Role.Root,
            },

            // Null should be interpreted as omitted for these properties
            AuthorName = null,
            Content = null,
            License = null,
            Metadata = null,
            Name = null,
            Slug = null,
            Source = null,
            Summary = null,
            Tags = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SkillReadResponse
        {
            AuthorName = "author_name",
            Content = "content",
            License = "license",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Source = Source.Curated,
            Summary = "summary",
            Tags = ["string"],
            Version = "version",
        };

        Assert.Null(model.Bundle);
        Assert.False(model.RawData.ContainsKey("bundle"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SkillReadResponse
        {
            AuthorName = "author_name",
            Content = "content",
            License = "license",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Source = Source.Curated,
            Summary = "summary",
            Tags = ["string"],
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SkillReadResponse
        {
            AuthorName = "author_name",
            Content = "content",
            License = "license",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Source = Source.Curated,
            Summary = "summary",
            Tags = ["string"],
            Version = "version",

            Bundle = null,
        };

        Assert.Null(model.Bundle);
        Assert.True(model.RawData.ContainsKey("bundle"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SkillReadResponse
        {
            AuthorName = "author_name",
            Content = "content",
            License = "license",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Source = Source.Curated,
            Summary = "summary",
            Tags = ["string"],
            Version = "version",

            Bundle = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SkillReadResponse
        {
            AuthorName = "author_name",
            Bundle = new UnionMember0()
            {
                Files =
                [
                    new()
                    {
                        Path = "path",
                        Slug = "slug",
                        ContentType = "content_type",
                        Name = "name",
                    },
                ],
                Role = Role.Root,
            },
            Content = "content",
            License = "license",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            Slug = "slug",
            Source = Source.Curated,
            Summary = "summary",
            Tags = ["string"],
            Version = "version",
        };

        SkillReadResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BundleTest : TestBase
{
    [Fact]
    public void UnionMember0ValidationWorks()
    {
        Bundle value = new UnionMember0()
        {
            Files =
            [
                new()
                {
                    Path = "path",
                    Slug = "slug",
                    ContentType = "content_type",
                    Name = "name",
                },
            ],
            Role = Role.Root,
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember1ValidationWorks()
    {
        Bundle value = new UnionMember1()
        {
            Path = "path",
            Role = UnionMember1Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember0SerializationRoundtripWorks()
    {
        Bundle value = new UnionMember0()
        {
            Files =
            [
                new()
                {
                    Path = "path",
                    Slug = "slug",
                    ContentType = "content_type",
                    Name = "name",
                },
            ],
            Role = Role.Root,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Bundle>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember1SerializationRoundtripWorks()
    {
        Bundle value = new UnionMember1()
        {
            Path = "path",
            Role = UnionMember1Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Bundle>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember0Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember0
        {
            Files =
            [
                new()
                {
                    Path = "path",
                    Slug = "slug",
                    ContentType = "content_type",
                    Name = "name",
                },
            ],
            Role = Role.Root,
        };

        List<File> expectedFiles =
        [
            new()
            {
                Path = "path",
                Slug = "slug",
                ContentType = "content_type",
                Name = "name",
            },
        ];
        ApiEnum<string, Role> expectedRole = Role.Root;

        Assert.Equal(expectedFiles.Count, model.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], model.Files[i]);
        }
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember0
        {
            Files =
            [
                new()
                {
                    Path = "path",
                    Slug = "slug",
                    ContentType = "content_type",
                    Name = "name",
                },
            ],
            Role = Role.Root,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember0
        {
            Files =
            [
                new()
                {
                    Path = "path",
                    Slug = "slug",
                    ContentType = "content_type",
                    Name = "name",
                },
            ],
            Role = Role.Root,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<File> expectedFiles =
        [
            new()
            {
                Path = "path",
                Slug = "slug",
                ContentType = "content_type",
                Name = "name",
            },
        ];
        ApiEnum<string, Role> expectedRole = Role.Root;

        Assert.Equal(expectedFiles.Count, deserialized.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], deserialized.Files[i]);
        }
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember0
        {
            Files =
            [
                new()
                {
                    Path = "path",
                    Slug = "slug",
                    ContentType = "content_type",
                    Name = "name",
                },
            ],
            Role = Role.Root,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember0
        {
            Files =
            [
                new()
                {
                    Path = "path",
                    Slug = "slug",
                    ContentType = "content_type",
                    Name = "name",
                },
            ],
            Role = Role.Root,
        };

        UnionMember0 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new File
        {
            Path = "path",
            Slug = "slug",
            ContentType = "content_type",
            Name = "name",
        };

        string expectedPath = "path";
        string expectedSlug = "slug";
        string expectedContentType = "content_type";
        string expectedName = "name";

        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedSlug, model.Slug);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new File
        {
            Path = "path",
            Slug = "slug",
            ContentType = "content_type",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new File
        {
            Path = "path",
            Slug = "slug",
            ContentType = "content_type",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedPath = "path";
        string expectedSlug = "slug";
        string expectedContentType = "content_type";
        string expectedName = "name";

        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedSlug, deserialized.Slug);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new File
        {
            Path = "path",
            Slug = "slug",
            ContentType = "content_type",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new File { Path = "path", Slug = "slug" };

        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("content_type"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new File { Path = "path", Slug = "slug" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new File
        {
            Path = "path",
            Slug = "slug",

            ContentType = null,
            Name = null,
        };

        Assert.Null(model.ContentType);
        Assert.True(model.RawData.ContainsKey("content_type"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new File
        {
            Path = "path",
            Slug = "slug",

            ContentType = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new File
        {
            Path = "path",
            Slug = "slug",
            ContentType = "content_type",
            Name = "name",
        };

        File copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.Root)]
    public void Validation_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.Root)]
    public void SerializationRoundtrip_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember1
        {
            Path = "path",
            Role = UnionMember1Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };

        string expectedPath = "path";
        ApiEnum<string, UnionMember1Role> expectedRole = UnionMember1Role.File;
        string expectedRootSlug = "root_slug";
        string expectedContentType = "content_type";

        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedRootSlug, model.RootSlug);
        Assert.Equal(expectedContentType, model.ContentType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember1
        {
            Path = "path",
            Role = UnionMember1Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember1
        {
            Path = "path",
            Role = UnionMember1Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPath = "path";
        ApiEnum<string, UnionMember1Role> expectedRole = UnionMember1Role.File;
        string expectedRootSlug = "root_slug";
        string expectedContentType = "content_type";

        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.Equal(expectedRootSlug, deserialized.RootSlug);
        Assert.Equal(expectedContentType, deserialized.ContentType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember1
        {
            Path = "path",
            Role = UnionMember1Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember1
        {
            Path = "path",
            Role = UnionMember1Role.File,
            RootSlug = "root_slug",
        };

        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("content_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember1
        {
            Path = "path",
            Role = UnionMember1Role.File,
            RootSlug = "root_slug",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember1
        {
            Path = "path",
            Role = UnionMember1Role.File,
            RootSlug = "root_slug",

            ContentType = null,
        };

        Assert.Null(model.ContentType);
        Assert.True(model.RawData.ContainsKey("content_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember1
        {
            Path = "path",
            Role = UnionMember1Role.File,
            RootSlug = "root_slug",

            ContentType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember1
        {
            Path = "path",
            Role = UnionMember1Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };

        UnionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember1RoleTest : TestBase
{
    [Theory]
    [InlineData(UnionMember1Role.File)]
    public void Validation_Works(UnionMember1Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember1Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember1Role.File)]
    public void SerializationRoundtrip_Works(UnionMember1Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember1Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember1Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.Curated)]
    [InlineData(Source.Custom)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.Curated)]
    [InlineData(Source.Custom)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
