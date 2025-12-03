using System;
using System.Text.Json;
using CaseDev.Models.Compute.V1;

namespace CaseDev.Tests.Models.Compute.V1;

public class V1DeployResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1DeployResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deploymentId",
            Environment = "environment",
            Runtime = "runtime",
            Status = "status",
            URL = "url",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeploymentID = "deploymentId";
        string expectedEnvironment = "environment";
        string expectedRuntime = "runtime";
        string expectedStatus = "status";
        string expectedURL = "url";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeploymentID, model.DeploymentID);
        Assert.Equal(expectedEnvironment, model.Environment);
        Assert.Equal(expectedRuntime, model.Runtime);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedURL, model.URL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1DeployResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deploymentId",
            Environment = "environment",
            Runtime = "runtime",
            Status = "status",
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1DeployResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1DeployResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deploymentId",
            Environment = "environment",
            Runtime = "runtime",
            Status = "status",
            URL = "url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1DeployResponse>(json);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeploymentID = "deploymentId";
        string expectedEnvironment = "environment";
        string expectedRuntime = "runtime";
        string expectedStatus = "status";
        string expectedURL = "url";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeploymentID, deserialized.DeploymentID);
        Assert.Equal(expectedEnvironment, deserialized.Environment);
        Assert.Equal(expectedRuntime, deserialized.Runtime);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedURL, deserialized.URL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1DeployResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deploymentId",
            Environment = "environment",
            Runtime = "runtime",
            Status = "status",
            URL = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1DeployResponse { };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DeploymentID);
        Assert.False(model.RawData.ContainsKey("deploymentId"));
        Assert.Null(model.Environment);
        Assert.False(model.RawData.ContainsKey("environment"));
        Assert.Null(model.Runtime);
        Assert.False(model.RawData.ContainsKey("runtime"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.URL);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1DeployResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1DeployResponse
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            DeploymentID = null,
            Environment = null,
            Runtime = null,
            Status = null,
            URL = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DeploymentID);
        Assert.False(model.RawData.ContainsKey("deploymentId"));
        Assert.Null(model.Environment);
        Assert.False(model.RawData.ContainsKey("environment"));
        Assert.Null(model.Runtime);
        Assert.False(model.RawData.ContainsKey("runtime"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.URL);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1DeployResponse
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            DeploymentID = null,
            Environment = null,
            Runtime = null,
            Status = null,
            URL = null,
        };

        model.Validate();
    }
}
