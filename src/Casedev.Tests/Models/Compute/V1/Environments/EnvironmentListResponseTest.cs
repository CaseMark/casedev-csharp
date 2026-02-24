using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Environments = Casedev.Models.Compute.V1.Environments;

namespace Casedev.Tests.Models.Compute.V1.Environments;

public class EnvironmentListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Environments::EnvironmentListResponse
        {
            Environments =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Domain = "domain",
                    IsDefault = true,
                    Name = "name",
                    Slug = "slug",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<Environments::Environment> expectedEnvironments =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Domain = "domain",
                IsDefault = true,
                Name = "name",
                Slug = "slug",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.NotNull(model.Environments);
        Assert.Equal(expectedEnvironments.Count, model.Environments.Count);
        for (int i = 0; i < expectedEnvironments.Count; i++)
        {
            Assert.Equal(expectedEnvironments[i], model.Environments[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Environments::EnvironmentListResponse
        {
            Environments =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Domain = "domain",
                    IsDefault = true,
                    Name = "name",
                    Slug = "slug",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Environments::EnvironmentListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Environments::EnvironmentListResponse
        {
            Environments =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Domain = "domain",
                    IsDefault = true,
                    Name = "name",
                    Slug = "slug",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Environments::EnvironmentListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Environments::Environment> expectedEnvironments =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Domain = "domain",
                IsDefault = true,
                Name = "name",
                Slug = "slug",
                Status = "status",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.NotNull(deserialized.Environments);
        Assert.Equal(expectedEnvironments.Count, deserialized.Environments.Count);
        for (int i = 0; i < expectedEnvironments.Count; i++)
        {
            Assert.Equal(expectedEnvironments[i], deserialized.Environments[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Environments::EnvironmentListResponse
        {
            Environments =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Domain = "domain",
                    IsDefault = true,
                    Name = "name",
                    Slug = "slug",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Environments::EnvironmentListResponse { };

        Assert.Null(model.Environments);
        Assert.False(model.RawData.ContainsKey("environments"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Environments::EnvironmentListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Environments::EnvironmentListResponse
        {
            // Null should be interpreted as omitted for these properties
            Environments = null,
        };

        Assert.Null(model.Environments);
        Assert.False(model.RawData.ContainsKey("environments"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Environments::EnvironmentListResponse
        {
            // Null should be interpreted as omitted for these properties
            Environments = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Environments::EnvironmentListResponse
        {
            Environments =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Domain = "domain",
                    IsDefault = true,
                    Name = "name",
                    Slug = "slug",
                    Status = "status",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Environments::EnvironmentListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EnvironmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Environments::Environment
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "domain",
            IsDefault = true,
            Name = "name",
            Slug = "slug",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDomain = "domain";
        bool expectedIsDefault = true;
        string expectedName = "name";
        string expectedSlug = "slug";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDomain, model.Domain);
        Assert.Equal(expectedIsDefault, model.IsDefault);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSlug, model.Slug);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Environments::Environment
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "domain",
            IsDefault = true,
            Name = "name",
            Slug = "slug",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Environments::Environment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Environments::Environment
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "domain",
            IsDefault = true,
            Name = "name",
            Slug = "slug",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Environments::Environment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDomain = "domain";
        bool expectedIsDefault = true;
        string expectedName = "name";
        string expectedSlug = "slug";
        string expectedStatus = "status";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDomain, deserialized.Domain);
        Assert.Equal(expectedIsDefault, deserialized.IsDefault);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSlug, deserialized.Slug);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Environments::Environment
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "domain",
            IsDefault = true,
            Name = "name",
            Slug = "slug",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Environments::Environment { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Domain);
        Assert.False(model.RawData.ContainsKey("domain"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("isDefault"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Environments::Environment { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Environments::Environment
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Domain = null,
            IsDefault = null,
            Name = null,
            Slug = null,
            Status = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Domain);
        Assert.False(model.RawData.ContainsKey("domain"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("isDefault"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Environments::Environment
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Domain = null,
            IsDefault = null,
            Name = null,
            Slug = null,
            Status = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Environments::Environment
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "domain",
            IsDefault = true,
            Name = "name",
            Slug = "slug",
            Status = "status",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Environments::Environment copied = new(model);

        Assert.Equal(model, copied);
    }
}
