using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Agent.Skills.Namespaces;

namespace Casedev.Tests.Models.Agent.Skills.Namespaces;

public class NamespacePublishParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NamespacePublishParams
        {
            ID = "id",
            Files =
            [
                new()
                {
                    Content = "content",
                    Encoding = Encoding.Utf8,
                    Path = "path",
                    ContentType = "contentType",
                },
            ],
        };

        string expectedID = "id";
        List<File> expectedFiles =
        [
            new()
            {
                Content = "content",
                Encoding = Encoding.Utf8,
                Path = "path",
                ContentType = "contentType",
            },
        ];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFiles.Count, parameters.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], parameters.Files[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        NamespacePublishParams parameters = new()
        {
            ID = "id",
            Files =
            [
                new()
                {
                    Content = "content",
                    Encoding = Encoding.Utf8,
                    Path = "path",
                    ContentType = "contentType",
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/agent/skills/namespaces/id/publish"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NamespacePublishParams
        {
            ID = "id",
            Files =
            [
                new()
                {
                    Content = "content",
                    Encoding = Encoding.Utf8,
                    Path = "path",
                    ContentType = "contentType",
                },
            ],
        };

        NamespacePublishParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new File
        {
            Content = "content",
            Encoding = Encoding.Utf8,
            Path = "path",
            ContentType = "contentType",
        };

        string expectedContent = "content";
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Utf8;
        string expectedPath = "path";
        string expectedContentType = "contentType";

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedEncoding, model.Encoding);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedContentType, model.ContentType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new File
        {
            Content = "content",
            Encoding = Encoding.Utf8,
            Path = "path",
            ContentType = "contentType",
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
            Content = "content",
            Encoding = Encoding.Utf8,
            Path = "path",
            ContentType = "contentType",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, Encoding> expectedEncoding = Encoding.Utf8;
        string expectedPath = "path";
        string expectedContentType = "contentType";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedEncoding, deserialized.Encoding);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedContentType, deserialized.ContentType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new File
        {
            Content = "content",
            Encoding = Encoding.Utf8,
            Path = "path",
            ContentType = "contentType",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new File
        {
            Content = "content",
            Encoding = Encoding.Utf8,
            Path = "path",
        };

        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("contentType"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new File
        {
            Content = "content",
            Encoding = Encoding.Utf8,
            Path = "path",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new File
        {
            Content = "content",
            Encoding = Encoding.Utf8,
            Path = "path",

            ContentType = null,
        };

        Assert.Null(model.ContentType);
        Assert.True(model.RawData.ContainsKey("contentType"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new File
        {
            Content = "content",
            Encoding = Encoding.Utf8,
            Path = "path",

            ContentType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new File
        {
            Content = "content",
            Encoding = Encoding.Utf8,
            Path = "path",
            ContentType = "contentType",
        };

        File copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EncodingTest : TestBase
{
    [Theory]
    [InlineData(Encoding.Utf8)]
    [InlineData(Encoding.Base64)]
    public void Validation_Works(Encoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Encoding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Encoding.Utf8)]
    [InlineData(Encoding.Base64)]
    public void SerializationRoundtrip_Works(Encoding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Encoding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Encoding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
