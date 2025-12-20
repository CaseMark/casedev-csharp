using CaseDev.Models.Compute.V1.Environments;

namespace CaseDev.Tests.Models.Compute.V1.Environments;

public class EnvironmentSetDefaultParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EnvironmentSetDefaultParams { Name = "prod-legal-docs" };

        string expectedName = "prod-legal-docs";

        Assert.Equal(expectedName, parameters.Name);
    }
}
