using System;
using System.Text.Json;
using CaseDev.Models.Payments.V1.Accounts;

namespace CaseDev.Tests.Models.Payments.V1.Accounts;

public class AccountUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountUpdateParams
        {
            ID = "id",
            IsActive = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        string expectedID = "id";
        bool expectedIsActive = true;
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIsActive, parameters.IsActive);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountUpdateParams { ID = "id" };

        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("is_active"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountUpdateParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            IsActive = null,
            Metadata = null,
            Name = null,
        };

        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("is_active"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/accounts/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountUpdateParams
        {
            ID = "id",
            IsActive = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
        };

        AccountUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
