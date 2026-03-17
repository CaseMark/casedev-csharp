using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1SecFilingResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1SecFilingResponse
        {
            Cik = "cik",
            DateAfter = "2019-12-27",
            DateBefore = "2019-12-27",
            Entity = "entity",
            Filings =
            [
                new()
                {
                    AccessionNumber = "accessionNumber",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            Description = "description",
                            Type = "type",
                            Url = "url",
                        },
                    ],
                    Entity = new()
                    {
                        Cik = "cik",
                        EntityType = "entityType",
                        Name = "name",
                        Sic = "sic",
                        SicDescription = "sicDescription",
                        StateOfIncorporation = "stateOfIncorporation",
                        Ticker = "ticker",
                    },
                    FiledAt = "2019-12-27",
                    FormType = "formType",
                    PeriodOfReport = "2019-12-27",
                    SecUrl = "secUrl",
                    Snippet = "snippet",
                },
            ],
            FormTypes = ["string"],
            Limit = 0,
            Offset = 0,
            Query = "query",
            Ticker = "ticker",
            Total = 0,
            Type = V1SecFilingResponseType.Search,
        };

        string expectedCik = "cik";
        string expectedDateAfter = "2019-12-27";
        string expectedDateBefore = "2019-12-27";
        string expectedEntity = "entity";
        List<Filing> expectedFilings =
        [
            new()
            {
                AccessionNumber = "accessionNumber",
                Description = "description",
                Documents =
                [
                    new()
                    {
                        Description = "description",
                        Type = "type",
                        Url = "url",
                    },
                ],
                Entity = new()
                {
                    Cik = "cik",
                    EntityType = "entityType",
                    Name = "name",
                    Sic = "sic",
                    SicDescription = "sicDescription",
                    StateOfIncorporation = "stateOfIncorporation",
                    Ticker = "ticker",
                },
                FiledAt = "2019-12-27",
                FormType = "formType",
                PeriodOfReport = "2019-12-27",
                SecUrl = "secUrl",
                Snippet = "snippet",
            },
        ];
        List<string> expectedFormTypes = ["string"];
        long expectedLimit = 0;
        long expectedOffset = 0;
        string expectedQuery = "query";
        string expectedTicker = "ticker";
        long expectedTotal = 0;
        ApiEnum<string, V1SecFilingResponseType> expectedType = V1SecFilingResponseType.Search;

        Assert.Equal(expectedCik, model.Cik);
        Assert.Equal(expectedDateAfter, model.DateAfter);
        Assert.Equal(expectedDateBefore, model.DateBefore);
        Assert.Equal(expectedEntity, model.Entity);
        Assert.NotNull(model.Filings);
        Assert.Equal(expectedFilings.Count, model.Filings.Count);
        for (int i = 0; i < expectedFilings.Count; i++)
        {
            Assert.Equal(expectedFilings[i], model.Filings[i]);
        }
        Assert.NotNull(model.FormTypes);
        Assert.Equal(expectedFormTypes.Count, model.FormTypes.Count);
        for (int i = 0; i < expectedFormTypes.Count; i++)
        {
            Assert.Equal(expectedFormTypes[i], model.FormTypes[i]);
        }
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedOffset, model.Offset);
        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedTicker, model.Ticker);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1SecFilingResponse
        {
            Cik = "cik",
            DateAfter = "2019-12-27",
            DateBefore = "2019-12-27",
            Entity = "entity",
            Filings =
            [
                new()
                {
                    AccessionNumber = "accessionNumber",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            Description = "description",
                            Type = "type",
                            Url = "url",
                        },
                    ],
                    Entity = new()
                    {
                        Cik = "cik",
                        EntityType = "entityType",
                        Name = "name",
                        Sic = "sic",
                        SicDescription = "sicDescription",
                        StateOfIncorporation = "stateOfIncorporation",
                        Ticker = "ticker",
                    },
                    FiledAt = "2019-12-27",
                    FormType = "formType",
                    PeriodOfReport = "2019-12-27",
                    SecUrl = "secUrl",
                    Snippet = "snippet",
                },
            ],
            FormTypes = ["string"],
            Limit = 0,
            Offset = 0,
            Query = "query",
            Ticker = "ticker",
            Total = 0,
            Type = V1SecFilingResponseType.Search,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1SecFilingResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1SecFilingResponse
        {
            Cik = "cik",
            DateAfter = "2019-12-27",
            DateBefore = "2019-12-27",
            Entity = "entity",
            Filings =
            [
                new()
                {
                    AccessionNumber = "accessionNumber",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            Description = "description",
                            Type = "type",
                            Url = "url",
                        },
                    ],
                    Entity = new()
                    {
                        Cik = "cik",
                        EntityType = "entityType",
                        Name = "name",
                        Sic = "sic",
                        SicDescription = "sicDescription",
                        StateOfIncorporation = "stateOfIncorporation",
                        Ticker = "ticker",
                    },
                    FiledAt = "2019-12-27",
                    FormType = "formType",
                    PeriodOfReport = "2019-12-27",
                    SecUrl = "secUrl",
                    Snippet = "snippet",
                },
            ],
            FormTypes = ["string"],
            Limit = 0,
            Offset = 0,
            Query = "query",
            Ticker = "ticker",
            Total = 0,
            Type = V1SecFilingResponseType.Search,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1SecFilingResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCik = "cik";
        string expectedDateAfter = "2019-12-27";
        string expectedDateBefore = "2019-12-27";
        string expectedEntity = "entity";
        List<Filing> expectedFilings =
        [
            new()
            {
                AccessionNumber = "accessionNumber",
                Description = "description",
                Documents =
                [
                    new()
                    {
                        Description = "description",
                        Type = "type",
                        Url = "url",
                    },
                ],
                Entity = new()
                {
                    Cik = "cik",
                    EntityType = "entityType",
                    Name = "name",
                    Sic = "sic",
                    SicDescription = "sicDescription",
                    StateOfIncorporation = "stateOfIncorporation",
                    Ticker = "ticker",
                },
                FiledAt = "2019-12-27",
                FormType = "formType",
                PeriodOfReport = "2019-12-27",
                SecUrl = "secUrl",
                Snippet = "snippet",
            },
        ];
        List<string> expectedFormTypes = ["string"];
        long expectedLimit = 0;
        long expectedOffset = 0;
        string expectedQuery = "query";
        string expectedTicker = "ticker";
        long expectedTotal = 0;
        ApiEnum<string, V1SecFilingResponseType> expectedType = V1SecFilingResponseType.Search;

        Assert.Equal(expectedCik, deserialized.Cik);
        Assert.Equal(expectedDateAfter, deserialized.DateAfter);
        Assert.Equal(expectedDateBefore, deserialized.DateBefore);
        Assert.Equal(expectedEntity, deserialized.Entity);
        Assert.NotNull(deserialized.Filings);
        Assert.Equal(expectedFilings.Count, deserialized.Filings.Count);
        for (int i = 0; i < expectedFilings.Count; i++)
        {
            Assert.Equal(expectedFilings[i], deserialized.Filings[i]);
        }
        Assert.NotNull(deserialized.FormTypes);
        Assert.Equal(expectedFormTypes.Count, deserialized.FormTypes.Count);
        for (int i = 0; i < expectedFormTypes.Count; i++)
        {
            Assert.Equal(expectedFormTypes[i], deserialized.FormTypes[i]);
        }
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedOffset, deserialized.Offset);
        Assert.Equal(expectedQuery, deserialized.Query);
        Assert.Equal(expectedTicker, deserialized.Ticker);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1SecFilingResponse
        {
            Cik = "cik",
            DateAfter = "2019-12-27",
            DateBefore = "2019-12-27",
            Entity = "entity",
            Filings =
            [
                new()
                {
                    AccessionNumber = "accessionNumber",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            Description = "description",
                            Type = "type",
                            Url = "url",
                        },
                    ],
                    Entity = new()
                    {
                        Cik = "cik",
                        EntityType = "entityType",
                        Name = "name",
                        Sic = "sic",
                        SicDescription = "sicDescription",
                        StateOfIncorporation = "stateOfIncorporation",
                        Ticker = "ticker",
                    },
                    FiledAt = "2019-12-27",
                    FormType = "formType",
                    PeriodOfReport = "2019-12-27",
                    SecUrl = "secUrl",
                    Snippet = "snippet",
                },
            ],
            FormTypes = ["string"],
            Limit = 0,
            Offset = 0,
            Query = "query",
            Ticker = "ticker",
            Total = 0,
            Type = V1SecFilingResponseType.Search,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1SecFilingResponse
        {
            Cik = "cik",
            DateAfter = "2019-12-27",
            DateBefore = "2019-12-27",
            Entity = "entity",
            Query = "query",
            Ticker = "ticker",
        };

        Assert.Null(model.Filings);
        Assert.False(model.RawData.ContainsKey("filings"));
        Assert.Null(model.FormTypes);
        Assert.False(model.RawData.ContainsKey("formTypes"));
        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Offset);
        Assert.False(model.RawData.ContainsKey("offset"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1SecFilingResponse
        {
            Cik = "cik",
            DateAfter = "2019-12-27",
            DateBefore = "2019-12-27",
            Entity = "entity",
            Query = "query",
            Ticker = "ticker",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1SecFilingResponse
        {
            Cik = "cik",
            DateAfter = "2019-12-27",
            DateBefore = "2019-12-27",
            Entity = "entity",
            Query = "query",
            Ticker = "ticker",

            // Null should be interpreted as omitted for these properties
            Filings = null,
            FormTypes = null,
            Limit = null,
            Offset = null,
            Total = null,
            Type = null,
        };

        Assert.Null(model.Filings);
        Assert.False(model.RawData.ContainsKey("filings"));
        Assert.Null(model.FormTypes);
        Assert.False(model.RawData.ContainsKey("formTypes"));
        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Offset);
        Assert.False(model.RawData.ContainsKey("offset"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1SecFilingResponse
        {
            Cik = "cik",
            DateAfter = "2019-12-27",
            DateBefore = "2019-12-27",
            Entity = "entity",
            Query = "query",
            Ticker = "ticker",

            // Null should be interpreted as omitted for these properties
            Filings = null,
            FormTypes = null,
            Limit = null,
            Offset = null,
            Total = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1SecFilingResponse
        {
            Filings =
            [
                new()
                {
                    AccessionNumber = "accessionNumber",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            Description = "description",
                            Type = "type",
                            Url = "url",
                        },
                    ],
                    Entity = new()
                    {
                        Cik = "cik",
                        EntityType = "entityType",
                        Name = "name",
                        Sic = "sic",
                        SicDescription = "sicDescription",
                        StateOfIncorporation = "stateOfIncorporation",
                        Ticker = "ticker",
                    },
                    FiledAt = "2019-12-27",
                    FormType = "formType",
                    PeriodOfReport = "2019-12-27",
                    SecUrl = "secUrl",
                    Snippet = "snippet",
                },
            ],
            FormTypes = ["string"],
            Limit = 0,
            Offset = 0,
            Total = 0,
            Type = V1SecFilingResponseType.Search,
        };

        Assert.Null(model.Cik);
        Assert.False(model.RawData.ContainsKey("cik"));
        Assert.Null(model.DateAfter);
        Assert.False(model.RawData.ContainsKey("dateAfter"));
        Assert.Null(model.DateBefore);
        Assert.False(model.RawData.ContainsKey("dateBefore"));
        Assert.Null(model.Entity);
        Assert.False(model.RawData.ContainsKey("entity"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Ticker);
        Assert.False(model.RawData.ContainsKey("ticker"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1SecFilingResponse
        {
            Filings =
            [
                new()
                {
                    AccessionNumber = "accessionNumber",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            Description = "description",
                            Type = "type",
                            Url = "url",
                        },
                    ],
                    Entity = new()
                    {
                        Cik = "cik",
                        EntityType = "entityType",
                        Name = "name",
                        Sic = "sic",
                        SicDescription = "sicDescription",
                        StateOfIncorporation = "stateOfIncorporation",
                        Ticker = "ticker",
                    },
                    FiledAt = "2019-12-27",
                    FormType = "formType",
                    PeriodOfReport = "2019-12-27",
                    SecUrl = "secUrl",
                    Snippet = "snippet",
                },
            ],
            FormTypes = ["string"],
            Limit = 0,
            Offset = 0,
            Total = 0,
            Type = V1SecFilingResponseType.Search,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new V1SecFilingResponse
        {
            Filings =
            [
                new()
                {
                    AccessionNumber = "accessionNumber",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            Description = "description",
                            Type = "type",
                            Url = "url",
                        },
                    ],
                    Entity = new()
                    {
                        Cik = "cik",
                        EntityType = "entityType",
                        Name = "name",
                        Sic = "sic",
                        SicDescription = "sicDescription",
                        StateOfIncorporation = "stateOfIncorporation",
                        Ticker = "ticker",
                    },
                    FiledAt = "2019-12-27",
                    FormType = "formType",
                    PeriodOfReport = "2019-12-27",
                    SecUrl = "secUrl",
                    Snippet = "snippet",
                },
            ],
            FormTypes = ["string"],
            Limit = 0,
            Offset = 0,
            Total = 0,
            Type = V1SecFilingResponseType.Search,

            Cik = null,
            DateAfter = null,
            DateBefore = null,
            Entity = null,
            Query = null,
            Ticker = null,
        };

        Assert.Null(model.Cik);
        Assert.True(model.RawData.ContainsKey("cik"));
        Assert.Null(model.DateAfter);
        Assert.True(model.RawData.ContainsKey("dateAfter"));
        Assert.Null(model.DateBefore);
        Assert.True(model.RawData.ContainsKey("dateBefore"));
        Assert.Null(model.Entity);
        Assert.True(model.RawData.ContainsKey("entity"));
        Assert.Null(model.Query);
        Assert.True(model.RawData.ContainsKey("query"));
        Assert.Null(model.Ticker);
        Assert.True(model.RawData.ContainsKey("ticker"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1SecFilingResponse
        {
            Filings =
            [
                new()
                {
                    AccessionNumber = "accessionNumber",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            Description = "description",
                            Type = "type",
                            Url = "url",
                        },
                    ],
                    Entity = new()
                    {
                        Cik = "cik",
                        EntityType = "entityType",
                        Name = "name",
                        Sic = "sic",
                        SicDescription = "sicDescription",
                        StateOfIncorporation = "stateOfIncorporation",
                        Ticker = "ticker",
                    },
                    FiledAt = "2019-12-27",
                    FormType = "formType",
                    PeriodOfReport = "2019-12-27",
                    SecUrl = "secUrl",
                    Snippet = "snippet",
                },
            ],
            FormTypes = ["string"],
            Limit = 0,
            Offset = 0,
            Total = 0,
            Type = V1SecFilingResponseType.Search,

            Cik = null,
            DateAfter = null,
            DateBefore = null,
            Entity = null,
            Query = null,
            Ticker = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1SecFilingResponse
        {
            Cik = "cik",
            DateAfter = "2019-12-27",
            DateBefore = "2019-12-27",
            Entity = "entity",
            Filings =
            [
                new()
                {
                    AccessionNumber = "accessionNumber",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            Description = "description",
                            Type = "type",
                            Url = "url",
                        },
                    ],
                    Entity = new()
                    {
                        Cik = "cik",
                        EntityType = "entityType",
                        Name = "name",
                        Sic = "sic",
                        SicDescription = "sicDescription",
                        StateOfIncorporation = "stateOfIncorporation",
                        Ticker = "ticker",
                    },
                    FiledAt = "2019-12-27",
                    FormType = "formType",
                    PeriodOfReport = "2019-12-27",
                    SecUrl = "secUrl",
                    Snippet = "snippet",
                },
            ],
            FormTypes = ["string"],
            Limit = 0,
            Offset = 0,
            Query = "query",
            Ticker = "ticker",
            Total = 0,
            Type = V1SecFilingResponseType.Search,
        };

        V1SecFilingResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FilingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filing
        {
            AccessionNumber = "accessionNumber",
            Description = "description",
            Documents =
            [
                new()
                {
                    Description = "description",
                    Type = "type",
                    Url = "url",
                },
            ],
            Entity = new()
            {
                Cik = "cik",
                EntityType = "entityType",
                Name = "name",
                Sic = "sic",
                SicDescription = "sicDescription",
                StateOfIncorporation = "stateOfIncorporation",
                Ticker = "ticker",
            },
            FiledAt = "2019-12-27",
            FormType = "formType",
            PeriodOfReport = "2019-12-27",
            SecUrl = "secUrl",
            Snippet = "snippet",
        };

        string expectedAccessionNumber = "accessionNumber";
        string expectedDescription = "description";
        List<FilingDocument> expectedDocuments =
        [
            new()
            {
                Description = "description",
                Type = "type",
                Url = "url",
            },
        ];
        Entity expectedEntity = new()
        {
            Cik = "cik",
            EntityType = "entityType",
            Name = "name",
            Sic = "sic",
            SicDescription = "sicDescription",
            StateOfIncorporation = "stateOfIncorporation",
            Ticker = "ticker",
        };
        string expectedFiledAt = "2019-12-27";
        string expectedFormType = "formType";
        string expectedPeriodOfReport = "2019-12-27";
        string expectedSecUrl = "secUrl";
        string expectedSnippet = "snippet";

        Assert.Equal(expectedAccessionNumber, model.AccessionNumber);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Documents);
        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
        Assert.Equal(expectedEntity, model.Entity);
        Assert.Equal(expectedFiledAt, model.FiledAt);
        Assert.Equal(expectedFormType, model.FormType);
        Assert.Equal(expectedPeriodOfReport, model.PeriodOfReport);
        Assert.Equal(expectedSecUrl, model.SecUrl);
        Assert.Equal(expectedSnippet, model.Snippet);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Filing
        {
            AccessionNumber = "accessionNumber",
            Description = "description",
            Documents =
            [
                new()
                {
                    Description = "description",
                    Type = "type",
                    Url = "url",
                },
            ],
            Entity = new()
            {
                Cik = "cik",
                EntityType = "entityType",
                Name = "name",
                Sic = "sic",
                SicDescription = "sicDescription",
                StateOfIncorporation = "stateOfIncorporation",
                Ticker = "ticker",
            },
            FiledAt = "2019-12-27",
            FormType = "formType",
            PeriodOfReport = "2019-12-27",
            SecUrl = "secUrl",
            Snippet = "snippet",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filing>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filing
        {
            AccessionNumber = "accessionNumber",
            Description = "description",
            Documents =
            [
                new()
                {
                    Description = "description",
                    Type = "type",
                    Url = "url",
                },
            ],
            Entity = new()
            {
                Cik = "cik",
                EntityType = "entityType",
                Name = "name",
                Sic = "sic",
                SicDescription = "sicDescription",
                StateOfIncorporation = "stateOfIncorporation",
                Ticker = "ticker",
            },
            FiledAt = "2019-12-27",
            FormType = "formType",
            PeriodOfReport = "2019-12-27",
            SecUrl = "secUrl",
            Snippet = "snippet",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filing>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedAccessionNumber = "accessionNumber";
        string expectedDescription = "description";
        List<FilingDocument> expectedDocuments =
        [
            new()
            {
                Description = "description",
                Type = "type",
                Url = "url",
            },
        ];
        Entity expectedEntity = new()
        {
            Cik = "cik",
            EntityType = "entityType",
            Name = "name",
            Sic = "sic",
            SicDescription = "sicDescription",
            StateOfIncorporation = "stateOfIncorporation",
            Ticker = "ticker",
        };
        string expectedFiledAt = "2019-12-27";
        string expectedFormType = "formType";
        string expectedPeriodOfReport = "2019-12-27";
        string expectedSecUrl = "secUrl";
        string expectedSnippet = "snippet";

        Assert.Equal(expectedAccessionNumber, deserialized.AccessionNumber);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Documents);
        Assert.Equal(expectedDocuments.Count, deserialized.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], deserialized.Documents[i]);
        }
        Assert.Equal(expectedEntity, deserialized.Entity);
        Assert.Equal(expectedFiledAt, deserialized.FiledAt);
        Assert.Equal(expectedFormType, deserialized.FormType);
        Assert.Equal(expectedPeriodOfReport, deserialized.PeriodOfReport);
        Assert.Equal(expectedSecUrl, deserialized.SecUrl);
        Assert.Equal(expectedSnippet, deserialized.Snippet);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Filing
        {
            AccessionNumber = "accessionNumber",
            Description = "description",
            Documents =
            [
                new()
                {
                    Description = "description",
                    Type = "type",
                    Url = "url",
                },
            ],
            Entity = new()
            {
                Cik = "cik",
                EntityType = "entityType",
                Name = "name",
                Sic = "sic",
                SicDescription = "sicDescription",
                StateOfIncorporation = "stateOfIncorporation",
                Ticker = "ticker",
            },
            FiledAt = "2019-12-27",
            FormType = "formType",
            PeriodOfReport = "2019-12-27",
            SecUrl = "secUrl",
            Snippet = "snippet",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Filing
        {
            Description = "description",
            PeriodOfReport = "2019-12-27",
            Snippet = "snippet",
        };

        Assert.Null(model.AccessionNumber);
        Assert.False(model.RawData.ContainsKey("accessionNumber"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.Entity);
        Assert.False(model.RawData.ContainsKey("entity"));
        Assert.Null(model.FiledAt);
        Assert.False(model.RawData.ContainsKey("filedAt"));
        Assert.Null(model.FormType);
        Assert.False(model.RawData.ContainsKey("formType"));
        Assert.Null(model.SecUrl);
        Assert.False(model.RawData.ContainsKey("secUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Filing
        {
            Description = "description",
            PeriodOfReport = "2019-12-27",
            Snippet = "snippet",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Filing
        {
            Description = "description",
            PeriodOfReport = "2019-12-27",
            Snippet = "snippet",

            // Null should be interpreted as omitted for these properties
            AccessionNumber = null,
            Documents = null,
            Entity = null,
            FiledAt = null,
            FormType = null,
            SecUrl = null,
        };

        Assert.Null(model.AccessionNumber);
        Assert.False(model.RawData.ContainsKey("accessionNumber"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.Entity);
        Assert.False(model.RawData.ContainsKey("entity"));
        Assert.Null(model.FiledAt);
        Assert.False(model.RawData.ContainsKey("filedAt"));
        Assert.Null(model.FormType);
        Assert.False(model.RawData.ContainsKey("formType"));
        Assert.Null(model.SecUrl);
        Assert.False(model.RawData.ContainsKey("secUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Filing
        {
            Description = "description",
            PeriodOfReport = "2019-12-27",
            Snippet = "snippet",

            // Null should be interpreted as omitted for these properties
            AccessionNumber = null,
            Documents = null,
            Entity = null,
            FiledAt = null,
            FormType = null,
            SecUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Filing
        {
            AccessionNumber = "accessionNumber",
            Documents =
            [
                new()
                {
                    Description = "description",
                    Type = "type",
                    Url = "url",
                },
            ],
            Entity = new()
            {
                Cik = "cik",
                EntityType = "entityType",
                Name = "name",
                Sic = "sic",
                SicDescription = "sicDescription",
                StateOfIncorporation = "stateOfIncorporation",
                Ticker = "ticker",
            },
            FiledAt = "2019-12-27",
            FormType = "formType",
            SecUrl = "secUrl",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.PeriodOfReport);
        Assert.False(model.RawData.ContainsKey("periodOfReport"));
        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Filing
        {
            AccessionNumber = "accessionNumber",
            Documents =
            [
                new()
                {
                    Description = "description",
                    Type = "type",
                    Url = "url",
                },
            ],
            Entity = new()
            {
                Cik = "cik",
                EntityType = "entityType",
                Name = "name",
                Sic = "sic",
                SicDescription = "sicDescription",
                StateOfIncorporation = "stateOfIncorporation",
                Ticker = "ticker",
            },
            FiledAt = "2019-12-27",
            FormType = "formType",
            SecUrl = "secUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Filing
        {
            AccessionNumber = "accessionNumber",
            Documents =
            [
                new()
                {
                    Description = "description",
                    Type = "type",
                    Url = "url",
                },
            ],
            Entity = new()
            {
                Cik = "cik",
                EntityType = "entityType",
                Name = "name",
                Sic = "sic",
                SicDescription = "sicDescription",
                StateOfIncorporation = "stateOfIncorporation",
                Ticker = "ticker",
            },
            FiledAt = "2019-12-27",
            FormType = "formType",
            SecUrl = "secUrl",

            Description = null,
            PeriodOfReport = null,
            Snippet = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.PeriodOfReport);
        Assert.True(model.RawData.ContainsKey("periodOfReport"));
        Assert.Null(model.Snippet);
        Assert.True(model.RawData.ContainsKey("snippet"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Filing
        {
            AccessionNumber = "accessionNumber",
            Documents =
            [
                new()
                {
                    Description = "description",
                    Type = "type",
                    Url = "url",
                },
            ],
            Entity = new()
            {
                Cik = "cik",
                EntityType = "entityType",
                Name = "name",
                Sic = "sic",
                SicDescription = "sicDescription",
                StateOfIncorporation = "stateOfIncorporation",
                Ticker = "ticker",
            },
            FiledAt = "2019-12-27",
            FormType = "formType",
            SecUrl = "secUrl",

            Description = null,
            PeriodOfReport = null,
            Snippet = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Filing
        {
            AccessionNumber = "accessionNumber",
            Description = "description",
            Documents =
            [
                new()
                {
                    Description = "description",
                    Type = "type",
                    Url = "url",
                },
            ],
            Entity = new()
            {
                Cik = "cik",
                EntityType = "entityType",
                Name = "name",
                Sic = "sic",
                SicDescription = "sicDescription",
                StateOfIncorporation = "stateOfIncorporation",
                Ticker = "ticker",
            },
            FiledAt = "2019-12-27",
            FormType = "formType",
            PeriodOfReport = "2019-12-27",
            SecUrl = "secUrl",
            Snippet = "snippet",
        };

        Filing copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FilingDocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FilingDocument
        {
            Description = "description",
            Type = "type",
            Url = "url",
        };

        string expectedDescription = "description";
        string expectedType = "type";
        string expectedUrl = "url";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FilingDocument
        {
            Description = "description",
            Type = "type",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FilingDocument>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FilingDocument
        {
            Description = "description",
            Type = "type",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FilingDocument>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedType = "type";
        string expectedUrl = "url";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FilingDocument
        {
            Description = "description",
            Type = "type",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FilingDocument { };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FilingDocument { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FilingDocument
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            Type = null,
            Url = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FilingDocument
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            Type = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FilingDocument
        {
            Description = "description",
            Type = "type",
            Url = "url",
        };

        FilingDocument copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entity
        {
            Cik = "cik",
            EntityType = "entityType",
            Name = "name",
            Sic = "sic",
            SicDescription = "sicDescription",
            StateOfIncorporation = "stateOfIncorporation",
            Ticker = "ticker",
        };

        string expectedCik = "cik";
        string expectedEntityType = "entityType";
        string expectedName = "name";
        string expectedSic = "sic";
        string expectedSicDescription = "sicDescription";
        string expectedStateOfIncorporation = "stateOfIncorporation";
        string expectedTicker = "ticker";

        Assert.Equal(expectedCik, model.Cik);
        Assert.Equal(expectedEntityType, model.EntityType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSic, model.Sic);
        Assert.Equal(expectedSicDescription, model.SicDescription);
        Assert.Equal(expectedStateOfIncorporation, model.StateOfIncorporation);
        Assert.Equal(expectedTicker, model.Ticker);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entity
        {
            Cik = "cik",
            EntityType = "entityType",
            Name = "name",
            Sic = "sic",
            SicDescription = "sicDescription",
            StateOfIncorporation = "stateOfIncorporation",
            Ticker = "ticker",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entity>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entity
        {
            Cik = "cik",
            EntityType = "entityType",
            Name = "name",
            Sic = "sic",
            SicDescription = "sicDescription",
            StateOfIncorporation = "stateOfIncorporation",
            Ticker = "ticker",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entity>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCik = "cik";
        string expectedEntityType = "entityType";
        string expectedName = "name";
        string expectedSic = "sic";
        string expectedSicDescription = "sicDescription";
        string expectedStateOfIncorporation = "stateOfIncorporation";
        string expectedTicker = "ticker";

        Assert.Equal(expectedCik, deserialized.Cik);
        Assert.Equal(expectedEntityType, deserialized.EntityType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSic, deserialized.Sic);
        Assert.Equal(expectedSicDescription, deserialized.SicDescription);
        Assert.Equal(expectedStateOfIncorporation, deserialized.StateOfIncorporation);
        Assert.Equal(expectedTicker, deserialized.Ticker);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entity
        {
            Cik = "cik",
            EntityType = "entityType",
            Name = "name",
            Sic = "sic",
            SicDescription = "sicDescription",
            StateOfIncorporation = "stateOfIncorporation",
            Ticker = "ticker",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entity
        {
            EntityType = "entityType",
            Name = "name",
            Sic = "sic",
            SicDescription = "sicDescription",
            StateOfIncorporation = "stateOfIncorporation",
            Ticker = "ticker",
        };

        Assert.Null(model.Cik);
        Assert.False(model.RawData.ContainsKey("cik"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entity
        {
            EntityType = "entityType",
            Name = "name",
            Sic = "sic",
            SicDescription = "sicDescription",
            StateOfIncorporation = "stateOfIncorporation",
            Ticker = "ticker",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Entity
        {
            EntityType = "entityType",
            Name = "name",
            Sic = "sic",
            SicDescription = "sicDescription",
            StateOfIncorporation = "stateOfIncorporation",
            Ticker = "ticker",

            // Null should be interpreted as omitted for these properties
            Cik = null,
        };

        Assert.Null(model.Cik);
        Assert.False(model.RawData.ContainsKey("cik"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entity
        {
            EntityType = "entityType",
            Name = "name",
            Sic = "sic",
            SicDescription = "sicDescription",
            StateOfIncorporation = "stateOfIncorporation",
            Ticker = "ticker",

            // Null should be interpreted as omitted for these properties
            Cik = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entity { Cik = "cik" };

        Assert.Null(model.EntityType);
        Assert.False(model.RawData.ContainsKey("entityType"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Sic);
        Assert.False(model.RawData.ContainsKey("sic"));
        Assert.Null(model.SicDescription);
        Assert.False(model.RawData.ContainsKey("sicDescription"));
        Assert.Null(model.StateOfIncorporation);
        Assert.False(model.RawData.ContainsKey("stateOfIncorporation"));
        Assert.Null(model.Ticker);
        Assert.False(model.RawData.ContainsKey("ticker"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entity { Cik = "cik" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Entity
        {
            Cik = "cik",

            EntityType = null,
            Name = null,
            Sic = null,
            SicDescription = null,
            StateOfIncorporation = null,
            Ticker = null,
        };

        Assert.Null(model.EntityType);
        Assert.True(model.RawData.ContainsKey("entityType"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Sic);
        Assert.True(model.RawData.ContainsKey("sic"));
        Assert.Null(model.SicDescription);
        Assert.True(model.RawData.ContainsKey("sicDescription"));
        Assert.Null(model.StateOfIncorporation);
        Assert.True(model.RawData.ContainsKey("stateOfIncorporation"));
        Assert.Null(model.Ticker);
        Assert.True(model.RawData.ContainsKey("ticker"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entity
        {
            Cik = "cik",

            EntityType = null,
            Name = null,
            Sic = null,
            SicDescription = null,
            StateOfIncorporation = null,
            Ticker = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entity
        {
            Cik = "cik",
            EntityType = "entityType",
            Name = "name",
            Sic = "sic",
            SicDescription = "sicDescription",
            StateOfIncorporation = "stateOfIncorporation",
            Ticker = "ticker",
        };

        Entity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1SecFilingResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(V1SecFilingResponseType.Search)]
    [InlineData(V1SecFilingResponseType.Entity)]
    public void Validation_Works(V1SecFilingResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1SecFilingResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1SecFilingResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1SecFilingResponseType.Search)]
    [InlineData(V1SecFilingResponseType.Entity)]
    public void SerializationRoundtrip_Works(V1SecFilingResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1SecFilingResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1SecFilingResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1SecFilingResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1SecFilingResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
