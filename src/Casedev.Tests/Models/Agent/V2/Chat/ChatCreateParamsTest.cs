using System;
using System.Collections.Generic;
using Casedev.Models.Agent.V2.Chat;

namespace Casedev.Tests.Models.Agent.V2.Chat;

public class ChatCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatCreateParams
        {
            IdleTimeoutMs = 0,
            Model = "model",
            Title = "title",
            VaultIds = ["string"],
        };

        long expectedIdleTimeoutMs = 0;
        string expectedModel = "model";
        string expectedTitle = "title";
        List<string> expectedVaultIds = ["string"];

        Assert.Equal(expectedIdleTimeoutMs, parameters.IdleTimeoutMs);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.NotNull(parameters.VaultIds);
        Assert.Equal(expectedVaultIds.Count, parameters.VaultIds.Count);
        for (int i = 0; i < expectedVaultIds.Count; i++)
        {
            Assert.Equal(expectedVaultIds[i], parameters.VaultIds[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChatCreateParams
        {
            IdleTimeoutMs = 0,
            Model = "model",
            VaultIds = ["string"],
        };

        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChatCreateParams
        {
            IdleTimeoutMs = 0,
            Model = "model",
            VaultIds = ["string"],

            // Null should be interpreted as omitted for these properties
            Title = null,
        };

        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChatCreateParams { Title = "title" };

        Assert.Null(parameters.IdleTimeoutMs);
        Assert.False(parameters.RawBodyData.ContainsKey("idleTimeoutMs"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ChatCreateParams
        {
            Title = "title",

            IdleTimeoutMs = null,
            Model = null,
            VaultIds = null,
        };

        Assert.Null(parameters.IdleTimeoutMs);
        Assert.True(parameters.RawBodyData.ContainsKey("idleTimeoutMs"));
        Assert.Null(parameters.Model);
        Assert.True(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.VaultIds);
        Assert.True(parameters.RawBodyData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void Url_Works()
    {
        ChatCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/agent/v2/chat"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatCreateParams
        {
            IdleTimeoutMs = 0,
            Model = "model",
            Title = "title",
            VaultIds = ["string"],
        };

        ChatCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
