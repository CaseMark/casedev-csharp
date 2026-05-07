using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Skills;

[JsonConverter(typeof(JsonModelConverter<ReadResponseFileBundle, ReadResponseFileBundleFromRaw>))]
public sealed record class ReadResponseFileBundle : JsonModel
{
    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    public required ApiEnum<string, Role> Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Role>>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    public required string RootSlug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("root_slug");
        }
        init { this._rawData.Set("root_slug", value); }
    }

    public string? ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_type");
        }
        init { this._rawData.Set("content_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Path;
        this.Role.Validate();
        _ = this.RootSlug;
        _ = this.ContentType;
    }

    public ReadResponseFileBundle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReadResponseFileBundle(ReadResponseFileBundle readResponseFileBundle)
        : base(readResponseFileBundle) { }
#pragma warning restore CS8618

    public ReadResponseFileBundle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReadResponseFileBundle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReadResponseFileBundleFromRaw.FromRawUnchecked"/>
    public static ReadResponseFileBundle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReadResponseFileBundleFromRaw : IFromRawJson<ReadResponseFileBundle>
{
    /// <inheritdoc/>
    public ReadResponseFileBundle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReadResponseFileBundle.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    File,
}

sealed class RoleConverter : JsonConverter<Role>
{
    public override Role Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file" => Role.File,
            _ => (Role)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Role.File => "file",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
