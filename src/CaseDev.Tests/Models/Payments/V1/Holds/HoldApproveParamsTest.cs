using System;
using CaseDev.Models.Payments.V1.Holds;

namespace CaseDev.Tests.Models.Payments.V1.Holds;

public class HoldApproveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new HoldApproveParams { ID = "id", ApproverID = "approver_id" };

        string expectedID = "id";
        string expectedApproverID = "approver_id";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedApproverID, parameters.ApproverID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new HoldApproveParams { ID = "id" };

        Assert.Null(parameters.ApproverID);
        Assert.False(parameters.RawBodyData.ContainsKey("approver_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new HoldApproveParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            ApproverID = null,
        };

        Assert.Null(parameters.ApproverID);
        Assert.False(parameters.RawBodyData.ContainsKey("approver_id"));
    }

    [Fact]
    public void Url_Works()
    {
        HoldApproveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/payments/v1/holds/id/approve"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new HoldApproveParams { ID = "id", ApproverID = "approver_id" };

        HoldApproveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
