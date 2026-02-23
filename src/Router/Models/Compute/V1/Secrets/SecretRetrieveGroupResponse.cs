using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Router.Core;

namespace Router.Models.Compute.V1.Secrets;

[JsonConverter(
    typeof(JsonModelConverter<SecretRetrieveGroupResponse, SecretRetrieveGroupResponseFromRaw>)
)]
public sealed record class SecretRetrieveGroupResponse : JsonModel
{
    public SecretRetrieveGroupResponseGroup? Group
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SecretRetrieveGroupResponseGroup>("group");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("group", value);
        }
    }

    public IReadOnlyList<Key>? Keys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Key>>("keys");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Key>?>(
                "keys",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Group?.Validate();
        foreach (var item in this.Keys ?? [])
        {
            item.Validate();
        }
    }

    public SecretRetrieveGroupResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecretRetrieveGroupResponse(SecretRetrieveGroupResponse secretRetrieveGroupResponse)
        : base(secretRetrieveGroupResponse) { }
#pragma warning restore CS8618

    public SecretRetrieveGroupResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecretRetrieveGroupResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecretRetrieveGroupResponseFromRaw.FromRawUnchecked"/>
    public static SecretRetrieveGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SecretRetrieveGroupResponseFromRaw : IFromRawJson<SecretRetrieveGroupResponse>
{
    /// <inheritdoc/>
    public SecretRetrieveGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SecretRetrieveGroupResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SecretRetrieveGroupResponseGroup,
        SecretRetrieveGroupResponseGroupFromRaw
    >)
)]
public sealed record class SecretRetrieveGroupResponseGroup : JsonModel
{
    /// <summary>
    /// Unique identifier of the secret group
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Description of the secret group
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Name of the secret group
    /// </summary>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Name;
    }

    public SecretRetrieveGroupResponseGroup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecretRetrieveGroupResponseGroup(
        SecretRetrieveGroupResponseGroup secretRetrieveGroupResponseGroup
    )
        : base(secretRetrieveGroupResponseGroup) { }
#pragma warning restore CS8618

    public SecretRetrieveGroupResponseGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecretRetrieveGroupResponseGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecretRetrieveGroupResponseGroupFromRaw.FromRawUnchecked"/>
    public static SecretRetrieveGroupResponseGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SecretRetrieveGroupResponseGroupFromRaw : IFromRawJson<SecretRetrieveGroupResponseGroup>
{
    /// <inheritdoc/>
    public SecretRetrieveGroupResponseGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SecretRetrieveGroupResponseGroup.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Key, KeyFromRaw>))]
public sealed record class Key : JsonModel
{
    /// <summary>
    /// When the secret was created
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Name of the secret key
    /// </summary>
    public string? KeyValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key", value);
        }
    }

    /// <summary>
    /// When the secret was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.KeyValue;
        _ = this.UpdatedAt;
    }

    public Key() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Key(Key key)
        : base(key) { }
#pragma warning restore CS8618

    public Key(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Key(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KeyFromRaw.FromRawUnchecked"/>
    public static Key FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class KeyFromRaw : IFromRawJson<Key>
{
    /// <inheritdoc/>
    public Key FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Key.FromRawUnchecked(rawData);
}
