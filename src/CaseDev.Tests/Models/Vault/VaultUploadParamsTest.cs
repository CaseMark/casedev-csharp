using System.Text.Json;
using CaseDev.Models.Vault;

namespace CaseDev.Tests.Models.Vault;

public class VaultUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultUploadParams
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            AutoIndex = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            RelativePath = "relative_path",
            SizeBytes = 0,
        };

        string expectedID = "id";
        string expectedContentType = "contentType";
        string expectedFilename = "filename";
        bool expectedAutoIndex = true;
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedRelativePath = "relative_path";
        double expectedSizeBytes = 0;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedContentType, parameters.ContentType);
        Assert.Equal(expectedFilename, parameters.Filename);
        Assert.Equal(expectedAutoIndex, parameters.AutoIndex);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.Equal(expectedRelativePath, parameters.RelativePath);
        Assert.Equal(expectedSizeBytes, parameters.SizeBytes);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VaultUploadParams
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
        };

        Assert.Null(parameters.AutoIndex);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_index"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RelativePath);
        Assert.False(parameters.RawBodyData.ContainsKey("relative_path"));
        Assert.Null(parameters.SizeBytes);
        Assert.False(parameters.RawBodyData.ContainsKey("sizeBytes"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VaultUploadParams
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",

            // Null should be interpreted as omitted for these properties
            AutoIndex = null,
            Metadata = null,
            RelativePath = null,
            SizeBytes = null,
        };

        Assert.Null(parameters.AutoIndex);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_index"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RelativePath);
        Assert.False(parameters.RawBodyData.ContainsKey("relative_path"));
        Assert.Null(parameters.SizeBytes);
        Assert.False(parameters.RawBodyData.ContainsKey("sizeBytes"));
    }
}
