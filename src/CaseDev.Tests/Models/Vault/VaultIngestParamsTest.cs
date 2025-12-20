using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultIngestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultIngestParams { ID = "id", ObjectID = "objectId" };

        string expectedID = "id";
        string expectedObjectID = "objectId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
    }
}
