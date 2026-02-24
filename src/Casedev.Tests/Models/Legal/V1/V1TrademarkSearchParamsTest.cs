using System;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1TrademarkSearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1TrademarkSearchParams
        {
            RegistrationNumber = "registrationNumber",
            SerialNumber = "serialNumber",
        };

        string expectedRegistrationNumber = "registrationNumber";
        string expectedSerialNumber = "serialNumber";

        Assert.Equal(expectedRegistrationNumber, parameters.RegistrationNumber);
        Assert.Equal(expectedSerialNumber, parameters.SerialNumber);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1TrademarkSearchParams { };

        Assert.Null(parameters.RegistrationNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("registrationNumber"));
        Assert.Null(parameters.SerialNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("serialNumber"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1TrademarkSearchParams
        {
            // Null should be interpreted as omitted for these properties
            RegistrationNumber = null,
            SerialNumber = null,
        };

        Assert.Null(parameters.RegistrationNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("registrationNumber"));
        Assert.Null(parameters.SerialNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("serialNumber"));
    }

    [Fact]
    public void Url_Works()
    {
        V1TrademarkSearchParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/trademark-search"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1TrademarkSearchParams
        {
            RegistrationNumber = "registrationNumber",
            SerialNumber = "serialNumber",
        };

        V1TrademarkSearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
