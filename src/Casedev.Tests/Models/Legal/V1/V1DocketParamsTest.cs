using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using V1 = Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1DocketParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1::V1DocketParams
        {
            Type = V1::Type.Search,
            AcknowledgePacerFees = true,
            Court = "court",
            DateFiledAfter = "2019-12-27",
            DateFiledBefore = "2019-12-27",
            DocketID = "docketId",
            IncludeEntries = true,
            Limit = 1,
            Live = true,
            Offset = 0,
            Query = "xx",
        };

        ApiEnum<string, V1::Type> expectedType = V1::Type.Search;
        bool expectedAcknowledgePacerFees = true;
        string expectedCourt = "court";
        string expectedDateFiledAfter = "2019-12-27";
        string expectedDateFiledBefore = "2019-12-27";
        string expectedDocketID = "docketId";
        bool expectedIncludeEntries = true;
        long expectedLimit = 1;
        bool expectedLive = true;
        long expectedOffset = 0;
        string expectedQuery = "xx";

        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedAcknowledgePacerFees, parameters.AcknowledgePacerFees);
        Assert.Equal(expectedCourt, parameters.Court);
        Assert.Equal(expectedDateFiledAfter, parameters.DateFiledAfter);
        Assert.Equal(expectedDateFiledBefore, parameters.DateFiledBefore);
        Assert.Equal(expectedDocketID, parameters.DocketID);
        Assert.Equal(expectedIncludeEntries, parameters.IncludeEntries);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedLive, parameters.Live);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedQuery, parameters.Query);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1::V1DocketParams { Type = V1::Type.Search };

        Assert.Null(parameters.AcknowledgePacerFees);
        Assert.False(parameters.RawBodyData.ContainsKey("acknowledgePacerFees"));
        Assert.Null(parameters.Court);
        Assert.False(parameters.RawBodyData.ContainsKey("court"));
        Assert.Null(parameters.DateFiledAfter);
        Assert.False(parameters.RawBodyData.ContainsKey("dateFiledAfter"));
        Assert.Null(parameters.DateFiledBefore);
        Assert.False(parameters.RawBodyData.ContainsKey("dateFiledBefore"));
        Assert.Null(parameters.DocketID);
        Assert.False(parameters.RawBodyData.ContainsKey("docketId"));
        Assert.Null(parameters.IncludeEntries);
        Assert.False(parameters.RawBodyData.ContainsKey("includeEntries"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Live);
        Assert.False(parameters.RawBodyData.ContainsKey("live"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawBodyData.ContainsKey("query"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1::V1DocketParams
        {
            Type = V1::Type.Search,

            // Null should be interpreted as omitted for these properties
            AcknowledgePacerFees = null,
            Court = null,
            DateFiledAfter = null,
            DateFiledBefore = null,
            DocketID = null,
            IncludeEntries = null,
            Limit = null,
            Live = null,
            Offset = null,
            Query = null,
        };

        Assert.Null(parameters.AcknowledgePacerFees);
        Assert.False(parameters.RawBodyData.ContainsKey("acknowledgePacerFees"));
        Assert.Null(parameters.Court);
        Assert.False(parameters.RawBodyData.ContainsKey("court"));
        Assert.Null(parameters.DateFiledAfter);
        Assert.False(parameters.RawBodyData.ContainsKey("dateFiledAfter"));
        Assert.Null(parameters.DateFiledBefore);
        Assert.False(parameters.RawBodyData.ContainsKey("dateFiledBefore"));
        Assert.Null(parameters.DocketID);
        Assert.False(parameters.RawBodyData.ContainsKey("docketId"));
        Assert.Null(parameters.IncludeEntries);
        Assert.False(parameters.RawBodyData.ContainsKey("includeEntries"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Live);
        Assert.False(parameters.RawBodyData.ContainsKey("live"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawBodyData.ContainsKey("query"));
    }

    [Fact]
    public void Url_Works()
    {
        V1::V1DocketParams parameters = new() { Type = V1::Type.Search };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/docket"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1::V1DocketParams
        {
            Type = V1::Type.Search,
            AcknowledgePacerFees = true,
            Court = "court",
            DateFiledAfter = "2019-12-27",
            DateFiledBefore = "2019-12-27",
            DocketID = "docketId",
            IncludeEntries = true,
            Limit = 1,
            Live = true,
            Offset = 0,
            Query = "xx",
        };

        V1::V1DocketParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(V1::Type.Search)]
    [InlineData(V1::Type.Lookup)]
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
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1::Type.Search)]
    [InlineData(V1::Type.Lookup)]
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
            JsonSerializer.SerializeToElement("invalid value"),
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
