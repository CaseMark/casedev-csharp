using System;
using Casedev.Models.Matters.V1;

namespace Casedev.Tests.Models.Matters.V1;

public class V1ListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1ListParams
        {
            MatterType = "matter_type",
            PracticeArea = "practice_area",
            Query = "query",
            Status = "status",
        };

        string expectedMatterType = "matter_type";
        string expectedPracticeArea = "practice_area";
        string expectedQuery = "query";
        string expectedStatus = "status";

        Assert.Equal(expectedMatterType, parameters.MatterType);
        Assert.Equal(expectedPracticeArea, parameters.PracticeArea);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1ListParams { };

        Assert.Null(parameters.MatterType);
        Assert.False(parameters.RawQueryData.ContainsKey("matter_type"));
        Assert.Null(parameters.PracticeArea);
        Assert.False(parameters.RawQueryData.ContainsKey("practice_area"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawQueryData.ContainsKey("query"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1ListParams
        {
            // Null should be interpreted as omitted for these properties
            MatterType = null,
            PracticeArea = null,
            Query = null,
            Status = null,
        };

        Assert.Null(parameters.MatterType);
        Assert.False(parameters.RawQueryData.ContainsKey("matter_type"));
        Assert.Null(parameters.PracticeArea);
        Assert.False(parameters.RawQueryData.ContainsKey("practice_area"));
        Assert.Null(parameters.Query);
        Assert.False(parameters.RawQueryData.ContainsKey("query"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        V1ListParams parameters = new()
        {
            MatterType = "matter_type",
            PracticeArea = "practice_area",
            Query = "query",
            Status = "status",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.case.dev/matters/v1?matter_type=matter_type&practice_area=practice_area&query=query&status=status"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1ListParams
        {
            MatterType = "matter_type",
            PracticeArea = "practice_area",
            Query = "query",
            Status = "status",
        };

        V1ListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
