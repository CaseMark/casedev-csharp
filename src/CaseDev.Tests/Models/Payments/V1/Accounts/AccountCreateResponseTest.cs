using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Payments.V1.Accounts;

namespace CaseDev.Tests.Models.Payments.V1.Accounts;

public class AccountCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountCreateResponse
        {
            ID = "id",
            CachedAvailableBalance = 0,
            CachedBalance = 0,
            CreatedAt = "createdAt",
            Currency = "currency",
            IsActive = true,
            Name = "name",
            OrganizationID = "organizationId",
            Type = "type",
        };

        string expectedID = "id";
        double expectedCachedAvailableBalance = 0;
        double expectedCachedBalance = 0;
        string expectedCreatedAt = "createdAt";
        string expectedCurrency = "currency";
        bool expectedIsActive = true;
        string expectedName = "name";
        string expectedOrganizationID = "organizationId";
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCachedAvailableBalance, model.CachedAvailableBalance);
        Assert.Equal(expectedCachedBalance, model.CachedBalance);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountCreateResponse
        {
            ID = "id",
            CachedAvailableBalance = 0,
            CachedBalance = 0,
            CreatedAt = "createdAt",
            Currency = "currency",
            IsActive = true,
            Name = "name",
            OrganizationID = "organizationId",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountCreateResponse
        {
            ID = "id",
            CachedAvailableBalance = 0,
            CachedBalance = 0,
            CreatedAt = "createdAt",
            Currency = "currency",
            IsActive = true,
            Name = "name",
            OrganizationID = "organizationId",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedCachedAvailableBalance = 0;
        double expectedCachedBalance = 0;
        string expectedCreatedAt = "createdAt";
        string expectedCurrency = "currency";
        bool expectedIsActive = true;
        string expectedName = "name";
        string expectedOrganizationID = "organizationId";
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCachedAvailableBalance, deserialized.CachedAvailableBalance);
        Assert.Equal(expectedCachedBalance, deserialized.CachedBalance);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountCreateResponse
        {
            ID = "id",
            CachedAvailableBalance = 0,
            CachedBalance = 0,
            CreatedAt = "createdAt",
            Currency = "currency",
            IsActive = true,
            Name = "name",
            OrganizationID = "organizationId",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountCreateResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CachedAvailableBalance);
        Assert.False(model.RawData.ContainsKey("cachedAvailableBalance"));
        Assert.Null(model.CachedBalance);
        Assert.False(model.RawData.ContainsKey("cachedBalance"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("isActive"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organizationId"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountCreateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CachedAvailableBalance = null,
            CachedBalance = null,
            CreatedAt = null,
            Currency = null,
            IsActive = null,
            Name = null,
            OrganizationID = null,
            Type = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CachedAvailableBalance);
        Assert.False(model.RawData.ContainsKey("cachedAvailableBalance"));
        Assert.Null(model.CachedBalance);
        Assert.False(model.RawData.ContainsKey("cachedBalance"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("isActive"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organizationId"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CachedAvailableBalance = null,
            CachedBalance = null,
            CreatedAt = null,
            Currency = null,
            IsActive = null,
            Name = null,
            OrganizationID = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountCreateResponse
        {
            ID = "id",
            CachedAvailableBalance = 0,
            CachedBalance = 0,
            CreatedAt = "createdAt",
            Currency = "currency",
            IsActive = true,
            Name = "name",
            OrganizationID = "organizationId",
            Type = "type",
        };

        AccountCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
