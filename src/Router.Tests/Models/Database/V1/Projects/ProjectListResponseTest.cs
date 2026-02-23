using System;
using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Database.V1.Projects;

namespace Router.Tests.Models.Database.V1.Projects;

public class ProjectListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProjectListResponse
        {
            Projects =
            [
                new()
                {
                    ID = "id",
                    ComputeTimeSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    LinkedDeployments =
                    [
                        new()
                        {
                            ID = "id",
                            Name = "name",
                            Type = ProjectLinkedDeploymentType.Thurgood,
                            Url = "url",
                        },
                    ],
                    Name = "name",
                    PgVersion = 0,
                    Region = "region",
                    Status = ProjectStatus.Active,
                    StorageSizeBytes = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<Project> expectedProjects =
        [
            new()
            {
                ID = "id",
                ComputeTimeSeconds = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                LinkedDeployments =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Type = ProjectLinkedDeploymentType.Thurgood,
                        Url = "url",
                    },
                ],
                Name = "name",
                PgVersion = 0,
                Region = "region",
                Status = ProjectStatus.Active,
                StorageSizeBytes = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedProjects.Count, model.Projects.Count);
        for (int i = 0; i < expectedProjects.Count; i++)
        {
            Assert.Equal(expectedProjects[i], model.Projects[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProjectListResponse
        {
            Projects =
            [
                new()
                {
                    ID = "id",
                    ComputeTimeSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    LinkedDeployments =
                    [
                        new()
                        {
                            ID = "id",
                            Name = "name",
                            Type = ProjectLinkedDeploymentType.Thurgood,
                            Url = "url",
                        },
                    ],
                    Name = "name",
                    PgVersion = 0,
                    Region = "region",
                    Status = ProjectStatus.Active,
                    StorageSizeBytes = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProjectListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProjectListResponse
        {
            Projects =
            [
                new()
                {
                    ID = "id",
                    ComputeTimeSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    LinkedDeployments =
                    [
                        new()
                        {
                            ID = "id",
                            Name = "name",
                            Type = ProjectLinkedDeploymentType.Thurgood,
                            Url = "url",
                        },
                    ],
                    Name = "name",
                    PgVersion = 0,
                    Region = "region",
                    Status = ProjectStatus.Active,
                    StorageSizeBytes = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProjectListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Project> expectedProjects =
        [
            new()
            {
                ID = "id",
                ComputeTimeSeconds = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                LinkedDeployments =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Type = ProjectLinkedDeploymentType.Thurgood,
                        Url = "url",
                    },
                ],
                Name = "name",
                PgVersion = 0,
                Region = "region",
                Status = ProjectStatus.Active,
                StorageSizeBytes = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedProjects.Count, deserialized.Projects.Count);
        for (int i = 0; i < expectedProjects.Count; i++)
        {
            Assert.Equal(expectedProjects[i], deserialized.Projects[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProjectListResponse
        {
            Projects =
            [
                new()
                {
                    ID = "id",
                    ComputeTimeSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    LinkedDeployments =
                    [
                        new()
                        {
                            ID = "id",
                            Name = "name",
                            Type = ProjectLinkedDeploymentType.Thurgood,
                            Url = "url",
                        },
                    ],
                    Name = "name",
                    PgVersion = 0,
                    Region = "region",
                    Status = ProjectStatus.Active,
                    StorageSizeBytes = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProjectListResponse
        {
            Projects =
            [
                new()
                {
                    ID = "id",
                    ComputeTimeSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    LinkedDeployments =
                    [
                        new()
                        {
                            ID = "id",
                            Name = "name",
                            Type = ProjectLinkedDeploymentType.Thurgood,
                            Url = "url",
                        },
                    ],
                    Name = "name",
                    PgVersion = 0,
                    Region = "region",
                    Status = ProjectStatus.Active,
                    StorageSizeBytes = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        ProjectListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Project
        {
            ID = "id",
            ComputeTimeSeconds = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Type = ProjectLinkedDeploymentType.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = ProjectStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        double expectedComputeTimeSeconds = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        List<ProjectLinkedDeployment> expectedLinkedDeployments =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Type = ProjectLinkedDeploymentType.Thurgood,
                Url = "url",
            },
        ];
        string expectedName = "name";
        long expectedPgVersion = 0;
        string expectedRegion = "region";
        ApiEnum<string, ProjectStatus> expectedStatus = ProjectStatus.Active;
        double expectedStorageSizeBytes = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedComputeTimeSeconds, model.ComputeTimeSeconds);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.LinkedDeployments);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Project
        {
            ID = "id",
            ComputeTimeSeconds = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Type = ProjectLinkedDeploymentType.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = ProjectStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Project>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Project
        {
            ID = "id",
            ComputeTimeSeconds = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Type = ProjectLinkedDeploymentType.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = ProjectStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Project>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedComputeTimeSeconds = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        List<ProjectLinkedDeployment> expectedLinkedDeployments =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Type = ProjectLinkedDeploymentType.Thurgood,
                Url = "url",
            },
        ];
        string expectedName = "name";
        long expectedPgVersion = 0;
        string expectedRegion = "region";
        ApiEnum<string, ProjectStatus> expectedStatus = ProjectStatus.Active;
        double expectedStorageSizeBytes = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedComputeTimeSeconds, deserialized.ComputeTimeSeconds);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.LinkedDeployments);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Project
        {
            ID = "id",
            ComputeTimeSeconds = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Type = ProjectLinkedDeploymentType.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = ProjectStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Project { Description = "description" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ComputeTimeSeconds);
        Assert.False(model.RawData.ContainsKey("computeTimeSeconds"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.LinkedDeployments);
        Assert.False(model.RawData.ContainsKey("linkedDeployments"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PgVersion);
        Assert.False(model.RawData.ContainsKey("pgVersion"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.StorageSizeBytes);
        Assert.False(model.RawData.ContainsKey("storageSizeBytes"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Project { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Project
        {
            Description = "description",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ComputeTimeSeconds = null,
            CreatedAt = null,
            LinkedDeployments = null,
            Name = null,
            PgVersion = null,
            Region = null,
            Status = null,
            StorageSizeBytes = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ComputeTimeSeconds);
        Assert.False(model.RawData.ContainsKey("computeTimeSeconds"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.LinkedDeployments);
        Assert.False(model.RawData.ContainsKey("linkedDeployments"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PgVersion);
        Assert.False(model.RawData.ContainsKey("pgVersion"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.StorageSizeBytes);
        Assert.False(model.RawData.ContainsKey("storageSizeBytes"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Project
        {
            Description = "description",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ComputeTimeSeconds = null,
            CreatedAt = null,
            LinkedDeployments = null,
            Name = null,
            PgVersion = null,
            Region = null,
            Status = null,
            StorageSizeBytes = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Project
        {
            ID = "id",
            ComputeTimeSeconds = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Type = ProjectLinkedDeploymentType.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = ProjectStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Project
        {
            ID = "id",
            ComputeTimeSeconds = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Type = ProjectLinkedDeploymentType.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = ProjectStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Project
        {
            ID = "id",
            ComputeTimeSeconds = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Type = ProjectLinkedDeploymentType.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = ProjectStatus.Active,
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
        var model = new Project
        {
            ID = "id",
            ComputeTimeSeconds = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Type = ProjectLinkedDeploymentType.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = ProjectStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Project
        {
            ID = "id",
            ComputeTimeSeconds = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LinkedDeployments =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Type = ProjectLinkedDeploymentType.Thurgood,
                    Url = "url",
                },
            ],
            Name = "name",
            PgVersion = 0,
            Region = "region",
            Status = ProjectStatus.Active,
            StorageSizeBytes = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Project copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProjectLinkedDeploymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProjectLinkedDeployment
        {
            ID = "id",
            Name = "name",
            Type = ProjectLinkedDeploymentType.Thurgood,
            Url = "url",
        };

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, ProjectLinkedDeploymentType> expectedType =
            ProjectLinkedDeploymentType.Thurgood;
        string expectedUrl = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProjectLinkedDeployment
        {
            ID = "id",
            Name = "name",
            Type = ProjectLinkedDeploymentType.Thurgood,
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProjectLinkedDeployment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProjectLinkedDeployment
        {
            ID = "id",
            Name = "name",
            Type = ProjectLinkedDeploymentType.Thurgood,
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProjectLinkedDeployment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, ProjectLinkedDeploymentType> expectedType =
            ProjectLinkedDeploymentType.Thurgood;
        string expectedUrl = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProjectLinkedDeployment
        {
            ID = "id",
            Name = "name",
            Type = ProjectLinkedDeploymentType.Thurgood,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProjectLinkedDeployment { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
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
        var model = new ProjectLinkedDeployment { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProjectLinkedDeployment
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
            Type = null,
            Url = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
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
        var model = new ProjectLinkedDeployment
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
            Type = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProjectLinkedDeployment
        {
            ID = "id",
            Name = "name",
            Type = ProjectLinkedDeploymentType.Thurgood,
            Url = "url",
        };

        ProjectLinkedDeployment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProjectLinkedDeploymentTypeTest : TestBase
{
    [Theory]
    [InlineData(ProjectLinkedDeploymentType.Thurgood)]
    [InlineData(ProjectLinkedDeploymentType.Compute)]
    public void Validation_Works(ProjectLinkedDeploymentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectLinkedDeploymentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectLinkedDeploymentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProjectLinkedDeploymentType.Thurgood)]
    [InlineData(ProjectLinkedDeploymentType.Compute)]
    public void SerializationRoundtrip_Works(ProjectLinkedDeploymentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectLinkedDeploymentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProjectLinkedDeploymentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectLinkedDeploymentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProjectLinkedDeploymentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProjectStatusTest : TestBase
{
    [Theory]
    [InlineData(ProjectStatus.Active)]
    [InlineData(ProjectStatus.Suspended)]
    [InlineData(ProjectStatus.Deleted)]
    public void Validation_Works(ProjectStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProjectStatus.Active)]
    [InlineData(ProjectStatus.Suspended)]
    [InlineData(ProjectStatus.Deleted)]
    public void SerializationRoundtrip_Works(ProjectStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProjectStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProjectStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
