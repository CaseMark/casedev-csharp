using System;
using System.Collections.Generic;
using Router.Models.Compute.V1.Instances;

namespace Router.Tests.Models.Compute.V1.Instances;

public class InstanceCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InstanceCreateParams
        {
            InstanceType = "gpu_1x_a10",
            Name = "ocr-batch-job",
            Region = "us-west-1",
            AutoShutdownMinutes = 120,
            VaultIds = ["vault_abc123"],
        };

        string expectedInstanceType = "gpu_1x_a10";
        string expectedName = "ocr-batch-job";
        string expectedRegion = "us-west-1";
        long expectedAutoShutdownMinutes = 120;
        List<string> expectedVaultIds = ["vault_abc123"];

        Assert.Equal(expectedInstanceType, parameters.InstanceType);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedRegion, parameters.Region);
        Assert.Equal(expectedAutoShutdownMinutes, parameters.AutoShutdownMinutes);
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
        var parameters = new InstanceCreateParams
        {
            InstanceType = "gpu_1x_a10",
            Name = "ocr-batch-job",
            Region = "us-west-1",
            AutoShutdownMinutes = 120,
        };

        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InstanceCreateParams
        {
            InstanceType = "gpu_1x_a10",
            Name = "ocr-batch-job",
            Region = "us-west-1",
            AutoShutdownMinutes = 120,

            // Null should be interpreted as omitted for these properties
            VaultIds = null,
        };

        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vaultIds"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InstanceCreateParams
        {
            InstanceType = "gpu_1x_a10",
            Name = "ocr-batch-job",
            Region = "us-west-1",
            VaultIds = ["vault_abc123"],
        };

        Assert.Null(parameters.AutoShutdownMinutes);
        Assert.False(parameters.RawBodyData.ContainsKey("autoShutdownMinutes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new InstanceCreateParams
        {
            InstanceType = "gpu_1x_a10",
            Name = "ocr-batch-job",
            Region = "us-west-1",
            VaultIds = ["vault_abc123"],

            AutoShutdownMinutes = null,
        };

        Assert.Null(parameters.AutoShutdownMinutes);
        Assert.True(parameters.RawBodyData.ContainsKey("autoShutdownMinutes"));
    }

    [Fact]
    public void Url_Works()
    {
        InstanceCreateParams parameters = new()
        {
            InstanceType = "gpu_1x_a10",
            Name = "ocr-batch-job",
            Region = "us-west-1",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/compute/v1/instances"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InstanceCreateParams
        {
            InstanceType = "gpu_1x_a10",
            Name = "ocr-batch-job",
            Region = "us-west-1",
            AutoShutdownMinutes = 120,
            VaultIds = ["vault_abc123"],
        };

        InstanceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
