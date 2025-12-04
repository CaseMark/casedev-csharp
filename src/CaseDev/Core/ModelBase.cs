using System.Collections.Generic;
using System.Text.Json;
using CaseDev.Exceptions;
using CaseDev.Models.Actions.V1;
using CaseDev.Models.Compute.V1;
using CaseDev.Models.Format.V1;
using CaseDev.Models.Llm.V1;
using CaseDev.Models.Llm.V1.Chat;
using CaseDev.Models.Vault.Objects;
using CaseDev.Models.Voice.V1;
using Environments = CaseDev.Models.Compute.V1.Environments;
using Invoke = CaseDev.Models.Compute.V1.Invoke;
using Speak = CaseDev.Models.Voice.V1.Speak;
using Templates = CaseDev.Models.Format.V1.Templates;
using Transcription = CaseDev.Models.Voice.Transcription;
using V1 = CaseDev.Models.Convert.V1;
using Vault = CaseDev.Models.Vault;

namespace CaseDev.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, GPUType>(),
            new ApiEnumConverter<string, Runtime>(),
            new ApiEnumConverter<string, Environments::Status>(),
            new ApiEnumConverter<string, Invoke::Status>(),
            new ApiEnumConverter<string, Invoke::AsynchronousResponseStatus>(),
            new ApiEnumConverter<string, Invoke::FunctionSuffix>(),
            new ApiEnumConverter<string, V1::V1ProcessResponseStatus>(),
            new ApiEnumConverter<string, V1::Status>(),
            new ApiEnumConverter<string, OutputFormat>(),
            new ApiEnumConverter<string, InputFormat>(),
            new ApiEnumConverter<string, Templates::Type>(),
            new ApiEnumConverter<string, EncodingFormat>(),
            new ApiEnumConverter<string, Role>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Ocr.V1.Status>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Ocr.V1.Type>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Ocr.V1.Engine>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Search.V1.SearchType>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Search.V1.Model>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Search.V1.Type>(),
            new ApiEnumConverter<string, Vault::Status>(),
            new ApiEnumConverter<string, Vault::Method>(),
            new ApiEnumConverter<string, Operation>(),
            new ApiEnumConverter<string, Transcription::Status>(),
            new ApiEnumConverter<string, Sort>(),
            new ApiEnumConverter<string, SortDirection>(),
            new ApiEnumConverter<string, VoiceType>(),
            new ApiEnumConverter<string, Speak::ModelID>(),
            new ApiEnumConverter<string, Speak::OutputFormat>(),
            new ApiEnumConverter<string, Speak::SpeakStreamParamsModelID>(),
            new ApiEnumConverter<string, Speak::SpeakStreamParamsOutputFormat>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Templates.V1.Status>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Templates.V1.OptionsFormat>(),
            new ApiEnumConverter<
                string,
                global::CaseDev.Models.Workflows.V1.V1ExecuteResponseStatus
            >(),
            new ApiEnumConverter<string, global::CaseDev.Models.Workflows.V1.TriggerType>(),
            new ApiEnumConverter<string, global::CaseDev.Models.Workflows.V1.Visibility>(),
            new ApiEnumConverter<
                string,
                global::CaseDev.Models.Workflows.V1.V1UpdateParamsTriggerType
            >(),
            new ApiEnumConverter<
                string,
                global::CaseDev.Models.Workflows.V1.V1UpdateParamsVisibility
            >(),
            new ApiEnumConverter<
                string,
                global::CaseDev.Models.Workflows.V1.V1ListParamsVisibility
            >(),
            new ApiEnumConverter<string, global::CaseDev.Models.Workflows.V1.Status>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    internal static void Set<T>(IDictionary<string, JsonElement> dictionary, string key, T value)
    {
        dictionary[key] = JsonSerializer.SerializeToElement(value, SerializerOptions);
    }

    internal static T GetNotNullClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new CasedevInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T>(element, SerializerOptions)
                ?? throw new CasedevInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new CasedevInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T GetNotNullStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new CasedevInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions)
                ?? throw new CasedevInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new CasedevInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new CasedevInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new CasedevInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
    }

    public virtual bool Equals(ModelBase? other)
    {
        if (other == null || this.RawData.Count != other.RawData.Count)
        {
            return false;
        }

        foreach (var item in this.RawData)
        {
            if (!other.RawData.TryGetValue(item.Key, out var otherValue))
            {
                return false;
            }

            if (!JsonElement.DeepEquals(item.Value, otherValue))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public abstract void Validate();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
interface IFromRaw<T>
{
    /// <summary>
    /// NOTE: This interface is in the style of a factory instance instead of using
    /// abstract static methods because .NET Standard 2.0 doesn't support abstract
    /// static methods.
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
