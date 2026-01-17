using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Voice.V1;

namespace CaseDev.Tests.Models.Voice.V1;

public class V1ListVoicesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ListVoicesParams
        {
            Category = "category",
            CollectionID = "collection_id",
            IncludeTotalCount = true,
            NextPageToken = "next_page_token",
            PageSize = 1,
            Search = "search",
            Sort = Sort.Name,
            SortDirection = SortDirection.Asc,
            VoiceType = VoiceType.Premade,
        };

        string expectedCategory = "category";
        string expectedCollectionID = "collection_id";
        bool expectedIncludeTotalCount = true;
        string expectedNextPageToken = "next_page_token";
        long expectedPageSize = 1;
        string expectedSearch = "search";
        ApiEnum<string, Sort> expectedSort = Sort.Name;
        ApiEnum<string, SortDirection> expectedSortDirection = SortDirection.Asc;
        ApiEnum<string, VoiceType> expectedVoiceType = VoiceType.Premade;

        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedCollectionID, parameters.CollectionID);
        Assert.Equal(expectedIncludeTotalCount, parameters.IncludeTotalCount);
        Assert.Equal(expectedNextPageToken, parameters.NextPageToken);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedSearch, parameters.Search);
        Assert.Equal(expectedSort, parameters.Sort);
        Assert.Equal(expectedSortDirection, parameters.SortDirection);
        Assert.Equal(expectedVoiceType, parameters.VoiceType);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ListVoicesParams { };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.CollectionID);
        Assert.False(parameters.RawQueryData.ContainsKey("collection_id"));
        Assert.Null(parameters.IncludeTotalCount);
        Assert.False(parameters.RawQueryData.ContainsKey("include_total_count"));
        Assert.Null(parameters.NextPageToken);
        Assert.False(parameters.RawQueryData.ContainsKey("next_page_token"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
        Assert.Null(parameters.SortDirection);
        Assert.False(parameters.RawQueryData.ContainsKey("sort_direction"));
        Assert.Null(parameters.VoiceType);
        Assert.False(parameters.RawQueryData.ContainsKey("voice_type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ListVoicesParams
        {
            // Null should be interpreted as omitted for these properties
            Category = null,
            CollectionID = null,
            IncludeTotalCount = null,
            NextPageToken = null,
            PageSize = null,
            Search = null,
            Sort = null,
            SortDirection = null,
            VoiceType = null,
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.CollectionID);
        Assert.False(parameters.RawQueryData.ContainsKey("collection_id"));
        Assert.Null(parameters.IncludeTotalCount);
        Assert.False(parameters.RawQueryData.ContainsKey("include_total_count"));
        Assert.Null(parameters.NextPageToken);
        Assert.False(parameters.RawQueryData.ContainsKey("next_page_token"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
        Assert.Null(parameters.SortDirection);
        Assert.False(parameters.RawQueryData.ContainsKey("sort_direction"));
        Assert.Null(parameters.VoiceType);
        Assert.False(parameters.RawQueryData.ContainsKey("voice_type"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ListVoicesParams parameters = new()
        {
            Category = "category",
            CollectionID = "collection_id",
            IncludeTotalCount = true,
            NextPageToken = "next_page_token",
            PageSize = 1,
            Search = "search",
            Sort = Sort.Name,
            SortDirection = SortDirection.Asc,
            VoiceType = VoiceType.Premade,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/voice/v1/voices?category=category&collection_id=collection_id&include_total_count=true&next_page_token=next_page_token&page_size=1&search=search&sort=name&sort_direction=asc&voice_type=premade"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1ListVoicesParams
        {
            Category = "category",
            CollectionID = "collection_id",
            IncludeTotalCount = true,
            NextPageToken = "next_page_token",
            PageSize = 1,
            Search = "search",
            Sort = Sort.Name,
            SortDirection = SortDirection.Asc,
            VoiceType = VoiceType.Premade,
        };

        V1ListVoicesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SortTest : TestBase
{
    [Theory]
    [InlineData(Sort.Name)]
    [InlineData(Sort.CreatedAt)]
    [InlineData(Sort.UpdatedAt)]
    public void Validation_Works(Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sort> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Sort.Name)]
    [InlineData(Sort.CreatedAt)]
    [InlineData(Sort.UpdatedAt)]
    public void SerializationRoundtrip_Works(Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sort> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SortDirectionTest : TestBase
{
    [Theory]
    [InlineData(SortDirection.Asc)]
    [InlineData(SortDirection.Desc)]
    public void Validation_Works(SortDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortDirection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SortDirection.Asc)]
    [InlineData(SortDirection.Desc)]
    public void SerializationRoundtrip_Works(SortDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortDirection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VoiceTypeTest : TestBase
{
    [Theory]
    [InlineData(VoiceType.Premade)]
    [InlineData(VoiceType.Cloned)]
    [InlineData(VoiceType.Professional)]
    public void Validation_Works(VoiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VoiceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VoiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VoiceType.Premade)]
    [InlineData(VoiceType.Cloned)]
    [InlineData(VoiceType.Professional)]
    public void SerializationRoundtrip_Works(VoiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VoiceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VoiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VoiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VoiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
