using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using Parties = CaseDev.Models.Payments.V1.Parties;

namespace CaseDev.Tests.Models.Payments.V1.Parties;

public class PartyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Parties::PartyCreateParams
        {
            Name = "name",
            Type = Parties::Type.Individual,
            AddressLine1 = "address_line1",
            City = "city",
            Country = "country",
            Email = "email",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Phone = "phone",
            PostalCode = "postal_code",
            Role = Parties::Role.Client,
            State = "state",
        };

        string expectedName = "name";
        ApiEnum<string, Parties::Type> expectedType = Parties::Type.Individual;
        string expectedAddressLine1 = "address_line1";
        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedEmail = "email";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedPhone = "phone";
        string expectedPostalCode = "postal_code";
        ApiEnum<string, Parties::Role> expectedRole = Parties::Role.Client;
        string expectedState = "state";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedAddressLine1, parameters.AddressLine1);
        Assert.Equal(expectedCity, parameters.City);
        Assert.Equal(expectedCountry, parameters.Country);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.Equal(expectedPhone, parameters.Phone);
        Assert.Equal(expectedPostalCode, parameters.PostalCode);
        Assert.Equal(expectedRole, parameters.Role);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Parties::PartyCreateParams
        {
            Name = "name",
            Type = Parties::Type.Individual,
        };

        Assert.Null(parameters.AddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("address_line1"));
        Assert.Null(parameters.City);
        Assert.False(parameters.RawBodyData.ContainsKey("city"));
        Assert.Null(parameters.Country);
        Assert.False(parameters.RawBodyData.ContainsKey("country"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Phone);
        Assert.False(parameters.RawBodyData.ContainsKey("phone"));
        Assert.Null(parameters.PostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("postal_code"));
        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Parties::PartyCreateParams
        {
            Name = "name",
            Type = Parties::Type.Individual,

            // Null should be interpreted as omitted for these properties
            AddressLine1 = null,
            City = null,
            Country = null,
            Email = null,
            Metadata = null,
            Phone = null,
            PostalCode = null,
            Role = null,
            State = null,
        };

        Assert.Null(parameters.AddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("address_line1"));
        Assert.Null(parameters.City);
        Assert.False(parameters.RawBodyData.ContainsKey("city"));
        Assert.Null(parameters.Country);
        Assert.False(parameters.RawBodyData.ContainsKey("country"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Phone);
        Assert.False(parameters.RawBodyData.ContainsKey("phone"));
        Assert.Null(parameters.PostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("postal_code"));
        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void Url_Works()
    {
        Parties::PartyCreateParams parameters = new()
        {
            Name = "name",
            Type = Parties::Type.Individual,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/parties"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Parties::PartyCreateParams
        {
            Name = "name",
            Type = Parties::Type.Individual,
            AddressLine1 = "address_line1",
            City = "city",
            Country = "country",
            Email = "email",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Phone = "phone",
            PostalCode = "postal_code",
            Role = Parties::Role.Client,
            State = "state",
        };

        Parties::PartyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Parties::Type.Individual)]
    [InlineData(Parties::Type.Organization)]
    public void Validation_Works(Parties::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parties::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parties::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parties::Type.Individual)]
    [InlineData(Parties::Type.Organization)]
    public void SerializationRoundtrip_Works(Parties::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parties::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parties::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parties::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parties::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Parties::Role.Client)]
    [InlineData(Parties::Role.Vendor)]
    [InlineData(Parties::Role.Counsel)]
    [InlineData(Parties::Role.Expert)]
    [InlineData(Parties::Role.LienHolder)]
    [InlineData(Parties::Role.Funder)]
    [InlineData(Parties::Role.OpposingParty)]
    [InlineData(Parties::Role.Other)]
    public void Validation_Works(Parties::Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parties::Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parties::Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parties::Role.Client)]
    [InlineData(Parties::Role.Vendor)]
    [InlineData(Parties::Role.Counsel)]
    [InlineData(Parties::Role.Expert)]
    [InlineData(Parties::Role.LienHolder)]
    [InlineData(Parties::Role.Funder)]
    [InlineData(Parties::Role.OpposingParty)]
    [InlineData(Parties::Role.Other)]
    public void SerializationRoundtrip_Works(Parties::Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parties::Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parties::Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parties::Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parties::Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
