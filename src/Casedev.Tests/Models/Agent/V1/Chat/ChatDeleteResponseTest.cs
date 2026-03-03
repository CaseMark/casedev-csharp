using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Agent.V1.Chat;

namespace Casedev.Tests.Models.Agent.V1.Chat;

public class ChatDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            SnapshotImageID = "snapshotImageId",
            Status = "status",
        };

        string expectedID = "id";
        double expectedCost = 0;
        long expectedRuntimeMs = 0;
        string expectedSnapshotImageID = "snapshotImageId";
        string expectedStatus = "status";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedRuntimeMs, model.RuntimeMs);
        Assert.Equal(expectedSnapshotImageID, model.SnapshotImageID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            SnapshotImageID = "snapshotImageId",
            Status = "status",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            SnapshotImageID = "snapshotImageId",
            Status = "status",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedCost = 0;
        long expectedRuntimeMs = 0;
        string expectedSnapshotImageID = "snapshotImageId";
        string expectedStatus = "status";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedRuntimeMs, deserialized.RuntimeMs);
        Assert.Equal(expectedSnapshotImageID, deserialized.SnapshotImageID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            SnapshotImageID = "snapshotImageId",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatDeleteResponse { SnapshotImageID = "snapshotImageId" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.RuntimeMs);
        Assert.False(model.RawData.ContainsKey("runtimeMs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatDeleteResponse { SnapshotImageID = "snapshotImageId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChatDeleteResponse
        {
            SnapshotImageID = "snapshotImageId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Cost = null,
            RuntimeMs = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.RuntimeMs);
        Assert.False(model.RawData.ContainsKey("runtimeMs"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatDeleteResponse
        {
            SnapshotImageID = "snapshotImageId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Cost = null,
            RuntimeMs = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            Status = "status",
        };

        Assert.Null(model.SnapshotImageID);
        Assert.False(model.RawData.ContainsKey("snapshotImageId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            Status = "status",

            SnapshotImageID = null,
        };

        Assert.Null(model.SnapshotImageID);
        Assert.True(model.RawData.ContainsKey("snapshotImageId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            Status = "status",

            SnapshotImageID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatDeleteResponse
        {
            ID = "id",
            Cost = 0,
            RuntimeMs = 0,
            SnapshotImageID = "snapshotImageId",
            Status = "status",
        };

        ChatDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
