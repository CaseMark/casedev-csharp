using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.MatterParties;

namespace Casedev.Tests.Models.Matters.V1.MatterParties;

public class MatterPartyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MatterPartyCreateParams
        {
            ID = "id",
            PartyID = "party_id",
            Role = Role.Client,
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsPrimary = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Notes = "notes",
            SetAsClient = true,
        };

        string expectedID = "id";
        string expectedPartyID = "party_id";
        ApiEnum<string, Role> expectedRole = Role.Client;
        Dictionary<string, JsonElement> expectedCustomFields = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedIsPrimary = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedNotes = "notes";
        bool expectedSetAsClient = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedPartyID, parameters.PartyID);
        Assert.Equal(expectedRole, parameters.Role);
        Assert.NotNull(parameters.CustomFields);
        Assert.Equal(expectedCustomFields.Count, parameters.CustomFields.Count);
        foreach (var item in expectedCustomFields)
        {
            Assert.True(parameters.CustomFields.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.CustomFields[item.Key]));
        }
        Assert.Equal(expectedIsPrimary, parameters.IsPrimary);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedSetAsClient, parameters.SetAsClient);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MatterPartyCreateParams
        {
            ID = "id",
            PartyID = "party_id",
            Role = Role.Client,
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Notes = "notes",
        };

        Assert.Null(parameters.IsPrimary);
        Assert.False(parameters.RawBodyData.ContainsKey("is_primary"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.SetAsClient);
        Assert.False(parameters.RawBodyData.ContainsKey("set_as_client"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MatterPartyCreateParams
        {
            ID = "id",
            PartyID = "party_id",
            Role = Role.Client,
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Notes = "notes",

            // Null should be interpreted as omitted for these properties
            IsPrimary = null,
            Metadata = null,
            SetAsClient = null,
        };

        Assert.Null(parameters.IsPrimary);
        Assert.False(parameters.RawBodyData.ContainsKey("is_primary"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.SetAsClient);
        Assert.False(parameters.RawBodyData.ContainsKey("set_as_client"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MatterPartyCreateParams
        {
            ID = "id",
            PartyID = "party_id",
            Role = Role.Client,
            IsPrimary = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            SetAsClient = true,
        };

        Assert.Null(parameters.CustomFields);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_fields"));
        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MatterPartyCreateParams
        {
            ID = "id",
            PartyID = "party_id",
            Role = Role.Client,
            IsPrimary = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            SetAsClient = true,

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
        MatterPartyCreateParams parameters = new()
        {
            ID = "id",
            PartyID = "party_id",
            Role = Role.Client,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/matters/v1/id/parties"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MatterPartyCreateParams
        {
            ID = "id",
            PartyID = "party_id",
            Role = Role.Client,
            CustomFields = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsPrimary = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Notes = "notes",
            SetAsClient = true,
        };

        MatterPartyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.Client)]
    [InlineData(Role.Prospect)]
    [InlineData(Role.OpposingParty)]
    [InlineData(Role.OpposingCounsel)]
    [InlineData(Role.CoCounsel)]
    [InlineData(Role.Judge)]
    [InlineData(Role.Expert)]
    [InlineData(Role.Witness)]
    [InlineData(Role.Vendor)]
    [InlineData(Role.Insurer)]
    [InlineData(Role.Other)]
    public void Validation_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.Client)]
    [InlineData(Role.Prospect)]
    [InlineData(Role.OpposingParty)]
    [InlineData(Role.OpposingCounsel)]
    [InlineData(Role.CoCounsel)]
    [InlineData(Role.Judge)]
    [InlineData(Role.Expert)]
    [InlineData(Role.Witness)]
    [InlineData(Role.Vendor)]
    [InlineData(Role.Insurer)]
    [InlineData(Role.Other)]
    public void SerializationRoundtrip_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
