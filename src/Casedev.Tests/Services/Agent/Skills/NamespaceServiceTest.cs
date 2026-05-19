using System.Threading.Tasks;
using Casedev.Models.Agent.Skills.Namespaces;

namespace Casedev.Tests.Services.Agent.Skills;

public class NamespaceServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Agent.Skills.Namespaces.Create(
            new() { NamespaceID = "namespaceId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        await this.client.Agent.Skills.Namespaces.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Agent.Skills.Namespaces.List(
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Agent.Skills.Namespaces.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Publish_Works()
    {
        await this.client.Agent.Skills.Namespaces.Publish(
            "id",
            new()
            {
                Files =
                [
                    new()
                    {
                        Content = "content",
                        Encoding = Encoding.Utf8,
                        Path = "path",
                        ContentType = "contentType",
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Pull_Works()
    {
        await this.client.Agent.Skills.Namespaces.Pull(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task RotateToken_Works()
    {
        await this.client.Agent.Skills.Namespaces.RotateToken(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
