using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Templates.V1;

namespace CaseDev.Tests.Models.Templates.V1;

public class OptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Options { Format = OptionsFormat.Json, Model = "model" };

        ApiEnum<string, OptionsFormat> expectedFormat = OptionsFormat.Json;
        string expectedModel = "model";

        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedModel, model.Model);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Options { Format = OptionsFormat.Json, Model = "model" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Options>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Options { Format = OptionsFormat.Json, Model = "model" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Options>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, OptionsFormat> expectedFormat = OptionsFormat.Json;
        string expectedModel = "model";

        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedModel, deserialized.Model);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Options { Format = OptionsFormat.Json, Model = "model" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Options { };

        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Options { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Options
        {
            // Null should be interpreted as omitted for these properties
            Format = null,
            Model = null,
        };

        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Options
        {
            // Null should be interpreted as omitted for these properties
            Format = null,
            Model = null,
        };

        model.Validate();
    }
}
