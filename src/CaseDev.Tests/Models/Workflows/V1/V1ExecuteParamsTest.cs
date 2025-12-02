using CaseDev.Core;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Options { Format = OptionsFormat.Json, Model = "model" };

        ApiEnum<string, OptionsFormat> expectedFormat = OptionsFormat.Json;
        string expectedModel = "model";

        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedModel, model.Model);
    }
}
