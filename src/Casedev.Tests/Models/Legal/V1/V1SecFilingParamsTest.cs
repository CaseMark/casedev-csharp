using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1SecFilingParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1SecFilingParams
        {
            Type = V1SecFilingParamsType.Search,
            Cik = "cik",
            DateAfter = "2019-12-27",
            DateBefore = "2019-12-27",
            Entity = "entity",
            FormTypes = ["string"],
            Limit = 1,
            Offset = 0,
            Query = "xx",
            Ticker = "ticker",
        };

        ApiEnum<string, V1SecFilingParamsType> expectedType = V1SecFilingParamsType.Search;
        string expectedCik = "cik";
        string expectedDateAfter = "2019-12-27";
        string expectedDateBefore = "2019-12-27";
        string expectedEntity = "entity";
        List<string> expectedFormTypes = ["string"];
        long expectedLimit = 1;
        long expectedOffset = 0;
        string expectedQuery = "xx";
        string expectedTicker = "ticker";

        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedCik, parameters.Cik);
        Assert.Equal(expectedDateAfter, parameters.DateAfter);
        Assert.Equal(expectedDateBefore, parameters.DateBefore);
        Assert.Equal(expectedEntity, parameters.Entity);
        Assert.NotNull(parameters.FormTypes);
        Assert.Equal(expectedFormTypes.Count, parameters.FormTypes.Count);
        for (int i = 0; i < expectedFormTypes.Count; i++)
        {
            Assert.Equal(expectedFormTypes[i], parameters.FormTypes[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedTicker, parameters.Ticker);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1SecFilingParams { Type = V1SecFilingParamsType.Search };

        Assert.Null(parameters.Cik);
        Assert.False(parameters.RawBodyData.ContainsKey("cik"));
        Assert.Null(parameters.DateAfter);
        Assert.False(parameters.RawBodyData.ContainsKey("dateAfter"));
        Assert.Null(parameters.DateBefore);
        Assert.False(parameters.RawBodyData.ContainsKey("dateBefore"));
        Assert.Null(parameters.Entity);
        Assert.False(parameters.RawBodyData.ContainsKey("entity"));
        Assert.Null(parameters.FormTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("formTypes"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawBodyData.ContainsKey("query"));
        Assert.Null(parameters.Ticker);
        Assert.False(parameters.RawBodyData.ContainsKey("ticker"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1SecFilingParams
        {
            Type = V1SecFilingParamsType.Search,

            // Null should be interpreted as omitted for these properties
            Cik = null,
            DateAfter = null,
            DateBefore = null,
            Entity = null,
            FormTypes = null,
            Limit = null,
            Offset = null,
            Query = null,
            Ticker = null,
        };

        Assert.Null(parameters.Cik);
        Assert.False(parameters.RawBodyData.ContainsKey("cik"));
        Assert.Null(parameters.DateAfter);
        Assert.False(parameters.RawBodyData.ContainsKey("dateAfter"));
        Assert.Null(parameters.DateBefore);
        Assert.False(parameters.RawBodyData.ContainsKey("dateBefore"));
        Assert.Null(parameters.Entity);
        Assert.False(parameters.RawBodyData.ContainsKey("entity"));
        Assert.Null(parameters.FormTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("formTypes"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawBodyData.ContainsKey("query"));
        Assert.Null(parameters.Ticker);
        Assert.False(parameters.RawBodyData.ContainsKey("ticker"));
    }

    [Fact]
    public void Url_Works()
    {
        V1SecFilingParams parameters = new() { Type = V1SecFilingParamsType.Search };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.case.dev/legal/v1/sec-filing"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1SecFilingParams
        {
            Type = V1SecFilingParamsType.Search,
            Cik = "cik",
            DateAfter = "2019-12-27",
            DateBefore = "2019-12-27",
            Entity = "entity",
            FormTypes = ["string"],
            Limit = 1,
            Offset = 0,
            Query = "xx",
            Ticker = "ticker",
        };

        V1SecFilingParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class V1SecFilingParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(V1SecFilingParamsType.Search)]
    [InlineData(V1SecFilingParamsType.Entity)]
    public void Validation_Works(V1SecFilingParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1SecFilingParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1SecFilingParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1SecFilingParamsType.Search)]
    [InlineData(V1SecFilingParamsType.Entity)]
    public void SerializationRoundtrip_Works(V1SecFilingParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1SecFilingParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1SecFilingParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1SecFilingParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1SecFilingParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
