using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Skills;

namespace Casedev.Tests.Models.Skills;

public class ReadResponseRootBundleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReadResponseRootBundle
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
            Role = ReadResponseRootBundleRole.Root,
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
        ApiEnum<string, ReadResponseRootBundleRole> expectedRole = ReadResponseRootBundleRole.Root;

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
        var model = new ReadResponseRootBundle
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
            Role = ReadResponseRootBundleRole.Root,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReadResponseRootBundle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReadResponseRootBundle
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
            Role = ReadResponseRootBundleRole.Root,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReadResponseRootBundle>(
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
        ApiEnum<string, ReadResponseRootBundleRole> expectedRole = ReadResponseRootBundleRole.Root;

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
        var model = new ReadResponseRootBundle
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
            Role = ReadResponseRootBundleRole.Root,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReadResponseRootBundle
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
            Role = ReadResponseRootBundleRole.Root,
        };

        ReadResponseRootBundle copied = new(model);

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

public class ReadResponseRootBundleRoleTest : TestBase
{
    [Theory]
    [InlineData(ReadResponseRootBundleRole.Root)]
    public void Validation_Works(ReadResponseRootBundleRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReadResponseRootBundleRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReadResponseRootBundleRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReadResponseRootBundleRole.Root)]
    public void SerializationRoundtrip_Works(ReadResponseRootBundleRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReadResponseRootBundleRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReadResponseRootBundleRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReadResponseRootBundleRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReadResponseRootBundleRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
