using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Vault;

namespace Casedev.Tests.Models.Vault;

public class VaultListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultListResponse
        {
            Total = 0,
            Vaults =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnableGraph = true,
                    Name = "name",
                    TotalBytes = 0,
                    TotalObjects = 0,
                },
            ],
        };

        long expectedTotal = 0;
        List<VaultListResponseVault> expectedVaults =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                EnableGraph = true,
                Name = "name",
                TotalBytes = 0,
                TotalObjects = 0,
            },
        ];

        Assert.Equal(expectedTotal, model.Total);
        Assert.NotNull(model.Vaults);
        Assert.Equal(expectedVaults.Count, model.Vaults.Count);
        for (int i = 0; i < expectedVaults.Count; i++)
        {
            Assert.Equal(expectedVaults[i], model.Vaults[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultListResponse
        {
            Total = 0,
            Vaults =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnableGraph = true,
                    Name = "name",
                    TotalBytes = 0,
                    TotalObjects = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultListResponse
        {
            Total = 0,
            Vaults =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnableGraph = true,
                    Name = "name",
                    TotalBytes = 0,
                    TotalObjects = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedTotal = 0;
        List<VaultListResponseVault> expectedVaults =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                EnableGraph = true,
                Name = "name",
                TotalBytes = 0,
                TotalObjects = 0,
            },
        ];

        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.NotNull(deserialized.Vaults);
        Assert.Equal(expectedVaults.Count, deserialized.Vaults.Count);
        for (int i = 0; i < expectedVaults.Count; i++)
        {
            Assert.Equal(expectedVaults[i], deserialized.Vaults[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultListResponse
        {
            Total = 0,
            Vaults =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnableGraph = true,
                    Name = "name",
                    TotalBytes = 0,
                    TotalObjects = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultListResponse { };

        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Vaults);
        Assert.False(model.RawData.ContainsKey("vaults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultListResponse
        {
            // Null should be interpreted as omitted for these properties
            Total = null,
            Vaults = null,
        };

        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Vaults);
        Assert.False(model.RawData.ContainsKey("vaults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultListResponse
        {
            // Null should be interpreted as omitted for these properties
            Total = null,
            Vaults = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VaultListResponse
        {
            Total = 0,
            Vaults =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    EnableGraph = true,
                    Name = "name",
                    TotalBytes = 0,
                    TotalObjects = 0,
                },
            ],
        };

        VaultListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VaultListResponseVaultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VaultListResponseVault
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableGraph = true,
            Name = "name",
            TotalBytes = 0,
            TotalObjects = 0,
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        bool expectedEnableGraph = true;
        string expectedName = "name";
        long expectedTotalBytes = 0;
        long expectedTotalObjects = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEnableGraph, model.EnableGraph);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTotalBytes, model.TotalBytes);
        Assert.Equal(expectedTotalObjects, model.TotalObjects);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VaultListResponseVault
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableGraph = true,
            Name = "name",
            TotalBytes = 0,
            TotalObjects = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultListResponseVault>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VaultListResponseVault
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableGraph = true,
            Name = "name",
            TotalBytes = 0,
            TotalObjects = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VaultListResponseVault>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        bool expectedEnableGraph = true;
        string expectedName = "name";
        long expectedTotalBytes = 0;
        long expectedTotalObjects = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEnableGraph, deserialized.EnableGraph);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTotalBytes, deserialized.TotalBytes);
        Assert.Equal(expectedTotalObjects, deserialized.TotalObjects);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VaultListResponseVault
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableGraph = true,
            Name = "name",
            TotalBytes = 0,
            TotalObjects = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VaultListResponseVault { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EnableGraph);
        Assert.False(model.RawData.ContainsKey("enableGraph"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.TotalBytes);
        Assert.False(model.RawData.ContainsKey("totalBytes"));
        Assert.Null(model.TotalObjects);
        Assert.False(model.RawData.ContainsKey("totalObjects"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VaultListResponseVault { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VaultListResponseVault
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Description = null,
            EnableGraph = null,
            Name = null,
            TotalBytes = null,
            TotalObjects = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EnableGraph);
        Assert.False(model.RawData.ContainsKey("enableGraph"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.TotalBytes);
        Assert.False(model.RawData.ContainsKey("totalBytes"));
        Assert.Null(model.TotalObjects);
        Assert.False(model.RawData.ContainsKey("totalObjects"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VaultListResponseVault
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Description = null,
            EnableGraph = null,
            Name = null,
            TotalBytes = null,
            TotalObjects = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VaultListResponseVault
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EnableGraph = true,
            Name = "name",
            TotalBytes = 0,
            TotalObjects = 0,
        };

        VaultListResponseVault copied = new(model);

        Assert.Equal(model, copied);
    }
}
