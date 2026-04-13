using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Agent.V2.Chat;

namespace Casedev.Tests.Models.Agent.V2.Chat;

public class ChatCreateStreamTokenResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCreateStreamTokenResponse
        {
            Token = "token",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StreamUrl = "https://example.com",
        };

        string expectedToken = "token";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStreamUrl = "https://example.com";

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedStreamUrl, model.StreamUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCreateStreamTokenResponse
        {
            Token = "token",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StreamUrl = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCreateStreamTokenResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCreateStreamTokenResponse
        {
            Token = "token",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StreamUrl = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCreateStreamTokenResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "token";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStreamUrl = "https://example.com";

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedStreamUrl, deserialized.StreamUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCreateStreamTokenResponse
        {
            Token = "token",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StreamUrl = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCreateStreamTokenResponse
        {
            Token = "token",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StreamUrl = "https://example.com",
        };

        ChatCreateStreamTokenResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
