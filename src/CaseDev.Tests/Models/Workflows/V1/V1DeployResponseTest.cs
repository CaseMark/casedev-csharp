using System.Text.Json;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Tests.Models.Workflows.V1;

public class V1DeployResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1DeployResponse
        {
            Message = "message",
            StateMachineArn = "stateMachineArn",
            Success = true,
            WebhookSecret = "webhookSecret",
            WebhookUrl = "webhookUrl",
        };

        string expectedMessage = "message";
        string expectedStateMachineArn = "stateMachineArn";
        bool expectedSuccess = true;
        string expectedWebhookSecret = "webhookSecret";
        string expectedWebhookUrl = "webhookUrl";

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStateMachineArn, model.StateMachineArn);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedWebhookSecret, model.WebhookSecret);
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1DeployResponse
        {
            Message = "message",
            StateMachineArn = "stateMachineArn",
            Success = true,
            WebhookSecret = "webhookSecret",
            WebhookUrl = "webhookUrl",
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
            Message = "message",
            StateMachineArn = "stateMachineArn",
            Success = true,
            WebhookSecret = "webhookSecret",
            WebhookUrl = "webhookUrl",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<V1DeployResponse>(element);
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        string expectedStateMachineArn = "stateMachineArn";
        bool expectedSuccess = true;
        string expectedWebhookSecret = "webhookSecret";
        string expectedWebhookUrl = "webhookUrl";

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedStateMachineArn, deserialized.StateMachineArn);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedWebhookSecret, deserialized.WebhookSecret);
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1DeployResponse
        {
            Message = "message",
            StateMachineArn = "stateMachineArn",
            Success = true,
            WebhookSecret = "webhookSecret",
            WebhookUrl = "webhookUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1DeployResponse { };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.StateMachineArn);
        Assert.False(model.RawData.ContainsKey("stateMachineArn"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
        Assert.Null(model.WebhookSecret);
        Assert.False(model.RawData.ContainsKey("webhookSecret"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhookUrl"));
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
            Message = null,
            StateMachineArn = null,
            Success = null,
            WebhookSecret = null,
            WebhookUrl = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.StateMachineArn);
        Assert.False(model.RawData.ContainsKey("stateMachineArn"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
        Assert.Null(model.WebhookSecret);
        Assert.False(model.RawData.ContainsKey("webhookSecret"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1DeployResponse
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            StateMachineArn = null,
            Success = null,
            WebhookSecret = null,
            WebhookUrl = null,
        };

        model.Validate();
    }
}
