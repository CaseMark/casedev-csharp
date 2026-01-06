using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using V1 = CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1SearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1::V1SearchParams
        {
            Query = "query",
            AdditionalQueries = ["string"],
            Category = "category",
            Contents = "contents",
            EndCrawlDate = "2019-12-27",
            EndPublishedDate = "2019-12-27",
            ExcludeDomains = ["string"],
            IncludeDomains = ["string"],
            IncludeText = true,
            NumResults = 1,
            StartCrawlDate = "2019-12-27",
            StartPublishedDate = "2019-12-27",
            Type = V1::Type.Auto,
            UserLocation = "userLocation",
        };

        string expectedQuery = "query";
        List<string> expectedAdditionalQueries = ["string"];
        string expectedCategory = "category";
        string expectedContents = "contents";
        string expectedEndCrawlDate = "2019-12-27";
        string expectedEndPublishedDate = "2019-12-27";
        List<string> expectedExcludeDomains = ["string"];
        List<string> expectedIncludeDomains = ["string"];
        bool expectedIncludeText = true;
        long expectedNumResults = 1;
        string expectedStartCrawlDate = "2019-12-27";
        string expectedStartPublishedDate = "2019-12-27";
        ApiEnum<string, V1::Type> expectedType = V1::Type.Auto;
        string expectedUserLocation = "userLocation";

        Assert.Equal(expectedQuery, parameters.Query);
        Assert.NotNull(parameters.AdditionalQueries);
        Assert.Equal(expectedAdditionalQueries.Count, parameters.AdditionalQueries.Count);
        for (int i = 0; i < expectedAdditionalQueries.Count; i++)
        {
            Assert.Equal(expectedAdditionalQueries[i], parameters.AdditionalQueries[i]);
        }
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedContents, parameters.Contents);
        Assert.Equal(expectedEndCrawlDate, parameters.EndCrawlDate);
        Assert.Equal(expectedEndPublishedDate, parameters.EndPublishedDate);
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
        Assert.Equal(expectedIncludeText, parameters.IncludeText);
        Assert.Equal(expectedNumResults, parameters.NumResults);
        Assert.Equal(expectedStartCrawlDate, parameters.StartCrawlDate);
        Assert.Equal(expectedStartPublishedDate, parameters.StartPublishedDate);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedUserLocation, parameters.UserLocation);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1::V1SearchParams { Query = "query" };

        Assert.Null(parameters.AdditionalQueries);
        Assert.False(parameters.RawBodyData.ContainsKey("additionalQueries"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Contents);
        Assert.False(parameters.RawBodyData.ContainsKey("contents"));
        Assert.Null(parameters.EndCrawlDate);
        Assert.False(parameters.RawBodyData.ContainsKey("endCrawlDate"));
        Assert.Null(parameters.EndPublishedDate);
        Assert.False(parameters.RawBodyData.ContainsKey("endPublishedDate"));
        Assert.Null(parameters.ExcludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("excludeDomains"));
        Assert.Null(parameters.IncludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("includeDomains"));
        Assert.Null(parameters.IncludeText);
        Assert.False(parameters.RawBodyData.ContainsKey("includeText"));
        Assert.Null(parameters.NumResults);
        Assert.False(parameters.RawBodyData.ContainsKey("numResults"));
        Assert.Null(parameters.StartCrawlDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startCrawlDate"));
        Assert.Null(parameters.StartPublishedDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startPublishedDate"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
        Assert.Null(parameters.UserLocation);
        Assert.False(parameters.RawBodyData.ContainsKey("userLocation"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1::V1SearchParams
        {
            Query = "query",

            // Null should be interpreted as omitted for these properties
            AdditionalQueries = null,
            Category = null,
            Contents = null,
            EndCrawlDate = null,
            EndPublishedDate = null,
            ExcludeDomains = null,
            IncludeDomains = null,
            IncludeText = null,
            NumResults = null,
            StartCrawlDate = null,
            StartPublishedDate = null,
            Type = null,
            UserLocation = null,
        };

        Assert.Null(parameters.AdditionalQueries);
        Assert.False(parameters.RawBodyData.ContainsKey("additionalQueries"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Contents);
        Assert.False(parameters.RawBodyData.ContainsKey("contents"));
        Assert.Null(parameters.EndCrawlDate);
        Assert.False(parameters.RawBodyData.ContainsKey("endCrawlDate"));
        Assert.Null(parameters.EndPublishedDate);
        Assert.False(parameters.RawBodyData.ContainsKey("endPublishedDate"));
        Assert.Null(parameters.ExcludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("excludeDomains"));
        Assert.Null(parameters.IncludeDomains);
        Assert.False(parameters.RawBodyData.ContainsKey("includeDomains"));
        Assert.Null(parameters.IncludeText);
        Assert.False(parameters.RawBodyData.ContainsKey("includeText"));
        Assert.Null(parameters.NumResults);
        Assert.False(parameters.RawBodyData.ContainsKey("numResults"));
        Assert.Null(parameters.StartCrawlDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startCrawlDate"));
        Assert.Null(parameters.StartPublishedDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startPublishedDate"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
        Assert.Null(parameters.UserLocation);
        Assert.False(parameters.RawBodyData.ContainsKey("userLocation"));
    }

    [Fact]
    public void Url_Works()
    {
        V1::V1SearchParams parameters = new() { Query = "query" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/search/v1/search"), url);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(V1::Type.Auto)]
    [InlineData(V1::Type.Search)]
    [InlineData(V1::Type.News)]
    public void Validation_Works(V1::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1::Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1::Type.Auto)]
    [InlineData(V1::Type.Search)]
    [InlineData(V1::Type.News)]
    public void SerializationRoundtrip_Works(V1::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1::Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
