using System.Threading.Tasks;

namespace Casedev.Tests.Services;

public class SystemServiceTest : TestBase
{
    [Fact]
    public async Task ListServices_Works()
    {
        var response = await this.client.System.ListServices(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
