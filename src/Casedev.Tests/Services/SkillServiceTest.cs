using System.Threading.Tasks;

namespace Casedev.Tests.Services;

public class SkillServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var skill = await this.client.Skills.Create(
            new() { Content = "x", Name = "x" },
            TestContext.Current.CancellationToken
        );
        skill.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var skill = await this.client.Skills.Update(
            "slug",
            new(),
            TestContext.Current.CancellationToken
        );
        skill.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var skill = await this.client.Skills.Delete(
            "slug",
            new(),
            TestContext.Current.CancellationToken
        );
        skill.Validate();
    }

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
