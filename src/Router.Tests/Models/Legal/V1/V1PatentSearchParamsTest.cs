using System;
using System.Text.Json;
using Router.Core;
using Router.Exceptions;
using Router.Models.Legal.V1;

namespace Router.Tests.Models.Legal.V1;

public class V1PatentSearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1PatentSearchParams
        {
            Query = "x",
            ApplicationStatus = "applicationStatus",
            ApplicationType = ApplicationType.Utility,
            Assignee = "assignee",
            FilingDateFrom = "2019-12-27",
            FilingDateTo = "2019-12-27",
            GrantDateFrom = "2019-12-27",
            GrantDateTo = "2019-12-27",
            Inventor = "inventor",
            Limit = 1,
            Offset = 0,
            SortBy = SortBy.FilingDate,
            SortOrder = SortOrder.Asc,
        };

        string expectedQuery = "x";
        string expectedApplicationStatus = "applicationStatus";
        ApiEnum<string, ApplicationType> expectedApplicationType = ApplicationType.Utility;
        string expectedAssignee = "assignee";
        string expectedFilingDateFrom = "2019-12-27";
        string expectedFilingDateTo = "2019-12-27";
        string expectedGrantDateFrom = "2019-12-27";
        string expectedGrantDateTo = "2019-12-27";
        string expectedInventor = "inventor";
        long expectedLimit = 1;
        long expectedOffset = 0;
        ApiEnum<string, SortBy> expectedSortBy = SortBy.FilingDate;
        ApiEnum<string, SortOrder> expectedSortOrder = SortOrder.Asc;

        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedApplicationStatus, parameters.ApplicationStatus);
        Assert.Equal(expectedApplicationType, parameters.ApplicationType);
        Assert.Equal(expectedAssignee, parameters.Assignee);
        Assert.Equal(expectedFilingDateFrom, parameters.FilingDateFrom);
        Assert.Equal(expectedFilingDateTo, parameters.FilingDateTo);
        Assert.Equal(expectedGrantDateFrom, parameters.GrantDateFrom);
        Assert.Equal(expectedGrantDateTo, parameters.GrantDateTo);
        Assert.Equal(expectedInventor, parameters.Inventor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedSortBy, parameters.SortBy);
        Assert.Equal(expectedSortOrder, parameters.SortOrder);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1PatentSearchParams { Query = "x" };

        Assert.Null(parameters.ApplicationStatus);
        Assert.False(parameters.RawBodyData.ContainsKey("applicationStatus"));
        Assert.Null(parameters.ApplicationType);
        Assert.False(parameters.RawBodyData.ContainsKey("applicationType"));
        Assert.Null(parameters.Assignee);
        Assert.False(parameters.RawBodyData.ContainsKey("assignee"));
        Assert.Null(parameters.FilingDateFrom);
        Assert.False(parameters.RawBodyData.ContainsKey("filingDateFrom"));
        Assert.Null(parameters.FilingDateTo);
        Assert.False(parameters.RawBodyData.ContainsKey("filingDateTo"));
        Assert.Null(parameters.GrantDateFrom);
        Assert.False(parameters.RawBodyData.ContainsKey("grantDateFrom"));
        Assert.Null(parameters.GrantDateTo);
        Assert.False(parameters.RawBodyData.ContainsKey("grantDateTo"));
        Assert.Null(parameters.Inventor);
        Assert.False(parameters.RawBodyData.ContainsKey("inventor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.SortBy);
        Assert.False(parameters.RawBodyData.ContainsKey("sortBy"));
        Assert.Null(parameters.SortOrder);
        Assert.False(parameters.RawBodyData.ContainsKey("sortOrder"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1PatentSearchParams
        {
            Query = "x",

            // Null should be interpreted as omitted for these properties
            ApplicationStatus = null,
            ApplicationType = null,
            Assignee = null,
            FilingDateFrom = null,
            FilingDateTo = null,
            GrantDateFrom = null,
            GrantDateTo = null,
            Inventor = null,
            Limit = null,
            Offset = null,
            SortBy = null,
            SortOrder = null,
        };

        Assert.Null(parameters.ApplicationStatus);
        Assert.False(parameters.RawBodyData.ContainsKey("applicationStatus"));
        Assert.Null(parameters.ApplicationType);
        Assert.False(parameters.RawBodyData.ContainsKey("applicationType"));
        Assert.Null(parameters.Assignee);
        Assert.False(parameters.RawBodyData.ContainsKey("assignee"));
        Assert.Null(parameters.FilingDateFrom);
        Assert.False(parameters.RawBodyData.ContainsKey("filingDateFrom"));
        Assert.Null(parameters.FilingDateTo);
        Assert.False(parameters.RawBodyData.ContainsKey("filingDateTo"));
        Assert.Null(parameters.GrantDateFrom);
        Assert.False(parameters.RawBodyData.ContainsKey("grantDateFrom"));
        Assert.Null(parameters.GrantDateTo);
        Assert.False(parameters.RawBodyData.ContainsKey("grantDateTo"));
        Assert.Null(parameters.Inventor);
        Assert.False(parameters.RawBodyData.ContainsKey("inventor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.SortBy);
        Assert.False(parameters.RawBodyData.ContainsKey("sortBy"));
        Assert.Null(parameters.SortOrder);
        Assert.False(parameters.RawBodyData.ContainsKey("sortOrder"));
    }

    [Fact]
    public void Url_Works()
    {
        V1PatentSearchParams parameters = new() { Query = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/patent-search"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1PatentSearchParams
        {
            Query = "x",
            ApplicationStatus = "applicationStatus",
            ApplicationType = ApplicationType.Utility,
            Assignee = "assignee",
            FilingDateFrom = "2019-12-27",
            FilingDateTo = "2019-12-27",
            GrantDateFrom = "2019-12-27",
            GrantDateTo = "2019-12-27",
            Inventor = "inventor",
            Limit = 1,
            Offset = 0,
            SortBy = SortBy.FilingDate,
            SortOrder = SortOrder.Asc,
        };

        V1PatentSearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ApplicationTypeTest : TestBase
{
    [Theory]
    [InlineData(ApplicationType.Utility)]
    [InlineData(ApplicationType.Design)]
    [InlineData(ApplicationType.Plant)]
    [InlineData(ApplicationType.Provisional)]
    [InlineData(ApplicationType.Reissue)]
    public void Validation_Works(ApplicationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApplicationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApplicationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ApplicationType.Utility)]
    [InlineData(ApplicationType.Design)]
    [InlineData(ApplicationType.Plant)]
    [InlineData(ApplicationType.Provisional)]
    [InlineData(ApplicationType.Reissue)]
    public void SerializationRoundtrip_Works(ApplicationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApplicationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApplicationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApplicationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApplicationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SortByTest : TestBase
{
    [Theory]
    [InlineData(SortBy.FilingDate)]
    [InlineData(SortBy.GrantDate)]
    public void Validation_Works(SortBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SortBy.FilingDate)]
    [InlineData(SortBy.GrantDate)]
    public void SerializationRoundtrip_Works(SortBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SortOrderTest : TestBase
{
    [Theory]
    [InlineData(SortOrder.Asc)]
    [InlineData(SortOrder.Desc)]
    public void Validation_Works(SortOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortOrder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SortOrder.Asc)]
    [InlineData(SortOrder.Desc)]
    public void SerializationRoundtrip_Works(SortOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortOrder> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
