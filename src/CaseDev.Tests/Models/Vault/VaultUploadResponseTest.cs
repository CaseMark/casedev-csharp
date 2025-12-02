using System.Text.Json;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultUploadResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultUploadResponse
        {
            AutoIndex = true,
            ExpiresIn = 0,
            Instructions = new()
            {
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Note = "note",
            },
            NextStep = "next_step",
            ObjectID = "objectId",
            S3Key = "s3Key",
            UploadURL = "uploadUrl",
        };

        bool expectedAutoIndex = true;
        double expectedExpiresIn = 0;
        Instructions expectedInstructions = new()
        {
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Note = "note",
        };
        string expectedNextStep = "next_step";
        string expectedObjectID = "objectId";
        string expectedS3Key = "s3Key";
        string expectedUploadURL = "uploadUrl";

        Assert.Equal(expectedAutoIndex, model.AutoIndex);
        Assert.Equal(expectedExpiresIn, model.ExpiresIn);
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedNextStep, model.NextStep);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedS3Key, model.S3Key);
        Assert.Equal(expectedUploadURL, model.UploadURL);
    }
}

public class InstructionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Instructions
        {
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Note = "note",
        };

        JsonElement expectedHeaders = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedMethod = "method";
        string expectedNote = "note";

        Assert.True(JsonElement.DeepEquals(expectedHeaders, model.Headers));
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedNote, model.Note);
    }
}
