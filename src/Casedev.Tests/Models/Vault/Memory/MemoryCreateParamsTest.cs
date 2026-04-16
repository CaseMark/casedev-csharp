using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using VaultMemory = Casedev.Models.Vault.Memory;

namespace Casedev.Tests.Models.Vault.Memory;

public class MemoryCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultMemory::MemoryCreateParams
        {
            ID = "id",
            Content = "content",
            Type = VaultMemory::Type.Fact,
            Source = "source",
            Tags = ["string"],
        };

        string expectedID = "id";
        string expectedContent = "content";
        ApiEnum<string, VaultMemory::Type> expectedType = VaultMemory::Type.Fact;
        string expectedSource = "source";
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedSource, parameters.Source);
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
        var parameters = new VaultMemory::MemoryCreateParams
        {
            ID = "id",
            Content = "content",
            Type = VaultMemory::Type.Fact,
        };

        Assert.Null(parameters.Source);
        Assert.False(parameters.RawBodyData.ContainsKey("source"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VaultMemory::MemoryCreateParams
        {
            ID = "id",
            Content = "content",
            Type = VaultMemory::Type.Fact,

            // Null should be interpreted as omitted for these properties
            Source = null,
            Tags = null,
        };

        Assert.Null(parameters.Source);
        Assert.False(parameters.RawBodyData.ContainsKey("source"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        VaultMemory::MemoryCreateParams parameters = new()
        {
            ID = "id",
            Content = "content",
            Type = VaultMemory::Type.Fact,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/vault/id/memory"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VaultMemory::MemoryCreateParams
        {
            ID = "id",
            Content = "content",
            Type = VaultMemory::Type.Fact,
            Source = "source",
            Tags = ["string"],
        };

        VaultMemory::MemoryCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(VaultMemory::Type.Fact)]
    [InlineData(VaultMemory::Type.Party)]
    [InlineData(VaultMemory::Type.Issue)]
    [InlineData(VaultMemory::Type.Deadline)]
    [InlineData(VaultMemory::Type.Discovery)]
    [InlineData(VaultMemory::Type.Correction)]
    [InlineData(VaultMemory::Type.Preference)]
    public void Validation_Works(VaultMemory::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VaultMemory::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VaultMemory::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VaultMemory::Type.Fact)]
    [InlineData(VaultMemory::Type.Party)]
    [InlineData(VaultMemory::Type.Issue)]
    [InlineData(VaultMemory::Type.Deadline)]
    [InlineData(VaultMemory::Type.Discovery)]
    [InlineData(VaultMemory::Type.Correction)]
    [InlineData(VaultMemory::Type.Preference)]
    public void SerializationRoundtrip_Works(VaultMemory::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VaultMemory::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VaultMemory::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VaultMemory::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VaultMemory::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
