using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Vault.Graphrag;

namespace Casedev.Tests.Models.Vault.Graphrag;

public class GraphragInitResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GraphragInitResponse
        {
            Message = "message",
            Status = "status",
            Success = true,
            VaultID = "vault_id",
        };

        string expectedMessage = "message";
        string expectedStatus = "status";
        bool expectedSuccess = true;
        string expectedVaultID = "vault_id";

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GraphragInitResponse
        {
            Message = "message",
            Status = "status",
            Success = true,
            VaultID = "vault_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GraphragInitResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GraphragInitResponse
        {
            Message = "message",
            Status = "status",
            Success = true,
            VaultID = "vault_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GraphragInitResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        string expectedStatus = "status";
        bool expectedSuccess = true;
        string expectedVaultID = "vault_id";

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GraphragInitResponse
        {
            Message = "message",
            Status = "status",
            Success = true,
            VaultID = "vault_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GraphragInitResponse { };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GraphragInitResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GraphragInitResponse
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Status = null,
            Success = null,
            VaultID = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
        Assert.Null(model.VaultID);
        Assert.False(model.RawData.ContainsKey("vault_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GraphragInitResponse
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Status = null,
            Success = null,
            VaultID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GraphragInitResponse
        {
            Message = "message",
            Status = "status",
            Success = true,
            VaultID = "vault_id",
        };

        GraphragInitResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
