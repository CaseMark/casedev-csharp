using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1DocketResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1DocketResponse
        {
            Court = "court",
            DateFiledAfter = "2019-12-27",
            DateFiledBefore = "2019-12-27",
            Docket = new()
            {
                ID = "id",
                AssignedTo = "assignedTo",
                CaseName = "caseName",
                Cause = "cause",
                Court = "court",
                CourtID = "courtId",
                DateFiled = "2019-12-27",
                DateTerminated = "2019-12-27",
                DocketNumber = "docketNumber",
                NatureOfSuit = "natureOfSuit",
                PacerCaseID = "pacerCaseId",
                Parties = ["string"],
                Url = "url",
            },
            Dockets =
            [
                new()
                {
                    ID = "id",
                    AssignedTo = "assignedTo",
                    CaseName = "caseName",
                    Cause = "cause",
                    Court = "court",
                    CourtID = "courtId",
                    DateFiled = "2019-12-27",
                    DateTerminated = "2019-12-27",
                    DocketNumber = "docketNumber",
                    NatureOfSuit = "natureOfSuit",
                    PacerCaseID = "pacerCaseId",
                    Parties = ["string"],
                    Url = "url",
                },
            ],
            Entries =
            [
                new()
                {
                    Date = "2019-12-27",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            ID = "id",
                            AttachmentNumber = 0,
                            Description = "description",
                            DocumentNumber = "documentNumber",
                            IsAvailable = true,
                            PageCount = 0,
                            PdfUrl = "pdfUrl",
                        },
                    ],
                    EntryNumber = 0,
                },
            ],
            Found = 0,
            IncludeEntries = true,
            Pagination = new()
            {
                Limit = 0,
                Offset = 0,
                Returned = 0,
            },
            Query = "query",
            Type = V1DocketResponseType.Search,
        };

        string expectedCourt = "court";
        string expectedDateFiledAfter = "2019-12-27";
        string expectedDateFiledBefore = "2019-12-27";
        Docket expectedDocket = new()
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };
        List<V1DocketResponseDocket> expectedDockets =
        [
            new()
            {
                ID = "id",
                AssignedTo = "assignedTo",
                CaseName = "caseName",
                Cause = "cause",
                Court = "court",
                CourtID = "courtId",
                DateFiled = "2019-12-27",
                DateTerminated = "2019-12-27",
                DocketNumber = "docketNumber",
                NatureOfSuit = "natureOfSuit",
                PacerCaseID = "pacerCaseId",
                Parties = ["string"],
                Url = "url",
            },
        ];
        List<Entry> expectedEntries =
        [
            new()
            {
                Date = "2019-12-27",
                Description = "description",
                Documents =
                [
                    new()
                    {
                        ID = "id",
                        AttachmentNumber = 0,
                        Description = "description",
                        DocumentNumber = "documentNumber",
                        IsAvailable = true,
                        PageCount = 0,
                        PdfUrl = "pdfUrl",
                    },
                ],
                EntryNumber = 0,
            },
        ];
        long expectedFound = 0;
        bool expectedIncludeEntries = true;
        Pagination expectedPagination = new()
        {
            Limit = 0,
            Offset = 0,
            Returned = 0,
        };
        string expectedQuery = "query";
        ApiEnum<string, V1DocketResponseType> expectedType = V1DocketResponseType.Search;

        Assert.Equal(expectedCourt, model.Court);
        Assert.Equal(expectedDateFiledAfter, model.DateFiledAfter);
        Assert.Equal(expectedDateFiledBefore, model.DateFiledBefore);
        Assert.Equal(expectedDocket, model.Docket);
        Assert.NotNull(model.Dockets);
        Assert.Equal(expectedDockets.Count, model.Dockets.Count);
        for (int i = 0; i < expectedDockets.Count; i++)
        {
            Assert.Equal(expectedDockets[i], model.Dockets[i]);
        }
        Assert.NotNull(model.Entries);
        Assert.Equal(expectedEntries.Count, model.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], model.Entries[i]);
        }
        Assert.Equal(expectedFound, model.Found);
        Assert.Equal(expectedIncludeEntries, model.IncludeEntries);
        Assert.Equal(expectedPagination, model.Pagination);
        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1DocketResponse
        {
            Court = "court",
            DateFiledAfter = "2019-12-27",
            DateFiledBefore = "2019-12-27",
            Docket = new()
            {
                ID = "id",
                AssignedTo = "assignedTo",
                CaseName = "caseName",
                Cause = "cause",
                Court = "court",
                CourtID = "courtId",
                DateFiled = "2019-12-27",
                DateTerminated = "2019-12-27",
                DocketNumber = "docketNumber",
                NatureOfSuit = "natureOfSuit",
                PacerCaseID = "pacerCaseId",
                Parties = ["string"],
                Url = "url",
            },
            Dockets =
            [
                new()
                {
                    ID = "id",
                    AssignedTo = "assignedTo",
                    CaseName = "caseName",
                    Cause = "cause",
                    Court = "court",
                    CourtID = "courtId",
                    DateFiled = "2019-12-27",
                    DateTerminated = "2019-12-27",
                    DocketNumber = "docketNumber",
                    NatureOfSuit = "natureOfSuit",
                    PacerCaseID = "pacerCaseId",
                    Parties = ["string"],
                    Url = "url",
                },
            ],
            Entries =
            [
                new()
                {
                    Date = "2019-12-27",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            ID = "id",
                            AttachmentNumber = 0,
                            Description = "description",
                            DocumentNumber = "documentNumber",
                            IsAvailable = true,
                            PageCount = 0,
                            PdfUrl = "pdfUrl",
                        },
                    ],
                    EntryNumber = 0,
                },
            ],
            Found = 0,
            IncludeEntries = true,
            Pagination = new()
            {
                Limit = 0,
                Offset = 0,
                Returned = 0,
            },
            Query = "query",
            Type = V1DocketResponseType.Search,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DocketResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1DocketResponse
        {
            Court = "court",
            DateFiledAfter = "2019-12-27",
            DateFiledBefore = "2019-12-27",
            Docket = new()
            {
                ID = "id",
                AssignedTo = "assignedTo",
                CaseName = "caseName",
                Cause = "cause",
                Court = "court",
                CourtID = "courtId",
                DateFiled = "2019-12-27",
                DateTerminated = "2019-12-27",
                DocketNumber = "docketNumber",
                NatureOfSuit = "natureOfSuit",
                PacerCaseID = "pacerCaseId",
                Parties = ["string"],
                Url = "url",
            },
            Dockets =
            [
                new()
                {
                    ID = "id",
                    AssignedTo = "assignedTo",
                    CaseName = "caseName",
                    Cause = "cause",
                    Court = "court",
                    CourtID = "courtId",
                    DateFiled = "2019-12-27",
                    DateTerminated = "2019-12-27",
                    DocketNumber = "docketNumber",
                    NatureOfSuit = "natureOfSuit",
                    PacerCaseID = "pacerCaseId",
                    Parties = ["string"],
                    Url = "url",
                },
            ],
            Entries =
            [
                new()
                {
                    Date = "2019-12-27",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            ID = "id",
                            AttachmentNumber = 0,
                            Description = "description",
                            DocumentNumber = "documentNumber",
                            IsAvailable = true,
                            PageCount = 0,
                            PdfUrl = "pdfUrl",
                        },
                    ],
                    EntryNumber = 0,
                },
            ],
            Found = 0,
            IncludeEntries = true,
            Pagination = new()
            {
                Limit = 0,
                Offset = 0,
                Returned = 0,
            },
            Query = "query",
            Type = V1DocketResponseType.Search,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DocketResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCourt = "court";
        string expectedDateFiledAfter = "2019-12-27";
        string expectedDateFiledBefore = "2019-12-27";
        Docket expectedDocket = new()
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };
        List<V1DocketResponseDocket> expectedDockets =
        [
            new()
            {
                ID = "id",
                AssignedTo = "assignedTo",
                CaseName = "caseName",
                Cause = "cause",
                Court = "court",
                CourtID = "courtId",
                DateFiled = "2019-12-27",
                DateTerminated = "2019-12-27",
                DocketNumber = "docketNumber",
                NatureOfSuit = "natureOfSuit",
                PacerCaseID = "pacerCaseId",
                Parties = ["string"],
                Url = "url",
            },
        ];
        List<Entry> expectedEntries =
        [
            new()
            {
                Date = "2019-12-27",
                Description = "description",
                Documents =
                [
                    new()
                    {
                        ID = "id",
                        AttachmentNumber = 0,
                        Description = "description",
                        DocumentNumber = "documentNumber",
                        IsAvailable = true,
                        PageCount = 0,
                        PdfUrl = "pdfUrl",
                    },
                ],
                EntryNumber = 0,
            },
        ];
        long expectedFound = 0;
        bool expectedIncludeEntries = true;
        Pagination expectedPagination = new()
        {
            Limit = 0,
            Offset = 0,
            Returned = 0,
        };
        string expectedQuery = "query";
        ApiEnum<string, V1DocketResponseType> expectedType = V1DocketResponseType.Search;

        Assert.Equal(expectedCourt, deserialized.Court);
        Assert.Equal(expectedDateFiledAfter, deserialized.DateFiledAfter);
        Assert.Equal(expectedDateFiledBefore, deserialized.DateFiledBefore);
        Assert.Equal(expectedDocket, deserialized.Docket);
        Assert.NotNull(deserialized.Dockets);
        Assert.Equal(expectedDockets.Count, deserialized.Dockets.Count);
        for (int i = 0; i < expectedDockets.Count; i++)
        {
            Assert.Equal(expectedDockets[i], deserialized.Dockets[i]);
        }
        Assert.NotNull(deserialized.Entries);
        Assert.Equal(expectedEntries.Count, deserialized.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], deserialized.Entries[i]);
        }
        Assert.Equal(expectedFound, deserialized.Found);
        Assert.Equal(expectedIncludeEntries, deserialized.IncludeEntries);
        Assert.Equal(expectedPagination, deserialized.Pagination);
        Assert.Equal(expectedQuery, deserialized.Query);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1DocketResponse
        {
            Court = "court",
            DateFiledAfter = "2019-12-27",
            DateFiledBefore = "2019-12-27",
            Docket = new()
            {
                ID = "id",
                AssignedTo = "assignedTo",
                CaseName = "caseName",
                Cause = "cause",
                Court = "court",
                CourtID = "courtId",
                DateFiled = "2019-12-27",
                DateTerminated = "2019-12-27",
                DocketNumber = "docketNumber",
                NatureOfSuit = "natureOfSuit",
                PacerCaseID = "pacerCaseId",
                Parties = ["string"],
                Url = "url",
            },
            Dockets =
            [
                new()
                {
                    ID = "id",
                    AssignedTo = "assignedTo",
                    CaseName = "caseName",
                    Cause = "cause",
                    Court = "court",
                    CourtID = "courtId",
                    DateFiled = "2019-12-27",
                    DateTerminated = "2019-12-27",
                    DocketNumber = "docketNumber",
                    NatureOfSuit = "natureOfSuit",
                    PacerCaseID = "pacerCaseId",
                    Parties = ["string"],
                    Url = "url",
                },
            ],
            Entries =
            [
                new()
                {
                    Date = "2019-12-27",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            ID = "id",
                            AttachmentNumber = 0,
                            Description = "description",
                            DocumentNumber = "documentNumber",
                            IsAvailable = true,
                            PageCount = 0,
                            PdfUrl = "pdfUrl",
                        },
                    ],
                    EntryNumber = 0,
                },
            ],
            Found = 0,
            IncludeEntries = true,
            Pagination = new()
            {
                Limit = 0,
                Offset = 0,
                Returned = 0,
            },
            Query = "query",
            Type = V1DocketResponseType.Search,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1DocketResponse
        {
            Court = "court",
            DateFiledAfter = "2019-12-27",
            DateFiledBefore = "2019-12-27",
            Docket = new()
            {
                ID = "id",
                AssignedTo = "assignedTo",
                CaseName = "caseName",
                Cause = "cause",
                Court = "court",
                CourtID = "courtId",
                DateFiled = "2019-12-27",
                DateTerminated = "2019-12-27",
                DocketNumber = "docketNumber",
                NatureOfSuit = "natureOfSuit",
                PacerCaseID = "pacerCaseId",
                Parties = ["string"],
                Url = "url",
            },
            Entries =
            [
                new()
                {
                    Date = "2019-12-27",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            ID = "id",
                            AttachmentNumber = 0,
                            Description = "description",
                            DocumentNumber = "documentNumber",
                            IsAvailable = true,
                            PageCount = 0,
                            PdfUrl = "pdfUrl",
                        },
                    ],
                    EntryNumber = 0,
                },
            ],
            Pagination = new()
            {
                Limit = 0,
                Offset = 0,
                Returned = 0,
            },
            Query = "query",
        };

        Assert.Null(model.Dockets);
        Assert.False(model.RawData.ContainsKey("dockets"));
        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.IncludeEntries);
        Assert.False(model.RawData.ContainsKey("includeEntries"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1DocketResponse
        {
            Court = "court",
            DateFiledAfter = "2019-12-27",
            DateFiledBefore = "2019-12-27",
            Docket = new()
            {
                ID = "id",
                AssignedTo = "assignedTo",
                CaseName = "caseName",
                Cause = "cause",
                Court = "court",
                CourtID = "courtId",
                DateFiled = "2019-12-27",
                DateTerminated = "2019-12-27",
                DocketNumber = "docketNumber",
                NatureOfSuit = "natureOfSuit",
                PacerCaseID = "pacerCaseId",
                Parties = ["string"],
                Url = "url",
            },
            Entries =
            [
                new()
                {
                    Date = "2019-12-27",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            ID = "id",
                            AttachmentNumber = 0,
                            Description = "description",
                            DocumentNumber = "documentNumber",
                            IsAvailable = true,
                            PageCount = 0,
                            PdfUrl = "pdfUrl",
                        },
                    ],
                    EntryNumber = 0,
                },
            ],
            Pagination = new()
            {
                Limit = 0,
                Offset = 0,
                Returned = 0,
            },
            Query = "query",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1DocketResponse
        {
            Court = "court",
            DateFiledAfter = "2019-12-27",
            DateFiledBefore = "2019-12-27",
            Docket = new()
            {
                ID = "id",
                AssignedTo = "assignedTo",
                CaseName = "caseName",
                Cause = "cause",
                Court = "court",
                CourtID = "courtId",
                DateFiled = "2019-12-27",
                DateTerminated = "2019-12-27",
                DocketNumber = "docketNumber",
                NatureOfSuit = "natureOfSuit",
                PacerCaseID = "pacerCaseId",
                Parties = ["string"],
                Url = "url",
            },
            Entries =
            [
                new()
                {
                    Date = "2019-12-27",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            ID = "id",
                            AttachmentNumber = 0,
                            Description = "description",
                            DocumentNumber = "documentNumber",
                            IsAvailable = true,
                            PageCount = 0,
                            PdfUrl = "pdfUrl",
                        },
                    ],
                    EntryNumber = 0,
                },
            ],
            Pagination = new()
            {
                Limit = 0,
                Offset = 0,
                Returned = 0,
            },
            Query = "query",

            // Null should be interpreted as omitted for these properties
            Dockets = null,
            Found = null,
            IncludeEntries = null,
            Type = null,
        };

        Assert.Null(model.Dockets);
        Assert.False(model.RawData.ContainsKey("dockets"));
        Assert.Null(model.Found);
        Assert.False(model.RawData.ContainsKey("found"));
        Assert.Null(model.IncludeEntries);
        Assert.False(model.RawData.ContainsKey("includeEntries"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1DocketResponse
        {
            Court = "court",
            DateFiledAfter = "2019-12-27",
            DateFiledBefore = "2019-12-27",
            Docket = new()
            {
                ID = "id",
                AssignedTo = "assignedTo",
                CaseName = "caseName",
                Cause = "cause",
                Court = "court",
                CourtID = "courtId",
                DateFiled = "2019-12-27",
                DateTerminated = "2019-12-27",
                DocketNumber = "docketNumber",
                NatureOfSuit = "natureOfSuit",
                PacerCaseID = "pacerCaseId",
                Parties = ["string"],
                Url = "url",
            },
            Entries =
            [
                new()
                {
                    Date = "2019-12-27",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            ID = "id",
                            AttachmentNumber = 0,
                            Description = "description",
                            DocumentNumber = "documentNumber",
                            IsAvailable = true,
                            PageCount = 0,
                            PdfUrl = "pdfUrl",
                        },
                    ],
                    EntryNumber = 0,
                },
            ],
            Pagination = new()
            {
                Limit = 0,
                Offset = 0,
                Returned = 0,
            },
            Query = "query",

            // Null should be interpreted as omitted for these properties
            Dockets = null,
            Found = null,
            IncludeEntries = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1DocketResponse
        {
            Dockets =
            [
                new()
                {
                    ID = "id",
                    AssignedTo = "assignedTo",
                    CaseName = "caseName",
                    Cause = "cause",
                    Court = "court",
                    CourtID = "courtId",
                    DateFiled = "2019-12-27",
                    DateTerminated = "2019-12-27",
                    DocketNumber = "docketNumber",
                    NatureOfSuit = "natureOfSuit",
                    PacerCaseID = "pacerCaseId",
                    Parties = ["string"],
                    Url = "url",
                },
            ],
            Found = 0,
            IncludeEntries = true,
            Type = V1DocketResponseType.Search,
        };

        Assert.Null(model.Court);
        Assert.False(model.RawData.ContainsKey("court"));
        Assert.Null(model.DateFiledAfter);
        Assert.False(model.RawData.ContainsKey("dateFiledAfter"));
        Assert.Null(model.DateFiledBefore);
        Assert.False(model.RawData.ContainsKey("dateFiledBefore"));
        Assert.Null(model.Docket);
        Assert.False(model.RawData.ContainsKey("docket"));
        Assert.Null(model.Entries);
        Assert.False(model.RawData.ContainsKey("entries"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1DocketResponse
        {
            Dockets =
            [
                new()
                {
                    ID = "id",
                    AssignedTo = "assignedTo",
                    CaseName = "caseName",
                    Cause = "cause",
                    Court = "court",
                    CourtID = "courtId",
                    DateFiled = "2019-12-27",
                    DateTerminated = "2019-12-27",
                    DocketNumber = "docketNumber",
                    NatureOfSuit = "natureOfSuit",
                    PacerCaseID = "pacerCaseId",
                    Parties = ["string"],
                    Url = "url",
                },
            ],
            Found = 0,
            IncludeEntries = true,
            Type = V1DocketResponseType.Search,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new V1DocketResponse
        {
            Dockets =
            [
                new()
                {
                    ID = "id",
                    AssignedTo = "assignedTo",
                    CaseName = "caseName",
                    Cause = "cause",
                    Court = "court",
                    CourtID = "courtId",
                    DateFiled = "2019-12-27",
                    DateTerminated = "2019-12-27",
                    DocketNumber = "docketNumber",
                    NatureOfSuit = "natureOfSuit",
                    PacerCaseID = "pacerCaseId",
                    Parties = ["string"],
                    Url = "url",
                },
            ],
            Found = 0,
            IncludeEntries = true,
            Type = V1DocketResponseType.Search,

            Court = null,
            DateFiledAfter = null,
            DateFiledBefore = null,
            Docket = null,
            Entries = null,
            Pagination = null,
            Query = null,
        };

        Assert.Null(model.Court);
        Assert.True(model.RawData.ContainsKey("court"));
        Assert.Null(model.DateFiledAfter);
        Assert.True(model.RawData.ContainsKey("dateFiledAfter"));
        Assert.Null(model.DateFiledBefore);
        Assert.True(model.RawData.ContainsKey("dateFiledBefore"));
        Assert.Null(model.Docket);
        Assert.True(model.RawData.ContainsKey("docket"));
        Assert.Null(model.Entries);
        Assert.True(model.RawData.ContainsKey("entries"));
        Assert.Null(model.Pagination);
        Assert.True(model.RawData.ContainsKey("pagination"));
        Assert.Null(model.Query);
        Assert.True(model.RawData.ContainsKey("query"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1DocketResponse
        {
            Dockets =
            [
                new()
                {
                    ID = "id",
                    AssignedTo = "assignedTo",
                    CaseName = "caseName",
                    Cause = "cause",
                    Court = "court",
                    CourtID = "courtId",
                    DateFiled = "2019-12-27",
                    DateTerminated = "2019-12-27",
                    DocketNumber = "docketNumber",
                    NatureOfSuit = "natureOfSuit",
                    PacerCaseID = "pacerCaseId",
                    Parties = ["string"],
                    Url = "url",
                },
            ],
            Found = 0,
            IncludeEntries = true,
            Type = V1DocketResponseType.Search,

            Court = null,
            DateFiledAfter = null,
            DateFiledBefore = null,
            Docket = null,
            Entries = null,
            Pagination = null,
            Query = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1DocketResponse
        {
            Court = "court",
            DateFiledAfter = "2019-12-27",
            DateFiledBefore = "2019-12-27",
            Docket = new()
            {
                ID = "id",
                AssignedTo = "assignedTo",
                CaseName = "caseName",
                Cause = "cause",
                Court = "court",
                CourtID = "courtId",
                DateFiled = "2019-12-27",
                DateTerminated = "2019-12-27",
                DocketNumber = "docketNumber",
                NatureOfSuit = "natureOfSuit",
                PacerCaseID = "pacerCaseId",
                Parties = ["string"],
                Url = "url",
            },
            Dockets =
            [
                new()
                {
                    ID = "id",
                    AssignedTo = "assignedTo",
                    CaseName = "caseName",
                    Cause = "cause",
                    Court = "court",
                    CourtID = "courtId",
                    DateFiled = "2019-12-27",
                    DateTerminated = "2019-12-27",
                    DocketNumber = "docketNumber",
                    NatureOfSuit = "natureOfSuit",
                    PacerCaseID = "pacerCaseId",
                    Parties = ["string"],
                    Url = "url",
                },
            ],
            Entries =
            [
                new()
                {
                    Date = "2019-12-27",
                    Description = "description",
                    Documents =
                    [
                        new()
                        {
                            ID = "id",
                            AttachmentNumber = 0,
                            Description = "description",
                            DocumentNumber = "documentNumber",
                            IsAvailable = true,
                            PageCount = 0,
                            PdfUrl = "pdfUrl",
                        },
                    ],
                    EntryNumber = 0,
                },
            ],
            Found = 0,
            IncludeEntries = true,
            Pagination = new()
            {
                Limit = 0,
                Offset = 0,
                Returned = 0,
            },
            Query = "query",
            Type = V1DocketResponseType.Search,
        };

        V1DocketResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DocketTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Docket
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        string expectedID = "id";
        string expectedAssignedTo = "assignedTo";
        string expectedCaseName = "caseName";
        string expectedCause = "cause";
        string expectedCourt = "court";
        string expectedCourtID = "courtId";
        string expectedDateFiled = "2019-12-27";
        string expectedDateTerminated = "2019-12-27";
        string expectedDocketNumber = "docketNumber";
        string expectedNatureOfSuit = "natureOfSuit";
        string expectedPacerCaseID = "pacerCaseId";
        List<string> expectedParties = ["string"];
        string expectedUrl = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAssignedTo, model.AssignedTo);
        Assert.Equal(expectedCaseName, model.CaseName);
        Assert.Equal(expectedCause, model.Cause);
        Assert.Equal(expectedCourt, model.Court);
        Assert.Equal(expectedCourtID, model.CourtID);
        Assert.Equal(expectedDateFiled, model.DateFiled);
        Assert.Equal(expectedDateTerminated, model.DateTerminated);
        Assert.Equal(expectedDocketNumber, model.DocketNumber);
        Assert.Equal(expectedNatureOfSuit, model.NatureOfSuit);
        Assert.Equal(expectedPacerCaseID, model.PacerCaseID);
        Assert.NotNull(model.Parties);
        Assert.Equal(expectedParties.Count, model.Parties.Count);
        for (int i = 0; i < expectedParties.Count; i++)
        {
            Assert.Equal(expectedParties[i], model.Parties[i]);
        }
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Docket
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Docket>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Docket
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Docket>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAssignedTo = "assignedTo";
        string expectedCaseName = "caseName";
        string expectedCause = "cause";
        string expectedCourt = "court";
        string expectedCourtID = "courtId";
        string expectedDateFiled = "2019-12-27";
        string expectedDateTerminated = "2019-12-27";
        string expectedDocketNumber = "docketNumber";
        string expectedNatureOfSuit = "natureOfSuit";
        string expectedPacerCaseID = "pacerCaseId";
        List<string> expectedParties = ["string"];
        string expectedUrl = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAssignedTo, deserialized.AssignedTo);
        Assert.Equal(expectedCaseName, deserialized.CaseName);
        Assert.Equal(expectedCause, deserialized.Cause);
        Assert.Equal(expectedCourt, deserialized.Court);
        Assert.Equal(expectedCourtID, deserialized.CourtID);
        Assert.Equal(expectedDateFiled, deserialized.DateFiled);
        Assert.Equal(expectedDateTerminated, deserialized.DateTerminated);
        Assert.Equal(expectedDocketNumber, deserialized.DocketNumber);
        Assert.Equal(expectedNatureOfSuit, deserialized.NatureOfSuit);
        Assert.Equal(expectedPacerCaseID, deserialized.PacerCaseID);
        Assert.NotNull(deserialized.Parties);
        Assert.Equal(expectedParties.Count, deserialized.Parties.Count);
        for (int i = 0; i < expectedParties.Count; i++)
        {
            Assert.Equal(expectedParties[i], deserialized.Parties[i]);
        }
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Docket
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Docket
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Parties);
        Assert.False(model.RawData.ContainsKey("parties"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Docket
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Docket
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Parties = null,
            Url = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Parties);
        Assert.False(model.RawData.ContainsKey("parties"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Docket
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Parties = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Docket
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",
        };

        Assert.Null(model.AssignedTo);
        Assert.False(model.RawData.ContainsKey("assignedTo"));
        Assert.Null(model.CaseName);
        Assert.False(model.RawData.ContainsKey("caseName"));
        Assert.Null(model.Cause);
        Assert.False(model.RawData.ContainsKey("cause"));
        Assert.Null(model.Court);
        Assert.False(model.RawData.ContainsKey("court"));
        Assert.Null(model.CourtID);
        Assert.False(model.RawData.ContainsKey("courtId"));
        Assert.Null(model.DateFiled);
        Assert.False(model.RawData.ContainsKey("dateFiled"));
        Assert.Null(model.DateTerminated);
        Assert.False(model.RawData.ContainsKey("dateTerminated"));
        Assert.Null(model.DocketNumber);
        Assert.False(model.RawData.ContainsKey("docketNumber"));
        Assert.Null(model.NatureOfSuit);
        Assert.False(model.RawData.ContainsKey("natureOfSuit"));
        Assert.Null(model.PacerCaseID);
        Assert.False(model.RawData.ContainsKey("pacerCaseId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Docket
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Docket
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",

            AssignedTo = null,
            CaseName = null,
            Cause = null,
            Court = null,
            CourtID = null,
            DateFiled = null,
            DateTerminated = null,
            DocketNumber = null,
            NatureOfSuit = null,
            PacerCaseID = null,
        };

        Assert.Null(model.AssignedTo);
        Assert.True(model.RawData.ContainsKey("assignedTo"));
        Assert.Null(model.CaseName);
        Assert.True(model.RawData.ContainsKey("caseName"));
        Assert.Null(model.Cause);
        Assert.True(model.RawData.ContainsKey("cause"));
        Assert.Null(model.Court);
        Assert.True(model.RawData.ContainsKey("court"));
        Assert.Null(model.CourtID);
        Assert.True(model.RawData.ContainsKey("courtId"));
        Assert.Null(model.DateFiled);
        Assert.True(model.RawData.ContainsKey("dateFiled"));
        Assert.Null(model.DateTerminated);
        Assert.True(model.RawData.ContainsKey("dateTerminated"));
        Assert.Null(model.DocketNumber);
        Assert.True(model.RawData.ContainsKey("docketNumber"));
        Assert.Null(model.NatureOfSuit);
        Assert.True(model.RawData.ContainsKey("natureOfSuit"));
        Assert.Null(model.PacerCaseID);
        Assert.True(model.RawData.ContainsKey("pacerCaseId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Docket
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",

            AssignedTo = null,
            CaseName = null,
            Cause = null,
            Court = null,
            CourtID = null,
            DateFiled = null,
            DateTerminated = null,
            DocketNumber = null,
            NatureOfSuit = null,
            PacerCaseID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Docket
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        Docket copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1DocketResponseDocketTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1DocketResponseDocket
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        string expectedID = "id";
        string expectedAssignedTo = "assignedTo";
        string expectedCaseName = "caseName";
        string expectedCause = "cause";
        string expectedCourt = "court";
        string expectedCourtID = "courtId";
        string expectedDateFiled = "2019-12-27";
        string expectedDateTerminated = "2019-12-27";
        string expectedDocketNumber = "docketNumber";
        string expectedNatureOfSuit = "natureOfSuit";
        string expectedPacerCaseID = "pacerCaseId";
        List<string> expectedParties = ["string"];
        string expectedUrl = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAssignedTo, model.AssignedTo);
        Assert.Equal(expectedCaseName, model.CaseName);
        Assert.Equal(expectedCause, model.Cause);
        Assert.Equal(expectedCourt, model.Court);
        Assert.Equal(expectedCourtID, model.CourtID);
        Assert.Equal(expectedDateFiled, model.DateFiled);
        Assert.Equal(expectedDateTerminated, model.DateTerminated);
        Assert.Equal(expectedDocketNumber, model.DocketNumber);
        Assert.Equal(expectedNatureOfSuit, model.NatureOfSuit);
        Assert.Equal(expectedPacerCaseID, model.PacerCaseID);
        Assert.NotNull(model.Parties);
        Assert.Equal(expectedParties.Count, model.Parties.Count);
        for (int i = 0; i < expectedParties.Count; i++)
        {
            Assert.Equal(expectedParties[i], model.Parties[i]);
        }
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1DocketResponseDocket
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DocketResponseDocket>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1DocketResponseDocket
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1DocketResponseDocket>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAssignedTo = "assignedTo";
        string expectedCaseName = "caseName";
        string expectedCause = "cause";
        string expectedCourt = "court";
        string expectedCourtID = "courtId";
        string expectedDateFiled = "2019-12-27";
        string expectedDateTerminated = "2019-12-27";
        string expectedDocketNumber = "docketNumber";
        string expectedNatureOfSuit = "natureOfSuit";
        string expectedPacerCaseID = "pacerCaseId";
        List<string> expectedParties = ["string"];
        string expectedUrl = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAssignedTo, deserialized.AssignedTo);
        Assert.Equal(expectedCaseName, deserialized.CaseName);
        Assert.Equal(expectedCause, deserialized.Cause);
        Assert.Equal(expectedCourt, deserialized.Court);
        Assert.Equal(expectedCourtID, deserialized.CourtID);
        Assert.Equal(expectedDateFiled, deserialized.DateFiled);
        Assert.Equal(expectedDateTerminated, deserialized.DateTerminated);
        Assert.Equal(expectedDocketNumber, deserialized.DocketNumber);
        Assert.Equal(expectedNatureOfSuit, deserialized.NatureOfSuit);
        Assert.Equal(expectedPacerCaseID, deserialized.PacerCaseID);
        Assert.NotNull(deserialized.Parties);
        Assert.Equal(expectedParties.Count, deserialized.Parties.Count);
        for (int i = 0; i < expectedParties.Count; i++)
        {
            Assert.Equal(expectedParties[i], deserialized.Parties[i]);
        }
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1DocketResponseDocket
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1DocketResponseDocket
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Parties);
        Assert.False(model.RawData.ContainsKey("parties"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1DocketResponseDocket
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1DocketResponseDocket
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Parties = null,
            Url = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Parties);
        Assert.False(model.RawData.ContainsKey("parties"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1DocketResponseDocket
        {
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Parties = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1DocketResponseDocket
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",
        };

        Assert.Null(model.AssignedTo);
        Assert.False(model.RawData.ContainsKey("assignedTo"));
        Assert.Null(model.CaseName);
        Assert.False(model.RawData.ContainsKey("caseName"));
        Assert.Null(model.Cause);
        Assert.False(model.RawData.ContainsKey("cause"));
        Assert.Null(model.Court);
        Assert.False(model.RawData.ContainsKey("court"));
        Assert.Null(model.CourtID);
        Assert.False(model.RawData.ContainsKey("courtId"));
        Assert.Null(model.DateFiled);
        Assert.False(model.RawData.ContainsKey("dateFiled"));
        Assert.Null(model.DateTerminated);
        Assert.False(model.RawData.ContainsKey("dateTerminated"));
        Assert.Null(model.DocketNumber);
        Assert.False(model.RawData.ContainsKey("docketNumber"));
        Assert.Null(model.NatureOfSuit);
        Assert.False(model.RawData.ContainsKey("natureOfSuit"));
        Assert.Null(model.PacerCaseID);
        Assert.False(model.RawData.ContainsKey("pacerCaseId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1DocketResponseDocket
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new V1DocketResponseDocket
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",

            AssignedTo = null,
            CaseName = null,
            Cause = null,
            Court = null,
            CourtID = null,
            DateFiled = null,
            DateTerminated = null,
            DocketNumber = null,
            NatureOfSuit = null,
            PacerCaseID = null,
        };

        Assert.Null(model.AssignedTo);
        Assert.True(model.RawData.ContainsKey("assignedTo"));
        Assert.Null(model.CaseName);
        Assert.True(model.RawData.ContainsKey("caseName"));
        Assert.Null(model.Cause);
        Assert.True(model.RawData.ContainsKey("cause"));
        Assert.Null(model.Court);
        Assert.True(model.RawData.ContainsKey("court"));
        Assert.Null(model.CourtID);
        Assert.True(model.RawData.ContainsKey("courtId"));
        Assert.Null(model.DateFiled);
        Assert.True(model.RawData.ContainsKey("dateFiled"));
        Assert.Null(model.DateTerminated);
        Assert.True(model.RawData.ContainsKey("dateTerminated"));
        Assert.Null(model.DocketNumber);
        Assert.True(model.RawData.ContainsKey("docketNumber"));
        Assert.Null(model.NatureOfSuit);
        Assert.True(model.RawData.ContainsKey("natureOfSuit"));
        Assert.Null(model.PacerCaseID);
        Assert.True(model.RawData.ContainsKey("pacerCaseId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1DocketResponseDocket
        {
            ID = "id",
            Parties = ["string"],
            Url = "url",

            AssignedTo = null,
            CaseName = null,
            Cause = null,
            Court = null,
            CourtID = null,
            DateFiled = null,
            DateTerminated = null,
            DocketNumber = null,
            NatureOfSuit = null,
            PacerCaseID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1DocketResponseDocket
        {
            ID = "id",
            AssignedTo = "assignedTo",
            CaseName = "caseName",
            Cause = "cause",
            Court = "court",
            CourtID = "courtId",
            DateFiled = "2019-12-27",
            DateTerminated = "2019-12-27",
            DocketNumber = "docketNumber",
            NatureOfSuit = "natureOfSuit",
            PacerCaseID = "pacerCaseId",
            Parties = ["string"],
            Url = "url",
        };

        V1DocketResponseDocket copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entry
        {
            Date = "2019-12-27",
            Description = "description",
            Documents =
            [
                new()
                {
                    ID = "id",
                    AttachmentNumber = 0,
                    Description = "description",
                    DocumentNumber = "documentNumber",
                    IsAvailable = true,
                    PageCount = 0,
                    PdfUrl = "pdfUrl",
                },
            ],
            EntryNumber = 0,
        };

        string expectedDate = "2019-12-27";
        string expectedDescription = "description";
        List<Document> expectedDocuments =
        [
            new()
            {
                ID = "id",
                AttachmentNumber = 0,
                Description = "description",
                DocumentNumber = "documentNumber",
                IsAvailable = true,
                PageCount = 0,
                PdfUrl = "pdfUrl",
            },
        ];
        long expectedEntryNumber = 0;

        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Documents);
        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
        Assert.Equal(expectedEntryNumber, model.EntryNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entry
        {
            Date = "2019-12-27",
            Description = "description",
            Documents =
            [
                new()
                {
                    ID = "id",
                    AttachmentNumber = 0,
                    Description = "description",
                    DocumentNumber = "documentNumber",
                    IsAvailable = true,
                    PageCount = 0,
                    PdfUrl = "pdfUrl",
                },
            ],
            EntryNumber = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entry>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entry
        {
            Date = "2019-12-27",
            Description = "description",
            Documents =
            [
                new()
                {
                    ID = "id",
                    AttachmentNumber = 0,
                    Description = "description",
                    DocumentNumber = "documentNumber",
                    IsAvailable = true,
                    PageCount = 0,
                    PdfUrl = "pdfUrl",
                },
            ],
            EntryNumber = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entry>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDate = "2019-12-27";
        string expectedDescription = "description";
        List<Document> expectedDocuments =
        [
            new()
            {
                ID = "id",
                AttachmentNumber = 0,
                Description = "description",
                DocumentNumber = "documentNumber",
                IsAvailable = true,
                PageCount = 0,
                PdfUrl = "pdfUrl",
            },
        ];
        long expectedEntryNumber = 0;

        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Documents);
        Assert.Equal(expectedDocuments.Count, deserialized.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], deserialized.Documents[i]);
        }
        Assert.Equal(expectedEntryNumber, deserialized.EntryNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entry
        {
            Date = "2019-12-27",
            Description = "description",
            Documents =
            [
                new()
                {
                    ID = "id",
                    AttachmentNumber = 0,
                    Description = "description",
                    DocumentNumber = "documentNumber",
                    IsAvailable = true,
                    PageCount = 0,
                    PdfUrl = "pdfUrl",
                },
            ],
            EntryNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entry
        {
            Date = "2019-12-27",
            Description = "description",
            EntryNumber = 0,
        };

        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entry
        {
            Date = "2019-12-27",
            Description = "description",
            EntryNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Entry
        {
            Date = "2019-12-27",
            Description = "description",
            EntryNumber = 0,

            // Null should be interpreted as omitted for these properties
            Documents = null,
        };

        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entry
        {
            Date = "2019-12-27",
            Description = "description",
            EntryNumber = 0,

            // Null should be interpreted as omitted for these properties
            Documents = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entry
        {
            Documents =
            [
                new()
                {
                    ID = "id",
                    AttachmentNumber = 0,
                    Description = "description",
                    DocumentNumber = "documentNumber",
                    IsAvailable = true,
                    PageCount = 0,
                    PdfUrl = "pdfUrl",
                },
            ],
        };

        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EntryNumber);
        Assert.False(model.RawData.ContainsKey("entryNumber"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entry
        {
            Documents =
            [
                new()
                {
                    ID = "id",
                    AttachmentNumber = 0,
                    Description = "description",
                    DocumentNumber = "documentNumber",
                    IsAvailable = true,
                    PageCount = 0,
                    PdfUrl = "pdfUrl",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Entry
        {
            Documents =
            [
                new()
                {
                    ID = "id",
                    AttachmentNumber = 0,
                    Description = "description",
                    DocumentNumber = "documentNumber",
                    IsAvailable = true,
                    PageCount = 0,
                    PdfUrl = "pdfUrl",
                },
            ],

            Date = null,
            Description = null,
            EntryNumber = null,
        };

        Assert.Null(model.Date);
        Assert.True(model.RawData.ContainsKey("date"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.EntryNumber);
        Assert.True(model.RawData.ContainsKey("entryNumber"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entry
        {
            Documents =
            [
                new()
                {
                    ID = "id",
                    AttachmentNumber = 0,
                    Description = "description",
                    DocumentNumber = "documentNumber",
                    IsAvailable = true,
                    PageCount = 0,
                    PdfUrl = "pdfUrl",
                },
            ],

            Date = null,
            Description = null,
            EntryNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entry
        {
            Date = "2019-12-27",
            Description = "description",
            Documents =
            [
                new()
                {
                    ID = "id",
                    AttachmentNumber = 0,
                    Description = "description",
                    DocumentNumber = "documentNumber",
                    IsAvailable = true,
                    PageCount = 0,
                    PdfUrl = "pdfUrl",
                },
            ],
            EntryNumber = 0,
        };

        Entry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Document
        {
            ID = "id",
            AttachmentNumber = 0,
            Description = "description",
            DocumentNumber = "documentNumber",
            IsAvailable = true,
            PageCount = 0,
            PdfUrl = "pdfUrl",
        };

        string expectedID = "id";
        long expectedAttachmentNumber = 0;
        string expectedDescription = "description";
        string expectedDocumentNumber = "documentNumber";
        bool expectedIsAvailable = true;
        long expectedPageCount = 0;
        string expectedPdfUrl = "pdfUrl";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttachmentNumber, model.AttachmentNumber);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDocumentNumber, model.DocumentNumber);
        Assert.Equal(expectedIsAvailable, model.IsAvailable);
        Assert.Equal(expectedPageCount, model.PageCount);
        Assert.Equal(expectedPdfUrl, model.PdfUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Document
        {
            ID = "id",
            AttachmentNumber = 0,
            Description = "description",
            DocumentNumber = "documentNumber",
            IsAvailable = true,
            PageCount = 0,
            PdfUrl = "pdfUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Document>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Document
        {
            ID = "id",
            AttachmentNumber = 0,
            Description = "description",
            DocumentNumber = "documentNumber",
            IsAvailable = true,
            PageCount = 0,
            PdfUrl = "pdfUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Document>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedAttachmentNumber = 0;
        string expectedDescription = "description";
        string expectedDocumentNumber = "documentNumber";
        bool expectedIsAvailable = true;
        long expectedPageCount = 0;
        string expectedPdfUrl = "pdfUrl";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttachmentNumber, deserialized.AttachmentNumber);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDocumentNumber, deserialized.DocumentNumber);
        Assert.Equal(expectedIsAvailable, deserialized.IsAvailable);
        Assert.Equal(expectedPageCount, deserialized.PageCount);
        Assert.Equal(expectedPdfUrl, deserialized.PdfUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Document
        {
            ID = "id",
            AttachmentNumber = 0,
            Description = "description",
            DocumentNumber = "documentNumber",
            IsAvailable = true,
            PageCount = 0,
            PdfUrl = "pdfUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Document
        {
            AttachmentNumber = 0,
            Description = "description",
            DocumentNumber = "documentNumber",
            PageCount = 0,
            PdfUrl = "pdfUrl",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.IsAvailable);
        Assert.False(model.RawData.ContainsKey("isAvailable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Document
        {
            AttachmentNumber = 0,
            Description = "description",
            DocumentNumber = "documentNumber",
            PageCount = 0,
            PdfUrl = "pdfUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Document
        {
            AttachmentNumber = 0,
            Description = "description",
            DocumentNumber = "documentNumber",
            PageCount = 0,
            PdfUrl = "pdfUrl",

            // Null should be interpreted as omitted for these properties
            ID = null,
            IsAvailable = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.IsAvailable);
        Assert.False(model.RawData.ContainsKey("isAvailable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Document
        {
            AttachmentNumber = 0,
            Description = "description",
            DocumentNumber = "documentNumber",
            PageCount = 0,
            PdfUrl = "pdfUrl",

            // Null should be interpreted as omitted for these properties
            ID = null,
            IsAvailable = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Document { ID = "id", IsAvailable = true };

        Assert.Null(model.AttachmentNumber);
        Assert.False(model.RawData.ContainsKey("attachmentNumber"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DocumentNumber);
        Assert.False(model.RawData.ContainsKey("documentNumber"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.PdfUrl);
        Assert.False(model.RawData.ContainsKey("pdfUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Document { ID = "id", IsAvailable = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Document
        {
            ID = "id",
            IsAvailable = true,

            AttachmentNumber = null,
            Description = null,
            DocumentNumber = null,
            PageCount = null,
            PdfUrl = null,
        };

        Assert.Null(model.AttachmentNumber);
        Assert.True(model.RawData.ContainsKey("attachmentNumber"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.DocumentNumber);
        Assert.True(model.RawData.ContainsKey("documentNumber"));
        Assert.Null(model.PageCount);
        Assert.True(model.RawData.ContainsKey("pageCount"));
        Assert.Null(model.PdfUrl);
        Assert.True(model.RawData.ContainsKey("pdfUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Document
        {
            ID = "id",
            IsAvailable = true,

            AttachmentNumber = null,
            Description = null,
            DocumentNumber = null,
            PageCount = null,
            PdfUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Document
        {
            ID = "id",
            AttachmentNumber = 0,
            Description = "description",
            DocumentNumber = "documentNumber",
            IsAvailable = true,
            PageCount = 0,
            PdfUrl = "pdfUrl",
        };

        Document copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination
        {
            Limit = 0,
            Offset = 0,
            Returned = 0,
        };

        long expectedLimit = 0;
        long expectedOffset = 0;
        long expectedReturned = 0;

        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedOffset, model.Offset);
        Assert.Equal(expectedReturned, model.Returned);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination
        {
            Limit = 0,
            Offset = 0,
            Returned = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination
        {
            Limit = 0,
            Offset = 0,
            Returned = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedLimit = 0;
        long expectedOffset = 0;
        long expectedReturned = 0;

        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedOffset, deserialized.Offset);
        Assert.Equal(expectedReturned, deserialized.Returned);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination
        {
            Limit = 0,
            Offset = 0,
            Returned = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pagination { };

        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Offset);
        Assert.False(model.RawData.ContainsKey("offset"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pagination { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Pagination
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
            Returned = null,
        };

        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Offset);
        Assert.False(model.RawData.ContainsKey("offset"));
        Assert.Null(model.Returned);
        Assert.False(model.RawData.ContainsKey("returned"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pagination
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
            Returned = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination
        {
            Limit = 0,
            Offset = 0,
            Returned = 0,
        };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1DocketResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(V1DocketResponseType.Search)]
    [InlineData(V1DocketResponseType.Lookup)]
    public void Validation_Works(V1DocketResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1DocketResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1DocketResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1DocketResponseType.Search)]
    [InlineData(V1DocketResponseType.Lookup)]
    public void SerializationRoundtrip_Works(V1DocketResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1DocketResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1DocketResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1DocketResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, V1DocketResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
