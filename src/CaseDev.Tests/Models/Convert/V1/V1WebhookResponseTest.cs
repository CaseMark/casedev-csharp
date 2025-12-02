using CaseDev.Models.Convert.V1;

namespace CaseDev.Tests.Models.Convert.V1;

public class V1WebhookResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1WebhookResponse { Message = "Webhook received", Success = true };

        string expectedMessage = "Webhook received";
        bool expectedSuccess = true;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedSuccess, model.Success);
    }
}
