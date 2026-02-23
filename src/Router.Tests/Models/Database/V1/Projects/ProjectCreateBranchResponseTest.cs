using System;
using System.Text.Json;
using Router.Core;
using Router.Models.Database.V1.Projects;

namespace Router.Tests.Models.Database.V1.Projects;

public class ProjectCreateBranchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProjectCreateBranchResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsDefault = true,
            Name = "name",
            ParentBranchID = "parentBranchId",
            Status = "status",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsDefault = true;
        string expectedName = "name";
        string expectedParentBranchID = "parentBranchId";
        string expectedStatus = "status";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsDefault, model.IsDefault);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedParentBranchID, model.ParentBranchID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProjectCreateBranchResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsDefault = true,
            Name = "name",
            ParentBranchID = "parentBranchId",
            Status = "status",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProjectCreateBranchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProjectCreateBranchResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsDefault = true,
            Name = "name",
            ParentBranchID = "parentBranchId",
            Status = "status",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProjectCreateBranchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsDefault = true;
        string expectedName = "name";
        string expectedParentBranchID = "parentBranchId";
        string expectedStatus = "status";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsDefault, deserialized.IsDefault);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedParentBranchID, deserialized.ParentBranchID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProjectCreateBranchResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsDefault = true,
            Name = "name",
            ParentBranchID = "parentBranchId",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProjectCreateBranchResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsDefault = true,
            Name = "name",
            ParentBranchID = "parentBranchId",
            Status = "status",
        };

        ProjectCreateBranchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
