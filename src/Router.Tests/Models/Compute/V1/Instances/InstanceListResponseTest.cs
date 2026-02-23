using System;
using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Compute.V1.Instances;

namespace Router.Tests.Models.Compute.V1.Instances;

public class InstanceListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InstanceListResponse
        {
            Count = 0,
            Instances =
            [
                new()
                {
                    ID = "id",
                    AutoShutdownMinutes = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Gpu = "gpu",
                    InstanceType = "instanceType",
                    IP = "ip",
                    Name = "name",
                    PricePerHour = "pricePerHour",
                    Region = "region",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Booting,
                    TotalCost = "totalCost",
                    TotalRuntimeSeconds = 0,
                },
            ],
        };

        long expectedCount = 0;
        List<Instance> expectedInstances =
        [
            new()
            {
                ID = "id",
                AutoShutdownMinutes = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Gpu = "gpu",
                InstanceType = "instanceType",
                IP = "ip",
                Name = "name",
                PricePerHour = "pricePerHour",
                Region = "region",
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Booting,
                TotalCost = "totalCost",
                TotalRuntimeSeconds = 0,
            },
        ];

        Assert.Equal(expectedCount, model.Count);
        Assert.NotNull(model.Instances);
        Assert.Equal(expectedInstances.Count, model.Instances.Count);
        for (int i = 0; i < expectedInstances.Count; i++)
        {
            Assert.Equal(expectedInstances[i], model.Instances[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InstanceListResponse
        {
            Count = 0,
            Instances =
            [
                new()
                {
                    ID = "id",
                    AutoShutdownMinutes = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Gpu = "gpu",
                    InstanceType = "instanceType",
                    IP = "ip",
                    Name = "name",
                    PricePerHour = "pricePerHour",
                    Region = "region",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Booting,
                    TotalCost = "totalCost",
                    TotalRuntimeSeconds = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InstanceListResponse
        {
            Count = 0,
            Instances =
            [
                new()
                {
                    ID = "id",
                    AutoShutdownMinutes = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Gpu = "gpu",
                    InstanceType = "instanceType",
                    IP = "ip",
                    Name = "name",
                    PricePerHour = "pricePerHour",
                    Region = "region",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Booting,
                    TotalCost = "totalCost",
                    TotalRuntimeSeconds = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCount = 0;
        List<Instance> expectedInstances =
        [
            new()
            {
                ID = "id",
                AutoShutdownMinutes = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Gpu = "gpu",
                InstanceType = "instanceType",
                IP = "ip",
                Name = "name",
                PricePerHour = "pricePerHour",
                Region = "region",
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Booting,
                TotalCost = "totalCost",
                TotalRuntimeSeconds = 0,
            },
        ];

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.NotNull(deserialized.Instances);
        Assert.Equal(expectedInstances.Count, deserialized.Instances.Count);
        for (int i = 0; i < expectedInstances.Count; i++)
        {
            Assert.Equal(expectedInstances[i], deserialized.Instances[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InstanceListResponse
        {
            Count = 0,
            Instances =
            [
                new()
                {
                    ID = "id",
                    AutoShutdownMinutes = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Gpu = "gpu",
                    InstanceType = "instanceType",
                    IP = "ip",
                    Name = "name",
                    PricePerHour = "pricePerHour",
                    Region = "region",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Booting,
                    TotalCost = "totalCost",
                    TotalRuntimeSeconds = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InstanceListResponse { };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Instances);
        Assert.False(model.RawData.ContainsKey("instances"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InstanceListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InstanceListResponse
        {
            // Null should be interpreted as omitted for these properties
            Count = null,
            Instances = null,
        };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.Instances);
        Assert.False(model.RawData.ContainsKey("instances"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InstanceListResponse
        {
            // Null should be interpreted as omitted for these properties
            Count = null,
            Instances = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InstanceListResponse
        {
            Count = 0,
            Instances =
            [
                new()
                {
                    ID = "id",
                    AutoShutdownMinutes = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Gpu = "gpu",
                    InstanceType = "instanceType",
                    IP = "ip",
                    Name = "name",
                    PricePerHour = "pricePerHour",
                    Region = "region",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Booting,
                    TotalCost = "totalCost",
                    TotalRuntimeSeconds = 0,
                },
            ],
        };

        InstanceListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InstanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Instance
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gpu = "gpu",
            InstanceType = "instanceType",
            IP = "ip",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Booting,
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        string expectedID = "id";
        long expectedAutoShutdownMinutes = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedGpu = "gpu";
        string expectedInstanceType = "instanceType";
        string expectedIP = "ip";
        string expectedName = "name";
        string expectedPricePerHour = "pricePerHour";
        string expectedRegion = "region";
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Status> expectedStatus = Status.Booting;
        string expectedTotalCost = "totalCost";
        long expectedTotalRuntimeSeconds = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAutoShutdownMinutes, model.AutoShutdownMinutes);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedGpu, model.Gpu);
        Assert.Equal(expectedInstanceType, model.InstanceType);
        Assert.Equal(expectedIP, model.IP);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPricePerHour, model.PricePerHour);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTotalCost, model.TotalCost);
        Assert.Equal(expectedTotalRuntimeSeconds, model.TotalRuntimeSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Instance
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gpu = "gpu",
            InstanceType = "instanceType",
            IP = "ip",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Booting,
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Instance>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Instance
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gpu = "gpu",
            InstanceType = "instanceType",
            IP = "ip",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Booting,
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Instance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedAutoShutdownMinutes = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedGpu = "gpu";
        string expectedInstanceType = "instanceType";
        string expectedIP = "ip";
        string expectedName = "name";
        string expectedPricePerHour = "pricePerHour";
        string expectedRegion = "region";
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Status> expectedStatus = Status.Booting;
        string expectedTotalCost = "totalCost";
        long expectedTotalRuntimeSeconds = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAutoShutdownMinutes, deserialized.AutoShutdownMinutes);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedGpu, deserialized.Gpu);
        Assert.Equal(expectedInstanceType, deserialized.InstanceType);
        Assert.Equal(expectedIP, deserialized.IP);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPricePerHour, deserialized.PricePerHour);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTotalCost, deserialized.TotalCost);
        Assert.Equal(expectedTotalRuntimeSeconds, deserialized.TotalRuntimeSeconds);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Instance
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gpu = "gpu",
            InstanceType = "instanceType",
            IP = "ip",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Booting,
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Instance
        {
            AutoShutdownMinutes = 0,
            IP = "ip",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Gpu);
        Assert.False(model.RawData.ContainsKey("gpu"));
        Assert.Null(model.InstanceType);
        Assert.False(model.RawData.ContainsKey("instanceType"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PricePerHour);
        Assert.False(model.RawData.ContainsKey("pricePerHour"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
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
        var model = new Instance
        {
            AutoShutdownMinutes = 0,
            IP = "ip",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Instance
        {
            AutoShutdownMinutes = 0,
            IP = "ip",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Gpu = null,
            InstanceType = null,
            Name = null,
            PricePerHour = null,
            Region = null,
            Status = null,
            TotalCost = null,
            TotalRuntimeSeconds = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Gpu);
        Assert.False(model.RawData.ContainsKey("gpu"));
        Assert.Null(model.InstanceType);
        Assert.False(model.RawData.ContainsKey("instanceType"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PricePerHour);
        Assert.False(model.RawData.ContainsKey("pricePerHour"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
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
        var model = new Instance
        {
            AutoShutdownMinutes = 0,
            IP = "ip",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Gpu = null,
            InstanceType = null,
            Name = null,
            PricePerHour = null,
            Region = null,
            Status = null,
            TotalCost = null,
            TotalRuntimeSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Instance
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gpu = "gpu",
            InstanceType = "instanceType",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Status = Status.Booting,
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        Assert.Null(model.AutoShutdownMinutes);
        Assert.False(model.RawData.ContainsKey("autoShutdownMinutes"));
        Assert.Null(model.IP);
        Assert.False(model.RawData.ContainsKey("ip"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Instance
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gpu = "gpu",
            InstanceType = "instanceType",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Status = Status.Booting,
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Instance
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gpu = "gpu",
            InstanceType = "instanceType",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Status = Status.Booting,
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,

            AutoShutdownMinutes = null,
            IP = null,
            StartedAt = null,
        };

        Assert.Null(model.AutoShutdownMinutes);
        Assert.True(model.RawData.ContainsKey("autoShutdownMinutes"));
        Assert.Null(model.IP);
        Assert.True(model.RawData.ContainsKey("ip"));
        Assert.Null(model.StartedAt);
        Assert.True(model.RawData.ContainsKey("startedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Instance
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gpu = "gpu",
            InstanceType = "instanceType",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Status = Status.Booting,
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,

            AutoShutdownMinutes = null,
            IP = null,
            StartedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Instance
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gpu = "gpu",
            InstanceType = "instanceType",
            IP = "ip",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Booting,
            TotalCost = "totalCost",
            TotalRuntimeSeconds = 0,
        };

        Instance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Booting)]
    [InlineData(Status.Running)]
    [InlineData(Status.Stopping)]
    [InlineData(Status.Stopped)]
    [InlineData(Status.Terminated)]
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
    [InlineData(Status.Booting)]
    [InlineData(Status.Running)]
    [InlineData(Status.Stopping)]
    [InlineData(Status.Stopped)]
    [InlineData(Status.Terminated)]
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
