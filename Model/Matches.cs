namespace PubgAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class Match
{
    [JsonProperty("data")]
    public Data Data { get; set; }
}

public class Data
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("attributes")]
    public MatchAttributes Attributes { get; set; }

    [JsonProperty("relationships")]
    public MatchRelationships Relationships { get; set; }

    [JsonProperty("links")]
    public MatchLinks Links { get; set; }
}

public class MatchAttributes
{
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("stats")]
    public string Stats { get; set; } // Assuming Stats is nullable

    [JsonProperty("gameMode")]
    public string GameMode { get; set; }

    [JsonProperty("titleId")]
    public string TitleId { get; set; }

    [JsonProperty("mapName")]
    public string MapName { get; set; }

    [JsonProperty("matchType")]
    public string MatchType { get; set; }

    [JsonProperty("seasonState")]
    public string SeasonState { get; set; }

    [JsonProperty("duration")]
    public int Duration { get; set; }

    [JsonProperty("shardId")]
    public string ShardId { get; set; }

    [JsonProperty("tags")]
    public string Tags { get; set; } // Assuming Tags is nullable

    [JsonProperty("isCustomMatch")]
    public bool IsCustomMatch { get; set; }
}

public class MatchRelationships
{
    [JsonProperty("rosters")]
    public List<RelationshipData> Rosters { get; set; }

    [JsonProperty("assets")]
    public List<RelationshipData> Assets { get; set; }
}

public class RelationshipData
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}

public class MatchLinks
{
    [JsonProperty("self")]
    public string Self { get; set; }

    [JsonProperty("schema")]
    public string Schema { get; set; }
}

public class Roster
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("attributes")]
    public RosterAttributes Attributes { get; set; }

    [JsonProperty("relationships")]
    public RosterRelationships Relationships { get; set; }
}

public class RosterAttributes
{
    [JsonProperty("shardId")]
    public string ShardId { get; set; }

    [JsonProperty("stats")]
    public RosterStats Stats { get; set; }

    [JsonProperty("won")]
    public bool Won { get; set; }
}

public class RosterStats
{
    [JsonProperty("rank")]
    public int Rank { get; set; }

    [JsonProperty("teamId")]
    public int TeamId { get; set; }
}

public class RosterRelationships
{
    [JsonProperty("participants")]
    public List<RelationshipData> Participants { get; set; }

    [JsonProperty("team")]
    public RelationshipData Team { get; set; } // Assuming Team could be null
}

public class Participant
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("attributes")]
    public ParticipantAttributes Attributes { get; set; }
}

public class ParticipantAttributes
{
    [JsonProperty("stats")]
    public ParticipantStats Stats { get; set; }

    [JsonProperty("actor")]
    public string Actor { get; set; } // Assuming Actor could be empty

    [JsonProperty("shardId")]
    public string ShardId { get; set; }
}

public class ParticipantStats
{
    [JsonProperty("DBNOs")]
    public int DBNOs { get; set; }

    [JsonProperty("assists")]
    public int Assists { get; set; }

    [JsonProperty("boosts")]
    public int Boosts { get; set; }

    [JsonProperty("damageDealt")]
    public float DamageDealt { get; set; }

    [JsonProperty("deathType")]
    public string DeathType { get; set; }

    [JsonProperty("headshotKills")]
    public int HeadshotKills { get; set; }

    [JsonProperty("heals")]
    public int Heals { get; set; }

    [JsonProperty("killPlace")]
    public int KillPlace { get; set; }

    [JsonProperty("killStreaks")]
    public int KillStreaks { get; set; }

    [JsonProperty("kills")]
    public int Kills { get; set; }

    [JsonProperty("longestKill")]
    public float LongestKill { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("playerId")]
    public string PlayerId { get; set; }

    [JsonProperty("revives")]
    public int Revives { get; set; }

    [JsonProperty("rideDistance")]
    public float RideDistance { get; set; }

    [JsonProperty("roadKills")]
    public int RoadKills { get; set; }

    [JsonProperty("swimDistance")]
    public float SwimDistance { get; set; }

    [JsonProperty("teamKills")]
    public int TeamKills { get; set; }

    [JsonProperty("timeSurvived")]
    public int TimeSurvived { get; set; }

    [JsonProperty("vehicleDestroys")]
    public int VehicleDestroys { get; set; }

    [JsonProperty("walkDistance")]
    public float WalkDistance { get; set; }

    [JsonProperty("weaponsAcquired")]
    public int WeaponsAcquired { get; set; }

    [JsonProperty("winPlace")]
    public int WinPlace { get; set; }
}
