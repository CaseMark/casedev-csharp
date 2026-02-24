using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Vault;

namespace Casedev.Tests.Models.Vault;

public class VaultConfirmUploadResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultConfirmUploadResponse
        {
            AlreadyConfirmed = true,
            ObjectID = "objectId",
            Status = Status.Completed,
            VaultID = "vaultId",
        };

        bool expectedAlreadyConfirmed = true;
        string expectedObjectID = "objectId";
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        string expectedVaultID = "vaultId";

        Assert.Equal(expectedAlreadyConfirmed, model.AlreadyConfirmed);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultConfirmUploadResponse
        {
            AlreadyConfirmed = true,
            ObjectID = "objectId",
            Status = Status.Completed,
            VaultID = "vaultId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultConfirmUploadResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultConfirmUploadResponse
        {
            AlreadyConfirmed = true,
            ObjectID = "objectId",
            Status = Status.Completed,
            VaultID = "vaultId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultConfirmUploadResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAlreadyConfirmed = true;
        string expectedObjectID = "objectId";
        ApiEnum<string, Status> expectedStatus = Status.Completed;
        string expectedVaultID = "vaultId";

        Assert.Equal(expectedAlreadyConfirmed, deserialized.AlreadyConfirmed);
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultConfirmUploadResponse
        {
            AlreadyConfirmed = true,
            ObjectID = "objectId",
            Status = Status.Completed,
            VaultID = "vaultId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultConfirmUploadResponse { };

        Assert.Null(model.AlreadyConfirmed);
        Assert.False(model.RawData.ContainsKey("alreadyConfirmed"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vaultId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultConfirmUploadResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultConfirmUploadResponse
        {
            // Null should be interpreted as omitted for these properties
            AlreadyConfirmed = null,
            ObjectID = null,
            Status = null,
            VaultID = null,
        };

        Assert.Null(model.AlreadyConfirmed);
        Assert.False(model.RawData.ContainsKey("alreadyConfirmed"));
        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("objectId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vaultId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultConfirmUploadResponse
        {
            // Null should be interpreted as omitted for these properties
            AlreadyConfirmed = null,
            ObjectID = null,
            Status = null,
            VaultID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VaultConfirmUploadResponse
        {
            AlreadyConfirmed = true,
            ObjectID = "objectId",
            Status = Status.Completed,
            VaultID = "vaultId",
        };

        VaultConfirmUploadResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
