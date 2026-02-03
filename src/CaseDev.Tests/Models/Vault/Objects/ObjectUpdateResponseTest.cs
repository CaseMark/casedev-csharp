using System;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Vault.Objects;

namespace CaseDev.Tests.Models.Vault.Objects;

public class ObjectUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectUpdateResponse
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Path = "path",
            SizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultID = "vaultId",
        };

        string expectedID = "id";
        string expectedContentType = "contentType";
        string expectedFilename = "filename";
        string expectedIngestionStatus = "ingestionStatus";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedPath = "path";
        long expectedSizeBytes = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVaultID = "vaultId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedIngestionStatus, model.IngestionStatus);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectUpdateResponse
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Path = "path",
            SizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultID = "vaultId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectUpdateResponse
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Path = "path",
            SizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultID = "vaultId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedContentType = "contentType";
        string expectedFilename = "filename";
        string expectedIngestionStatus = "ingestionStatus";
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedPath = "path";
        long expectedSizeBytes = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVaultID = "vaultId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedIngestionStatus, deserialized.IngestionStatus);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectUpdateResponse
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Path = "path",
            SizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultID = "vaultId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectUpdateResponse { Path = "path" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("contentType"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.IngestionStatus);
        Assert.False(model.RawData.ContainsKey("ingestionStatus"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vaultId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectUpdateResponse { Path = "path" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ObjectUpdateResponse
        {
            Path = "path",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ContentType = null,
            Filename = null,
            IngestionStatus = null,
            Metadata = null,
            SizeBytes = null,
            UpdatedAt = null,
            VaultID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("contentType"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.IngestionStatus);
        Assert.False(model.RawData.ContainsKey("ingestionStatus"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vaultId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectUpdateResponse
        {
            Path = "path",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ContentType = null,
            Filename = null,
            IngestionStatus = null,
            Metadata = null,
            SizeBytes = null,
            UpdatedAt = null,
            VaultID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectUpdateResponse
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            SizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultID = "vaultId",
        };

        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectUpdateResponse
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            SizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultID = "vaultId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ObjectUpdateResponse
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            SizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultID = "vaultId",

            Path = null,
        };

        Assert.Null(model.Path);
        Assert.True(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectUpdateResponse
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            SizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultID = "vaultId",

            Path = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectUpdateResponse
        {
            ID = "id",
            ContentType = "contentType",
            Filename = "filename",
            IngestionStatus = "ingestionStatus",
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            Path = "path",
            SizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VaultID = "vaultId",
        };

        ObjectUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
