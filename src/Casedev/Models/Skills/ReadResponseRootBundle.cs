using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;
using Casedev.Exceptions;

namespace Casedev.Models.Skills;

[JsonConverter(typeof(JsonModelConverter<ReadResponseRootBundle, ReadResponseRootBundleFromRaw>))]
public sealed record class ReadResponseRootBundle : JsonModel
{
    public required IReadOnlyList<File> Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<File>>("files");
        }
        init
        {
            this._rawData.Set<ImmutableArray<File>>(
                "files",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, ReadResponseRootBundleRole> Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReadResponseRootBundleRole>>(
                "role"
            );
        }
        init { this._rawData.Set("role", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Files)
        {
            item.Validate();
        }
        this.Role.Validate();
    }

    public ReadResponseRootBundle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReadResponseRootBundle(ReadResponseRootBundle readResponseRootBundle)
        : base(readResponseRootBundle) { }
#pragma warning restore CS8618

    public ReadResponseRootBundle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReadResponseRootBundle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReadResponseRootBundleFromRaw.FromRawUnchecked"/>
    public static ReadResponseRootBundle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReadResponseRootBundleFromRaw : IFromRawJson<ReadResponseRootBundle>
{
    /// <inheritdoc/>
    public ReadResponseRootBundle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReadResponseRootBundle.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<File, FileFromRaw>))]
public sealed record class File : JsonModel
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

    public required string Slug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("slug");
        }
        init { this._rawData.Set("slug", value); }
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

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Path;
        _ = this.Slug;
        _ = this.ContentType;
        _ = this.Name;
    }

    public File() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public File(File file)
        : base(file) { }
#pragma warning restore CS8618

    public File(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    File(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileFromRaw.FromRawUnchecked"/>
    public static File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileFromRaw : IFromRawJson<File>
{
    /// <inheritdoc/>
    public File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        File.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReadResponseRootBundleRoleConverter))]
public enum ReadResponseRootBundleRole
{
    Root,
}

sealed class ReadResponseRootBundleRoleConverter : JsonConverter<ReadResponseRootBundleRole>
{
    public override ReadResponseRootBundleRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "root" => ReadResponseRootBundleRole.Root,
            _ => (ReadResponseRootBundleRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReadResponseRootBundleRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReadResponseRootBundleRole.Root => "root",
                _ => throw new CasedevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
