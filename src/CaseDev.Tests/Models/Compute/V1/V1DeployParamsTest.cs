using System.Collections.Generic;
using CaseDev.Core;
using CaseDev.Models.Compute.V1;

namespace CaseDev.Tests.Models.Compute.V1;

public class ConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Config
        {
            AddPython = "addPython",
            AllowNetwork = true,
            Cmd = ["string"],
            Concurrency = 0,
            CPUCount = 0,
            CronSchedule = "cronSchedule",
            Dependencies = ["string"],
            Entrypoint = ["string"],
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            GPUCount = 0,
            GPUType = GPUType.CPU,
            IsWebService = true,
            MemoryMB = 0,
            PipInstall = ["string"],
            Port = 0,
            PythonVersion = "pythonVersion",
            Retries = 0,
            SecretGroups = ["string"],
            TimeoutSeconds = 0,
            UseUv = true,
            WarmInstances = 0,
            Workdir = "workdir",
        };

        string expectedAddPython = "addPython";
        bool expectedAllowNetwork = true;
        List<string> expectedCmd = ["string"];
        long expectedConcurrency = 0;
        long expectedCPUCount = 0;
        string expectedCronSchedule = "cronSchedule";
        List<string> expectedDependencies = ["string"];
        List<string> expectedEntrypoint = ["string"];
        Dictionary<string, string> expectedEnv = new() { { "foo", "string" } };
        long expectedGPUCount = 0;
        ApiEnum<string, GPUType> expectedGPUType = GPUType.CPU;
        bool expectedIsWebService = true;
        long expectedMemoryMB = 0;
        List<string> expectedPipInstall = ["string"];
        long expectedPort = 0;
        string expectedPythonVersion = "pythonVersion";
        long expectedRetries = 0;
        List<string> expectedSecretGroups = ["string"];
        long expectedTimeoutSeconds = 0;
        bool expectedUseUv = true;
        long expectedWarmInstances = 0;
        string expectedWorkdir = "workdir";

        Assert.Equal(expectedAddPython, model.AddPython);
        Assert.Equal(expectedAllowNetwork, model.AllowNetwork);
        Assert.Equal(expectedCmd.Count, model.Cmd.Count);
        for (int i = 0; i < expectedCmd.Count; i++)
        {
            Assert.Equal(expectedCmd[i], model.Cmd[i]);
        }
        Assert.Equal(expectedConcurrency, model.Concurrency);
        Assert.Equal(expectedCPUCount, model.CPUCount);
        Assert.Equal(expectedCronSchedule, model.CronSchedule);
        Assert.Equal(expectedDependencies.Count, model.Dependencies.Count);
        for (int i = 0; i < expectedDependencies.Count; i++)
        {
            Assert.Equal(expectedDependencies[i], model.Dependencies[i]);
        }
        Assert.Equal(expectedEntrypoint.Count, model.Entrypoint.Count);
        for (int i = 0; i < expectedEntrypoint.Count; i++)
        {
            Assert.Equal(expectedEntrypoint[i], model.Entrypoint[i]);
        }
        Assert.Equal(expectedEnv.Count, model.Env.Count);
        foreach (var item in expectedEnv)
        {
            Assert.True(model.Env.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Env[item.Key]);
        }
        Assert.Equal(expectedGPUCount, model.GPUCount);
        Assert.Equal(expectedGPUType, model.GPUType);
        Assert.Equal(expectedIsWebService, model.IsWebService);
        Assert.Equal(expectedMemoryMB, model.MemoryMB);
        Assert.Equal(expectedPipInstall.Count, model.PipInstall.Count);
        for (int i = 0; i < expectedPipInstall.Count; i++)
        {
            Assert.Equal(expectedPipInstall[i], model.PipInstall[i]);
        }
        Assert.Equal(expectedPort, model.Port);
        Assert.Equal(expectedPythonVersion, model.PythonVersion);
        Assert.Equal(expectedRetries, model.Retries);
        Assert.Equal(expectedSecretGroups.Count, model.SecretGroups.Count);
        for (int i = 0; i < expectedSecretGroups.Count; i++)
        {
            Assert.Equal(expectedSecretGroups[i], model.SecretGroups[i]);
        }
        Assert.Equal(expectedTimeoutSeconds, model.TimeoutSeconds);
        Assert.Equal(expectedUseUv, model.UseUv);
        Assert.Equal(expectedWarmInstances, model.WarmInstances);
        Assert.Equal(expectedWorkdir, model.Workdir);
    }
}
