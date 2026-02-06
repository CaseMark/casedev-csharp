using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CaseDev.Core;
using CaseDev.Exceptions;

namespace CaseDev.Models.Vault;

/// <summary>
/// Confirm whether a direct-to-S3 vault upload succeeded or failed. This endpoint
/// emits vault.upload.completed or vault.upload.failed events and is idempotent for
/// repeated confirmations.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VaultConfirmUploadParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string ID { get; init; }

    public string? ObjectID { get; init; }

    public required Body Body
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Body>("body");
        }
        init { this._rawBodyData.Set("body", value); }
    }

    public VaultConfirmUploadParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultConfirmUploadParams(VaultConfirmUploadParams vaultConfirmUploadParams)
        : base(vaultConfirmUploadParams)
    {
        this.ID = vaultConfirmUploadParams.ID;
        this.ObjectID = vaultConfirmUploadParams.ObjectID;

        this._rawBodyData = new(vaultConfirmUploadParams._rawBodyData);
    }
#pragma warning restore CS8618

    public VaultConfirmUploadParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultConfirmUploadParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static VaultConfirmUploadParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["ID"] = this.ID,
                ["ObjectID"] = this.ObjectID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(VaultConfirmUploadParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ID.Equals(other.ID)
            && (this.ObjectID?.Equals(other.ObjectID) ?? other.ObjectID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/vault/{0}/upload/{1}/confirm", this.ID, this.ObjectID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(BodyConverter))]
public record class Body : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? SizeBytes
    {
        get
        {
            return Match<long?>(unionMember0: (x) => x.SizeBytes, unionMember1: (x) => x.SizeBytes);
        }
    }

    public string? ErrorCode
    {
        get
        {
            return Match<string?>(
                unionMember0: (x) => x.ErrorCode,
                unionMember1: (x) => x.ErrorCode
            );
        }
    }

    public string? ErrorMessage
    {
        get
        {
            return Match<string?>(
                unionMember0: (x) => x.ErrorMessage,
                unionMember1: (x) => x.ErrorMessage
            );
        }
    }

    public string? Etag
    {
        get { return Match<string?>(unionMember0: (x) => x.Etag, unionMember1: (x) => x.Etag); }
    }

    public Body(UnionMember0 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(UnionMember1 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember0"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember0(out var value)) {
    ///     // `value` is of type `UnionMember0`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember0([NotNullWhen(true)] out UnionMember0? value)
    {
        value = this.Value as UnionMember0;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember1"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember1(out var value)) {
    ///     // `value` is of type `UnionMember1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value = this.Value as UnionMember1;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="CasedevInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (UnionMember0 value) => {...},
    ///     (UnionMember1 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<UnionMember0> unionMember0, Action<UnionMember1> unionMember1)
    {
        switch (this.Value)
        {
            case UnionMember0 value:
                unionMember0(value);
                break;
            case UnionMember1 value:
                unionMember1(value);
                break;
            default:
                throw new CasedevInvalidDataException("Data did not match any variant of Body");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="CasedevInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (UnionMember0 value) => {...},
    ///     (UnionMember1 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<UnionMember0, T> unionMember0, Func<UnionMember1, T> unionMember1)
    {
        return this.Value switch
        {
            UnionMember0 value => unionMember0(value),
            UnionMember1 value => unionMember1(value),
            _ => throw new CasedevInvalidDataException("Data did not match any variant of Body"),
        };
    }

    public static implicit operator Body(UnionMember0 value) => new(value);

    public static implicit operator Body(UnionMember1 value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="CasedevInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new CasedevInvalidDataException("Data did not match any variant of Body");
        }
        this.Switch(
            (unionMember0) => unionMember0.Validate(),
            (unionMember1) => unionMember1.Validate()
        );
    }

    public virtual bool Equals(Body? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            UnionMember0 _ => 0,
            UnionMember1 _ => 1,
            _ => -1,
        };
    }
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember0>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is CasedevInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<UnionMember0, UnionMember0FromRaw>))]
public sealed record class UnionMember0 : JsonModel
{
    /// <summary>
    /// Uploaded file size in bytes (required when success=true)
    /// </summary>
    public required long SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sizeBytes");
        }
        init { this._rawData.Set("sizeBytes", value); }
    }

    public required ApiEnum<bool, Success> Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<bool, Success>>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// Client-side error code (required when success=false)
    /// </summary>
    public string? ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("errorCode", value);
        }
    }

    /// <summary>
    /// Client-side error message (required when success=false)
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorMessage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("errorMessage", value);
        }
    }

    /// <summary>
    /// S3 ETag for the uploaded object (optional if client cannot access ETag header)
    /// </summary>
    public string? Etag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("etag");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("etag", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SizeBytes;
        this.Success.Validate();
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        _ = this.Etag;
    }

    public UnionMember0() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember0(UnionMember0 unionMember0)
        : base(unionMember0) { }
#pragma warning restore CS8618

    public UnionMember0(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember0(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember0FromRaw.FromRawUnchecked"/>
    public static UnionMember0 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember0FromRaw : IFromRawJson<UnionMember0>
{
    /// <inheritdoc/>
    public UnionMember0 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember0.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SuccessConverter))]
public enum Success
{
    True,
}

sealed class SuccessConverter : JsonConverter<Success>
{
    public override Success Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => Success.True,
            _ => (Success)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Success value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Success.True => true,
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<UnionMember1, UnionMember1FromRaw>))]
public sealed record class UnionMember1 : JsonModel
{
    /// <summary>
    /// Client-side error code (required when success=false)
    /// </summary>
    public required string ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("errorCode");
        }
        init { this._rawData.Set("errorCode", value); }
    }

    /// <summary>
    /// Client-side error message (required when success=false)
    /// </summary>
    public required string ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("errorMessage");
        }
        init { this._rawData.Set("errorMessage", value); }
    }

    public required ApiEnum<bool, UnionMember1Success> Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<bool, UnionMember1Success>>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// S3 ETag for the uploaded object (optional if client cannot access ETag header)
    /// </summary>
    public string? Etag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("etag");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("etag", value);
        }
    }

    /// <summary>
    /// Uploaded file size in bytes (required when success=true)
    /// </summary>
    public long? SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sizeBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sizeBytes", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        this.Success.Validate();
        _ = this.Etag;
        _ = this.SizeBytes;
    }

    public UnionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember1(UnionMember1 unionMember1)
        : base(unionMember1) { }
#pragma warning restore CS8618

    public UnionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionMember1FromRaw : IFromRawJson<UnionMember1>
{
    /// <inheritdoc/>
    public UnionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionMember1SuccessConverter))]
public enum UnionMember1Success
{
    False,
}

sealed class UnionMember1SuccessConverter : JsonConverter<UnionMember1Success>
{
    public override UnionMember1Success Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            false => UnionMember1Success.False,
            _ => (UnionMember1Success)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember1Success value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember1Success.False => false,
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
