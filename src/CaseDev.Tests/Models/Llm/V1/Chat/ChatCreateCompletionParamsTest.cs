using CaseDev.Core;
using CaseDev.Models.Llm.V1.Chat;

namespace CaseDev.Tests.Models.Llm.V1.Chat;

public class MessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Message { Content = "content", Role = Role.System };

        string expectedContent = "content";
        ApiEnum<string, Role> expectedRole = Role.System;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRole, model.Role);
    }
}
