using CaseDev.Models.Compute.V1.Environments;

namespace CaseDev.Tests.Models.Compute.V1.Environments;

public class EnvironmentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EnvironmentCreateParams { Name = "document-review-prod" };

        string expectedName = "document-review-prod";

        Assert.Equal(expectedName, parameters.Name);
    }
}
