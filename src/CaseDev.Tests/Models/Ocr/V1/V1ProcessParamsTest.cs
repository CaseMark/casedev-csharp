using System.Text.Json;
using CaseDev.Models.Ocr.V1;

namespace CaseDev.Tests.Models.Ocr.V1;

public class FeaturesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Features
        {
            Forms = false,
            Layout = true,
            Tables = true,
            Text = true,
        };

        bool expectedForms = false;
        bool expectedLayout = true;
        bool expectedTables = true;
        bool expectedText = true;

        Assert.Equal(expectedForms, model.Forms);
        Assert.Equal(expectedLayout, model.Layout);
        Assert.Equal(expectedTables, model.Tables);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Features
        {
            Forms = false,
            Layout = true,
            Tables = true,
            Text = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Features>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Features
        {
            Forms = false,
            Layout = true,
            Tables = true,
            Text = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Features>(json);
        Assert.NotNull(deserialized);

        bool expectedForms = false;
        bool expectedLayout = true;
        bool expectedTables = true;
        bool expectedText = true;

        Assert.Equal(expectedForms, deserialized.Forms);
        Assert.Equal(expectedLayout, deserialized.Layout);
        Assert.Equal(expectedTables, deserialized.Tables);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Features
        {
            Forms = false,
            Layout = true,
            Tables = true,
            Text = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Features { };

        Assert.Null(model.Forms);
        Assert.False(model.RawData.ContainsKey("forms"));
        Assert.Null(model.Layout);
        Assert.False(model.RawData.ContainsKey("layout"));
        Assert.Null(model.Tables);
        Assert.False(model.RawData.ContainsKey("tables"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Features { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Features
        {
            // Null should be interpreted as omitted for these properties
            Forms = null,
            Layout = null,
            Tables = null,
            Text = null,
        };

        Assert.Null(model.Forms);
        Assert.False(model.RawData.ContainsKey("forms"));
        Assert.Null(model.Layout);
        Assert.False(model.RawData.ContainsKey("layout"));
        Assert.Null(model.Tables);
        Assert.False(model.RawData.ContainsKey("tables"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Features
        {
            // Null should be interpreted as omitted for these properties
            Forms = null,
            Layout = null,
            Tables = null,
            Text = null,
        };

        model.Validate();
    }
}
