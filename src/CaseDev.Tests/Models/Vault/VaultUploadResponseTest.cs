using System.Text.Json;
using CaseDev.Core;
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
            EnableIndexing = true,
            ExpiresIn = 0,
            Instructions = new()
            {
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Note = "note",
            },
            NextStep = "next_step",
            ObjectID = "objectId",
            Path = "path",
            S3Key = "s3Key",
            UploadUrl = "uploadUrl",
        };

        bool expectedAutoIndex = true;
        bool expectedEnableIndexing = true;
        double expectedExpiresIn = 0;
        Instructions expectedInstructions = new()
        {
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Note = "note",
        };
        string expectedNextStep = "next_step";
        string expectedObjectID = "objectId";
        string expectedPath = "path";
        string expectedS3Key = "s3Key";
        string expectedUploadUrl = "uploadUrl";

        Assert.Equal(expectedAutoIndex, model.AutoIndex);
        Assert.Equal(expectedEnableIndexing, model.EnableIndexing);
        Assert.Equal(expectedExpiresIn, model.ExpiresIn);
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedNextStep, model.NextStep);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedS3Key, model.S3Key);
        Assert.Equal(expectedUploadUrl, model.UploadUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultUploadResponse
        {
            AutoIndex = true,
            EnableIndexing = true,
            ExpiresIn = 0,
            Instructions = new()
            {
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Note = "note",
            },
            NextStep = "next_step",
            ObjectID = "objectId",
            Path = "path",
            S3Key = "s3Key",
            UploadUrl = "uploadUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultUploadResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultUploadResponse
        {
            AutoIndex = true,
            EnableIndexing = true,
            ExpiresIn = 0,
            Instructions = new()
            {
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Note = "note",
            },
            NextStep = "next_step",
            ObjectID = "objectId",
            Path = "path",
            S3Key = "s3Key",
            UploadUrl = "uploadUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultUploadResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAutoIndex = true;
        bool expectedEnableIndexing = true;
        double expectedExpiresIn = 0;
        Instructions expectedInstructions = new()
        {
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Note = "note",
        };
        string expectedNextStep = "next_step";
        string expectedObjectID = "objectId";
        string expectedPath = "path";
        string expectedS3Key = "s3Key";
        string expectedUploadUrl = "uploadUrl";

        Assert.Equal(expectedAutoIndex, deserialized.AutoIndex);
        Assert.Equal(expectedEnableIndexing, deserialized.EnableIndexing);
        Assert.Equal(expectedExpiresIn, deserialized.ExpiresIn);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.Equal(expectedNextStep, deserialized.NextStep);
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedS3Key, deserialized.S3Key);
        Assert.Equal(expectedUploadUrl, deserialized.UploadUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultUploadResponse
        {
            AutoIndex = true,
            EnableIndexing = true,
            ExpiresIn = 0,
            Instructions = new()
            {
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Note = "note",
            },
            NextStep = "next_step",
            ObjectID = "objectId",
            Path = "path",
            S3Key = "s3Key",
            UploadUrl = "uploadUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultUploadResponse { NextStep = "next_step", Path = "path" };

        Assert.Null(model.AutoIndex);
        Assert.False(model.RawData.ContainsKey("auto_index"));
        Assert.Null(model.EnableIndexing);
        Assert.False(model.RawData.ContainsKey("enableIndexing"));
        Assert.Null(model.ExpiresIn);
        Assert.False(model.RawData.ContainsKey("expiresIn"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.S3Key);
        Assert.False(model.RawData.ContainsKey("s3Key"));
        Assert.Null(model.UploadUrl);
        Assert.False(model.RawData.ContainsKey("uploadUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultUploadResponse { NextStep = "next_step", Path = "path" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultUploadResponse
        {
            NextStep = "next_step",
            Path = "path",

            // Null should be interpreted as omitted for these properties
            AutoIndex = null,
            EnableIndexing = null,
            ExpiresIn = null,
            Instructions = null,
            ObjectID = null,
            S3Key = null,
            UploadUrl = null,
        };

        Assert.Null(model.AutoIndex);
        Assert.False(model.RawData.ContainsKey("auto_index"));
        Assert.Null(model.EnableIndexing);
        Assert.False(model.RawData.ContainsKey("enableIndexing"));
        Assert.Null(model.ExpiresIn);
        Assert.False(model.RawData.ContainsKey("expiresIn"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.S3Key);
        Assert.False(model.RawData.ContainsKey("s3Key"));
        Assert.Null(model.UploadUrl);
        Assert.False(model.RawData.ContainsKey("uploadUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultUploadResponse
        {
            NextStep = "next_step",
            Path = "path",

            // Null should be interpreted as omitted for these properties
            AutoIndex = null,
            EnableIndexing = null,
            ExpiresIn = null,
            Instructions = null,
            ObjectID = null,
            S3Key = null,
            UploadUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultUploadResponse
        {
            AutoIndex = true,
            EnableIndexing = true,
            ExpiresIn = 0,
            Instructions = new()
            {
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Note = "note",
            },
            ObjectID = "objectId",
            S3Key = "s3Key",
            UploadUrl = "uploadUrl",
        };

        Assert.Null(model.NextStep);
        Assert.False(model.RawData.ContainsKey("next_step"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultUploadResponse
        {
            AutoIndex = true,
            EnableIndexing = true,
            ExpiresIn = 0,
            Instructions = new()
            {
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Note = "note",
            },
            ObjectID = "objectId",
            S3Key = "s3Key",
            UploadUrl = "uploadUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VaultUploadResponse
        {
            AutoIndex = true,
            EnableIndexing = true,
            ExpiresIn = 0,
            Instructions = new()
            {
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Note = "note",
            },
            ObjectID = "objectId",
            S3Key = "s3Key",
            UploadUrl = "uploadUrl",

            NextStep = null,
            Path = null,
        };

        Assert.Null(model.NextStep);
        Assert.True(model.RawData.ContainsKey("next_step"));
        Assert.Null(model.Path);
        Assert.True(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultUploadResponse
        {
            AutoIndex = true,
            EnableIndexing = true,
            ExpiresIn = 0,
            Instructions = new()
            {
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Note = "note",
            },
            ObjectID = "objectId",
            S3Key = "s3Key",
            UploadUrl = "uploadUrl",

            NextStep = null,
            Path = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VaultUploadResponse
        {
            AutoIndex = true,
            EnableIndexing = true,
            ExpiresIn = 0,
            Instructions = new()
            {
                Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
                Method = "method",
                Note = "note",
            },
            NextStep = "next_step",
            ObjectID = "objectId",
            Path = "path",
            S3Key = "s3Key",
            UploadUrl = "uploadUrl",
        };

        VaultUploadResponse copied = new(model);

        Assert.Equal(model, copied);
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

        Assert.NotNull(model.Headers);
        Assert.True(JsonElement.DeepEquals(expectedHeaders, model.Headers.Value));
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedNote, model.Note);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Instructions
        {
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Note = "note",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Instructions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Instructions
        {
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Note = "note",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Instructions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedHeaders = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedMethod = "method";
        string expectedNote = "note";

        Assert.NotNull(deserialized.Headers);
        Assert.True(JsonElement.DeepEquals(expectedHeaders, deserialized.Headers.Value));
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedNote, deserialized.Note);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Instructions
        {
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Note = "note",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Instructions { };

        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.Note);
        Assert.False(model.RawData.ContainsKey("note"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Instructions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Instructions
        {
            // Null should be interpreted as omitted for these properties
            Headers = null,
            Method = null,
            Note = null,
        };

        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.Note);
        Assert.False(model.RawData.ContainsKey("note"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Instructions
        {
            // Null should be interpreted as omitted for these properties
            Headers = null,
            Method = null,
            Note = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Instructions
        {
            Headers = JsonSerializer.Deserialize<JsonElement>("{}"),
            Method = "method",
            Note = "note",
        };

        Instructions copied = new(model);

        Assert.Equal(model, copied);
    }
}
