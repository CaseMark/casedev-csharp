using System.Threading.Tasks;

namespace Casedev.Tests.Services;

public class SkillServiceTest : TestBase
{
    [Fact]
    public async Task Read_Works()
    {
        var response = await this.client.Skills.Read(
            "slug",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Resolve_Works()
    {
        var response = await this.client.Skills.Resolve(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
