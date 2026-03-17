using System.Threading.Tasks;

namespace Casedev.Tests.Services.Operator;

public class V1ServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Operator.V1.Create(
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task CreateChatCompletion_Works()
    {
        await this.client.Operator.V1.CreateChatCompletion(
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task CreateResponse_Works()
    {
        await this.client.Operator.V1.CreateResponse(new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task GetStatus_Works()
    {
        await this.client.Operator.V1.GetStatus(new(), TestContext.Current.CancellationToken);
    }
}
