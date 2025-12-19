using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class SearchTypeTest : TestBase
{
    [Theory]
    [InlineData(SearchType.Auto)]
    [InlineData(SearchType.Web)]
    [InlineData(SearchType.News)]
    [InlineData(SearchType.Academic)]
    public void Validation_Works(SearchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SearchType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SearchType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SearchType.Auto)]
    [InlineData(SearchType.Web)]
    [InlineData(SearchType.News)]
    [InlineData(SearchType.Academic)]
    public void SerializationRoundtrip_Works(SearchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SearchType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SearchType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SearchType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SearchType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
