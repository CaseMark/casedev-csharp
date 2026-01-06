using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1AnswerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1AnswerParams
        {
            Query = "query",
            ExcludeDomains = ["string"],
            IncludeDomains = ["string"],
            MaxTokens = 0,
            Model = "model",
            NumResults = 1,
            SearchType = SearchType.Auto,
            Stream = true,
            Temperature = 0,
            Text = true,
            UseCustomLlm = true,
        };

        string expectedQuery = "query";
        List<string> expectedExcludeDomains = ["string"];
        List<string> expectedIncludeDomains = ["string"];
        long expectedMaxTokens = 0;
        string expectedModel = "model";
        long expectedNumResults = 1;
        ApiEnum<string, SearchType> expectedSearchType = SearchType.Auto;
        bool expectedStream = true;
        double expectedTemperature = 0;
        bool expectedText = true;
        bool expectedUseCustomLlm = true;

        Assert.Equal(expectedQuery, parameters.Query);
        Assert.NotNull(parameters.ExcludeDomains);
        Assert.Equal(expectedExcludeDomains.Count, parameters.ExcludeDomains.Count);
        for (int i = 0; i < expectedExcludeDomains.Count; i++)
        {
            Assert.Equal(expectedExcludeDomains[i], parameters.ExcludeDomains[i]);
        }
        Assert.NotNull(parameters.IncludeDomains);
        Assert.Equal(expectedIncludeDomains.Count, parameters.IncludeDomains.Count);
        for (int i = 0; i < expectedIncludeDomains.Count; i++)
        {
            Assert.Equal(expectedIncludeDomains[i], parameters.IncludeDomains[i]);
        }
        Assert.Equal(expectedMaxTokens, parameters.MaxTokens);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedNumResults, parameters.NumResults);
        Assert.Equal(expectedSearchType, parameters.SearchType);
        Assert.Equal(expectedStream, parameters.Stream);
        Assert.Equal(expectedTemperature, parameters.Temperature);
        Assert.Equal(expectedText, parameters.Text);
        Assert.Equal(expectedUseCustomLlm, parameters.UseCustomLlm);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1AnswerParams { Query = "query" };

        Assert.Null(parameters.ExcludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("excludeDomains"));
        Assert.Null(parameters.IncludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("includeDomains"));
        Assert.Null(parameters.MaxTokens);
        Assert.False(parameters.RawBodyData.ContainsKey("maxTokens"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.NumResults);
        Assert.False(parameters.RawBodyData.ContainsKey("numResults"));
        Assert.Null(parameters.SearchType);
        Assert.False(parameters.RawBodyData.ContainsKey("searchType"));
        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawBodyData.ContainsKey("stream"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
        Assert.Null(parameters.UseCustomLlm);
        Assert.False(parameters.RawBodyData.ContainsKey("useCustomLLM"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1AnswerParams
        {
            Query = "query",

            // Null should be interpreted as omitted for these properties
            ExcludeDomains = null,
            IncludeDomains = null,
            MaxTokens = null,
            Model = null,
            NumResults = null,
            SearchType = null,
            Stream = null,
            Temperature = null,
            Text = null,
            UseCustomLlm = null,
        };

        Assert.Null(parameters.ExcludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("excludeDomains"));
        Assert.Null(parameters.IncludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("includeDomains"));
        Assert.Null(parameters.MaxTokens);
        Assert.False(parameters.RawBodyData.ContainsKey("maxTokens"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.NumResults);
        Assert.False(parameters.RawBodyData.ContainsKey("numResults"));
        Assert.Null(parameters.SearchType);
        Assert.False(parameters.RawBodyData.ContainsKey("searchType"));
        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawBodyData.ContainsKey("stream"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
        Assert.Null(parameters.UseCustomLlm);
        Assert.False(parameters.RawBodyData.ContainsKey("useCustomLLM"));
    }

    [Fact]
    public void Url_Works()
    {
        V1AnswerParams parameters = new() { Query = "query" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/search/v1/answer"), url);
    }
}

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
