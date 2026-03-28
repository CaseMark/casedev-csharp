using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Parties = Casedev.Models.Matters.V1.Parties;

namespace Casedev.Tests.Models.Matters.V1.Parties;

public class PartyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Parties::PartyCreateParams
        {
            Name = "name",
            Addresses =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Email = "email",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Notes = "notes",
            Phone = "phone",
            Type = Parties::Type.Person,
        };

        string expectedName = "name";
        List<Dictionary<string, JsonElement>> expectedAddresses =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        Dictionary<string, JsonElement> expectedCustomFields = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedEmail = "email";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedNotes = "notes";
        string expectedPhone = "phone";
        ApiEnum<string, Parties::Type> expectedType = Parties::Type.Person;

        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Addresses);
        Assert.Equal(expectedAddresses.Count, parameters.Addresses.Count);
        for (int i = 0; i < expectedAddresses.Count; i++)
        {
            Assert.Equal(expectedAddresses[i].Count, parameters.Addresses[i].Count);
            foreach (var item in expectedAddresses[i])
            {
                Assert.True(parameters.Addresses[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, parameters.Addresses[i][item.Key]));
            }
        }
        Assert.NotNull(parameters.CustomFields);
        Assert.Equal(expectedCustomFields.Count, parameters.CustomFields.Count);
        foreach (var item in expectedCustomFields)
        {
            Assert.True(parameters.CustomFields.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.CustomFields[item.Key]));
        }
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedPhone, parameters.Phone);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Parties::PartyCreateParams
        {
            Name = "name",
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Notes = "notes",
        };

        Assert.Null(parameters.Addresses);
        Assert.False(parameters.RawBodyData.ContainsKey("addresses"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Phone);
        Assert.False(parameters.RawBodyData.ContainsKey("phone"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Parties::PartyCreateParams
        {
            Name = "name",
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Notes = "notes",

            // Null should be interpreted as omitted for these properties
            Addresses = null,
            Email = null,
            Metadata = null,
            Phone = null,
            Type = null,
        };

        Assert.Null(parameters.Addresses);
        Assert.False(parameters.RawBodyData.ContainsKey("addresses"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Phone);
        Assert.False(parameters.RawBodyData.ContainsKey("phone"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Parties::PartyCreateParams
        {
            Name = "name",
            Addresses =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Email = "email",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Phone = "phone",
            Type = Parties::Type.Person,
        };

        Assert.Null(parameters.CustomFields);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_fields"));
        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Parties::PartyCreateParams
        {
            Name = "name",
            Addresses =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Email = "email",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Phone = "phone",
            Type = Parties::Type.Person,

            CustomFields = null,
            Notes = null,
        };

        Assert.Null(parameters.CustomFields);
        Assert.True(parameters.RawBodyData.ContainsKey("custom_fields"));
        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void Url_Works()
    {
        Parties::PartyCreateParams parameters = new() { Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/matters/v1/parties"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Parties::PartyCreateParams
        {
            Name = "name",
            Addresses =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Email = "email",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Notes = "notes",
            Phone = "phone",
            Type = Parties::Type.Person,
        };

        Parties::PartyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Parties::Type.Person)]
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
    [InlineData(Parties::Type.Person)]
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
