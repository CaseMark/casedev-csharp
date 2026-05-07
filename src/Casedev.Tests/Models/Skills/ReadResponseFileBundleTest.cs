using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Skills;

namespace Casedev.Tests.Models.Skills;

public class ReadResponseFileBundleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReadResponseFileBundle
        {
            Path = "path",
            Role = Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };

        string expectedPath = "path";
        ApiEnum<string, Role> expectedRole = Role.File;
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
        var model = new ReadResponseFileBundle
        {
            Path = "path",
            Role = Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReadResponseFileBundle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReadResponseFileBundle
        {
            Path = "path",
            Role = Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReadResponseFileBundle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPath = "path";
        ApiEnum<string, Role> expectedRole = Role.File;
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
        var model = new ReadResponseFileBundle
        {
            Path = "path",
            Role = Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReadResponseFileBundle
        {
            Path = "path",
            Role = Role.File,
            RootSlug = "root_slug",
        };

        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("content_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReadResponseFileBundle
        {
            Path = "path",
            Role = Role.File,
            RootSlug = "root_slug",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReadResponseFileBundle
        {
            Path = "path",
            Role = Role.File,
            RootSlug = "root_slug",

            ContentType = null,
        };

        Assert.Null(model.ContentType);
        Assert.True(model.RawData.ContainsKey("content_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReadResponseFileBundle
        {
            Path = "path",
            Role = Role.File,
            RootSlug = "root_slug",

            ContentType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReadResponseFileBundle
        {
            Path = "path",
            Role = Role.File,
            RootSlug = "root_slug",
            ContentType = "content_type",
        };

        ReadResponseFileBundle copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.File)]
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
    [InlineData(Role.File)]
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
