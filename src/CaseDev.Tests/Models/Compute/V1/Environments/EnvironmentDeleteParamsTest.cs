using CaseDev.Models.Compute.V1.Environments;

namespace CaseDev.Tests.Models.Compute.V1.Environments;

public class EnvironmentDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EnvironmentDeleteParams { Name = "litigation-processing" };

        string expectedName = "litigation-processing";

        Assert.Equal(expectedName, parameters.Name);
    }
}
