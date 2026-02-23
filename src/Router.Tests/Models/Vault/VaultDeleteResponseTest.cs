using System.Text.Json;
using Router.Core;
using Router.Models.Vault;

namespace Router.Tests.Models.Vault;

public class VaultDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultDeleteResponse
        {
            DeletedVault = new()
            {
                ID = "id",
                BytesFreed = 0,
                Name = "name",
                ObjectsDeleted = 0,
                VectorsDeleted = 0,
            },
            Status = "status",
            Success = true,
        };

        DeletedVault expectedDeletedVault = new()
        {
            ID = "id",
            BytesFreed = 0,
            Name = "name",
            ObjectsDeleted = 0,
            VectorsDeleted = 0,
        };
        string expectedStatus = "status";
        bool expectedSuccess = true;

        Assert.Equal(expectedDeletedVault, model.DeletedVault);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultDeleteResponse
        {
            DeletedVault = new()
            {
                ID = "id",
                BytesFreed = 0,
                Name = "name",
                ObjectsDeleted = 0,
                VectorsDeleted = 0,
            },
            Status = "status",
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultDeleteResponse
        {
            DeletedVault = new()
            {
                ID = "id",
                BytesFreed = 0,
                Name = "name",
                ObjectsDeleted = 0,
                VectorsDeleted = 0,
            },
            Status = "status",
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DeletedVault expectedDeletedVault = new()
        {
            ID = "id",
            BytesFreed = 0,
            Name = "name",
            ObjectsDeleted = 0,
            VectorsDeleted = 0,
        };
        string expectedStatus = "status";
        bool expectedSuccess = true;

        Assert.Equal(expectedDeletedVault, deserialized.DeletedVault);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultDeleteResponse
        {
            DeletedVault = new()
            {
                ID = "id",
                BytesFreed = 0,
                Name = "name",
                ObjectsDeleted = 0,
                VectorsDeleted = 0,
            },
            Status = "status",
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultDeleteResponse { };

        Assert.Null(model.DeletedVault);
        Assert.False(model.RawData.ContainsKey("deletedVault"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            DeletedVault = null,
            Status = null,
            Success = null,
        };

        Assert.Null(model.DeletedVault);
        Assert.False(model.RawData.ContainsKey("deletedVault"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            DeletedVault = null,
            Status = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VaultDeleteResponse
        {
            DeletedVault = new()
            {
                ID = "id",
                BytesFreed = 0,
                Name = "name",
                ObjectsDeleted = 0,
                VectorsDeleted = 0,
            },
            Status = "status",
            Success = true,
        };

        VaultDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeletedVaultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeletedVault
        {
            ID = "id",
            BytesFreed = 0,
            Name = "name",
            ObjectsDeleted = 0,
            VectorsDeleted = 0,
        };

        string expectedID = "id";
        long expectedBytesFreed = 0;
        string expectedName = "name";
        long expectedObjectsDeleted = 0;
        long expectedVectorsDeleted = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBytesFreed, model.BytesFreed);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedObjectsDeleted, model.ObjectsDeleted);
        Assert.Equal(expectedVectorsDeleted, model.VectorsDeleted);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeletedVault
        {
            ID = "id",
            BytesFreed = 0,
            Name = "name",
            ObjectsDeleted = 0,
            VectorsDeleted = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeletedVault>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeletedVault
        {
            ID = "id",
            BytesFreed = 0,
            Name = "name",
            ObjectsDeleted = 0,
            VectorsDeleted = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeletedVault>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedBytesFreed = 0;
        string expectedName = "name";
        long expectedObjectsDeleted = 0;
        long expectedVectorsDeleted = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBytesFreed, deserialized.BytesFreed);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedObjectsDeleted, deserialized.ObjectsDeleted);
        Assert.Equal(expectedVectorsDeleted, deserialized.VectorsDeleted);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeletedVault
        {
            ID = "id",
            BytesFreed = 0,
            Name = "name",
            ObjectsDeleted = 0,
            VectorsDeleted = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeletedVault { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BytesFreed);
        Assert.False(model.RawData.ContainsKey("bytesFreed"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ObjectsDeleted);
        Assert.False(model.RawData.ContainsKey("objectsDeleted"));
        Assert.Null(model.VectorsDeleted);
        Assert.False(model.RawData.ContainsKey("vectorsDeleted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DeletedVault { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DeletedVault
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            BytesFreed = null,
            Name = null,
            ObjectsDeleted = null,
            VectorsDeleted = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BytesFreed);
        Assert.False(model.RawData.ContainsKey("bytesFreed"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ObjectsDeleted);
        Assert.False(model.RawData.ContainsKey("objectsDeleted"));
        Assert.Null(model.VectorsDeleted);
        Assert.False(model.RawData.ContainsKey("vectorsDeleted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DeletedVault
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            BytesFreed = null,
            Name = null,
            ObjectsDeleted = null,
            VectorsDeleted = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeletedVault
        {
            ID = "id",
            BytesFreed = 0,
            Name = "name",
            ObjectsDeleted = 0,
            VectorsDeleted = 0,
        };

        DeletedVault copied = new(model);

        Assert.Equal(model, copied);
    }
}
