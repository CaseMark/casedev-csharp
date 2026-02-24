using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Compute.V1.InstanceTypes;

namespace Casedev.Tests.Models.Compute.V1.InstanceTypes;

public class InstanceTypeListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InstanceTypeListResponse
        {
            Count = 0,
            InstanceTypes =
            [
                new()
                {
                    Description = "description",
                    Gpu = "gpu",
                    Name = "name",
                    PricePerHour = "pricePerHour",
                    RegionsAvailable = ["string"],
                    Specs = new()
                    {
                        MemoryGib = 0,
                        StorageGib = 0,
                        Vcpus = 0,
                    },
                },
            ],
        };

        long expectedCount = 0;
        List<InstanceType> expectedInstanceTypes =
        [
            new()
            {
                Description = "description",
                Gpu = "gpu",
                Name = "name",
                PricePerHour = "pricePerHour",
                RegionsAvailable = ["string"],
                Specs = new()
                {
                    MemoryGib = 0,
                    StorageGib = 0,
                    Vcpus = 0,
                },
            },
        ];

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedInstanceTypes.Count, model.InstanceTypes.Count);
        for (int i = 0; i < expectedInstanceTypes.Count; i++)
        {
            Assert.Equal(expectedInstanceTypes[i], model.InstanceTypes[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InstanceTypeListResponse
        {
            Count = 0,
            InstanceTypes =
            [
                new()
                {
                    Description = "description",
                    Gpu = "gpu",
                    Name = "name",
                    PricePerHour = "pricePerHour",
                    RegionsAvailable = ["string"],
                    Specs = new()
                    {
                        MemoryGib = 0,
                        StorageGib = 0,
                        Vcpus = 0,
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceTypeListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InstanceTypeListResponse
        {
            Count = 0,
            InstanceTypes =
            [
                new()
                {
                    Description = "description",
                    Gpu = "gpu",
                    Name = "name",
                    PricePerHour = "pricePerHour",
                    RegionsAvailable = ["string"],
                    Specs = new()
                    {
                        MemoryGib = 0,
                        StorageGib = 0,
                        Vcpus = 0,
                    },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceTypeListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCount = 0;
        List<InstanceType> expectedInstanceTypes =
        [
            new()
            {
                Description = "description",
                Gpu = "gpu",
                Name = "name",
                PricePerHour = "pricePerHour",
                RegionsAvailable = ["string"],
                Specs = new()
                {
                    MemoryGib = 0,
                    StorageGib = 0,
                    Vcpus = 0,
                },
            },
        ];

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedInstanceTypes.Count, deserialized.InstanceTypes.Count);
        for (int i = 0; i < expectedInstanceTypes.Count; i++)
        {
            Assert.Equal(expectedInstanceTypes[i], deserialized.InstanceTypes[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InstanceTypeListResponse
        {
            Count = 0,
            InstanceTypes =
            [
                new()
                {
                    Description = "description",
                    Gpu = "gpu",
                    Name = "name",
                    PricePerHour = "pricePerHour",
                    RegionsAvailable = ["string"],
                    Specs = new()
                    {
                        MemoryGib = 0,
                        StorageGib = 0,
                        Vcpus = 0,
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InstanceTypeListResponse
        {
            Count = 0,
            InstanceTypes =
            [
                new()
                {
                    Description = "description",
                    Gpu = "gpu",
                    Name = "name",
                    PricePerHour = "pricePerHour",
                    RegionsAvailable = ["string"],
                    Specs = new()
                    {
                        MemoryGib = 0,
                        StorageGib = 0,
                        Vcpus = 0,
                    },
                },
            ],
        };

        InstanceTypeListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InstanceTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InstanceType
        {
            Description = "description",
            Gpu = "gpu",
            Name = "name",
            PricePerHour = "pricePerHour",
            RegionsAvailable = ["string"],
            Specs = new()
            {
                MemoryGib = 0,
                StorageGib = 0,
                Vcpus = 0,
            },
        };

        string expectedDescription = "description";
        string expectedGpu = "gpu";
        string expectedName = "name";
        string expectedPricePerHour = "pricePerHour";
        List<string> expectedRegionsAvailable = ["string"];
        Specs expectedSpecs = new()
        {
            MemoryGib = 0,
            StorageGib = 0,
            Vcpus = 0,
        };

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedGpu, model.Gpu);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPricePerHour, model.PricePerHour);
        Assert.NotNull(model.RegionsAvailable);
        Assert.Equal(expectedRegionsAvailable.Count, model.RegionsAvailable.Count);
        for (int i = 0; i < expectedRegionsAvailable.Count; i++)
        {
            Assert.Equal(expectedRegionsAvailable[i], model.RegionsAvailable[i]);
        }
        Assert.Equal(expectedSpecs, model.Specs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InstanceType
        {
            Description = "description",
            Gpu = "gpu",
            Name = "name",
            PricePerHour = "pricePerHour",
            RegionsAvailable = ["string"],
            Specs = new()
            {
                MemoryGib = 0,
                StorageGib = 0,
                Vcpus = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceType>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InstanceType
        {
            Description = "description",
            Gpu = "gpu",
            Name = "name",
            PricePerHour = "pricePerHour",
            RegionsAvailable = ["string"],
            Specs = new()
            {
                MemoryGib = 0,
                StorageGib = 0,
                Vcpus = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceType>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedGpu = "gpu";
        string expectedName = "name";
        string expectedPricePerHour = "pricePerHour";
        List<string> expectedRegionsAvailable = ["string"];
        Specs expectedSpecs = new()
        {
            MemoryGib = 0,
            StorageGib = 0,
            Vcpus = 0,
        };

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedGpu, deserialized.Gpu);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPricePerHour, deserialized.PricePerHour);
        Assert.NotNull(deserialized.RegionsAvailable);
        Assert.Equal(expectedRegionsAvailable.Count, deserialized.RegionsAvailable.Count);
        for (int i = 0; i < expectedRegionsAvailable.Count; i++)
        {
            Assert.Equal(expectedRegionsAvailable[i], deserialized.RegionsAvailable[i]);
        }
        Assert.Equal(expectedSpecs, deserialized.Specs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InstanceType
        {
            Description = "description",
            Gpu = "gpu",
            Name = "name",
            PricePerHour = "pricePerHour",
            RegionsAvailable = ["string"],
            Specs = new()
            {
                MemoryGib = 0,
                StorageGib = 0,
                Vcpus = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InstanceType { };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Gpu);
        Assert.False(model.RawData.ContainsKey("gpu"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PricePerHour);
        Assert.False(model.RawData.ContainsKey("pricePerHour"));
        Assert.Null(model.RegionsAvailable);
        Assert.False(model.RawData.ContainsKey("regionsAvailable"));
        Assert.Null(model.Specs);
        Assert.False(model.RawData.ContainsKey("specs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InstanceType { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InstanceType
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            Gpu = null,
            Name = null,
            PricePerHour = null,
            RegionsAvailable = null,
            Specs = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Gpu);
        Assert.False(model.RawData.ContainsKey("gpu"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PricePerHour);
        Assert.False(model.RawData.ContainsKey("pricePerHour"));
        Assert.Null(model.RegionsAvailable);
        Assert.False(model.RawData.ContainsKey("regionsAvailable"));
        Assert.Null(model.Specs);
        Assert.False(model.RawData.ContainsKey("specs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InstanceType
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            Gpu = null,
            Name = null,
            PricePerHour = null,
            RegionsAvailable = null,
            Specs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InstanceType
        {
            Description = "description",
            Gpu = "gpu",
            Name = "name",
            PricePerHour = "pricePerHour",
            RegionsAvailable = ["string"],
            Specs = new()
            {
                MemoryGib = 0,
                StorageGib = 0,
                Vcpus = 0,
            },
        };

        InstanceType copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SpecsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Specs
        {
            MemoryGib = 0,
            StorageGib = 0,
            Vcpus = 0,
        };

        long expectedMemoryGib = 0;
        long expectedStorageGib = 0;
        long expectedVcpus = 0;

        Assert.Equal(expectedMemoryGib, model.MemoryGib);
        Assert.Equal(expectedStorageGib, model.StorageGib);
        Assert.Equal(expectedVcpus, model.Vcpus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Specs
        {
            MemoryGib = 0,
            StorageGib = 0,
            Vcpus = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Specs>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Specs
        {
            MemoryGib = 0,
            StorageGib = 0,
            Vcpus = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Specs>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedMemoryGib = 0;
        long expectedStorageGib = 0;
        long expectedVcpus = 0;

        Assert.Equal(expectedMemoryGib, deserialized.MemoryGib);
        Assert.Equal(expectedStorageGib, deserialized.StorageGib);
        Assert.Equal(expectedVcpus, deserialized.Vcpus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Specs
        {
            MemoryGib = 0,
            StorageGib = 0,
            Vcpus = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Specs { };

        Assert.Null(model.MemoryGib);
        Assert.False(model.RawData.ContainsKey("memoryGib"));
        Assert.Null(model.StorageGib);
        Assert.False(model.RawData.ContainsKey("storageGib"));
        Assert.Null(model.Vcpus);
        Assert.False(model.RawData.ContainsKey("vcpus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Specs { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Specs
        {
            // Null should be interpreted as omitted for these properties
            MemoryGib = null,
            StorageGib = null,
            Vcpus = null,
        };

        Assert.Null(model.MemoryGib);
        Assert.False(model.RawData.ContainsKey("memoryGib"));
        Assert.Null(model.StorageGib);
        Assert.False(model.RawData.ContainsKey("storageGib"));
        Assert.Null(model.Vcpus);
        Assert.False(model.RawData.ContainsKey("vcpus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Specs
        {
            // Null should be interpreted as omitted for these properties
            MemoryGib = null,
            StorageGib = null,
            Vcpus = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Specs
        {
            MemoryGib = 0,
            StorageGib = 0,
            Vcpus = 0,
        };

        Specs copied = new(model);

        Assert.Equal(model, copied);
    }
}
