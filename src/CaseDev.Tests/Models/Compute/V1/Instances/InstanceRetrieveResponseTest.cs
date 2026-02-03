using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Compute.V1.Instances;

namespace CaseDev.Tests.Models.Compute.V1.Instances;

public class InstanceRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = "createdAt",
            CurrentCost = "currentCost",
            CurrentRuntimeSeconds = 0,
            Gpu = "gpu",
            InstanceType = "instanceType",
            IP = "ip",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Ssh = new()
            {
                Command = "command",
                Host = "host",
                Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
                PrivateKey = "privateKey",
                User = "user",
            },
            StartedAt = "startedAt",
            Status = "status",
            VaultMounts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedID = "id";
        long expectedAutoShutdownMinutes = 0;
        string expectedCreatedAt = "createdAt";
        string expectedCurrentCost = "currentCost";
        long expectedCurrentRuntimeSeconds = 0;
        string expectedGpu = "gpu";
        string expectedInstanceType = "instanceType";
        string expectedIP = "ip";
        string expectedName = "name";
        string expectedPricePerHour = "pricePerHour";
        string expectedRegion = "region";
        JsonElement expectedSpecs = JsonSerializer.Deserialize<JsonElement>("{}");
        Ssh expectedSsh = new()
        {
            Command = "command",
            Host = "host",
            Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
            PrivateKey = "privateKey",
            User = "user",
        };
        string expectedStartedAt = "startedAt";
        string expectedStatus = "status";
        JsonElement expectedVaultMounts = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAutoShutdownMinutes, model.AutoShutdownMinutes);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrentCost, model.CurrentCost);
        Assert.Equal(expectedCurrentRuntimeSeconds, model.CurrentRuntimeSeconds);
        Assert.Equal(expectedGpu, model.Gpu);
        Assert.Equal(expectedInstanceType, model.InstanceType);
        Assert.Equal(expectedIP, model.IP);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPricePerHour, model.PricePerHour);
        Assert.Equal(expectedRegion, model.Region);
        Assert.NotNull(model.Specs);
        Assert.True(JsonElement.DeepEquals(expectedSpecs, model.Specs.Value));
        Assert.Equal(expectedSsh, model.Ssh);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.VaultMounts);
        Assert.True(JsonElement.DeepEquals(expectedVaultMounts, model.VaultMounts.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = "createdAt",
            CurrentCost = "currentCost",
            CurrentRuntimeSeconds = 0,
            Gpu = "gpu",
            InstanceType = "instanceType",
            IP = "ip",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Ssh = new()
            {
                Command = "command",
                Host = "host",
                Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
                PrivateKey = "privateKey",
                User = "user",
            },
            StartedAt = "startedAt",
            Status = "status",
            VaultMounts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = "createdAt",
            CurrentCost = "currentCost",
            CurrentRuntimeSeconds = 0,
            Gpu = "gpu",
            InstanceType = "instanceType",
            IP = "ip",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Ssh = new()
            {
                Command = "command",
                Host = "host",
                Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
                PrivateKey = "privateKey",
                User = "user",
            },
            StartedAt = "startedAt",
            Status = "status",
            VaultMounts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InstanceRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedAutoShutdownMinutes = 0;
        string expectedCreatedAt = "createdAt";
        string expectedCurrentCost = "currentCost";
        long expectedCurrentRuntimeSeconds = 0;
        string expectedGpu = "gpu";
        string expectedInstanceType = "instanceType";
        string expectedIP = "ip";
        string expectedName = "name";
        string expectedPricePerHour = "pricePerHour";
        string expectedRegion = "region";
        JsonElement expectedSpecs = JsonSerializer.Deserialize<JsonElement>("{}");
        Ssh expectedSsh = new()
        {
            Command = "command",
            Host = "host",
            Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
            PrivateKey = "privateKey",
            User = "user",
        };
        string expectedStartedAt = "startedAt";
        string expectedStatus = "status";
        JsonElement expectedVaultMounts = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAutoShutdownMinutes, deserialized.AutoShutdownMinutes);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrentCost, deserialized.CurrentCost);
        Assert.Equal(expectedCurrentRuntimeSeconds, deserialized.CurrentRuntimeSeconds);
        Assert.Equal(expectedGpu, deserialized.Gpu);
        Assert.Equal(expectedInstanceType, deserialized.InstanceType);
        Assert.Equal(expectedIP, deserialized.IP);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPricePerHour, deserialized.PricePerHour);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.NotNull(deserialized.Specs);
        Assert.True(JsonElement.DeepEquals(expectedSpecs, deserialized.Specs.Value));
        Assert.Equal(expectedSsh, deserialized.Ssh);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.VaultMounts);
        Assert.True(JsonElement.DeepEquals(expectedVaultMounts, deserialized.VaultMounts.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = "createdAt",
            CurrentCost = "currentCost",
            CurrentRuntimeSeconds = 0,
            Gpu = "gpu",
            InstanceType = "instanceType",
            IP = "ip",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Ssh = new()
            {
                Command = "command",
                Host = "host",
                Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
                PrivateKey = "privateKey",
                User = "user",
            },
            StartedAt = "startedAt",
            Status = "status",
            VaultMounts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            AutoShutdownMinutes = 0,
            IP = "ip",
            Ssh = new()
            {
                Command = "command",
                Host = "host",
                Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
                PrivateKey = "privateKey",
                User = "user",
            },
            StartedAt = "startedAt",
            VaultMounts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CurrentCost);
        Assert.False(model.RawData.ContainsKey("currentCost"));
        Assert.Null(model.CurrentRuntimeSeconds);
        Assert.False(model.RawData.ContainsKey("currentRuntimeSeconds"));
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
        Assert.Null(model.Specs);
        Assert.False(model.RawData.ContainsKey("specs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            AutoShutdownMinutes = 0,
            IP = "ip",
            Ssh = new()
            {
                Command = "command",
                Host = "host",
                Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
                PrivateKey = "privateKey",
                User = "user",
            },
            StartedAt = "startedAt",
            VaultMounts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            AutoShutdownMinutes = 0,
            IP = "ip",
            Ssh = new()
            {
                Command = "command",
                Host = "host",
                Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
                PrivateKey = "privateKey",
                User = "user",
            },
            StartedAt = "startedAt",
            VaultMounts = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CurrentCost = null,
            CurrentRuntimeSeconds = null,
            Gpu = null,
            InstanceType = null,
            Name = null,
            PricePerHour = null,
            Region = null,
            Specs = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CurrentCost);
        Assert.False(model.RawData.ContainsKey("currentCost"));
        Assert.Null(model.CurrentRuntimeSeconds);
        Assert.False(model.RawData.ContainsKey("currentRuntimeSeconds"));
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
        Assert.Null(model.Specs);
        Assert.False(model.RawData.ContainsKey("specs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            AutoShutdownMinutes = 0,
            IP = "ip",
            Ssh = new()
            {
                Command = "command",
                Host = "host",
                Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
                PrivateKey = "privateKey",
                User = "user",
            },
            StartedAt = "startedAt",
            VaultMounts = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CurrentCost = null,
            CurrentRuntimeSeconds = null,
            Gpu = null,
            InstanceType = null,
            Name = null,
            PricePerHour = null,
            Region = null,
            Specs = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            CurrentCost = "currentCost",
            CurrentRuntimeSeconds = 0,
            Gpu = "gpu",
            InstanceType = "instanceType",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
        };

        Assert.Null(model.AutoShutdownMinutes);
        Assert.False(model.RawData.ContainsKey("autoShutdownMinutes"));
        Assert.Null(model.IP);
        Assert.False(model.RawData.ContainsKey("ip"));
        Assert.Null(model.Ssh);
        Assert.False(model.RawData.ContainsKey("ssh"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.VaultMounts);
        Assert.False(model.RawData.ContainsKey("vaultMounts"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            CurrentCost = "currentCost",
            CurrentRuntimeSeconds = 0,
            Gpu = "gpu",
            InstanceType = "instanceType",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            CurrentCost = "currentCost",
            CurrentRuntimeSeconds = 0,
            Gpu = "gpu",
            InstanceType = "instanceType",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",

            AutoShutdownMinutes = null,
            IP = null,
            Ssh = null,
            StartedAt = null,
            VaultMounts = null,
        };

        Assert.Null(model.AutoShutdownMinutes);
        Assert.True(model.RawData.ContainsKey("autoShutdownMinutes"));
        Assert.Null(model.IP);
        Assert.True(model.RawData.ContainsKey("ip"));
        Assert.Null(model.Ssh);
        Assert.True(model.RawData.ContainsKey("ssh"));
        Assert.Null(model.StartedAt);
        Assert.True(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.VaultMounts);
        Assert.True(model.RawData.ContainsKey("vaultMounts"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            ID = "id",
            CreatedAt = "createdAt",
            CurrentCost = "currentCost",
            CurrentRuntimeSeconds = 0,
            Gpu = "gpu",
            InstanceType = "instanceType",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Status = "status",

            AutoShutdownMinutes = null,
            IP = null,
            Ssh = null,
            StartedAt = null,
            VaultMounts = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InstanceRetrieveResponse
        {
            ID = "id",
            AutoShutdownMinutes = 0,
            CreatedAt = "createdAt",
            CurrentCost = "currentCost",
            CurrentRuntimeSeconds = 0,
            Gpu = "gpu",
            InstanceType = "instanceType",
            IP = "ip",
            Name = "name",
            PricePerHour = "pricePerHour",
            Region = "region",
            Specs = JsonSerializer.Deserialize<JsonElement>("{}"),
            Ssh = new()
            {
                Command = "command",
                Host = "host",
                Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
                PrivateKey = "privateKey",
                User = "user",
            },
            StartedAt = "startedAt",
            Status = "status",
            VaultMounts = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        InstanceRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SshTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ssh
        {
            Command = "command",
            Host = "host",
            Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
            PrivateKey = "privateKey",
            User = "user",
        };

        string expectedCommand = "command";
        string expectedHost = "host";
        List<JsonElement> expectedInstructions = [JsonSerializer.Deserialize<JsonElement>("{}")];
        string expectedPrivateKey = "privateKey";
        string expectedUser = "user";

        Assert.Equal(expectedCommand, model.Command);
        Assert.Equal(expectedHost, model.Host);
        Assert.NotNull(model.Instructions);
        Assert.Equal(expectedInstructions.Count, model.Instructions.Count);
        for (int i = 0; i < expectedInstructions.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedInstructions[i], model.Instructions[i]));
        }
        Assert.Equal(expectedPrivateKey, model.PrivateKey);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Ssh
        {
            Command = "command",
            Host = "host",
            Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
            PrivateKey = "privateKey",
            User = "user",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Ssh>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Ssh
        {
            Command = "command",
            Host = "host",
            Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
            PrivateKey = "privateKey",
            User = "user",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Ssh>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCommand = "command";
        string expectedHost = "host";
        List<JsonElement> expectedInstructions = [JsonSerializer.Deserialize<JsonElement>("{}")];
        string expectedPrivateKey = "privateKey";
        string expectedUser = "user";

        Assert.Equal(expectedCommand, deserialized.Command);
        Assert.Equal(expectedHost, deserialized.Host);
        Assert.NotNull(deserialized.Instructions);
        Assert.Equal(expectedInstructions.Count, deserialized.Instructions.Count);
        for (int i = 0; i < expectedInstructions.Count; i++)
        {
            Assert.True(
                JsonElement.DeepEquals(expectedInstructions[i], deserialized.Instructions[i])
            );
        }
        Assert.Equal(expectedPrivateKey, deserialized.PrivateKey);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Ssh
        {
            Command = "command",
            Host = "host",
            Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
            PrivateKey = "privateKey",
            User = "user",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Ssh { };

        Assert.Null(model.Command);
        Assert.False(model.RawData.ContainsKey("command"));
        Assert.Null(model.Host);
        Assert.False(model.RawData.ContainsKey("host"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.PrivateKey);
        Assert.False(model.RawData.ContainsKey("privateKey"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Ssh { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Ssh
        {
            // Null should be interpreted as omitted for these properties
            Command = null,
            Host = null,
            Instructions = null,
            PrivateKey = null,
            User = null,
        };

        Assert.Null(model.Command);
        Assert.False(model.RawData.ContainsKey("command"));
        Assert.Null(model.Host);
        Assert.False(model.RawData.ContainsKey("host"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.PrivateKey);
        Assert.False(model.RawData.ContainsKey("privateKey"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Ssh
        {
            // Null should be interpreted as omitted for these properties
            Command = null,
            Host = null,
            Instructions = null,
            PrivateKey = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Ssh
        {
            Command = "command",
            Host = "host",
            Instructions = [JsonSerializer.Deserialize<JsonElement>("{}")],
            PrivateKey = "privateKey",
            User = "user",
        };

        Ssh copied = new(model);

        Assert.Equal(model, copied);
    }
}
