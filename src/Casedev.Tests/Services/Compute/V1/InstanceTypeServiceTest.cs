using System.Threading.Tasks;

namespace Casedev.Tests.Services.Compute.V1;

public class InstanceTypeServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var instanceTypes = await this.client.Compute.V1.InstanceTypes.List(
            new(),
            TestContext.Current.CancellationToken
        );
        instanceTypes.Validate();
    }
}
