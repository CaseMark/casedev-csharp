using System.Text.Json;
using Router.Core;
using Router.Models.Database.V1.Projects;

namespace Router.Tests.Models.Database.V1.Projects;

public class ProjectGetConnectionResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProjectGetConnectionResponse
        {
            Branch = "branch",
            ConnectionUri = "https://example.com",
            Pooled = true,
        };

        string expectedBranch = "branch";
        string expectedConnectionUri = "https://example.com";
        bool expectedPooled = true;

        Assert.Equal(expectedBranch, model.Branch);
        Assert.Equal(expectedConnectionUri, model.ConnectionUri);
        Assert.Equal(expectedPooled, model.Pooled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProjectGetConnectionResponse
        {
            Branch = "branch",
            ConnectionUri = "https://example.com",
            Pooled = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProjectGetConnectionResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProjectGetConnectionResponse
        {
            Branch = "branch",
            ConnectionUri = "https://example.com",
            Pooled = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProjectGetConnectionResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBranch = "branch";
        string expectedConnectionUri = "https://example.com";
        bool expectedPooled = true;

        Assert.Equal(expectedBranch, deserialized.Branch);
        Assert.Equal(expectedConnectionUri, deserialized.ConnectionUri);
        Assert.Equal(expectedPooled, deserialized.Pooled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProjectGetConnectionResponse
        {
            Branch = "branch",
            ConnectionUri = "https://example.com",
            Pooled = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProjectGetConnectionResponse
        {
            Branch = "branch",
            ConnectionUri = "https://example.com",
            Pooled = true,
        };

        ProjectGetConnectionResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
