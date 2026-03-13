using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Agent.V1.Chat.Files;

namespace Casedev.Tests.Models.Agent.V1.Chat.Files;

public class FileListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileListResponse
        {
            ChatID = "chatId",
            Files =
            [
                new()
                {
                    Name = "name",
                    Path = "path",
                    SizeBytes = 0,
                },
            ],
        };

        string expectedChatID = "chatId";
        List<File> expectedFiles =
        [
            new()
            {
                Name = "name",
                Path = "path",
                SizeBytes = 0,
            },
        ];

        Assert.Equal(expectedChatID, model.ChatID);
        Assert.NotNull(model.Files);
        Assert.Equal(expectedFiles.Count, model.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], model.Files[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileListResponse
        {
            ChatID = "chatId",
            Files =
            [
                new()
                {
                    Name = "name",
                    Path = "path",
                    SizeBytes = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileListResponse
        {
            ChatID = "chatId",
            Files =
            [
                new()
                {
                    Name = "name",
                    Path = "path",
                    SizeBytes = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChatID = "chatId";
        List<File> expectedFiles =
        [
            new()
            {
                Name = "name",
                Path = "path",
                SizeBytes = 0,
            },
        ];

        Assert.Equal(expectedChatID, deserialized.ChatID);
        Assert.NotNull(deserialized.Files);
        Assert.Equal(expectedFiles.Count, deserialized.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], deserialized.Files[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileListResponse
        {
            ChatID = "chatId",
            Files =
            [
                new()
                {
                    Name = "name",
                    Path = "path",
                    SizeBytes = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileListResponse { };

        Assert.Null(model.ChatID);
        Assert.False(model.RawData.ContainsKey("chatId"));
        Assert.Null(model.Files);
        Assert.False(model.RawData.ContainsKey("files"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileListResponse
        {
            // Null should be interpreted as omitted for these properties
            ChatID = null,
            Files = null,
        };

        Assert.Null(model.ChatID);
        Assert.False(model.RawData.ContainsKey("chatId"));
        Assert.Null(model.Files);
        Assert.False(model.RawData.ContainsKey("files"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileListResponse
        {
            // Null should be interpreted as omitted for these properties
            ChatID = null,
            Files = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileListResponse
        {
            ChatID = "chatId",
            Files =
            [
                new()
                {
                    Name = "name",
                    Path = "path",
                    SizeBytes = 0,
                },
            ],
        };

        FileListResponse copied = new(model);

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
            Name = "name",
            Path = "path",
            SizeBytes = 0,
        };

        string expectedName = "name";
        string expectedPath = "path";
        long expectedSizeBytes = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new File
        {
            Name = "name",
            Path = "path",
            SizeBytes = 0,
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
            Name = "name",
            Path = "path",
            SizeBytes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedPath = "path";
        long expectedSizeBytes = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new File
        {
            Name = "name",
            Path = "path",
            SizeBytes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new File { };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new File { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new File
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            Path = null,
            SizeBytes = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new File
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            Path = null,
            SizeBytes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new File
        {
            Name = "name",
            Path = "path",
            SizeBytes = 0,
        };

        File copied = new(model);

        Assert.Equal(model, copied);
    }
}
