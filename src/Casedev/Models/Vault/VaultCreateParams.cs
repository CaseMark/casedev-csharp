using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Vault;

/// <summary>
/// Creates a new secure vault with dedicated S3 storage and vector search capabilities.
/// Each vault provides isolated document storage with semantic search, OCR processing,
/// and optional GraphRAG knowledge graph features for legal document analysis and discovery.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VaultCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Display name for the vault
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Optional description of the vault's purpose
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// Optional embedding model for this vault. Defaults to casemark/embed-v1. Determines
    /// the S3 Vectors index dimension and which model is used at both ingest and
    /// search time. The vault is locked to this model after creation — use a re-embed
    /// flow to change later. Ignored when enableIndexing is false. Note: `casemark/llama-nemotron-embed-vl-1b-v2`
    /// is a deprecated alias for `casemark/embed-v1` (retained for SDK backward
    /// compatibility); new integrations should use `casemark/embed-v1` directly.
    /// </summary>
    public ApiEnum<string, EmbeddingModel>? EmbeddingModel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, EmbeddingModel>>(
                "embeddingModel"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("embeddingModel", value);
        }
    }

    /// <summary>
    /// Enable knowledge graph for entity relationship mapping. Only applies when
    /// enableIndexing is true.
    /// </summary>
    public bool? EnableGraph
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("enableGraph");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("enableGraph", value);
        }
    }

    /// <summary>
    /// Enable vector indexing and search capabilities. Set to false for storage-only vaults.
    /// </summary>
    public bool? EnableIndexing
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("enableIndexing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("enableIndexing", value);
        }
    }

    /// <summary>
    /// Assign the vault to a vault group for access control. Required when using
    /// a group-scoped API key.
    /// </summary>
    public string? GroupID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("groupId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("groupId", value);
        }
    }

    /// <summary>
    /// Optional metadata to attach to the vault (e.g., { containsPHI: true } for
    /// HIPAA compliance tracking)
    /// </summary>
    public JsonElement? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("metadata", value);
        }
    }

    public VaultCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultCreateParams(VaultCreateParams vaultCreateParams)
        : base(vaultCreateParams)
    {
        this._rawBodyData = new(vaultCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public VaultCreateParams(
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
    VaultCreateParams(
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

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VaultCreateParams FromRawUnchecked(
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

    public virtual bool Equals(VaultCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/vault")
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
/// Optional embedding model for this vault. Defaults to casemark/embed-v1. Determines
/// the S3 Vectors index dimension and which model is used at both ingest and search
/// time. The vault is locked to this model after creation — use a re-embed flow
/// to change later. Ignored when enableIndexing is false. Note: `casemark/llama-nemotron-embed-vl-1b-v2`
/// is a deprecated alias for `casemark/embed-v1` (retained for SDK backward compatibility);
/// new integrations should use `casemark/embed-v1` directly.
/// </summary>
[JsonConverter(typeof(EmbeddingModelConverter))]
public enum EmbeddingModel
{
    OpenAITextEmbedding3Small,
    OpenAITextEmbedding3Large,
    VoyageVoyage3_5,
    VoyageVoyageLaw2,
    CohereEmbedV4_0,
    GoogleGeminiEmbedding2,
    CasemarkEmbedV1,
    CasemarkLlamaNemotronEmbedVl1bV2,
}

sealed class EmbeddingModelConverter : JsonConverter<EmbeddingModel>
{
    public override EmbeddingModel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai/text-embedding-3-small" => EmbeddingModel.OpenAITextEmbedding3Small,
            "openai/text-embedding-3-large" => EmbeddingModel.OpenAITextEmbedding3Large,
            "voyage/voyage-3.5" => EmbeddingModel.VoyageVoyage3_5,
            "voyage/voyage-law-2" => EmbeddingModel.VoyageVoyageLaw2,
            "cohere/embed-v4.0" => EmbeddingModel.CohereEmbedV4_0,
            "google/gemini-embedding-2" => EmbeddingModel.GoogleGeminiEmbedding2,
            "casemark/embed-v1" => EmbeddingModel.CasemarkEmbedV1,
            "casemark/llama-nemotron-embed-vl-1b-v2" =>
                EmbeddingModel.CasemarkLlamaNemotronEmbedVl1bV2,
            _ => (EmbeddingModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmbeddingModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EmbeddingModel.OpenAITextEmbedding3Small => "openai/text-embedding-3-small",
                EmbeddingModel.OpenAITextEmbedding3Large => "openai/text-embedding-3-large",
                EmbeddingModel.VoyageVoyage3_5 => "voyage/voyage-3.5",
                EmbeddingModel.VoyageVoyageLaw2 => "voyage/voyage-law-2",
                EmbeddingModel.CohereEmbedV4_0 => "cohere/embed-v4.0",
                EmbeddingModel.GoogleGeminiEmbedding2 => "google/gemini-embedding-2",
                EmbeddingModel.CasemarkEmbedV1 => "casemark/embed-v1",
                EmbeddingModel.CasemarkLlamaNemotronEmbedVl1bV2 =>
                    "casemark/llama-nemotron-embed-vl-1b-v2",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
