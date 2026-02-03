using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Payments.V1.Accounts;

namespace CaseDev.Tests.Models.Payments.V1.Accounts;

public class AccountGetLedgerResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountGetLedgerResponse
        {
            Entries = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Pagination = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        List<JsonElement> expectedEntries = [JsonSerializer.Deserialize<JsonElement>("{}")];
        JsonElement expectedPagination = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.NotNull(model.Entries);
        Assert.Equal(expectedEntries.Count, model.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedEntries[i], model.Entries[i]));
        }
        Assert.NotNull(model.Pagination);
        Assert.True(JsonElement.DeepEquals(expectedPagination, model.Pagination.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountGetLedgerResponse
        {
            Entries = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Pagination = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountGetLedgerResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountGetLedgerResponse
        {
            Entries = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Pagination = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountGetLedgerResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<JsonElement> expectedEntries = [JsonSerializer.Deserialize<JsonElement>("{}")];
        JsonElement expectedPagination = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.NotNull(deserialized.Entries);
        Assert.Equal(expectedEntries.Count, deserialized.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedEntries[i], deserialized.Entries[i]));
        }
        Assert.NotNull(deserialized.Pagination);
        Assert.True(JsonElement.DeepEquals(expectedPagination, deserialized.Pagination.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountGetLedgerResponse
        {
            Entries = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Pagination = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountGetLedgerResponse { };

        Assert.Null(model.Entries);
        Assert.False(model.RawData.ContainsKey("entries"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountGetLedgerResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountGetLedgerResponse
        {
            // Null should be interpreted as omitted for these properties
            Entries = null,
            Pagination = null,
        };

        Assert.Null(model.Entries);
        Assert.False(model.RawData.ContainsKey("entries"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountGetLedgerResponse
        {
            // Null should be interpreted as omitted for these properties
            Entries = null,
            Pagination = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountGetLedgerResponse
        {
            Entries = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Pagination = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        AccountGetLedgerResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
