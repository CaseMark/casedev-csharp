using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Payments.V1;

public class ChargeServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Payments.V1.Charges.Create(
            new()
            {
                Amount = 0,
                DestinationAccountID = "destination_account_id",
                PartyID = "party_id",
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Payments.V1.Charges.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        await this.client.Payments.V1.Charges.List(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Cancel_Works()
    {
        await this.client.Payments.V1.Charges.Cancel(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Refund_Works()
    {
        await this.client.Payments.V1.Charges.Refund(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
