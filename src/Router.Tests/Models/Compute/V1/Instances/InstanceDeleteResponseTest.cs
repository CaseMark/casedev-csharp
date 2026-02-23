using System.Text.Json;
using Router.Core;
using Router.Models.Compute.V1.Instances;

namespace Router.Tests.Models.Compute.V1.Instances;

public class InstanceDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InstanceDeleteResponse
        {
            ID = "id",
            Message = "message",
            Name = "name",
            Status = "status",
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        string expectedID = "id";
        string expectedMessage = "message";
        string expectedName = "name";
        string expectedStatus = "status";
        string expectedTotalCost = "totalCost";
        long expectedTotalRuntimeSeconds = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTotalCost, model.TotalCost);
        Assert.Equal(expectedTotalRuntimeSeconds, model.TotalRuntimeSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InstanceDeleteResponse
        {
            ID = "id",
            Message = "message",
            Name = "name",
            Status = "status",
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InstanceDeleteResponse
        {
            ID = "id",
            Message = "message",
            Name = "name",
            Status = "status",
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedMessage = "message";
        string expectedName = "name";
        string expectedStatus = "status";
        string expectedTotalCost = "totalCost";
        long expectedTotalRuntimeSeconds = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTotalCost, deserialized.TotalCost);
        Assert.Equal(expectedTotalRuntimeSeconds, deserialized.TotalRuntimeSeconds);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InstanceDeleteResponse
        {
            ID = "id",
            Message = "message",
            Name = "name",
            Status = "status",
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InstanceDeleteResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TotalCost);
        Assert.False(model.RawData.ContainsKey("totalCost"));
        Assert.Null(model.TotalRuntimeSeconds);
        Assert.False(model.RawData.ContainsKey("totalRuntimeSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InstanceDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InstanceDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Message = null,
            Name = null,
            Status = null,
            TotalCost = null,
            TotalRuntimeSeconds = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TotalCost);
        Assert.False(model.RawData.ContainsKey("totalCost"));
        Assert.Null(model.TotalRuntimeSeconds);
        Assert.False(model.RawData.ContainsKey("totalRuntimeSeconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InstanceDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Message = null,
            Name = null,
            Status = null,
            TotalCost = null,
            TotalRuntimeSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InstanceDeleteResponse
        {
            ID = "id",
            Message = "message",
            Name = "name",
            Status = "status",
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        InstanceDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
