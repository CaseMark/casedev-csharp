using System.Threading.Tasks;

namespace CaseDev.Tests.Services.Payments.V1;

public class LedgerServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        await this.client.Payments.V1.Ledger.Get(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListTransactions_Works()
    {
        await this.client.Payments.V1.Ledger.ListTransactions(
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
