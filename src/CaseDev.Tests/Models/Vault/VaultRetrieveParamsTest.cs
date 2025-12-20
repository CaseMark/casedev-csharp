using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultRetrieveParams { ID = "vault_abc123" };

        string expectedID = "vault_abc123";

        Assert.Equal(expectedID, parameters.ID);
    }
}
