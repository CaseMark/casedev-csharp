using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.Parties;

namespace Casedev.Tests.Models.Matters.V1.Parties;

public class PartyListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PartyListParams
        {
            Email = "email",
            Query = "query",
            Type = PartyListParamsType.Person,
        };

        string expectedEmail = "email";
        string expectedQuery = "query";
        ApiEnum<string, PartyListParamsType> expectedType = PartyListParamsType.Person;

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PartyListParams { };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawQueryData.ContainsKey("email"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawQueryData.ContainsKey("query"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PartyListParams
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
            Query = null,
            Type = null,
        };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawQueryData.ContainsKey("email"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawQueryData.ContainsKey("query"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        PartyListParams parameters = new()
        {
            Email = "email",
            Query = "query",
            Type = PartyListParamsType.Person,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.case.dev/matters/v1/parties?email=email&query=query&type=person"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PartyListParams
        {
            Email = "email",
            Query = "query",
            Type = PartyListParamsType.Person,
        };

        PartyListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PartyListParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(PartyListParamsType.Person)]
    [InlineData(PartyListParamsType.Organization)]
    public void Validation_Works(PartyListParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PartyListParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PartyListParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PartyListParamsType.Person)]
    [InlineData(PartyListParamsType.Organization)]
    public void SerializationRoundtrip_Works(PartyListParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PartyListParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PartyListParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PartyListParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PartyListParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
