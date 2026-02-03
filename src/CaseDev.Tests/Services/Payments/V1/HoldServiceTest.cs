using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Payments.V1;

public class HoldServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Payments.V1.Holds.Create(
            new() { AccountID = "account_id", Amount = 0 },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Payments.V1.Holds.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Payments.V1.Holds.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Approve_Works()
    {
        await this.client.Payments.V1.Holds.Approve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Cancel_Works()
    {
        await this.client.Payments.V1.Holds.Cancel(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Release_Works()
    {
        await this.client.Payments.V1.Holds.Release(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
