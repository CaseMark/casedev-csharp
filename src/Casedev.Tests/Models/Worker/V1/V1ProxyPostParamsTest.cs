using System;
using Casedev.Models.Worker.V1;

namespace Casedev.Tests.Models.Worker.V1;

public class V1ProxyPostParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ProxyPostParams { ID = "id", WorkerPath = "workerPath" };

        string expectedID = "id";
        string expectedWorkerPath = "workerPath";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedWorkerPath, parameters.WorkerPath);
    }

    [Fact]
    public void Url_Works()
    {
        V1ProxyPostParams parameters = new() { ID = "id", WorkerPath = "workerPath" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.case.dev/worker/v1/id/workerPath"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1ProxyPostParams { ID = "id", WorkerPath = "workerPath" };

        V1ProxyPostParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
