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
            RelativePath = "relative_path",
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
        string expectedRelativePath = "relative_path";
        string expectedS3Key = "s3Key";
        string expectedUploadURL = "uploadUrl";

        Assert.Equal(expectedAutoIndex, model.AutoIndex);
        Assert.Equal(expectedExpiresIn, model.ExpiresIn);
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedNextStep, model.NextStep);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedRelativePath, model.RelativePath);
        Assert.Equal(expectedS3Key, model.S3Key);
        Assert.Equal(expectedUploadURL, model.UploadURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
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
            RelativePath = "relative_path",
            S3Key = "s3Key",
            UploadURL = "uploadUrl",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VaultUploadResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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
            RelativePath = "relative_path",
            S3Key = "s3Key",
            UploadURL = "uploadUrl",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<VaultUploadResponse>(element);
        Assert.NotNull(deserialized);

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
        string expectedRelativePath = "relative_path";
        string expectedS3Key = "s3Key";
        string expectedUploadURL = "uploadUrl";

        Assert.Equal(expectedAutoIndex, deserialized.AutoIndex);
        Assert.Equal(expectedExpiresIn, deserialized.ExpiresIn);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.Equal(expectedNextStep, deserialized.NextStep);
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedRelativePath, deserialized.RelativePath);
        Assert.Equal(expectedS3Key, deserialized.S3Key);
        Assert.Equal(expectedUploadURL, deserialized.UploadURL);
    }

    [Fact]
    public void Validation_Works()
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
            RelativePath = "relative_path",
            S3Key = "s3Key",
            UploadURL = "uploadUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultUploadResponse
        {
            NextStep = "next_step",
            RelativePath = "relative_path",
        };

        Assert.Null(model.AutoIndex);
        Assert.False(model.RawData.ContainsKey("auto_index"));
        Assert.Null(model.ExpiresIn);
        Assert.False(model.RawData.ContainsKey("expiresIn"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.S3Key);
        Assert.False(model.RawData.ContainsKey("s3Key"));
        Assert.Null(model.UploadURL);
        Assert.False(model.RawData.ContainsKey("uploadUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultUploadResponse
        {
            NextStep = "next_step",
            RelativePath = "relative_path",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultUploadResponse
        {
            NextStep = "next_step",
            RelativePath = "relative_path",

            // Null should be interpreted as omitted for these properties
            AutoIndex = null,
            ExpiresIn = null,
            Instructions = null,
            ObjectID = null,
            S3Key = null,
            UploadURL = null,
        };

        Assert.Null(model.AutoIndex);
        Assert.False(model.RawData.ContainsKey("auto_index"));
        Assert.Null(model.ExpiresIn);
        Assert.False(model.RawData.ContainsKey("expiresIn"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.S3Key);
        Assert.False(model.RawData.ContainsKey("s3Key"));
        Assert.Null(model.UploadURL);
        Assert.False(model.RawData.ContainsKey("uploadUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultUploadResponse
        {
            NextStep = "next_step",
            RelativePath = "relative_path",

            // Null should be interpreted as omitted for these properties
            AutoIndex = null,
            ExpiresIn = null,
            Instructions = null,
            ObjectID = null,
            S3Key = null,
            UploadURL = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
            ObjectID = "objectId",
            S3Key = "s3Key",
            UploadURL = "uploadUrl",
        };

        Assert.Null(model.NextStep);
        Assert.False(model.RawData.ContainsKey("next_step"));
        Assert.Null(model.RelativePath);
        Assert.False(model.RawData.ContainsKey("relative_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
            ObjectID = "objectId",
            S3Key = "s3Key",
            UploadURL = "uploadUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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
            ObjectID = "objectId",
            S3Key = "s3Key",
            UploadURL = "uploadUrl",

            NextStep = null,
            RelativePath = null,
        };

        Assert.Null(model.NextStep);
        Assert.True(model.RawData.ContainsKey("next_step"));
        Assert.Null(model.RelativePath);
        Assert.True(model.RawData.ContainsKey("relative_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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
            ObjectID = "objectId",
            S3Key = "s3Key",
            UploadURL = "uploadUrl",

            NextStep = null,
            RelativePath = null,
        };

        model.Validate();
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Instructions>(json);

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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Instructions>(element);
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
}
