using System;
using System.Text.Json;
using Router.Core;
using Router.Models.Translate.V1;

namespace Router.Tests.Models.Translate.V1;

public class V1DetectParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1DetectParams { Q = "string" };

        Q expectedQ = "string";

        Assert.Equal(expectedQ, parameters.Q);
    }

    [Fact]
    public void Url_Works()
    {
        V1DetectParams parameters = new() { Q = "string" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/translate/v1/detect"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1DetectParams { Q = "string" };

        V1DetectParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class QTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Q value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        Q value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Q value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Q>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        Q value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Q>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
