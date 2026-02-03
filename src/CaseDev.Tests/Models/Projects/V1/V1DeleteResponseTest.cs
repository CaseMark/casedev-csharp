using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Projects.V1;

namespace CaseDev.Tests.Models.Projects.V1;

public class V1DeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1DeleteResponse
        {
            ID = "id",
            DeploymentsDeleted = 0,
            Message = "message",
            ResourcesDeleted = new()
            {
                Bundles = 0,
                CodeBuild = 0,
                RoutingEntries = 0,
                S3Sources = 0,
            },
            Status = "status",
        };

        string expectedID = "id";
        double expectedDeploymentsDeleted = 0;
        string expectedMessage = "message";
        ResourcesDeleted expectedResourcesDeleted = new()
        {
            Bundles = 0,
            CodeBuild = 0,
            RoutingEntries = 0,
            S3Sources = 0,
        };
        string expectedStatus = "status";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDeploymentsDeleted, model.DeploymentsDeleted);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedResourcesDeleted, model.ResourcesDeleted);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1DeleteResponse
        {
            ID = "id",
            DeploymentsDeleted = 0,
            Message = "message",
            ResourcesDeleted = new()
            {
                Bundles = 0,
                CodeBuild = 0,
                RoutingEntries = 0,
                S3Sources = 0,
            },
            Status = "status",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1DeleteResponse
        {
            ID = "id",
            DeploymentsDeleted = 0,
            Message = "message",
            ResourcesDeleted = new()
            {
                Bundles = 0,
                CodeBuild = 0,
                RoutingEntries = 0,
                S3Sources = 0,
            },
            Status = "status",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedDeploymentsDeleted = 0;
        string expectedMessage = "message";
        ResourcesDeleted expectedResourcesDeleted = new()
        {
            Bundles = 0,
            CodeBuild = 0,
            RoutingEntries = 0,
            S3Sources = 0,
        };
        string expectedStatus = "status";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDeploymentsDeleted, deserialized.DeploymentsDeleted);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedResourcesDeleted, deserialized.ResourcesDeleted);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1DeleteResponse
        {
            ID = "id",
            DeploymentsDeleted = 0,
            Message = "message",
            ResourcesDeleted = new()
            {
                Bundles = 0,
                CodeBuild = 0,
                RoutingEntries = 0,
                S3Sources = 0,
            },
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1DeleteResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.DeploymentsDeleted);
        Assert.False(model.RawData.ContainsKey("deploymentsDeleted"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.ResourcesDeleted);
        Assert.False(model.RawData.ContainsKey("resourcesDeleted"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1DeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1DeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            DeploymentsDeleted = null,
            Message = null,
            ResourcesDeleted = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.DeploymentsDeleted);
        Assert.False(model.RawData.ContainsKey("deploymentsDeleted"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.ResourcesDeleted);
        Assert.False(model.RawData.ContainsKey("resourcesDeleted"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1DeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            DeploymentsDeleted = null,
            Message = null,
            ResourcesDeleted = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1DeleteResponse
        {
            ID = "id",
            DeploymentsDeleted = 0,
            Message = "message",
            ResourcesDeleted = new()
            {
                Bundles = 0,
                CodeBuild = 0,
                RoutingEntries = 0,
                S3Sources = 0,
            },
            Status = "status",
        };

        V1DeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResourcesDeletedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResourcesDeleted
        {
            Bundles = 0,
            CodeBuild = 0,
            RoutingEntries = 0,
            S3Sources = 0,
        };

        double expectedBundles = 0;
        double expectedCodeBuild = 0;
        double expectedRoutingEntries = 0;
        double expectedS3Sources = 0;

        Assert.Equal(expectedBundles, model.Bundles);
        Assert.Equal(expectedCodeBuild, model.CodeBuild);
        Assert.Equal(expectedRoutingEntries, model.RoutingEntries);
        Assert.Equal(expectedS3Sources, model.S3Sources);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResourcesDeleted
        {
            Bundles = 0,
            CodeBuild = 0,
            RoutingEntries = 0,
            S3Sources = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourcesDeleted>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResourcesDeleted
        {
            Bundles = 0,
            CodeBuild = 0,
            RoutingEntries = 0,
            S3Sources = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourcesDeleted>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBundles = 0;
        double expectedCodeBuild = 0;
        double expectedRoutingEntries = 0;
        double expectedS3Sources = 0;

        Assert.Equal(expectedBundles, deserialized.Bundles);
        Assert.Equal(expectedCodeBuild, deserialized.CodeBuild);
        Assert.Equal(expectedRoutingEntries, deserialized.RoutingEntries);
        Assert.Equal(expectedS3Sources, deserialized.S3Sources);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ResourcesDeleted
        {
            Bundles = 0,
            CodeBuild = 0,
            RoutingEntries = 0,
            S3Sources = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ResourcesDeleted { };

        Assert.Null(model.Bundles);
        Assert.False(model.RawData.ContainsKey("bundles"));
        Assert.Null(model.CodeBuild);
        Assert.False(model.RawData.ContainsKey("codeBuild"));
        Assert.Null(model.RoutingEntries);
        Assert.False(model.RawData.ContainsKey("routingEntries"));
        Assert.Null(model.S3Sources);
        Assert.False(model.RawData.ContainsKey("s3Sources"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ResourcesDeleted { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ResourcesDeleted
        {
            // Null should be interpreted as omitted for these properties
            Bundles = null,
            CodeBuild = null,
            RoutingEntries = null,
            S3Sources = null,
        };

        Assert.Null(model.Bundles);
        Assert.False(model.RawData.ContainsKey("bundles"));
        Assert.Null(model.CodeBuild);
        Assert.False(model.RawData.ContainsKey("codeBuild"));
        Assert.Null(model.RoutingEntries);
        Assert.False(model.RawData.ContainsKey("routingEntries"));
        Assert.Null(model.S3Sources);
        Assert.False(model.RawData.ContainsKey("s3Sources"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ResourcesDeleted
        {
            // Null should be interpreted as omitted for these properties
            Bundles = null,
            CodeBuild = null,
            RoutingEntries = null,
            S3Sources = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ResourcesDeleted
        {
            Bundles = 0,
            CodeBuild = 0,
            RoutingEntries = 0,
            S3Sources = 0,
        };

        ResourcesDeleted copied = new(model);

        Assert.Equal(model, copied);
    }
}
