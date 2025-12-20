using CaseDev.Models.Templates.V1;

namespace CaseDev.Tests.Models.Templates.V1;

public class V1RetrieveExecutionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1RetrieveExecutionParams { ID = "exec_abc123def456" };

        string expectedID = "exec_abc123def456";

        Assert.Equal(expectedID, parameters.ID);
    }
}
