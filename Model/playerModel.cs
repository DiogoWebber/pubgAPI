namespace PubgAPI.Model
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class playerModel
    {
        public class RootObject
        {
            [JsonProperty("data")]
            public List<Data> Data { get; set; }

            [JsonProperty("links")]
            public Links Links { get; set; }

            [JsonProperty("meta")]
            public Meta Meta { get; set; }
        }

        public class Data
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("attributes")]
            public Attributes Attributes { get; set; }

            [JsonProperty("relationships")]
            public Relationships Relationships { get; set; }

            [JsonProperty("links")]
            public Links Links { get; set; }
        }

        public class Attributes
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("shardId")]
            public string ShardId { get; set; }

            [JsonProperty("stats")]
            public Dictionary<string, object> Stats { get; set; }

            [JsonProperty("createdAt")]
            public string CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public string UpdatedAt { get; set; }

            [JsonProperty("patchVersion")]
            public string PatchVersion { get; set; }

            [JsonProperty("banType")]
            public string BanType { get; set; }

            [JsonProperty("titleId")]
            public string TitleId { get; set; }
        }

        public class Relationships
        {
            [JsonProperty("assets")]
            public Assets Assets { get; set; }

            [JsonProperty("matches")]
            public Matches Matches { get; set; }
        }

        public class Assets
        {
            [JsonProperty("data")]
            public object Data { get; set; }
        }

        public class Matches
        {
            [JsonProperty("data")]
            public List<Match> Data { get; set; }
        }

        public class Match
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public class Links
        {
            [JsonProperty("schema")]
            public string Schema { get; set; }

            [JsonProperty("self")]
            public string Self { get; set; }
        }

        public class Meta
        {
            // Define properties for the 'meta' object if needed
        }
    }
}
