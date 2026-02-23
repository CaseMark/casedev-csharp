using System.Text.Json;
using Router.Core;
using Router.Models.Vault.Objects;

namespace Router.Tests.Models.Vault.Objects;

public class ObjectDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectDeleteResponse
        {
            DeletedObject = new()
            {
                ID = "id",
                Filename = "filename",
                SizeBytes = 0,
                VectorsDeleted = 0,
            },
            Success = true,
        };

        DeletedObject expectedDeletedObject = new()
        {
            ID = "id",
            Filename = "filename",
            SizeBytes = 0,
            VectorsDeleted = 0,
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedDeletedObject, model.DeletedObject);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectDeleteResponse
        {
            DeletedObject = new()
            {
                ID = "id",
                Filename = "filename",
                SizeBytes = 0,
                VectorsDeleted = 0,
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectDeleteResponse
        {
            DeletedObject = new()
            {
                ID = "id",
                Filename = "filename",
                SizeBytes = 0,
                VectorsDeleted = 0,
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DeletedObject expectedDeletedObject = new()
        {
            ID = "id",
            Filename = "filename",
            SizeBytes = 0,
            VectorsDeleted = 0,
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedDeletedObject, deserialized.DeletedObject);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectDeleteResponse
        {
            DeletedObject = new()
            {
                ID = "id",
                Filename = "filename",
                SizeBytes = 0,
                VectorsDeleted = 0,
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectDeleteResponse { };

        Assert.Null(model.DeletedObject);
        Assert.False(model.RawData.ContainsKey("deletedObject"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ObjectDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            DeletedObject = null,
            Success = null,
        };

        Assert.Null(model.DeletedObject);
        Assert.False(model.RawData.ContainsKey("deletedObject"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            DeletedObject = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectDeleteResponse
        {
            DeletedObject = new()
            {
                ID = "id",
                Filename = "filename",
                SizeBytes = 0,
                VectorsDeleted = 0,
            },
            Success = true,
        };

        ObjectDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeletedObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeletedObject
        {
            ID = "id",
            Filename = "filename",
            SizeBytes = 0,
            VectorsDeleted = 0,
        };

        string expectedID = "id";
        string expectedFilename = "filename";
        long expectedSizeBytes = 0;
        long expectedVectorsDeleted = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.Equal(expectedVectorsDeleted, model.VectorsDeleted);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeletedObject
        {
            ID = "id",
            Filename = "filename",
            SizeBytes = 0,
            VectorsDeleted = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeletedObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeletedObject
        {
            ID = "id",
            Filename = "filename",
            SizeBytes = 0,
            VectorsDeleted = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeletedObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedFilename = "filename";
        long expectedSizeBytes = 0;
        long expectedVectorsDeleted = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.Equal(expectedVectorsDeleted, deserialized.VectorsDeleted);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeletedObject
        {
            ID = "id",
            Filename = "filename",
            SizeBytes = 0,
            VectorsDeleted = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeletedObject { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
        Assert.Null(model.VectorsDeleted);
        Assert.False(model.RawData.ContainsKey("vectorsDeleted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DeletedObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DeletedObject
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Filename = null,
            SizeBytes = null,
            VectorsDeleted = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("sizeBytes"));
        Assert.Null(model.VectorsDeleted);
        Assert.False(model.RawData.ContainsKey("vectorsDeleted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DeletedObject
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Filename = null,
            SizeBytes = null,
            VectorsDeleted = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeletedObject
        {
            ID = "id",
            Filename = "filename",
            SizeBytes = 0,
            VectorsDeleted = 0,
        };

        DeletedObject copied = new(model);

        Assert.Equal(model, copied);
    }
}
