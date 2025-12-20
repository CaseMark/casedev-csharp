using CaseDev.Models.Vault.Objects;

namespace CaseDev.Tests.Models.Vault.Objects;

public class ObjectGetTextParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ObjectGetTextParams { ID = "id", ObjectID = "objectId" };

        string expectedID = "id";
        string expectedObjectID = "objectId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
    }
}
