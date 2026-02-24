using System;
using Casedev.Models.Vault;

namespace Casedev.Tests.Models.Vault;

public class VaultRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultRetrieveParams { ID = "vault_abc123" };

        string expectedID = "vault_abc123";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        VaultRetrieveParams parameters = new() { ID = "vault_abc123" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/vault_abc123"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VaultRetrieveParams { ID = "vault_abc123" };

        VaultRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
