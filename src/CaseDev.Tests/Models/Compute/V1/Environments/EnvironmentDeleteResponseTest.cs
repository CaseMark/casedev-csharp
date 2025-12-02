using CaseDev.Models.Compute.V1.Environments;

namespace CaseDev.Tests.Models.Compute.V1.Environments;

public class EnvironmentDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EnvironmentDeleteResponse
        {
            Message = "Environment 'litigation-processing' deleted",
            Success = true,
        };

        string expectedMessage = "Environment 'litigation-processing' deleted";
        bool expectedSuccess = true;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedSuccess, model.Success);
    }
}
