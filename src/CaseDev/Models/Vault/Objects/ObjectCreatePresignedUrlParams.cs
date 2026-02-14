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

namespace CaseDev.Models.Vault.Objects;

/// <summary>
/// Generate presigned URLs for direct S3 operations (GET, PUT, DELETE, HEAD) on
/// vault objects. This allows secure, time-limited access to files without proxying
/// through the API. Essential for large document uploads/downloads in legal workflows.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ObjectCreatePresignedUrlParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string ID { get; init; }

    public string? ObjectID { get; init; }

    /// <summary>
    /// Content type for PUT operations (optional, defaults to object's content type)
    /// </summary>
    public string? ContentType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("contentType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("contentType", value);
        }
    }

    /// <summary>
    /// URL expiration time in seconds (1 minute to 7 days)
    /// </summary>
    public long? ExpiresIn
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("expiresIn");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("expiresIn", value);
        }
    }

    /// <summary>
    /// The S3 operation to generate URL for
    /// </summary>
    public ApiEnum<string, Operation>? Operation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Operation>>("operation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("operation", value);
        }
    }

    /// <summary>
    /// File size in bytes (optional, max 5GB for single PUT uploads). When provided
    /// for PUT operations, enforces exact file size at S3 level.
    /// </summary>
    public long? SizeBytes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("sizeBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sizeBytes", value);
        }
    }

    public ObjectCreatePresignedUrlParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectCreatePresignedUrlParams(
        ObjectCreatePresignedUrlParams objectCreatePresignedUrlParams
    )
        : base(objectCreatePresignedUrlParams)
    {
        this.ID = objectCreatePresignedUrlParams.ID;
        this.ObjectID = objectCreatePresignedUrlParams.ObjectID;

        this._rawBodyData = new(objectCreatePresignedUrlParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ObjectCreatePresignedUrlParams(
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
    ObjectCreatePresignedUrlParams(
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
    public static ObjectCreatePresignedUrlParams FromRawUnchecked(
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

    public virtual bool Equals(ObjectCreatePresignedUrlParams? other)
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
                + string.Format("/vault/{0}/objects/{1}/presigned-url", this.ID, this.ObjectID)
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

/// <summary>
/// The S3 operation to generate URL for
/// </summary>
[JsonConverter(typeof(OperationConverter))]
public enum Operation
{
    Get,
    Put,
    Delete,
    Head,
}

sealed class OperationConverter : JsonConverter<Operation>
{
    public override Operation Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET" => Operation.Get,
            "PUT" => Operation.Put,
            "DELETE" => Operation.Delete,
            "HEAD" => Operation.Head,
            _ => (Operation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operation.Get => "GET",
                Operation.Put => "PUT",
                Operation.Delete => "DELETE",
                Operation.Head => "HEAD",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
