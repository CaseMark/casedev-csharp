using System.Text.Json;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1ResearchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ResearchResponse
        {
            Model = "model",
            ResearchID = "researchId",
            Results = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedModel = "model";
        string expectedResearchID = "researchId";
        JsonElement expectedResults = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedResearchID, model.ResearchID);
        Assert.True(
            model.Results.HasValue && JsonElement.DeepEquals(expectedResults, model.Results.Value)
        );
    }
}
