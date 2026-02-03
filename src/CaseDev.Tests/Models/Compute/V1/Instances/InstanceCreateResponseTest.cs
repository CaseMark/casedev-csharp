using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Compute.V1.Instances;

namespace CaseDev.Tests.Models.Compute.V1.Instances;

public class InstanceCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InstanceCreateResponse
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = "createdAt",
            Gpu = "gpu",
            InstanceType = "instanceType",
            Message = "message",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Vaults = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string expectedID = "id";
        long expectedAutoShutdownMinutes = 0;
        string expectedCreatedAt = "createdAt";
        string expectedGpu = "gpu";
        string expectedInstanceType = "instanceType";
        string expectedMessage = "message";
        string expectedName = "name";
        string expectedPricePerHour = "pricePerHour";
        string expectedRegion = "region";
        JsonElement expectedSpecs = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedStatus = "status";
        List<JsonElement> expectedVaults = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAutoShutdownMinutes, model.AutoShutdownMinutes);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedGpu, model.Gpu);
        Assert.Equal(expectedInstanceType, model.InstanceType);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPricePerHour, model.PricePerHour);
        Assert.Equal(expectedRegion, model.Region);
        Assert.NotNull(model.Specs);
        Assert.True(JsonElement.DeepEquals(expectedSpecs, model.Specs.Value));
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Vaults);
        Assert.Equal(expectedVaults.Count, model.Vaults.Count);
        for (int i = 0; i < expectedVaults.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedVaults[i], model.Vaults[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InstanceCreateResponse
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = "createdAt",
            Gpu = "gpu",
            InstanceType = "instanceType",
            Message = "message",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Vaults = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InstanceCreateResponse
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = "createdAt",
            Gpu = "gpu",
            InstanceType = "instanceType",
            Message = "message",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Vaults = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedAutoShutdownMinutes = 0;
        string expectedCreatedAt = "createdAt";
        string expectedGpu = "gpu";
        string expectedInstanceType = "instanceType";
        string expectedMessage = "message";
        string expectedName = "name";
        string expectedPricePerHour = "pricePerHour";
        string expectedRegion = "region";
        JsonElement expectedSpecs = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedStatus = "status";
        List<JsonElement> expectedVaults = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAutoShutdownMinutes, deserialized.AutoShutdownMinutes);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedGpu, deserialized.Gpu);
        Assert.Equal(expectedInstanceType, deserialized.InstanceType);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPricePerHour, deserialized.PricePerHour);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.NotNull(deserialized.Specs);
        Assert.True(JsonElement.DeepEquals(expectedSpecs, deserialized.Specs.Value));
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Vaults);
        Assert.Equal(expectedVaults.Count, deserialized.Vaults.Count);
        for (int i = 0; i < expectedVaults.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedVaults[i], deserialized.Vaults[i]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InstanceCreateResponse
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = "createdAt",
            Gpu = "gpu",
            InstanceType = "instanceType",
            Message = "message",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Vaults = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InstanceCreateResponse { AutoShutdownMinutes = 0 };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Gpu);
        Assert.False(model.RawData.ContainsKey("gpu"));
        Assert.Null(model.InstanceType);
        Assert.False(model.RawData.ContainsKey("instanceType"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PricePerHour);
        Assert.False(model.RawData.ContainsKey("pricePerHour"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.Specs);
        Assert.False(model.RawData.ContainsKey("specs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Vaults);
        Assert.False(model.RawData.ContainsKey("vaults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InstanceCreateResponse { AutoShutdownMinutes = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InstanceCreateResponse
        {
            AutoShutdownMinutes = 0,

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Gpu = null,
            InstanceType = null,
            Message = null,
            Name = null,
            PricePerHour = null,
            Region = null,
            Specs = null,
            Status = null,
            Vaults = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Gpu);
        Assert.False(model.RawData.ContainsKey("gpu"));
        Assert.Null(model.InstanceType);
        Assert.False(model.RawData.ContainsKey("instanceType"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PricePerHour);
        Assert.False(model.RawData.ContainsKey("pricePerHour"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.Specs);
        Assert.False(model.RawData.ContainsKey("specs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Vaults);
        Assert.False(model.RawData.ContainsKey("vaults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InstanceCreateResponse
        {
            AutoShutdownMinutes = 0,

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Gpu = null,
            InstanceType = null,
            Message = null,
            Name = null,
            PricePerHour = null,
            Region = null,
            Specs = null,
            Status = null,
            Vaults = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InstanceCreateResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            Gpu = "gpu",
            InstanceType = "instanceType",
            Message = "message",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Vaults = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        Assert.Null(model.AutoShutdownMinutes);
        Assert.False(model.RawData.ContainsKey("autoShutdownMinutes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InstanceCreateResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            Gpu = "gpu",
            InstanceType = "instanceType",
            Message = "message",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Vaults = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InstanceCreateResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            Gpu = "gpu",
            InstanceType = "instanceType",
            Message = "message",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Vaults = [JsonSerializer.Deserialize<JsonElement>("{}")],

            AutoShutdownMinutes = null,
        };

        Assert.Null(model.AutoShutdownMinutes);
        Assert.True(model.RawData.ContainsKey("autoShutdownMinutes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InstanceCreateResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            Gpu = "gpu",
            InstanceType = "instanceType",
            Message = "message",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Vaults = [JsonSerializer.Deserialize<JsonElement>("{}")],

            AutoShutdownMinutes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InstanceCreateResponse
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = "createdAt",
            Gpu = "gpu",
            InstanceType = "instanceType",
            Message = "message",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
            Vaults = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        InstanceCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
