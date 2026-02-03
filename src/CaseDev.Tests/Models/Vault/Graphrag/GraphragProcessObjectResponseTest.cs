using System.Text.Json;
using CaseDev.Core;
using CaseDev.Models.Vault.Graphrag;

namespace CaseDev.Tests.Models.Vault.Graphrag;

public class GraphragProcessObjectResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GraphragProcessObjectResponse
        {
            Communities = 0,
            Entities = 0,
            ObjectID = "objectId",
            Relationships = 0,
            Stats = new()
            {
                CommunityCount = 0,
                EntityCount = 0,
                RelationshipCount = 0,
            },
            Status = "status",
            Success = true,
            VaultID = "vaultId",
        };

        long expectedCommunities = 0;
        long expectedEntities = 0;
        string expectedObjectID = "objectId";
        long expectedRelationships = 0;
        Stats expectedStats = new()
        {
            CommunityCount = 0,
            EntityCount = 0,
            RelationshipCount = 0,
        };
        string expectedStatus = "status";
        bool expectedSuccess = true;
        string expectedVaultID = "vaultId";

        Assert.Equal(expectedCommunities, model.Communities);
        Assert.Equal(expectedEntities, model.Entities);
        Assert.Equal(expectedObjectID, model.ObjectID);
        Assert.Equal(expectedRelationships, model.Relationships);
        Assert.Equal(expectedStats, model.Stats);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GraphragProcessObjectResponse
        {
            Communities = 0,
            Entities = 0,
            ObjectID = "objectId",
            Relationships = 0,
            Stats = new()
            {
                CommunityCount = 0,
                EntityCount = 0,
                RelationshipCount = 0,
            },
            Status = "status",
            Success = true,
            VaultID = "vaultId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GraphragProcessObjectResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GraphragProcessObjectResponse
        {
            Communities = 0,
            Entities = 0,
            ObjectID = "objectId",
            Relationships = 0,
            Stats = new()
            {
                CommunityCount = 0,
                EntityCount = 0,
                RelationshipCount = 0,
            },
            Status = "status",
            Success = true,
            VaultID = "vaultId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GraphragProcessObjectResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCommunities = 0;
        long expectedEntities = 0;
        string expectedObjectID = "objectId";
        long expectedRelationships = 0;
        Stats expectedStats = new()
        {
            CommunityCount = 0,
            EntityCount = 0,
            RelationshipCount = 0,
        };
        string expectedStatus = "status";
        bool expectedSuccess = true;
        string expectedVaultID = "vaultId";

        Assert.Equal(expectedCommunities, deserialized.Communities);
        Assert.Equal(expectedEntities, deserialized.Entities);
        Assert.Equal(expectedObjectID, deserialized.ObjectID);
        Assert.Equal(expectedRelationships, deserialized.Relationships);
        Assert.Equal(expectedStats, deserialized.Stats);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GraphragProcessObjectResponse
        {
            Communities = 0,
            Entities = 0,
            ObjectID = "objectId",
            Relationships = 0,
            Stats = new()
            {
                CommunityCount = 0,
                EntityCount = 0,
                RelationshipCount = 0,
            },
            Status = "status",
            Success = true,
            VaultID = "vaultId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GraphragProcessObjectResponse
        {
            Communities = 0,
            Entities = 0,
            ObjectID = "objectId",
            Relationships = 0,
            Stats = new()
            {
                CommunityCount = 0,
                EntityCount = 0,
                RelationshipCount = 0,
            },
            Status = "status",
            Success = true,
            VaultID = "vaultId",
        };

        GraphragProcessObjectResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Stats
        {
            CommunityCount = 0,
            EntityCount = 0,
            RelationshipCount = 0,
        };

        long expectedCommunityCount = 0;
        long expectedEntityCount = 0;
        long expectedRelationshipCount = 0;

        Assert.Equal(expectedCommunityCount, model.CommunityCount);
        Assert.Equal(expectedEntityCount, model.EntityCount);
        Assert.Equal(expectedRelationshipCount, model.RelationshipCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Stats
        {
            CommunityCount = 0,
            EntityCount = 0,
            RelationshipCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stats>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Stats
        {
            CommunityCount = 0,
            EntityCount = 0,
            RelationshipCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stats>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedCommunityCount = 0;
        long expectedEntityCount = 0;
        long expectedRelationshipCount = 0;

        Assert.Equal(expectedCommunityCount, deserialized.CommunityCount);
        Assert.Equal(expectedEntityCount, deserialized.EntityCount);
        Assert.Equal(expectedRelationshipCount, deserialized.RelationshipCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Stats
        {
            CommunityCount = 0,
            EntityCount = 0,
            RelationshipCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Stats { };

        Assert.Null(model.CommunityCount);
        Assert.False(model.RawData.ContainsKey("community_count"));
        Assert.Null(model.EntityCount);
        Assert.False(model.RawData.ContainsKey("entity_count"));
        Assert.Null(model.RelationshipCount);
        Assert.False(model.RawData.ContainsKey("relationship_count"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Stats { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Stats
        {
            // Null should be interpreted as omitted for these properties
            CommunityCount = null,
            EntityCount = null,
            RelationshipCount = null,
        };

        Assert.Null(model.CommunityCount);
        Assert.False(model.RawData.ContainsKey("community_count"));
        Assert.Null(model.EntityCount);
        Assert.False(model.RawData.ContainsKey("entity_count"));
        Assert.Null(model.RelationshipCount);
        Assert.False(model.RawData.ContainsKey("relationship_count"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Stats
        {
            // Null should be interpreted as omitted for these properties
            CommunityCount = null,
            EntityCount = null,
            RelationshipCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Stats
        {
            CommunityCount = 0,
            EntityCount = 0,
            RelationshipCount = 0,
        };

        Stats copied = new(model);

        Assert.Equal(model, copied);
    }
}
