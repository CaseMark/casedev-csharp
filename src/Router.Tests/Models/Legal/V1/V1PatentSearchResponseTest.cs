using System.Collections.Generic;
using System.Text.Json;
using Router.Core;
using Router.Models.Legal.V1;

namespace Router.Tests.Models.Legal.V1;

public class V1PatentSearchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1PatentSearchResponse
        {
            Limit = 0,
            Offset = 0,
            Query = "query",
            Results =
            [
                new()
                {
                    ApplicationNumber = "applicationNumber",
                    ApplicationType = "applicationType",
                    Assignees = ["string"],
                    EntityStatus = "entityStatus",
                    FilingDate = "2019-12-27",
                    GrantDate = "2019-12-27",
                    Inventors = ["string"],
                    PatentNumber = "patentNumber",
                    Status = "status",
                    Title = "title",
                },
            ],
            TotalResults = 0,
        };

        long expectedLimit = 0;
        long expectedOffset = 0;
        string expectedQuery = "query";
        List<Result> expectedResults =
        [
            new()
            {
                ApplicationNumber = "applicationNumber",
                ApplicationType = "applicationType",
                Assignees = ["string"],
                EntityStatus = "entityStatus",
                FilingDate = "2019-12-27",
                GrantDate = "2019-12-27",
                Inventors = ["string"],
                PatentNumber = "patentNumber",
                Status = "status",
                Title = "title",
            },
        ];
        long expectedTotalResults = 0;

        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedOffset, model.Offset);
        Assert.Equal(expectedQuery, model.Query);
        Assert.NotNull(model.Results);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
        Assert.Equal(expectedTotalResults, model.TotalResults);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1PatentSearchResponse
        {
            Limit = 0,
            Offset = 0,
            Query = "query",
            Results =
            [
                new()
                {
                    ApplicationNumber = "applicationNumber",
                    ApplicationType = "applicationType",
                    Assignees = ["string"],
                    EntityStatus = "entityStatus",
                    FilingDate = "2019-12-27",
                    GrantDate = "2019-12-27",
                    Inventors = ["string"],
                    PatentNumber = "patentNumber",
                    Status = "status",
                    Title = "title",
                },
            ],
            TotalResults = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1PatentSearchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1PatentSearchResponse
        {
            Limit = 0,
            Offset = 0,
            Query = "query",
            Results =
            [
                new()
                {
                    ApplicationNumber = "applicationNumber",
                    ApplicationType = "applicationType",
                    Assignees = ["string"],
                    EntityStatus = "entityStatus",
                    FilingDate = "2019-12-27",
                    GrantDate = "2019-12-27",
                    Inventors = ["string"],
                    PatentNumber = "patentNumber",
                    Status = "status",
                    Title = "title",
                },
            ],
            TotalResults = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1PatentSearchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedLimit = 0;
        long expectedOffset = 0;
        string expectedQuery = "query";
        List<Result> expectedResults =
        [
            new()
            {
                ApplicationNumber = "applicationNumber",
                ApplicationType = "applicationType",
                Assignees = ["string"],
                EntityStatus = "entityStatus",
                FilingDate = "2019-12-27",
                GrantDate = "2019-12-27",
                Inventors = ["string"],
                PatentNumber = "patentNumber",
                Status = "status",
                Title = "title",
            },
        ];
        long expectedTotalResults = 0;

        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedOffset, deserialized.Offset);
        Assert.Equal(expectedQuery, deserialized.Query);
        Assert.NotNull(deserialized.Results);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
        Assert.Equal(expectedTotalResults, deserialized.TotalResults);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1PatentSearchResponse
        {
            Limit = 0,
            Offset = 0,
            Query = "query",
            Results =
            [
                new()
                {
                    ApplicationNumber = "applicationNumber",
                    ApplicationType = "applicationType",
                    Assignees = ["string"],
                    EntityStatus = "entityStatus",
                    FilingDate = "2019-12-27",
                    GrantDate = "2019-12-27",
                    Inventors = ["string"],
                    PatentNumber = "patentNumber",
                    Status = "status",
                    Title = "title",
                },
            ],
            TotalResults = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1PatentSearchResponse { };

        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Offset);
        Assert.False(model.RawData.ContainsKey("offset"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
        Assert.Null(model.TotalResults);
        Assert.False(model.RawData.ContainsKey("totalResults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1PatentSearchResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1PatentSearchResponse
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
            Query = null,
            Results = null,
            TotalResults = null,
        };

        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Offset);
        Assert.False(model.RawData.ContainsKey("offset"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
        Assert.Null(model.TotalResults);
        Assert.False(model.RawData.ContainsKey("totalResults"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1PatentSearchResponse
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
            Query = null,
            Results = null,
            TotalResults = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1PatentSearchResponse
        {
            Limit = 0,
            Offset = 0,
            Query = "query",
            Results =
            [
                new()
                {
                    ApplicationNumber = "applicationNumber",
                    ApplicationType = "applicationType",
                    Assignees = ["string"],
                    EntityStatus = "entityStatus",
                    FilingDate = "2019-12-27",
                    GrantDate = "2019-12-27",
                    Inventors = ["string"],
                    PatentNumber = "patentNumber",
                    Status = "status",
                    Title = "title",
                },
            ],
            TotalResults = 0,
        };

        V1PatentSearchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            ApplicationNumber = "applicationNumber",
            ApplicationType = "applicationType",
            Assignees = ["string"],
            EntityStatus = "entityStatus",
            FilingDate = "2019-12-27",
            GrantDate = "2019-12-27",
            Inventors = ["string"],
            PatentNumber = "patentNumber",
            Status = "status",
            Title = "title",
        };

        string expectedApplicationNumber = "applicationNumber";
        string expectedApplicationType = "applicationType";
        List<string> expectedAssignees = ["string"];
        string expectedEntityStatus = "entityStatus";
        string expectedFilingDate = "2019-12-27";
        string expectedGrantDate = "2019-12-27";
        List<string> expectedInventors = ["string"];
        string expectedPatentNumber = "patentNumber";
        string expectedStatus = "status";
        string expectedTitle = "title";

        Assert.Equal(expectedApplicationNumber, model.ApplicationNumber);
        Assert.Equal(expectedApplicationType, model.ApplicationType);
        Assert.NotNull(model.Assignees);
        Assert.Equal(expectedAssignees.Count, model.Assignees.Count);
        for (int i = 0; i < expectedAssignees.Count; i++)
        {
            Assert.Equal(expectedAssignees[i], model.Assignees[i]);
        }
        Assert.Equal(expectedEntityStatus, model.EntityStatus);
        Assert.Equal(expectedFilingDate, model.FilingDate);
        Assert.Equal(expectedGrantDate, model.GrantDate);
        Assert.NotNull(model.Inventors);
        Assert.Equal(expectedInventors.Count, model.Inventors.Count);
        for (int i = 0; i < expectedInventors.Count; i++)
        {
            Assert.Equal(expectedInventors[i], model.Inventors[i]);
        }
        Assert.Equal(expectedPatentNumber, model.PatentNumber);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            ApplicationNumber = "applicationNumber",
            ApplicationType = "applicationType",
            Assignees = ["string"],
            EntityStatus = "entityStatus",
            FilingDate = "2019-12-27",
            GrantDate = "2019-12-27",
            Inventors = ["string"],
            PatentNumber = "patentNumber",
            Status = "status",
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            ApplicationNumber = "applicationNumber",
            ApplicationType = "applicationType",
            Assignees = ["string"],
            EntityStatus = "entityStatus",
            FilingDate = "2019-12-27",
            GrantDate = "2019-12-27",
            Inventors = ["string"],
            PatentNumber = "patentNumber",
            Status = "status",
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedApplicationNumber = "applicationNumber";
        string expectedApplicationType = "applicationType";
        List<string> expectedAssignees = ["string"];
        string expectedEntityStatus = "entityStatus";
        string expectedFilingDate = "2019-12-27";
        string expectedGrantDate = "2019-12-27";
        List<string> expectedInventors = ["string"];
        string expectedPatentNumber = "patentNumber";
        string expectedStatus = "status";
        string expectedTitle = "title";

        Assert.Equal(expectedApplicationNumber, deserialized.ApplicationNumber);
        Assert.Equal(expectedApplicationType, deserialized.ApplicationType);
        Assert.NotNull(deserialized.Assignees);
        Assert.Equal(expectedAssignees.Count, deserialized.Assignees.Count);
        for (int i = 0; i < expectedAssignees.Count; i++)
        {
            Assert.Equal(expectedAssignees[i], deserialized.Assignees[i]);
        }
        Assert.Equal(expectedEntityStatus, deserialized.EntityStatus);
        Assert.Equal(expectedFilingDate, deserialized.FilingDate);
        Assert.Equal(expectedGrantDate, deserialized.GrantDate);
        Assert.NotNull(deserialized.Inventors);
        Assert.Equal(expectedInventors.Count, deserialized.Inventors.Count);
        for (int i = 0; i < expectedInventors.Count; i++)
        {
            Assert.Equal(expectedInventors[i], deserialized.Inventors[i]);
        }
        Assert.Equal(expectedPatentNumber, deserialized.PatentNumber);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            ApplicationNumber = "applicationNumber",
            ApplicationType = "applicationType",
            Assignees = ["string"],
            EntityStatus = "entityStatus",
            FilingDate = "2019-12-27",
            GrantDate = "2019-12-27",
            Inventors = ["string"],
            PatentNumber = "patentNumber",
            Status = "status",
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result
        {
            EntityStatus = "entityStatus",
            FilingDate = "2019-12-27",
            GrantDate = "2019-12-27",
            PatentNumber = "patentNumber",
        };

        Assert.Null(model.ApplicationNumber);
        Assert.False(model.RawData.ContainsKey("applicationNumber"));
        Assert.Null(model.ApplicationType);
        Assert.False(model.RawData.ContainsKey("applicationType"));
        Assert.Null(model.Assignees);
        Assert.False(model.RawData.ContainsKey("assignees"));
        Assert.Null(model.Inventors);
        Assert.False(model.RawData.ContainsKey("inventors"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result
        {
            EntityStatus = "entityStatus",
            FilingDate = "2019-12-27",
            GrantDate = "2019-12-27",
            PatentNumber = "patentNumber",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Result
        {
            EntityStatus = "entityStatus",
            FilingDate = "2019-12-27",
            GrantDate = "2019-12-27",
            PatentNumber = "patentNumber",

            // Null should be interpreted as omitted for these properties
            ApplicationNumber = null,
            ApplicationType = null,
            Assignees = null,
            Inventors = null,
            Status = null,
            Title = null,
        };

        Assert.Null(model.ApplicationNumber);
        Assert.False(model.RawData.ContainsKey("applicationNumber"));
        Assert.Null(model.ApplicationType);
        Assert.False(model.RawData.ContainsKey("applicationType"));
        Assert.Null(model.Assignees);
        Assert.False(model.RawData.ContainsKey("assignees"));
        Assert.Null(model.Inventors);
        Assert.False(model.RawData.ContainsKey("inventors"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            EntityStatus = "entityStatus",
            FilingDate = "2019-12-27",
            GrantDate = "2019-12-27",
            PatentNumber = "patentNumber",

            // Null should be interpreted as omitted for these properties
            ApplicationNumber = null,
            ApplicationType = null,
            Assignees = null,
            Inventors = null,
            Status = null,
            Title = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result
        {
            ApplicationNumber = "applicationNumber",
            ApplicationType = "applicationType",
            Assignees = ["string"],
            Inventors = ["string"],
            Status = "status",
            Title = "title",
        };

        Assert.Null(model.EntityStatus);
        Assert.False(model.RawData.ContainsKey("entityStatus"));
        Assert.Null(model.FilingDate);
        Assert.False(model.RawData.ContainsKey("filingDate"));
        Assert.Null(model.GrantDate);
        Assert.False(model.RawData.ContainsKey("grantDate"));
        Assert.Null(model.PatentNumber);
        Assert.False(model.RawData.ContainsKey("patentNumber"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result
        {
            ApplicationNumber = "applicationNumber",
            ApplicationType = "applicationType",
            Assignees = ["string"],
            Inventors = ["string"],
            Status = "status",
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Result
        {
            ApplicationNumber = "applicationNumber",
            ApplicationType = "applicationType",
            Assignees = ["string"],
            Inventors = ["string"],
            Status = "status",
            Title = "title",

            EntityStatus = null,
            FilingDate = null,
            GrantDate = null,
            PatentNumber = null,
        };

        Assert.Null(model.EntityStatus);
        Assert.True(model.RawData.ContainsKey("entityStatus"));
        Assert.Null(model.FilingDate);
        Assert.True(model.RawData.ContainsKey("filingDate"));
        Assert.Null(model.GrantDate);
        Assert.True(model.RawData.ContainsKey("grantDate"));
        Assert.Null(model.PatentNumber);
        Assert.True(model.RawData.ContainsKey("patentNumber"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            ApplicationNumber = "applicationNumber",
            ApplicationType = "applicationType",
            Assignees = ["string"],
            Inventors = ["string"],
            Status = "status",
            Title = "title",

            EntityStatus = null,
            FilingDate = null,
            GrantDate = null,
            PatentNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Result
        {
            ApplicationNumber = "applicationNumber",
            ApplicationType = "applicationType",
            Assignees = ["string"],
            EntityStatus = "entityStatus",
            FilingDate = "2019-12-27",
            GrantDate = "2019-12-27",
            Inventors = ["string"],
            PatentNumber = "patentNumber",
            Status = "status",
            Title = "title",
        };

        Result copied = new(model);

        Assert.Equal(model, copied);
    }
}
