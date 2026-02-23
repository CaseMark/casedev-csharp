using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Models.Applications.V1.Projects;

namespace Router.Tests.Models.Applications.V1.Projects;

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
                    CreatedAt = "createdAt",
                    Domains =
                    [
                        new()
                        {
                            ID = "id",
                            DomainValue = "domain",
                            IsPrimary = true,
                            IsVerified = true,
                        },
                    ],
                    Framework = "framework",
                    GitBranch = "gitBranch",
                    GitRepo = "gitRepo",
                    Name = "name",
                    Status = "status",
                    UpdatedAt = "updatedAt",
                    VercelProjectID = "vercelProjectId",
                },
            ],
        };

        List<Project> expectedProjects =
        [
            new()
            {
                ID = "id",
                CreatedAt = "createdAt",
                Domains =
                [
                    new()
                    {
                        ID = "id",
                        DomainValue = "domain",
                        IsPrimary = true,
                        IsVerified = true,
                    },
                ],
                Framework = "framework",
                GitBranch = "gitBranch",
                GitRepo = "gitRepo",
                Name = "name",
                Status = "status",
                UpdatedAt = "updatedAt",
                VercelProjectID = "vercelProjectId",
            },
        ];

        Assert.NotNull(model.Projects);
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
                    CreatedAt = "createdAt",
                    Domains =
                    [
                        new()
                        {
                            ID = "id",
                            DomainValue = "domain",
                            IsPrimary = true,
                            IsVerified = true,
                        },
                    ],
                    Framework = "framework",
                    GitBranch = "gitBranch",
                    GitRepo = "gitRepo",
                    Name = "name",
                    Status = "status",
                    UpdatedAt = "updatedAt",
                    VercelProjectID = "vercelProjectId",
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
                    CreatedAt = "createdAt",
                    Domains =
                    [
                        new()
                        {
                            ID = "id",
                            DomainValue = "domain",
                            IsPrimary = true,
                            IsVerified = true,
                        },
                    ],
                    Framework = "framework",
                    GitBranch = "gitBranch",
                    GitRepo = "gitRepo",
                    Name = "name",
                    Status = "status",
                    UpdatedAt = "updatedAt",
                    VercelProjectID = "vercelProjectId",
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
                CreatedAt = "createdAt",
                Domains =
                [
                    new()
                    {
                        ID = "id",
                        DomainValue = "domain",
                        IsPrimary = true,
                        IsVerified = true,
                    },
                ],
                Framework = "framework",
                GitBranch = "gitBranch",
                GitRepo = "gitRepo",
                Name = "name",
                Status = "status",
                UpdatedAt = "updatedAt",
                VercelProjectID = "vercelProjectId",
            },
        ];

        Assert.NotNull(deserialized.Projects);
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
                    CreatedAt = "createdAt",
                    Domains =
                    [
                        new()
                        {
                            ID = "id",
                            DomainValue = "domain",
                            IsPrimary = true,
                            IsVerified = true,
                        },
                    ],
                    Framework = "framework",
                    GitBranch = "gitBranch",
                    GitRepo = "gitRepo",
                    Name = "name",
                    Status = "status",
                    UpdatedAt = "updatedAt",
                    VercelProjectID = "vercelProjectId",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProjectListResponse { };

        Assert.Null(model.Projects);
        Assert.False(model.RawData.ContainsKey("projects"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProjectListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProjectListResponse
        {
            // Null should be interpreted as omitted for these properties
            Projects = null,
        };

        Assert.Null(model.Projects);
        Assert.False(model.RawData.ContainsKey("projects"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProjectListResponse
        {
            // Null should be interpreted as omitted for these properties
            Projects = null,
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
                    CreatedAt = "createdAt",
                    Domains =
                    [
                        new()
                        {
                            ID = "id",
                            DomainValue = "domain",
                            IsPrimary = true,
                            IsVerified = true,
                        },
                    ],
                    Framework = "framework",
                    GitBranch = "gitBranch",
                    GitRepo = "gitRepo",
                    Name = "name",
                    Status = "status",
                    UpdatedAt = "updatedAt",
                    VercelProjectID = "vercelProjectId",
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
            CreatedAt = "createdAt",
            Domains =
            [
                new()
                {
                    ID = "id",
                    DomainValue = "domain",
                    IsPrimary = true,
                    IsVerified = true,
                },
            ],
            Framework = "framework",
            GitBranch = "gitBranch",
            GitRepo = "gitRepo",
            Name = "name",
            Status = "status",
            UpdatedAt = "updatedAt",
            VercelProjectID = "vercelProjectId",
        };

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        List<Domain> expectedDomains =
        [
            new()
            {
                ID = "id",
                DomainValue = "domain",
                IsPrimary = true,
                IsVerified = true,
            },
        ];
        string expectedFramework = "framework";
        string expectedGitBranch = "gitBranch";
        string expectedGitRepo = "gitRepo";
        string expectedName = "name";
        string expectedStatus = "status";
        string expectedUpdatedAt = "updatedAt";
        string expectedVercelProjectID = "vercelProjectId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Domains);
        Assert.Equal(expectedDomains.Count, model.Domains.Count);
        for (int i = 0; i < expectedDomains.Count; i++)
        {
            Assert.Equal(expectedDomains[i], model.Domains[i]);
        }
        Assert.Equal(expectedFramework, model.Framework);
        Assert.Equal(expectedGitBranch, model.GitBranch);
        Assert.Equal(expectedGitRepo, model.GitRepo);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVercelProjectID, model.VercelProjectID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Project
        {
            ID = "id",
            CreatedAt = "createdAt",
            Domains =
            [
                new()
                {
                    ID = "id",
                    DomainValue = "domain",
                    IsPrimary = true,
                    IsVerified = true,
                },
            ],
            Framework = "framework",
            GitBranch = "gitBranch",
            GitRepo = "gitRepo",
            Name = "name",
            Status = "status",
            UpdatedAt = "updatedAt",
            VercelProjectID = "vercelProjectId",
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
            CreatedAt = "createdAt",
            Domains =
            [
                new()
                {
                    ID = "id",
                    DomainValue = "domain",
                    IsPrimary = true,
                    IsVerified = true,
                },
            ],
            Framework = "framework",
            GitBranch = "gitBranch",
            GitRepo = "gitRepo",
            Name = "name",
            Status = "status",
            UpdatedAt = "updatedAt",
            VercelProjectID = "vercelProjectId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Project>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        List<Domain> expectedDomains =
        [
            new()
            {
                ID = "id",
                DomainValue = "domain",
                IsPrimary = true,
                IsVerified = true,
            },
        ];
        string expectedFramework = "framework";
        string expectedGitBranch = "gitBranch";
        string expectedGitRepo = "gitRepo";
        string expectedName = "name";
        string expectedStatus = "status";
        string expectedUpdatedAt = "updatedAt";
        string expectedVercelProjectID = "vercelProjectId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Domains);
        Assert.Equal(expectedDomains.Count, deserialized.Domains.Count);
        for (int i = 0; i < expectedDomains.Count; i++)
        {
            Assert.Equal(expectedDomains[i], deserialized.Domains[i]);
        }
        Assert.Equal(expectedFramework, deserialized.Framework);
        Assert.Equal(expectedGitBranch, deserialized.GitBranch);
        Assert.Equal(expectedGitRepo, deserialized.GitRepo);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVercelProjectID, deserialized.VercelProjectID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Project
        {
            ID = "id",
            CreatedAt = "createdAt",
            Domains =
            [
                new()
                {
                    ID = "id",
                    DomainValue = "domain",
                    IsPrimary = true,
                    IsVerified = true,
                },
            ],
            Framework = "framework",
            GitBranch = "gitBranch",
            GitRepo = "gitRepo",
            Name = "name",
            Status = "status",
            UpdatedAt = "updatedAt",
            VercelProjectID = "vercelProjectId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Project { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Domains);
        Assert.False(model.RawData.ContainsKey("domains"));
        Assert.Null(model.Framework);
        Assert.False(model.RawData.ContainsKey("framework"));
        Assert.Null(model.GitBranch);
        Assert.False(model.RawData.ContainsKey("gitBranch"));
        Assert.Null(model.GitRepo);
        Assert.False(model.RawData.ContainsKey("gitRepo"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.VercelProjectID);
        Assert.False(model.RawData.ContainsKey("vercelProjectId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Project { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Project
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Domains = null,
            Framework = null,
            GitBranch = null,
            GitRepo = null,
            Name = null,
            Status = null,
            UpdatedAt = null,
            VercelProjectID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Domains);
        Assert.False(model.RawData.ContainsKey("domains"));
        Assert.Null(model.Framework);
        Assert.False(model.RawData.ContainsKey("framework"));
        Assert.Null(model.GitBranch);
        Assert.False(model.RawData.ContainsKey("gitBranch"));
        Assert.Null(model.GitRepo);
        Assert.False(model.RawData.ContainsKey("gitRepo"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.VercelProjectID);
        Assert.False(model.RawData.ContainsKey("vercelProjectId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Project
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Domains = null,
            Framework = null,
            GitBranch = null,
            GitRepo = null,
            Name = null,
            Status = null,
            UpdatedAt = null,
            VercelProjectID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Project
        {
            ID = "id",
            CreatedAt = "createdAt",
            Domains =
            [
                new()
                {
                    ID = "id",
                    DomainValue = "domain",
                    IsPrimary = true,
                    IsVerified = true,
                },
            ],
            Framework = "framework",
            GitBranch = "gitBranch",
            GitRepo = "gitRepo",
            Name = "name",
            Status = "status",
            UpdatedAt = "updatedAt",
            VercelProjectID = "vercelProjectId",
        };

        Project copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DomainTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Domain
        {
            ID = "id",
            DomainValue = "domain",
            IsPrimary = true,
            IsVerified = true,
        };

        string expectedID = "id";
        string expectedDomainValue = "domain";
        bool expectedIsPrimary = true;
        bool expectedIsVerified = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDomainValue, model.DomainValue);
        Assert.Equal(expectedIsPrimary, model.IsPrimary);
        Assert.Equal(expectedIsVerified, model.IsVerified);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Domain
        {
            ID = "id",
            DomainValue = "domain",
            IsPrimary = true,
            IsVerified = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Domain>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Domain
        {
            ID = "id",
            DomainValue = "domain",
            IsPrimary = true,
            IsVerified = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Domain>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDomainValue = "domain";
        bool expectedIsPrimary = true;
        bool expectedIsVerified = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDomainValue, deserialized.DomainValue);
        Assert.Equal(expectedIsPrimary, deserialized.IsPrimary);
        Assert.Equal(expectedIsVerified, deserialized.IsVerified);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Domain
        {
            ID = "id",
            DomainValue = "domain",
            IsPrimary = true,
            IsVerified = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Domain { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.DomainValue);
        Assert.False(model.RawData.ContainsKey("domain"));
        Assert.Null(model.IsPrimary);
        Assert.False(model.RawData.ContainsKey("isPrimary"));
        Assert.Null(model.IsVerified);
        Assert.False(model.RawData.ContainsKey("isVerified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Domain { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Domain
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            DomainValue = null,
            IsPrimary = null,
            IsVerified = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.DomainValue);
        Assert.False(model.RawData.ContainsKey("domain"));
        Assert.Null(model.IsPrimary);
        Assert.False(model.RawData.ContainsKey("isPrimary"));
        Assert.Null(model.IsVerified);
        Assert.False(model.RawData.ContainsKey("isVerified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Domain
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            DomainValue = null,
            IsPrimary = null,
            IsVerified = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Domain
        {
            ID = "id",
            DomainValue = "domain",
            IsPrimary = true,
            IsVerified = true,
        };

        Domain copied = new(model);

        Assert.Equal(model, copied);
    }
}
