using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Memory.V1;

namespace Casedev.Tests.Models.Memory.V1;

public class V1DeleteAllResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1DeleteAllResponse { Deleted = 0 };

        long expectedDeleted = 0;

        Assert.Equal(expectedDeleted, model.Deleted);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1DeleteAllResponse { Deleted = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DeleteAllResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1DeleteAllResponse { Deleted = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DeleteAllResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDeleted = 0;

        Assert.Equal(expectedDeleted, deserialized.Deleted);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1DeleteAllResponse { Deleted = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1DeleteAllResponse { };

        Assert.Null(model.Deleted);
        Assert.False(model.RawData.ContainsKey("deleted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1DeleteAllResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1DeleteAllResponse
        {
            // Null should be interpreted as omitted for these properties
            Deleted = null,
        };

        Assert.Null(model.Deleted);
        Assert.False(model.RawData.ContainsKey("deleted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1DeleteAllResponse
        {
            // Null should be interpreted as omitted for these properties
            Deleted = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1DeleteAllResponse { Deleted = 0 };

        V1DeleteAllResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
