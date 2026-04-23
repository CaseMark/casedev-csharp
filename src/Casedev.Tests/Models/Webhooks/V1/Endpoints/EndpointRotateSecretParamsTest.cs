using System;
using Casedev.Models.Webhooks.V1.Endpoints;

namespace Casedev.Tests.Models.Webhooks.V1.Endpoints;

public class EndpointRotateSecretParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EndpointRotateSecretParams
        {
            ID = "id",
            PreviousSecretExpiresInSec = 0,
        };

        string expectedID = "id";
        long expectedPreviousSecretExpiresInSec = 0;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedPreviousSecretExpiresInSec, parameters.PreviousSecretExpiresInSec);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EndpointRotateSecretParams { ID = "id" };

        Assert.Null(parameters.PreviousSecretExpiresInSec);
        Assert.False(parameters.RawBodyData.ContainsKey("previousSecretExpiresInSec"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EndpointRotateSecretParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            PreviousSecretExpiresInSec = null,
        };

        Assert.Null(parameters.PreviousSecretExpiresInSec);
        Assert.False(parameters.RawBodyData.ContainsKey("previousSecretExpiresInSec"));
    }

    [Fact]
    public void Url_Works()
    {
        EndpointRotateSecretParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.case.dev/webhooks/v1/endpoints/id/rotate_secret"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EndpointRotateSecretParams
        {
            ID = "id",
            PreviousSecretExpiresInSec = 0,
        };

        EndpointRotateSecretParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
