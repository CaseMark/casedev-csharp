using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using Projects = CaseDev.Models.Database.V1.Projects;

namespace CaseDev.Tests.Models.Database.V1.Projects;

public class ProjectRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Projects::ProjectRetrieveResponse
        {
            ID = "id",
            Branches =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsDefault = true,
                    Name = "name",
                    Status = "status",
                },
            ],
            ComputeTimeSeconds = 0,
            ConnectionHost = "connectionHost",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Databases =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    OwnerName = "ownerName",
                },
            ],
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    EnvVarName = "envVarName",
                    Name = "name",
                    Type = Projects::Type.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = Projects::ProjectRetrieveResponseStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string expectedID = "id";
        List<Projects::Branch> expectedBranches =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsDefault = true,
                Name = "name",
                Status = "status",
            },
        ];
        double expectedComputeTimeSeconds = 0;
        string expectedConnectionHost = "connectionHost";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Projects::ProjectRetrieveResponseDatabase> expectedDatabases =
        [
            new()
            {
                ID = "id",
                Name = "name",
                OwnerName = "ownerName",
            },
        ];
        List<Projects::LinkedDeployment> expectedLinkedDeployments =
        [
            new()
            {
                ID = "id",
                EnvVarName = "envVarName",
                Name = "name",
                Type = Projects::Type.Thurgood,
                Url = "url",
            },
        ];
        string expectedName = "name";
        long expectedPgVersion = 0;
        string expectedRegion = "region";
        ApiEnum<string, Projects::ProjectRetrieveResponseStatus> expectedStatus =
            Projects::ProjectRetrieveResponseStatus.Active;
        double expectedStorageSizeBytes = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBranches.Count, model.Branches.Count);
        for (int i = 0; i < expectedBranches.Count; i++)
        {
            Assert.Equal(expectedBranches[i], model.Branches[i]);
        }
        Assert.Equal(expectedComputeTimeSeconds, model.ComputeTimeSeconds);
        Assert.Equal(expectedConnectionHost, model.ConnectionHost);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDatabases.Count, model.Databases.Count);
        for (int i = 0; i < expectedDatabases.Count; i++)
        {
            Assert.Equal(expectedDatabases[i], model.Databases[i]);
        }
        Assert.Equal(expectedLinkedDeployments.Count, model.LinkedDeployments.Count);
        for (int i = 0; i < expectedLinkedDeployments.Count; i++)
        {
            Assert.Equal(expectedLinkedDeployments[i], model.LinkedDeployments[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPgVersion, model.PgVersion);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStorageSizeBytes, model.StorageSizeBytes);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Projects::ProjectRetrieveResponse
        {
            ID = "id",
            Branches =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsDefault = true,
                    Name = "name",
                    Status = "status",
                },
            ],
            ComputeTimeSeconds = 0,
            ConnectionHost = "connectionHost",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Databases =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    OwnerName = "ownerName",
                },
            ],
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    EnvVarName = "envVarName",
                    Name = "name",
                    Type = Projects::Type.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = Projects::ProjectRetrieveResponseStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Projects::ProjectRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Projects::ProjectRetrieveResponse
        {
            ID = "id",
            Branches =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsDefault = true,
                    Name = "name",
                    Status = "status",
                },
            ],
            ComputeTimeSeconds = 0,
            ConnectionHost = "connectionHost",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Databases =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    OwnerName = "ownerName",
                },
            ],
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    EnvVarName = "envVarName",
                    Name = "name",
                    Type = Projects::Type.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = Projects::ProjectRetrieveResponseStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Projects::ProjectRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<Projects::Branch> expectedBranches =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsDefault = true,
                Name = "name",
                Status = "status",
            },
        ];
        double expectedComputeTimeSeconds = 0;
        string expectedConnectionHost = "connectionHost";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Projects::ProjectRetrieveResponseDatabase> expectedDatabases =
        [
            new()
            {
                ID = "id",
                Name = "name",
                OwnerName = "ownerName",
            },
        ];
        List<Projects::LinkedDeployment> expectedLinkedDeployments =
        [
            new()
            {
                ID = "id",
                EnvVarName = "envVarName",
                Name = "name",
                Type = Projects::Type.Thurgood,
                Url = "url",
            },
        ];
        string expectedName = "name";
        long expectedPgVersion = 0;
        string expectedRegion = "region";
        ApiEnum<string, Projects::ProjectRetrieveResponseStatus> expectedStatus =
            Projects::ProjectRetrieveResponseStatus.Active;
        double expectedStorageSizeBytes = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBranches.Count, deserialized.Branches.Count);
        for (int i = 0; i < expectedBranches.Count; i++)
        {
            Assert.Equal(expectedBranches[i], deserialized.Branches[i]);
        }
        Assert.Equal(expectedComputeTimeSeconds, deserialized.ComputeTimeSeconds);
        Assert.Equal(expectedConnectionHost, deserialized.ConnectionHost);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDatabases.Count, deserialized.Databases.Count);
        for (int i = 0; i < expectedDatabases.Count; i++)
        {
            Assert.Equal(expectedDatabases[i], deserialized.Databases[i]);
        }
        Assert.Equal(expectedLinkedDeployments.Count, deserialized.LinkedDeployments.Count);
        for (int i = 0; i < expectedLinkedDeployments.Count; i++)
        {
            Assert.Equal(expectedLinkedDeployments[i], deserialized.LinkedDeployments[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPgVersion, deserialized.PgVersion);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStorageSizeBytes, deserialized.StorageSizeBytes);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Projects::ProjectRetrieveResponse
        {
            ID = "id",
            Branches =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsDefault = true,
                    Name = "name",
                    Status = "status",
                },
            ],
            ComputeTimeSeconds = 0,
            ConnectionHost = "connectionHost",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Databases =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    OwnerName = "ownerName",
                },
            ],
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    EnvVarName = "envVarName",
                    Name = "name",
                    Type = Projects::Type.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = Projects::ProjectRetrieveResponseStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Projects::ProjectRetrieveResponse
        {
            ID = "id",
            Branches =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsDefault = true,
                    Name = "name",
                    Status = "status",
                },
            ],
            ComputeTimeSeconds = 0,
            ConnectionHost = "connectionHost",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Databases =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    OwnerName = "ownerName",
                },
            ],
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    EnvVarName = "envVarName",
                    Name = "name",
                    Type = Projects::Type.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = Projects::ProjectRetrieveResponseStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Projects::ProjectRetrieveResponse
        {
            ID = "id",
            Branches =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsDefault = true,
                    Name = "name",
                    Status = "status",
                },
            ],
            ComputeTimeSeconds = 0,
            ConnectionHost = "connectionHost",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Databases =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    OwnerName = "ownerName",
                },
            ],
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    EnvVarName = "envVarName",
                    Name = "name",
                    Type = Projects::Type.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = Projects::ProjectRetrieveResponseStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Projects::ProjectRetrieveResponse
        {
            ID = "id",
            Branches =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsDefault = true,
                    Name = "name",
                    Status = "status",
                },
            ],
            ComputeTimeSeconds = 0,
            ConnectionHost = "connectionHost",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Databases =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    OwnerName = "ownerName",
                },
            ],
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    EnvVarName = "envVarName",
                    Name = "name",
                    Type = Projects::Type.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = Projects::ProjectRetrieveResponseStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Projects::ProjectRetrieveResponse
        {
            ID = "id",
            Branches =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsDefault = true,
                    Name = "name",
                    Status = "status",
                },
            ],
            ComputeTimeSeconds = 0,
            ConnectionHost = "connectionHost",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Databases =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    OwnerName = "ownerName",
                },
            ],
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    EnvVarName = "envVarName",
                    Name = "name",
                    Type = Projects::Type.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = Projects::ProjectRetrieveResponseStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Projects::ProjectRetrieveResponse
        {
            ID = "id",
            Branches =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsDefault = true,
                    Name = "name",
                    Status = "status",
                },
            ],
            ComputeTimeSeconds = 0,
            ConnectionHost = "connectionHost",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Databases =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    OwnerName = "ownerName",
                },
            ],
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    EnvVarName = "envVarName",
                    Name = "name",
                    Type = Projects::Type.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = Projects::ProjectRetrieveResponseStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        Projects::ProjectRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BranchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Projects::Branch
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsDefault = true,
            Name = "name",
            Status = "status",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsDefault = true;
        string expectedName = "name";
        string expectedStatus = "status";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsDefault, model.IsDefault);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Projects::Branch
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsDefault = true,
            Name = "name",
            Status = "status",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Projects::Branch>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Projects::Branch
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsDefault = true,
            Name = "name",
            Status = "status",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Projects::Branch>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsDefault = true;
        string expectedName = "name";
        string expectedStatus = "status";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsDefault, deserialized.IsDefault);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Projects::Branch
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsDefault = true,
            Name = "name",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Projects::Branch { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("isDefault"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Projects::Branch { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Projects::Branch
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            IsDefault = null,
            Name = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("isDefault"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Projects::Branch
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            IsDefault = null,
            Name = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Projects::Branch
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsDefault = true,
            Name = "name",
            Status = "status",
        };

        Projects::Branch copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProjectRetrieveResponseDatabaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Projects::ProjectRetrieveResponseDatabase
        {
            ID = "id",
            Name = "name",
            OwnerName = "ownerName",
        };

        string expectedID = "id";
        string expectedName = "name";
        string expectedOwnerName = "ownerName";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOwnerName, model.OwnerName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Projects::ProjectRetrieveResponseDatabase
        {
            ID = "id",
            Name = "name",
            OwnerName = "ownerName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Projects::ProjectRetrieveResponseDatabase>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Projects::ProjectRetrieveResponseDatabase
        {
            ID = "id",
            Name = "name",
            OwnerName = "ownerName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Projects::ProjectRetrieveResponseDatabase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        string expectedOwnerName = "ownerName";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOwnerName, deserialized.OwnerName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Projects::ProjectRetrieveResponseDatabase
        {
            ID = "id",
            Name = "name",
            OwnerName = "ownerName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Projects::ProjectRetrieveResponseDatabase { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.OwnerName);
        Assert.False(model.RawData.ContainsKey("ownerName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Projects::ProjectRetrieveResponseDatabase { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Projects::ProjectRetrieveResponseDatabase
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
            OwnerName = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.OwnerName);
        Assert.False(model.RawData.ContainsKey("ownerName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Projects::ProjectRetrieveResponseDatabase
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
            OwnerName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Projects::ProjectRetrieveResponseDatabase
        {
            ID = "id",
            Name = "name",
            OwnerName = "ownerName",
        };

        Projects::ProjectRetrieveResponseDatabase copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LinkedDeploymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Projects::LinkedDeployment
        {
            ID = "id",
            EnvVarName = "envVarName",
            Name = "name",
            Type = Projects::Type.Thurgood,
            Url = "url",
        };

        string expectedID = "id";
        string expectedEnvVarName = "envVarName";
        string expectedName = "name";
        ApiEnum<string, Projects::Type> expectedType = Projects::Type.Thurgood;
        string expectedUrl = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEnvVarName, model.EnvVarName);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Projects::LinkedDeployment
        {
            ID = "id",
            EnvVarName = "envVarName",
            Name = "name",
            Type = Projects::Type.Thurgood,
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Projects::LinkedDeployment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Projects::LinkedDeployment
        {
            ID = "id",
            EnvVarName = "envVarName",
            Name = "name",
            Type = Projects::Type.Thurgood,
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Projects::LinkedDeployment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedEnvVarName = "envVarName";
        string expectedName = "name";
        ApiEnum<string, Projects::Type> expectedType = Projects::Type.Thurgood;
        string expectedUrl = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEnvVarName, deserialized.EnvVarName);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Projects::LinkedDeployment
        {
            ID = "id",
            EnvVarName = "envVarName",
            Name = "name",
            Type = Projects::Type.Thurgood,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Projects::LinkedDeployment { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.EnvVarName);
        Assert.False(model.RawData.ContainsKey("envVarName"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Projects::LinkedDeployment { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Projects::LinkedDeployment
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            EnvVarName = null,
            Name = null,
            Type = null,
            Url = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.EnvVarName);
        Assert.False(model.RawData.ContainsKey("envVarName"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Projects::LinkedDeployment
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            EnvVarName = null,
            Name = null,
            Type = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Projects::LinkedDeployment
        {
            ID = "id",
            EnvVarName = "envVarName",
            Name = "name",
            Type = Projects::Type.Thurgood,
            Url = "url",
        };

        Projects::LinkedDeployment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Projects::Type.Thurgood)]
    [InlineData(Projects::Type.Compute)]
    public void Validation_Works(Projects::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Projects::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Projects::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Projects::Type.Thurgood)]
    [InlineData(Projects::Type.Compute)]
    public void SerializationRoundtrip_Works(Projects::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Projects::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Projects::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Projects::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Projects::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProjectRetrieveResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(Projects::ProjectRetrieveResponseStatus.Active)]
    [InlineData(Projects::ProjectRetrieveResponseStatus.Suspended)]
    [InlineData(Projects::ProjectRetrieveResponseStatus.Deleted)]
    public void Validation_Works(Projects::ProjectRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Projects::ProjectRetrieveResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Projects::ProjectRetrieveResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Projects::ProjectRetrieveResponseStatus.Active)]
    [InlineData(Projects::ProjectRetrieveResponseStatus.Suspended)]
    [InlineData(Projects::ProjectRetrieveResponseStatus.Deleted)]
    public void SerializationRoundtrip_Works(Projects::ProjectRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Projects::ProjectRetrieveResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Projects::ProjectRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Projects::ProjectRetrieveResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Projects::ProjectRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
