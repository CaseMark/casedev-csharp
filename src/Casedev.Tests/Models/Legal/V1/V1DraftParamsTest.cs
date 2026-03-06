using System;
using System.Collections.Generic;
using System.Text.Json;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Legal.V1;

namespace Casedev.Tests.Models.Legal.V1;

public class V1DraftParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1DraftParams
        {
            Instructions = "xxxxxxxxxx",
            VaultID = "vault_id",
            Citations = true,
            Format = "format",
            Length = new() { Target = 0, Unit = Unit.Words },
            Model = "model",
            ObjectIds = ["string"],
            OutputName = "output_name",
            OutputType = OutputType.Pdf,
            Verified = true,
        };

        string expectedInstructions = "xxxxxxxxxx";
        string expectedVaultID = "vault_id";
        bool expectedCitations = true;
        string expectedFormat = "format";
        Length expectedLength = new() { Target = 0, Unit = Unit.Words };
        string expectedModel = "model";
        List<string> expectedObjectIds = ["string"];
        string expectedOutputName = "output_name";
        ApiEnum<string, OutputType> expectedOutputType = OutputType.Pdf;
        bool expectedVerified = true;

        Assert.Equal(expectedInstructions, parameters.Instructions);
        Assert.Equal(expectedVaultID, parameters.VaultID);
        Assert.Equal(expectedCitations, parameters.Citations);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedLength, parameters.Length);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.NotNull(parameters.ObjectIds);
        Assert.Equal(expectedObjectIds.Count, parameters.ObjectIds.Count);
        for (int i = 0; i < expectedObjectIds.Count; i++)
        {
            Assert.Equal(expectedObjectIds[i], parameters.ObjectIds[i]);
        }
        Assert.Equal(expectedOutputName, parameters.OutputName);
        Assert.Equal(expectedOutputType, parameters.OutputType);
        Assert.Equal(expectedVerified, parameters.Verified);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1DraftParams
        {
            Instructions = "xxxxxxxxxx",
            VaultID = "vault_id",
            Format = "format",
            Length = new() { Target = 0, Unit = Unit.Words },
            Model = "model",
            ObjectIds = ["string"],
            OutputName = "output_name",
        };

        Assert.Null(parameters.Citations);
        Assert.False(parameters.RawBodyData.ContainsKey("citations"));
        Assert.Null(parameters.OutputType);
        Assert.False(parameters.RawBodyData.ContainsKey("output_type"));
        Assert.Null(parameters.Verified);
        Assert.False(parameters.RawBodyData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new V1DraftParams
        {
            Instructions = "xxxxxxxxxx",
            VaultID = "vault_id",
            Format = "format",
            Length = new() { Target = 0, Unit = Unit.Words },
            Model = "model",
            ObjectIds = ["string"],
            OutputName = "output_name",

            // Null should be interpreted as omitted for these properties
            Citations = null,
            OutputType = null,
            Verified = null,
        };

        Assert.Null(parameters.Citations);
        Assert.False(parameters.RawBodyData.ContainsKey("citations"));
        Assert.Null(parameters.OutputType);
        Assert.False(parameters.RawBodyData.ContainsKey("output_type"));
        Assert.Null(parameters.Verified);
        Assert.False(parameters.RawBodyData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V1DraftParams
        {
            Instructions = "xxxxxxxxxx",
            VaultID = "vault_id",
            Citations = true,
            OutputType = OutputType.Pdf,
            Verified = true,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawBodyData.ContainsKey("format"));
        Assert.Null(parameters.Length);
        Assert.False(parameters.RawBodyData.ContainsKey("length"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.ObjectIds);
        Assert.False(parameters.RawBodyData.ContainsKey("object_ids"));
        Assert.Null(parameters.OutputName);
        Assert.False(parameters.RawBodyData.ContainsKey("output_name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new V1DraftParams
        {
            Instructions = "xxxxxxxxxx",
            VaultID = "vault_id",
            Citations = true,
            OutputType = OutputType.Pdf,
            Verified = true,

            Format = null,
            Length = null,
            Model = null,
            ObjectIds = null,
            OutputName = null,
        };

        Assert.Null(parameters.Format);
        Assert.True(parameters.RawBodyData.ContainsKey("format"));
        Assert.Null(parameters.Length);
        Assert.True(parameters.RawBodyData.ContainsKey("length"));
        Assert.Null(parameters.Model);
        Assert.True(parameters.RawBodyData.ContainsKey("model"));
        Assert.Null(parameters.ObjectIds);
        Assert.True(parameters.RawBodyData.ContainsKey("object_ids"));
        Assert.Null(parameters.OutputName);
        Assert.True(parameters.RawBodyData.ContainsKey("output_name"));
    }

    [Fact]
    public void Url_Works()
    {
        V1DraftParams parameters = new() { Instructions = "xxxxxxxxxx", VaultID = "vault_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.case.dev/legal/v1/draft"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1DraftParams
        {
            Instructions = "xxxxxxxxxx",
            VaultID = "vault_id",
            Citations = true,
            Format = "format",
            Length = new() { Target = 0, Unit = Unit.Words },
            Model = "model",
            ObjectIds = ["string"],
            OutputName = "output_name",
            OutputType = OutputType.Pdf,
            Verified = true,
        };

        V1DraftParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class LengthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Length { Target = 0, Unit = Unit.Words };

        double expectedTarget = 0;
        ApiEnum<string, Unit> expectedUnit = Unit.Words;

        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedUnit, model.Unit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Length { Target = 0, Unit = Unit.Words };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Length>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Length { Target = 0, Unit = Unit.Words };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Length>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedTarget = 0;
        ApiEnum<string, Unit> expectedUnit = Unit.Words;

        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedUnit, deserialized.Unit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Length { Target = 0, Unit = Unit.Words };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Length { };

        Assert.Null(model.Target);
        Assert.False(model.RawData.ContainsKey("target"));
        Assert.Null(model.Unit);
        Assert.False(model.RawData.ContainsKey("unit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Length { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Length
        {
            // Null should be interpreted as omitted for these properties
            Target = null,
            Unit = null,
        };

        Assert.Null(model.Target);
        Assert.False(model.RawData.ContainsKey("target"));
        Assert.Null(model.Unit);
        Assert.False(model.RawData.ContainsKey("unit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Length
        {
            // Null should be interpreted as omitted for these properties
            Target = null,
            Unit = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Length { Target = 0, Unit = Unit.Words };

        Length copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnitTest : TestBase
{
    [Theory]
    [InlineData(Unit.Words)]
    [InlineData(Unit.Pages)]
    public void Validation_Works(Unit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Unit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Unit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Unit.Words)]
    [InlineData(Unit.Pages)]
    public void SerializationRoundtrip_Works(Unit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Unit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Unit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Unit>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Unit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OutputTypeTest : TestBase
{
    [Theory]
    [InlineData(OutputType.Pdf)]
    [InlineData(OutputType.Docx)]
    [InlineData(OutputType.Xlsx)]
    [InlineData(OutputType.Pptx)]
    [InlineData(OutputType.Md)]
    public void Validation_Works(OutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CasedevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputType.Pdf)]
    [InlineData(OutputType.Docx)]
    [InlineData(OutputType.Xlsx)]
    [InlineData(OutputType.Pptx)]
    [InlineData(OutputType.Md)]
    public void SerializationRoundtrip_Works(OutputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OutputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
