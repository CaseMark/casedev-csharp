using System.Threading.Tasks;

namespace Casedev.Tests.Services.Skills;

public class CustomServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var customs = await this.client.Skills.Custom.List(
            new(),
            TestContext.Current.CancellationToken
        );
        customs.Validate();
    }
}
