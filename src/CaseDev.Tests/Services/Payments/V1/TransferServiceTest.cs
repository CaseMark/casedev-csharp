using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Payments.V1;

public class TransferServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Payments.V1.Transfers.Create(
            new()
            {
                Amount = 0,
                FromAccountID = "from_account_id",
                ToAccountID = "to_account_id",
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Payments.V1.Transfers.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Payments.V1.Transfers.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Approve_Works()
    {
        await this.client.Payments.V1.Transfers.Approve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Cancel_Works()
    {
        await this.client.Payments.V1.Transfers.Cancel(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
