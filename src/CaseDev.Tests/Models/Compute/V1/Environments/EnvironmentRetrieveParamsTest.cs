using CaseDev.Models.Compute.V1.Environments;

namespace CaseDev.Tests.Models.Compute.V1.Environments;

public class EnvironmentRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EnvironmentRetrieveParams { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, parameters.Name);
    }
}
