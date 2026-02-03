using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Projects.V1;

namespace CaseDev.Tests.Models.Projects.V1;

public class V1ListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1ListResponse
        {
            Projects =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    Framework = "framework",
                    Name = "name",
                    Slug = "slug",
                    SourceType = ProjectSourceType.GitHub,
                },
            ],
        };

        List<Project> expectedProjects =
        [
            new()
            {
                ID = "id",
                CreatedAt = "createdAt",
                Framework = "framework",
                Name = "name",
                Slug = "slug",
                SourceType = ProjectSourceType.GitHub,
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
        var model = new V1ListResponse
        {
            Projects =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    Framework = "framework",
                    Name = "name",
                    Slug = "slug",
                    SourceType = ProjectSourceType.GitHub,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1ListResponse
        {
            Projects =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    Framework = "framework",
                    Name = "name",
                    Slug = "slug",
                    SourceType = ProjectSourceType.GitHub,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1ListResponse>(
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
                Framework = "framework",
                Name = "name",
                Slug = "slug",
                SourceType = ProjectSourceType.GitHub,
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
        var model = new V1ListResponse
        {
            Projects =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    Framework = "framework",
                    Name = "name",
                    Slug = "slug",
                    SourceType = ProjectSourceType.GitHub,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1ListResponse { };

        Assert.Null(model.Projects);
        Assert.False(model.RawData.ContainsKey("projects"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1ListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1ListResponse
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
        var model = new V1ListResponse
        {
            // Null should be interpreted as omitted for these properties
            Projects = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1ListResponse
        {
            Projects =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    Framework = "framework",
                    Name = "name",
                    Slug = "slug",
                    SourceType = ProjectSourceType.GitHub,
                },
            ],
        };

        V1ListResponse copied = new(model);

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
            Framework = "framework",
            Name = "name",
            Slug = "slug",
            SourceType = ProjectSourceType.GitHub,
        };

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedFramework = "framework";
        string expectedName = "name";
        string expectedSlug = "slug";
        ApiEnum<string, ProjectSourceType> expectedSourceType = ProjectSourceType.GitHub;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFramework, model.Framework);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSlug, model.Slug);
        Assert.Equal(expectedSourceType, model.SourceType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Project
        {
            ID = "id",
            CreatedAt = "createdAt",
            Framework = "framework",
            Name = "name",
            Slug = "slug",
            SourceType = ProjectSourceType.GitHub,
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
            Framework = "framework",
            Name = "name",
            Slug = "slug",
            SourceType = ProjectSourceType.GitHub,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Project>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedFramework = "framework";
        string expectedName = "name";
        string expectedSlug = "slug";
        ApiEnum<string, ProjectSourceType> expectedSourceType = ProjectSourceType.GitHub;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFramework, deserialized.Framework);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSlug, deserialized.Slug);
        Assert.Equal(expectedSourceType, deserialized.SourceType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Project
        {
            ID = "id",
            CreatedAt = "createdAt",
            Framework = "framework",
            Name = "name",
            Slug = "slug",
            SourceType = ProjectSourceType.GitHub,
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
        Assert.Null(model.Framework);
        Assert.False(model.RawData.ContainsKey("framework"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.SourceType);
        Assert.False(model.RawData.ContainsKey("sourceType"));
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
            Framework = null,
            Name = null,
            Slug = null,
            SourceType = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Framework);
        Assert.False(model.RawData.ContainsKey("framework"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
        Assert.Null(model.SourceType);
        Assert.False(model.RawData.ContainsKey("sourceType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Project
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Framework = null,
            Name = null,
            Slug = null,
            SourceType = null,
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
            Framework = "framework",
            Name = "name",
            Slug = "slug",
            SourceType = ProjectSourceType.GitHub,
        };

        Project copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProjectSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(ProjectSourceType.GitHub)]
    [InlineData(ProjectSourceType.Thurgood)]
    public void Validation_Works(ProjectSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProjectSourceType.GitHub)]
    [InlineData(ProjectSourceType.Thurgood)]
    public void SerializationRoundtrip_Works(ProjectSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProjectSourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProjectSourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProjectSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProjectSourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
