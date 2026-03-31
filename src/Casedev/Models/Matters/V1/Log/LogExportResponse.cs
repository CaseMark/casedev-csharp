using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Casedev.Core;

namespace Casedev.Models.Matters.V1.Log;

[JsonConverter(typeof(JsonModelConverter<LogExportResponse, LogExportResponseFromRaw>))]
public sealed record class LogExportResponse : JsonModel
{
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "data",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(
                            value,
                            (item) => FrozenDictionary.ToFrozenDictionary(item)
                        )
                    )
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
    }

    public LogExportResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LogExportResponse(LogExportResponse logExportResponse)
        : base(logExportResponse) { }
#pragma warning restore CS8618

    public LogExportResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LogExportResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LogExportResponseFromRaw.FromRawUnchecked"/>
    public static LogExportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LogExportResponseFromRaw : IFromRawJson<LogExportResponse>
{
    /// <inheritdoc/>
    public LogExportResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LogExportResponse.FromRawUnchecked(rawData);
}
