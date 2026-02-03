using System.Threading.Tasks;
using CaseDev.Models.Payments.V1.Payouts;

namespace CaseDev.Tests.Services.Payments.V1;

public class PayoutServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Payments.V1.Payouts.Create(
            new()
            {
                Amount = 0,
                DestinationType = DestinationType.BankAccount,
                FromAccountID = "from_account_id",
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Payments.V1.Payouts.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Payments.V1.Payouts.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Cancel_Works()
    {
        await this.client.Payments.V1.Payouts.Cancel(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
