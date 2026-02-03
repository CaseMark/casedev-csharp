using System;
using CaseDev.Models.Payments.V1.Ledger;

namespace CaseDev.Tests.Models.Payments.V1.Ledger;

public class LedgerListTransactionsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LedgerListTransactionsParams
        {
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            Offset = 0,
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedLimit = 0;
        long expectedOffset = 0;
        string expectedReferenceID = "reference_id";
        string expectedReferenceType = "reference_type";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedReferenceID, parameters.ReferenceID);
        Assert.Equal(expectedReferenceType, parameters.ReferenceType);
        Assert.Equal(expectedStartDate, parameters.StartDate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LedgerListTransactionsParams { };

        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.ReferenceID);
        Assert.False(parameters.RawQueryData.ContainsKey("reference_id"));
        Assert.Null(parameters.ReferenceType);
        Assert.False(parameters.RawQueryData.ContainsKey("reference_type"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LedgerListTransactionsParams
        {
            // Null should be interpreted as omitted for these properties
            EndDate = null,
            Limit = null,
            Offset = null,
            ReferenceID = null,
            ReferenceType = null,
            StartDate = null,
        };

        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.ReferenceID);
        Assert.False(parameters.RawQueryData.ContainsKey("reference_id"));
        Assert.Null(parameters.ReferenceType);
        Assert.False(parameters.RawQueryData.ContainsKey("reference_type"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date"));
    }

    [Fact]
    public void Url_Works()
    {
        LedgerListTransactionsParams parameters = new()
        {
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            Offset = 0,
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/payments/v1/ledger/transactions?end_date=2019-12-27T18%3a11%3a19.117%2b00%3a00&limit=0&offset=0&reference_id=reference_id&reference_type=reference_type&start_date=2019-12-27T18%3a11%3a19.117%2b00%3a00"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LedgerListTransactionsParams
        {
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            Offset = 0,
            ReferenceID = "reference_id",
            ReferenceType = "reference_type",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        LedgerListTransactionsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
