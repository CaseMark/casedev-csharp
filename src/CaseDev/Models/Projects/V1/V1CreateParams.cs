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

namespace CaseDev.Models.Projects.V1;

/// <summary>
/// Create a new project for deployments
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1CreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Project name
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

    public required ApiEnum<string, SourceType> SourceType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, SourceType>>("sourceType");
        }
        init { this._rawBodyData.Set("sourceType", value); }
    }

    public string? BuildCommand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("buildCommand");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("buildCommand", value);
        }
    }

    public string? DefaultMemory
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("defaultMemory");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("defaultMemory", value);
        }
    }

    public string? DefaultVcpu
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("defaultVcpu");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("defaultVcpu", value);
        }
    }

    /// <summary>
    /// Project description
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

    public string? Framework
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("framework");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("framework", value);
        }
    }

    public string? GitHubBranch
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("githubBranch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("githubBranch", value);
        }
    }

    /// <summary>
    /// GitHub repo (owner/repo)
    /// </summary>
    public string? GitHubRepo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("githubRepo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("githubRepo", value);
        }
    }

    public string? InstallCommand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("installCommand");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("installCommand", value);
        }
    }

    public string? RootDirectory
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("rootDirectory");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("rootDirectory", value);
        }
    }

    public string? S3SourceBucket
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("s3SourceBucket");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("s3SourceBucket", value);
        }
    }

    public string? S3SourcePrefix
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("s3SourcePrefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("s3SourcePrefix", value);
        }
    }

    public string? StartCommand
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("startCommand");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("startCommand", value);
        }
    }

    public string? ThurgoodSessionID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("thurgoodSessionId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("thurgoodSessionId", value);
        }
    }

    public V1CreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1CreateParams(V1CreateParams v1CreateParams)
        : base(v1CreateParams)
    {
        this._rawBodyData = new(v1CreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public V1CreateParams(
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
    V1CreateParams(
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
    public static V1CreateParams FromRawUnchecked(
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
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(V1CreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/projects/v1")
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

[JsonConverter(typeof(SourceTypeConverter))]
public enum SourceType
{
    GitHub,
    Thurgood,
}

sealed class SourceTypeConverter : JsonConverter<SourceType>
{
    public override SourceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "github" => SourceType.GitHub,
            "thurgood" => SourceType.Thurgood,
            _ => (SourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SourceType.GitHub => "github",
                SourceType.Thurgood => "thurgood",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
