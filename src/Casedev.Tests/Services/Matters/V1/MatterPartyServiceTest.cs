using System.Threading.Tasks;
using Casedev.Models.Matters.V1.MatterParties;

namespace Casedev.Tests.Services.Matters.V1;

public class MatterPartyServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        await this.client.Matters.V1.MatterParties.Create(
            "id",
            new() { PartyID = "party_id", Role = Role.Client },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task List_Works()
    {
        await this.client.Matters.V1.MatterParties.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
