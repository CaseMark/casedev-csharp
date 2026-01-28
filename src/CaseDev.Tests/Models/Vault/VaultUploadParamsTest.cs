using System;
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
            Path = "path",
            SizeBytes = 1,
        };

        string expectedID = "id";
        string expectedContentType = "contentType";
        string expectedFilename = "filename";
        bool expectedAutoIndex = true;
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedPath = "path";
        long expectedSizeBytes = 1;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedContentType, parameters.ContentType);
        Assert.Equal(expectedFilename, parameters.Filename);
        Assert.Equal(expectedAutoIndex, parameters.AutoIndex);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.Equal(expectedPath, parameters.Path);
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
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawBodyData.ContainsKey("path"));
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
            Path = null,
            SizeBytes = null,
        };

        Assert.Null(parameters.AutoIndex);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_index"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawBodyData.ContainsKey("path"));
        Assert.Null(parameters.SizeBytes);
        Assert.False(parameters.RawBodyData.ContainsKey("sizeBytes"));
    }

    [Fact]
    public void Url_Works()
    {
        VaultUploadParams parameters = new()
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/upload"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VaultUploadParams
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            AutoIndex = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Path = "path",
            SizeBytes = 1,
        };

        VaultUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
