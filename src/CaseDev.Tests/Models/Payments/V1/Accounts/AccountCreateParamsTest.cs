using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using Accounts = CaseDev.Models.Payments.V1.Accounts;

namespace CaseDev.Tests.Models.Payments.V1.Accounts;

public class AccountCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Accounts::AccountCreateParams
        {
            Name = "name",
            Type = Accounts::Type.Trust,
            Currency = "currency",
            MatterID = "matter_id",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            ParentAccountID = "parent_account_id",
        };

        string expectedName = "name";
        ApiEnum<string, Accounts::Type> expectedType = Accounts::Type.Trust;
        string expectedCurrency = "currency";
        string expectedMatterID = "matter_id";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedParentAccountID = "parent_account_id";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedMatterID, parameters.MatterID);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.Equal(expectedParentAccountID, parameters.ParentAccountID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Accounts::AccountCreateParams
        {
            Name = "name",
            Type = Accounts::Type.Trust,
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.MatterID);
        Assert.False(parameters.RawBodyData.ContainsKey("matter_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ParentAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("parent_account_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Accounts::AccountCreateParams
        {
            Name = "name",
            Type = Accounts::Type.Trust,

            // Null should be interpreted as omitted for these properties
            Currency = null,
            MatterID = null,
            Metadata = null,
            ParentAccountID = null,
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.MatterID);
        Assert.False(parameters.RawBodyData.ContainsKey("matter_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ParentAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("parent_account_id"));
    }

    [Fact]
    public void Url_Works()
    {
        Accounts::AccountCreateParams parameters = new()
        {
            Name = "name",
            Type = Accounts::Type.Trust,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/accounts"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Accounts::AccountCreateParams
        {
            Name = "name",
            Type = Accounts::Type.Trust,
            Currency = "currency",
            MatterID = "matter_id",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            ParentAccountID = "parent_account_id",
        };

        Accounts::AccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Accounts::Type.Trust)]
    [InlineData(Accounts::Type.Operating)]
    [InlineData(Accounts::Type.Escrow)]
    [InlineData(Accounts::Type.Reserve)]
    [InlineData(Accounts::Type.Client)]
    [InlineData(Accounts::Type.Sub)]
    public void Validation_Works(Accounts::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Accounts::Type.Trust)]
    [InlineData(Accounts::Type.Operating)]
    [InlineData(Accounts::Type.Escrow)]
    [InlineData(Accounts::Type.Reserve)]
    [InlineData(Accounts::Type.Client)]
    [InlineData(Accounts::Type.Sub)]
    public void SerializationRoundtrip_Works(Accounts::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Accounts::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Accounts::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
