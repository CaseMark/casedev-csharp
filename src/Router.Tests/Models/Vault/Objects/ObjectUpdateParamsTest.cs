using System;
using System.Text.Json;
using Router.Models.Vault.Objects;

namespace Router.Tests.Models.Vault.Objects;

public class ObjectUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ObjectUpdateParams
        {
            ID = "id",
            ObjectID = "objectId",
            Filename = "deposition-smith-2024.pdf",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Path = "/Discovery/Depositions",
        };

        string expectedID = "id";
        string expectedObjectID = "objectId";
        string expectedFilename = "deposition-smith-2024.pdf";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedPath = "/Discovery/Depositions";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedObjectID, parameters.ObjectID);
        Assert.Equal(expectedFilename, parameters.Filename);
        Assert.NotNull(parameters.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, parameters.Metadata.Value));
        Assert.Equal(expectedPath, parameters.Path);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ObjectUpdateParams
        {
            ID = "id",
            ObjectID = "objectId",
            Path = "/Discovery/Depositions",
        };

        Assert.Null(parameters.Filename);
        Assert.False(parameters.RawBodyData.ContainsKey("filename"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ObjectUpdateParams
        {
            ID = "id",
            ObjectID = "objectId",
            Path = "/Discovery/Depositions",

            // Null should be interpreted as omitted for these properties
            Filename = null,
            Metadata = null,
        };

        Assert.Null(parameters.Filename);
        Assert.False(parameters.RawBodyData.ContainsKey("filename"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ObjectUpdateParams
        {
            ID = "id",
            ObjectID = "objectId",
            Filename = "deposition-smith-2024.pdf",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(parameters.Path);
        Assert.False(parameters.RawBodyData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ObjectUpdateParams
        {
            ID = "id",
            ObjectID = "objectId",
            Filename = "deposition-smith-2024.pdf",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),

            Path = null,
        };

        Assert.Null(parameters.Path);
        Assert.True(parameters.RawBodyData.ContainsKey("path"));
    }

    [Fact]
    public void Url_Works()
    {
        ObjectUpdateParams parameters = new() { ID = "id", ObjectID = "objectId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/objects/objectId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ObjectUpdateParams
        {
            ID = "id",
            ObjectID = "objectId",
            Filename = "deposition-smith-2024.pdf",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Path = "/Discovery/Depositions",
        };

        ObjectUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
