using System;
using System.Text.Json;
using CaseDev.Models.Vault.Multipart;

namespace CaseDev.Tests.Models.Vault.Multipart;

public class MultipartInitParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MultipartInitParams
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            SizeBytes = 1,
            AutoIndex = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PartSizeBytes = 5242880,
            Path = "path",
        };

        string expectedID = "id";
        string expectedContentType = "contentType";
        string expectedFilename = "filename";
        long expectedSizeBytes = 1;
        bool expectedAutoIndex = true;
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedPartSizeBytes = 5242880;
        string expectedPath = "path";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedContentType, parameters.ContentType);
        Assert.Equal(expectedFilename, parameters.Filename);
        Assert.Equal(expectedSizeBytes, parameters.SizeBytes);
        Assert.Equal(expectedAutoIndex, parameters.AutoIndex);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.Equal(expectedPartSizeBytes, parameters.PartSizeBytes);
        Assert.Equal(expectedPath, parameters.Path);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MultipartInitParams
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            SizeBytes = 1,
        };

        Assert.Null(parameters.AutoIndex);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_index"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PartSizeBytes);
        Assert.False(parameters.RawBodyData.ContainsKey("partSizeBytes"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawBodyData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MultipartInitParams
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            SizeBytes = 1,

            // Null should be interpreted as omitted for these properties
            AutoIndex = null,
            Metadata = null,
            PartSizeBytes = null,
            Path = null,
        };

        Assert.Null(parameters.AutoIndex);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_index"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PartSizeBytes);
        Assert.False(parameters.RawBodyData.ContainsKey("partSizeBytes"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawBodyData.ContainsKey("path"));
    }

    [Fact]
    public void Url_Works()
    {
        MultipartInitParams parameters = new()
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            SizeBytes = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/multipart/init"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MultipartInitParams
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            SizeBytes = 1,
            AutoIndex = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            PartSizeBytes = 5242880,
            Path = "path",
        };

        MultipartInitParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
