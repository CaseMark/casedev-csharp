using System;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Vault;

namespace Casedev.Tests.Models.Vault;

public class VaultSearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultSearchParams
        {
            ID = "id",
            Query = "query",
            Filters = new() { ObjectID = "string" },
            Method = Method.Vector,
            TopK = 1,
        };

        string expectedID = "id";
        string expectedQuery = "query";
        Filters expectedFilters = new() { ObjectID = "string" };
        ApiEnum<string, Method> expectedMethod = Method.Vector;
        long expectedTopK = 1;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedFilters, parameters.Filters);
        Assert.Equal(expectedMethod, parameters.Method);
        Assert.Equal(expectedTopK, parameters.TopK);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VaultSearchParams { ID = "id", Query = "query" };

        Assert.Null(parameters.Filters);
        Assert.False(parameters.RawBodyData.ContainsKey("filters"));
        Assert.Null(parameters.Method);
        Assert.False(parameters.RawBodyData.ContainsKey("method"));
        Assert.Null(parameters.TopK);
        Assert.False(parameters.RawBodyData.ContainsKey("topK"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VaultSearchParams
        {
            ID = "id",
            Query = "query",

            // Null should be interpreted as omitted for these properties
            Filters = null,
            Method = null,
            TopK = null,
        };

        Assert.Null(parameters.Filters);
        Assert.False(parameters.RawBodyData.ContainsKey("filters"));
        Assert.Null(parameters.Method);
        Assert.False(parameters.RawBodyData.ContainsKey("method"));
        Assert.Null(parameters.TopK);
        Assert.False(parameters.RawBodyData.ContainsKey("topK"));
    }

    [Fact]
    public void Url_Works()
    {
        VaultSearchParams parameters = new() { ID = "id", Query = "query" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/vault/id/search"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VaultSearchParams
        {
            ID = "id",
            Query = "query",
            Filters = new() { ObjectID = "string" },
            Method = Method.Vector,
            TopK = 1,
        };

        VaultSearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filters { ObjectID = "string" };

        ObjectID expectedObjectID = "string";

        Assert.Equal(expectedObjectID, model.ObjectID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Filters { ObjectID = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filters>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filters { ObjectID = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ObjectID expectedObjectID = "string";

        Assert.Equal(expectedObjectID, deserialized.ObjectID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Filters { ObjectID = "string" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Filters { };

        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("object_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Filters { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Filters
        {
            // Null should be interpreted as omitted for these properties
            ObjectID = null,
        };

        Assert.Null(model.ObjectID);
        Assert.False(model.RawData.ContainsKey("object_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Filters
        {
            // Null should be interpreted as omitted for these properties
            ObjectID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Filters { ObjectID = "string" };

        Filters copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ObjectIDTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ObjectID value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        ObjectID value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ObjectID value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectID>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        ObjectID value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectID>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MethodTest : TestBase
{
    [Theory]
    [InlineData(Method.Vector)]
    [InlineData(Method.Graph)]
    [InlineData(Method.Hybrid)]
    [InlineData(Method.Global)]
    [InlineData(Method.Local)]
    [InlineData(Method.Fast)]
    [InlineData(Method.Entity)]
    public void Validation_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Method.Vector)]
    [InlineData(Method.Graph)]
    [InlineData(Method.Hybrid)]
    [InlineData(Method.Global)]
    [InlineData(Method.Local)]
    [InlineData(Method.Fast)]
    [InlineData(Method.Entity)]
    public void SerializationRoundtrip_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
