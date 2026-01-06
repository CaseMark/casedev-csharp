using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1ListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ListParams
        {
            Limit = 100,
            Offset = 0,
            Visibility = V1ListParamsVisibility.Private,
        };

        long expectedLimit = 100;
        long expectedOffset = 0;
        ApiEnum<string, V1ListParamsVisibility> expectedVisibility = V1ListParamsVisibility.Private;

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedVisibility, parameters.Visibility);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ListParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Visibility);
        Assert.False(parameters.RawQueryData.ContainsKey("visibility"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ListParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
            Visibility = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Visibility);
        Assert.False(parameters.RawQueryData.ContainsKey("visibility"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ListParams parameters = new()
        {
            Limit = 100,
            Offset = 0,
            Visibility = V1ListParamsVisibility.Private,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.case.dev/workflows/v1?limit=100&offset=0&visibility=private"),
            url
        );
    }
}

public class V1ListParamsVisibilityTest : TestBase
{
    [Theory]
    [InlineData(V1ListParamsVisibility.Private)]
    [InlineData(V1ListParamsVisibility.Org)]
    [InlineData(V1ListParamsVisibility.Public)]
    public void Validation_Works(V1ListParamsVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ListParamsVisibility> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ListParamsVisibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1ListParamsVisibility.Private)]
    [InlineData(V1ListParamsVisibility.Org)]
    [InlineData(V1ListParamsVisibility.Public)]
    public void SerializationRoundtrip_Works(V1ListParamsVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1ListParamsVisibility> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1ListParamsVisibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1ListParamsVisibility>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1ListParamsVisibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
