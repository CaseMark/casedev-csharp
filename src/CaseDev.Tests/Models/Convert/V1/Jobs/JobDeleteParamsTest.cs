using CaseDev.Models.Convert.V1.Jobs;

namespace CaseDev.Tests.Models.Convert.V1.Jobs;

public class JobDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JobDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }
}
