using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;
using Router.Exceptions;

namespace Router.Models.Vault;

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
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["ObjectID"] = JsonSerializer.SerializeToElement(this.ObjectID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
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

    public Body(VaultConfirmUploadSuccess value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(VaultConfirmUploadFailure value, JsonElement? element = null)
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
    /// type <see cref="VaultConfirmUploadSuccess"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVaultConfirmUploadSuccess(out var value)) {
    ///     // `value` is of type `VaultConfirmUploadSuccess`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVaultConfirmUploadSuccess(
        [NotNullWhen(true)] out VaultConfirmUploadSuccess? value
    )
    {
        value = this.Value as VaultConfirmUploadSuccess;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VaultConfirmUploadFailure"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVaultConfirmUploadFailure(out var value)) {
    ///     // `value` is of type `VaultConfirmUploadFailure`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVaultConfirmUploadFailure(
        [NotNullWhen(true)] out VaultConfirmUploadFailure? value
    )
    {
        value = this.Value as VaultConfirmUploadFailure;
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
    ///     (VaultConfirmUploadSuccess value) => {...},
    ///     (VaultConfirmUploadFailure value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<VaultConfirmUploadSuccess> vaultConfirmUploadSuccess,
        Action<VaultConfirmUploadFailure> vaultConfirmUploadFailure
    )
    {
        switch (this.Value)
        {
            case VaultConfirmUploadSuccess value:
                vaultConfirmUploadSuccess(value);
                break;
            case VaultConfirmUploadFailure value:
                vaultConfirmUploadFailure(value);
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
    ///     (VaultConfirmUploadSuccess value) => {...},
    ///     (VaultConfirmUploadFailure value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<VaultConfirmUploadSuccess, T> vaultConfirmUploadSuccess,
        Func<VaultConfirmUploadFailure, T> vaultConfirmUploadFailure
    )
    {
        return this.Value switch
        {
            VaultConfirmUploadSuccess value => vaultConfirmUploadSuccess(value),
            VaultConfirmUploadFailure value => vaultConfirmUploadFailure(value),
            _ => throw new CasedevInvalidDataException("Data did not match any variant of Body"),
        };
    }

    public static implicit operator Body(VaultConfirmUploadSuccess value) => new(value);

    public static implicit operator Body(VaultConfirmUploadFailure value) => new(value);

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
            (vaultConfirmUploadSuccess) => vaultConfirmUploadSuccess.Validate(),
            (vaultConfirmUploadFailure) => vaultConfirmUploadFailure.Validate()
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
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            VaultConfirmUploadSuccess _ => 0,
            VaultConfirmUploadFailure _ => 1,
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
            var deserialized = JsonSerializer.Deserialize<VaultConfirmUploadSuccess>(
                element,
                options
            );
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
            var deserialized = JsonSerializer.Deserialize<VaultConfirmUploadFailure>(
                element,
                options
            );
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

[JsonConverter(
    typeof(JsonModelConverter<VaultConfirmUploadSuccess, VaultConfirmUploadSuccessFromRaw>)
)]
public sealed record class VaultConfirmUploadSuccess : JsonModel
{
    /// <summary>
    /// Uploaded file size in bytes
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

    /// <summary>
    /// Whether the upload succeeded
    /// </summary>
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
        _ = this.Etag;
    }

    public VaultConfirmUploadSuccess() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultConfirmUploadSuccess(VaultConfirmUploadSuccess vaultConfirmUploadSuccess)
        : base(vaultConfirmUploadSuccess) { }
#pragma warning restore CS8618

    public VaultConfirmUploadSuccess(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultConfirmUploadSuccess(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultConfirmUploadSuccessFromRaw.FromRawUnchecked"/>
    public static VaultConfirmUploadSuccess FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultConfirmUploadSuccessFromRaw : IFromRawJson<VaultConfirmUploadSuccess>
{
    /// <inheritdoc/>
    public VaultConfirmUploadSuccess FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VaultConfirmUploadSuccess.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the upload succeeded
/// </summary>
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

[JsonConverter(
    typeof(JsonModelConverter<VaultConfirmUploadFailure, VaultConfirmUploadFailureFromRaw>)
)]
public sealed record class VaultConfirmUploadFailure : JsonModel
{
    /// <summary>
    /// Client-side error code
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
    /// Client-side error message
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

    /// <summary>
    /// Whether the upload succeeded
    /// </summary>
    public required ApiEnum<bool, VaultConfirmUploadFailureSuccess> Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<bool, VaultConfirmUploadFailureSuccess>>(
                "success"
            );
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        this.Success.Validate();
    }

    public VaultConfirmUploadFailure() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultConfirmUploadFailure(VaultConfirmUploadFailure vaultConfirmUploadFailure)
        : base(vaultConfirmUploadFailure) { }
#pragma warning restore CS8618

    public VaultConfirmUploadFailure(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultConfirmUploadFailure(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultConfirmUploadFailureFromRaw.FromRawUnchecked"/>
    public static VaultConfirmUploadFailure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultConfirmUploadFailureFromRaw : IFromRawJson<VaultConfirmUploadFailure>
{
    /// <inheritdoc/>
    public VaultConfirmUploadFailure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VaultConfirmUploadFailure.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the upload succeeded
/// </summary>
[JsonConverter(typeof(VaultConfirmUploadFailureSuccessConverter))]
public enum VaultConfirmUploadFailureSuccess
{
    False,
}

sealed class VaultConfirmUploadFailureSuccessConverter
    : JsonConverter<VaultConfirmUploadFailureSuccess>
{
    public override VaultConfirmUploadFailureSuccess Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            false => VaultConfirmUploadFailureSuccess.False,
            _ => (VaultConfirmUploadFailureSuccess)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VaultConfirmUploadFailureSuccess value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VaultConfirmUploadFailureSuccess.False => false,
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
