using System.Text.Json;
using Casedev.Core;
using Casedev.Models.Voice.Streaming;

namespace Casedev.Tests.Models.Voice.Streaming;

public class StreamingGetUrlResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StreamingGetUrlResponse
        {
            AudioFormat = new()
            {
                Channels = 0,
                Encoding = "encoding",
                SampleRate = 0,
            },
            ConnectUrl = "connect_url",
            Pricing = new()
            {
                Currency = "currency",
                PerHour = 0,
                PerMinute = 0,
            },
            Protocol = "protocol",
            Url = "url",
        };

        AudioFormat expectedAudioFormat = new()
        {
            Channels = 0,
            Encoding = "encoding",
            SampleRate = 0,
        };
        string expectedConnectUrl = "connect_url";
        Pricing expectedPricing = new()
        {
            Currency = "currency",
            PerHour = 0,
            PerMinute = 0,
        };
        string expectedProtocol = "protocol";
        string expectedUrl = "url";

        Assert.Equal(expectedAudioFormat, model.AudioFormat);
        Assert.Equal(expectedConnectUrl, model.ConnectUrl);
        Assert.Equal(expectedPricing, model.Pricing);
        Assert.Equal(expectedProtocol, model.Protocol);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StreamingGetUrlResponse
        {
            AudioFormat = new()
            {
                Channels = 0,
                Encoding = "encoding",
                SampleRate = 0,
            },
            ConnectUrl = "connect_url",
            Pricing = new()
            {
                Currency = "currency",
                PerHour = 0,
                PerMinute = 0,
            },
            Protocol = "protocol",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StreamingGetUrlResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StreamingGetUrlResponse
        {
            AudioFormat = new()
            {
                Channels = 0,
                Encoding = "encoding",
                SampleRate = 0,
            },
            ConnectUrl = "connect_url",
            Pricing = new()
            {
                Currency = "currency",
                PerHour = 0,
                PerMinute = 0,
            },
            Protocol = "protocol",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StreamingGetUrlResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AudioFormat expectedAudioFormat = new()
        {
            Channels = 0,
            Encoding = "encoding",
            SampleRate = 0,
        };
        string expectedConnectUrl = "connect_url";
        Pricing expectedPricing = new()
        {
            Currency = "currency",
            PerHour = 0,
            PerMinute = 0,
        };
        string expectedProtocol = "protocol";
        string expectedUrl = "url";

        Assert.Equal(expectedAudioFormat, deserialized.AudioFormat);
        Assert.Equal(expectedConnectUrl, deserialized.ConnectUrl);
        Assert.Equal(expectedPricing, deserialized.Pricing);
        Assert.Equal(expectedProtocol, deserialized.Protocol);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StreamingGetUrlResponse
        {
            AudioFormat = new()
            {
                Channels = 0,
                Encoding = "encoding",
                SampleRate = 0,
            },
            ConnectUrl = "connect_url",
            Pricing = new()
            {
                Currency = "currency",
                PerHour = 0,
                PerMinute = 0,
            },
            Protocol = "protocol",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StreamingGetUrlResponse { };

        Assert.Null(model.AudioFormat);
        Assert.False(model.RawData.ContainsKey("audio_format"));
        Assert.Null(model.ConnectUrl);
        Assert.False(model.RawData.ContainsKey("connect_url"));
        Assert.Null(model.Pricing);
        Assert.False(model.RawData.ContainsKey("pricing"));
        Assert.Null(model.Protocol);
        Assert.False(model.RawData.ContainsKey("protocol"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StreamingGetUrlResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StreamingGetUrlResponse
        {
            // Null should be interpreted as omitted for these properties
            AudioFormat = null,
            ConnectUrl = null,
            Pricing = null,
            Protocol = null,
            Url = null,
        };

        Assert.Null(model.AudioFormat);
        Assert.False(model.RawData.ContainsKey("audio_format"));
        Assert.Null(model.ConnectUrl);
        Assert.False(model.RawData.ContainsKey("connect_url"));
        Assert.Null(model.Pricing);
        Assert.False(model.RawData.ContainsKey("pricing"));
        Assert.Null(model.Protocol);
        Assert.False(model.RawData.ContainsKey("protocol"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StreamingGetUrlResponse
        {
            // Null should be interpreted as omitted for these properties
            AudioFormat = null,
            ConnectUrl = null,
            Pricing = null,
            Protocol = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StreamingGetUrlResponse
        {
            AudioFormat = new()
            {
                Channels = 0,
                Encoding = "encoding",
                SampleRate = 0,
            },
            ConnectUrl = "connect_url",
            Pricing = new()
            {
                Currency = "currency",
                PerHour = 0,
                PerMinute = 0,
            },
            Protocol = "protocol",
            Url = "url",
        };

        StreamingGetUrlResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AudioFormatTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudioFormat
        {
            Channels = 0,
            Encoding = "encoding",
            SampleRate = 0,
        };

        long expectedChannels = 0;
        string expectedEncoding = "encoding";
        long expectedSampleRate = 0;

        Assert.Equal(expectedChannels, model.Channels);
        Assert.Equal(expectedEncoding, model.Encoding);
        Assert.Equal(expectedSampleRate, model.SampleRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AudioFormat
        {
            Channels = 0,
            Encoding = "encoding",
            SampleRate = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AudioFormat>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudioFormat
        {
            Channels = 0,
            Encoding = "encoding",
            SampleRate = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AudioFormat>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedChannels = 0;
        string expectedEncoding = "encoding";
        long expectedSampleRate = 0;

        Assert.Equal(expectedChannels, deserialized.Channels);
        Assert.Equal(expectedEncoding, deserialized.Encoding);
        Assert.Equal(expectedSampleRate, deserialized.SampleRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AudioFormat
        {
            Channels = 0,
            Encoding = "encoding",
            SampleRate = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AudioFormat { };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.SampleRate);
        Assert.False(model.RawData.ContainsKey("sample_rate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AudioFormat { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AudioFormat
        {
            // Null should be interpreted as omitted for these properties
            Channels = null,
            Encoding = null,
            SampleRate = null,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Encoding);
        Assert.False(model.RawData.ContainsKey("encoding"));
        Assert.Null(model.SampleRate);
        Assert.False(model.RawData.ContainsKey("sample_rate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AudioFormat
        {
            // Null should be interpreted as omitted for these properties
            Channels = null,
            Encoding = null,
            SampleRate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AudioFormat
        {
            Channels = 0,
            Encoding = "encoding",
            SampleRate = 0,
        };

        AudioFormat copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pricing
        {
            Currency = "currency",
            PerHour = 0,
            PerMinute = 0,
        };

        string expectedCurrency = "currency";
        double expectedPerHour = 0;
        double expectedPerMinute = 0;

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedPerHour, model.PerHour);
        Assert.Equal(expectedPerMinute, model.PerMinute);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pricing
        {
            Currency = "currency",
            PerHour = 0,
            PerMinute = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pricing>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pricing
        {
            Currency = "currency",
            PerHour = 0,
            PerMinute = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pricing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrency = "currency";
        double expectedPerHour = 0;
        double expectedPerMinute = 0;

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedPerHour, deserialized.PerHour);
        Assert.Equal(expectedPerMinute, deserialized.PerMinute);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pricing
        {
            Currency = "currency",
            PerHour = 0,
            PerMinute = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pricing { };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.PerHour);
        Assert.False(model.RawData.ContainsKey("per_hour"));
        Assert.Null(model.PerMinute);
        Assert.False(model.RawData.ContainsKey("per_minute"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pricing { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Pricing
        {
            // Null should be interpreted as omitted for these properties
            Currency = null,
            PerHour = null,
            PerMinute = null,
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.PerHour);
        Assert.False(model.RawData.ContainsKey("per_hour"));
        Assert.Null(model.PerMinute);
        Assert.False(model.RawData.ContainsKey("per_minute"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pricing
        {
            // Null should be interpreted as omitted for these properties
            Currency = null,
            PerHour = null,
            PerMinute = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pricing
        {
            Currency = "currency",
            PerHour = 0,
            PerMinute = 0,
        };

        Pricing copied = new(model);

        Assert.Equal(model, copied);
    }
}
