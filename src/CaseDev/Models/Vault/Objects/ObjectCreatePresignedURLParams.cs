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
/// </summary>
public sealed record class ObjectCreatePresignedURLParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
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
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "contentType"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "contentType", value);
        }
    }

    /// <summary>
    /// URL expiration time in seconds (1 minute to 7 days)
    /// </summary>
    public long? ExpiresIn
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "expiresIn"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "expiresIn", value);
        }
    }

    /// <summary>
    /// The S3 operation to generate URL for
    /// </summary>
    public ApiEnum<string, Operation>? Operation
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Operation>>(
                this.RawBodyData,
                "operation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "operation", value);
        }
    }

    public ObjectCreatePresignedURLParams() { }

    public ObjectCreatePresignedURLParams(
        ObjectCreatePresignedURLParams objectCreatePresignedURLParams
    )
        : base(objectCreatePresignedURLParams)
    {
        this._rawBodyData = [.. objectCreatePresignedURLParams._rawBodyData];
    }

    public ObjectCreatePresignedURLParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectCreatePresignedURLParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static ObjectCreatePresignedURLParams FromRawUnchecked(
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

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
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
