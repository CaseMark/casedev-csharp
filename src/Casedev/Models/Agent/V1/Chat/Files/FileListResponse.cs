using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Agent.V1.Chat.Files;

[JsonConverter(typeof(JsonModelConverter<FileListResponse, FileListResponseFromRaw>))]
public sealed record class FileListResponse : JsonModel
{
    public string? ChatID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("chatId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chatId", value);
        }
    }

    public IReadOnlyList<File>? Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<File>>("files");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<File>?>(
                "files",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChatID;
        foreach (var item in this.Files ?? [])
        {
            item.Validate();
        }
    }

    public FileListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileListResponse(FileListResponse fileListResponse)
        : base(fileListResponse) { }
#pragma warning restore CS8618

    public FileListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileListResponseFromRaw.FromRawUnchecked"/>
    public static FileListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileListResponseFromRaw : IFromRawJson<FileListResponse>
{
    /// <inheritdoc/>
    public FileListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<File, FileFromRaw>))]
public sealed record class File : JsonModel
{
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Relative path from /workspace
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("path", value);
        }
    }

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
        _ = this.Name;
        _ = this.Path;
        _ = this.SizeBytes;
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
