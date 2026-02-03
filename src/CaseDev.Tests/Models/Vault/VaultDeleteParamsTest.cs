using System;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultDeleteParams { ID = "id", Async = true };

        string expectedID = "id";
        bool expectedAsync = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAsync, parameters.Async);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VaultDeleteParams { ID = "id" };

        Assert.Null(parameters.Async);
        Assert.False(parameters.RawQueryData.ContainsKey("async"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VaultDeleteParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Async = null,
        };

        Assert.Null(parameters.Async);
        Assert.False(parameters.RawQueryData.ContainsKey("async"));
    }

    [Fact]
    public void Url_Works()
    {
        VaultDeleteParams parameters = new() { ID = "id", Async = true };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id?async=true"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VaultDeleteParams { ID = "id", Async = true };

        VaultDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
