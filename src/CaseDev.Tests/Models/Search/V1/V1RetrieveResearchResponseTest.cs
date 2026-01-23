using System;
using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Search.V1;

namespace CaseDev.Tests.Models.Search.V1;

public class V1RetrieveResearchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1RetrieveResearchResponse
        {
            ID = "id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = V1RetrieveResearchResponseModel.Fast,
            Progress = 0,
            Query = "query",
            Results = new()
            {
                Sections =
                [
                    new()
                    {
                        Content = "content",
                        Sources =
                        [
                            new()
                            {
                                Snippet = "snippet",
                                Title = "title",
                                Url = "url",
                            },
                        ],
                        Title = "title",
                    },
                ],
                Sources =
                [
                    new()
                    {
                        Snippet = "snippet",
                        Title = "title",
                        Url = "url",
                    },
                ],
                Summary = "summary",
            },
            Status = Status.Pending,
        };

        string expectedID = "id";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, V1RetrieveResearchResponseModel> expectedModel =
            V1RetrieveResearchResponseModel.Fast;
        double expectedProgress = 0;
        string expectedQuery = "query";
        Results expectedResults = new()
        {
            Sections =
            [
                new()
                {
                    Content = "content",
                    Sources =
                    [
                        new()
                        {
                            Snippet = "snippet",
                            Title = "title",
                            Url = "url",
                        },
                    ],
                    Title = "title",
                },
            ],
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Summary = "summary",
        };
        ApiEnum<string, Status> expectedStatus = Status.Pending;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedProgress, model.Progress);
        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedResults, model.Results);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1RetrieveResearchResponse
        {
            ID = "id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = V1RetrieveResearchResponseModel.Fast,
            Progress = 0,
            Query = "query",
            Results = new()
            {
                Sections =
                [
                    new()
                    {
                        Content = "content",
                        Sources =
                        [
                            new()
                            {
                                Snippet = "snippet",
                                Title = "title",
                                Url = "url",
                            },
                        ],
                        Title = "title",
                    },
                ],
                Sources =
                [
                    new()
                    {
                        Snippet = "snippet",
                        Title = "title",
                        Url = "url",
                    },
                ],
                Summary = "summary",
            },
            Status = Status.Pending,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1RetrieveResearchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1RetrieveResearchResponse
        {
            ID = "id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = V1RetrieveResearchResponseModel.Fast,
            Progress = 0,
            Query = "query",
            Results = new()
            {
                Sections =
                [
                    new()
                    {
                        Content = "content",
                        Sources =
                        [
                            new()
                            {
                                Snippet = "snippet",
                                Title = "title",
                                Url = "url",
                            },
                        ],
                        Title = "title",
                    },
                ],
                Sources =
                [
                    new()
                    {
                        Snippet = "snippet",
                        Title = "title",
                        Url = "url",
                    },
                ],
                Summary = "summary",
            },
            Status = Status.Pending,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1RetrieveResearchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, V1RetrieveResearchResponseModel> expectedModel =
            V1RetrieveResearchResponseModel.Fast;
        double expectedProgress = 0;
        string expectedQuery = "query";
        Results expectedResults = new()
        {
            Sections =
            [
                new()
                {
                    Content = "content",
                    Sources =
                    [
                        new()
                        {
                            Snippet = "snippet",
                            Title = "title",
                            Url = "url",
                        },
                    ],
                    Title = "title",
                },
            ],
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Summary = "summary",
        };
        ApiEnum<string, Status> expectedStatus = Status.Pending;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedProgress, deserialized.Progress);
        Assert.Equal(expectedQuery, deserialized.Query);
        Assert.Equal(expectedResults, deserialized.Results);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1RetrieveResearchResponse
        {
            ID = "id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = V1RetrieveResearchResponseModel.Fast,
            Progress = 0,
            Query = "query",
            Results = new()
            {
                Sections =
                [
                    new()
                    {
                        Content = "content",
                        Sources =
                        [
                            new()
                            {
                                Snippet = "snippet",
                                Title = "title",
                                Url = "url",
                            },
                        ],
                        Title = "title",
                    },
                ],
                Sources =
                [
                    new()
                    {
                        Snippet = "snippet",
                        Title = "title",
                        Url = "url",
                    },
                ],
                Summary = "summary",
            },
            Status = Status.Pending,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V1RetrieveResearchResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Progress);
        Assert.False(model.RawData.ContainsKey("progress"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V1RetrieveResearchResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V1RetrieveResearchResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CompletedAt = null,
            CreatedAt = null,
            Model = null,
            Progress = null,
            Query = null,
            Results = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Progress);
        Assert.False(model.RawData.ContainsKey("progress"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V1RetrieveResearchResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CompletedAt = null,
            CreatedAt = null,
            Model = null,
            Progress = null,
            Query = null,
            Results = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1RetrieveResearchResponse
        {
            ID = "id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Model = V1RetrieveResearchResponseModel.Fast,
            Progress = 0,
            Query = "query",
            Results = new()
            {
                Sections =
                [
                    new()
                    {
                        Content = "content",
                        Sources =
                        [
                            new()
                            {
                                Snippet = "snippet",
                                Title = "title",
                                Url = "url",
                            },
                        ],
                        Title = "title",
                    },
                ],
                Sources =
                [
                    new()
                    {
                        Snippet = "snippet",
                        Title = "title",
                        Url = "url",
                    },
                ],
                Summary = "summary",
            },
            Status = Status.Pending,
        };

        V1RetrieveResearchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V1RetrieveResearchResponseModelTest : TestBase
{
    [Theory]
    [InlineData(V1RetrieveResearchResponseModel.Fast)]
    [InlineData(V1RetrieveResearchResponseModel.Normal)]
    [InlineData(V1RetrieveResearchResponseModel.Pro)]
    public void Validation_Works(V1RetrieveResearchResponseModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1RetrieveResearchResponseModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1RetrieveResearchResponseModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(V1RetrieveResearchResponseModel.Fast)]
    [InlineData(V1RetrieveResearchResponseModel.Normal)]
    [InlineData(V1RetrieveResearchResponseModel.Pro)]
    public void SerializationRoundtrip_Works(V1RetrieveResearchResponseModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, V1RetrieveResearchResponseModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, V1RetrieveResearchResponseModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, V1RetrieveResearchResponseModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, V1RetrieveResearchResponseModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ResultsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Results
        {
            Sections =
            [
                new()
                {
                    Content = "content",
                    Sources =
                    [
                        new()
                        {
                            Snippet = "snippet",
                            Title = "title",
                            Url = "url",
                        },
                    ],
                    Title = "title",
                },
            ],
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Summary = "summary",
        };

        List<Section> expectedSections =
        [
            new()
            {
                Content = "content",
                Sources =
                [
                    new()
                    {
                        Snippet = "snippet",
                        Title = "title",
                        Url = "url",
                    },
                ],
                Title = "title",
            },
        ];
        List<ResultsSource> expectedSources =
        [
            new()
            {
                Snippet = "snippet",
                Title = "title",
                Url = "url",
            },
        ];
        string expectedSummary = "summary";

        Assert.NotNull(model.Sections);
        Assert.Equal(expectedSections.Count, model.Sections.Count);
        for (int i = 0; i < expectedSections.Count; i++)
        {
            Assert.Equal(expectedSections[i], model.Sections[i]);
        }
        Assert.NotNull(model.Sources);
        Assert.Equal(expectedSources.Count, model.Sources.Count);
        for (int i = 0; i < expectedSources.Count; i++)
        {
            Assert.Equal(expectedSources[i], model.Sources[i]);
        }
        Assert.Equal(expectedSummary, model.Summary);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Results
        {
            Sections =
            [
                new()
                {
                    Content = "content",
                    Sources =
                    [
                        new()
                        {
                            Snippet = "snippet",
                            Title = "title",
                            Url = "url",
                        },
                    ],
                    Title = "title",
                },
            ],
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Summary = "summary",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Results>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Results
        {
            Sections =
            [
                new()
                {
                    Content = "content",
                    Sources =
                    [
                        new()
                        {
                            Snippet = "snippet",
                            Title = "title",
                            Url = "url",
                        },
                    ],
                    Title = "title",
                },
            ],
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Summary = "summary",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Results>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Section> expectedSections =
        [
            new()
            {
                Content = "content",
                Sources =
                [
                    new()
                    {
                        Snippet = "snippet",
                        Title = "title",
                        Url = "url",
                    },
                ],
                Title = "title",
            },
        ];
        List<ResultsSource> expectedSources =
        [
            new()
            {
                Snippet = "snippet",
                Title = "title",
                Url = "url",
            },
        ];
        string expectedSummary = "summary";

        Assert.NotNull(deserialized.Sections);
        Assert.Equal(expectedSections.Count, deserialized.Sections.Count);
        for (int i = 0; i < expectedSections.Count; i++)
        {
            Assert.Equal(expectedSections[i], deserialized.Sections[i]);
        }
        Assert.NotNull(deserialized.Sources);
        Assert.Equal(expectedSources.Count, deserialized.Sources.Count);
        for (int i = 0; i < expectedSources.Count; i++)
        {
            Assert.Equal(expectedSources[i], deserialized.Sources[i]);
        }
        Assert.Equal(expectedSummary, deserialized.Summary);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Results
        {
            Sections =
            [
                new()
                {
                    Content = "content",
                    Sources =
                    [
                        new()
                        {
                            Snippet = "snippet",
                            Title = "title",
                            Url = "url",
                        },
                    ],
                    Title = "title",
                },
            ],
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Summary = "summary",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Results { };

        Assert.Null(model.Sections);
        Assert.False(model.RawData.ContainsKey("sections"));
        Assert.Null(model.Sources);
        Assert.False(model.RawData.ContainsKey("sources"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Results { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Results
        {
            // Null should be interpreted as omitted for these properties
            Sections = null,
            Sources = null,
            Summary = null,
        };

        Assert.Null(model.Sections);
        Assert.False(model.RawData.ContainsKey("sections"));
        Assert.Null(model.Sources);
        Assert.False(model.RawData.ContainsKey("sources"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Results
        {
            // Null should be interpreted as omitted for these properties
            Sections = null,
            Sources = null,
            Summary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Results
        {
            Sections =
            [
                new()
                {
                    Content = "content",
                    Sources =
                    [
                        new()
                        {
                            Snippet = "snippet",
                            Title = "title",
                            Url = "url",
                        },
                    ],
                    Title = "title",
                },
            ],
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Summary = "summary",
        };

        Results copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Section
        {
            Content = "content",
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Title = "title",
        };

        string expectedContent = "content";
        List<Source> expectedSources =
        [
            new()
            {
                Snippet = "snippet",
                Title = "title",
                Url = "url",
            },
        ];
        string expectedTitle = "title";

        Assert.Equal(expectedContent, model.Content);
        Assert.NotNull(model.Sources);
        Assert.Equal(expectedSources.Count, model.Sources.Count);
        for (int i = 0; i < expectedSources.Count; i++)
        {
            Assert.Equal(expectedSources[i], model.Sources[i]);
        }
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Section
        {
            Content = "content",
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Section>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Section
        {
            Content = "content",
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Section>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        List<Source> expectedSources =
        [
            new()
            {
                Snippet = "snippet",
                Title = "title",
                Url = "url",
            },
        ];
        string expectedTitle = "title";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.NotNull(deserialized.Sources);
        Assert.Equal(expectedSources.Count, deserialized.Sources.Count);
        for (int i = 0; i < expectedSources.Count; i++)
        {
            Assert.Equal(expectedSources[i], deserialized.Sources[i]);
        }
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Section
        {
            Content = "content",
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Section { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Sources);
        Assert.False(model.RawData.ContainsKey("sources"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Section { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Section
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Sources = null,
            Title = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Sources);
        Assert.False(model.RawData.ContainsKey("sources"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Section
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Sources = null,
            Title = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Section
        {
            Content = "content",
            Sources =
            [
                new()
                {
                    Snippet = "snippet",
                    Title = "title",
                    Url = "url",
                },
            ],
            Title = "title",
        };

        Section copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Source
        {
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        string expectedSnippet = "snippet";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedSnippet, model.Snippet);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Source
        {
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Source
        {
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedSnippet = "snippet";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedSnippet, deserialized.Snippet);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Source
        {
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Source { };

        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Source { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Source
        {
            // Null should be interpreted as omitted for these properties
            Snippet = null,
            Title = null,
            Url = null,
        };

        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Source
        {
            // Null should be interpreted as omitted for these properties
            Snippet = null,
            Title = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Source
        {
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        Source copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultsSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResultsSource
        {
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        string expectedSnippet = "snippet";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedSnippet, model.Snippet);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResultsSource
        {
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResultsSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResultsSource
        {
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResultsSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSnippet = "snippet";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedSnippet, deserialized.Snippet);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ResultsSource
        {
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ResultsSource { };

        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ResultsSource { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ResultsSource
        {
            // Null should be interpreted as omitted for these properties
            Snippet = null,
            Title = null,
            Url = null,
        };

        Assert.Null(model.Snippet);
        Assert.False(model.RawData.ContainsKey("snippet"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ResultsSource
        {
            // Null should be interpreted as omitted for these properties
            Snippet = null,
            Title = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ResultsSource
        {
            Snippet = "snippet",
            Title = "title",
            Url = "url",
        };

        ResultsSource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
