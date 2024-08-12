namespace PubgAPI.Dtos
{
    public class PlayerResponse
    {
        public List<PlayerDataDTO> Data { get; set; }
        public LinksDTO Links { get; set; }
        public MetaDTO Meta { get; set; }

        public class PlayerDataDTO
        {
            public string Type { get; set; }
            public string Id { get; set; }
            public PlayerAttributesDTO Attributes { get; set; }
            public PlayerRelationshipsDTO Relationships { get; set; }
            public LinksDTO Links { get; set; }
        }

        public class PlayerAttributesDTO
        {
            public string Name { get; set; }
            public Dictionary<string, object> Stats { get; set; }
            public string TitleId { get; set; }
            public string ShardId { get; set; }
            public string PatchVersion { get; set; }
            public string BanType { get; set; }
            public string ClanId { get; set; }
        }

        public class PlayerRelationshipsDTO
        {
            public AssetsDTO Assets { get; set; }
            public MatchesDTO Matches { get; set; }
        }

        public class AssetsDTO
        {
            public List<object> Data { get; set; }
        }

        public class MatchesDTO
        {
            public List<MatchDTO> Data { get; set; }
        }

        public class MatchDTO
        {
            public string Id { get; set; }
            public string Type { get; set; }
        }

        public class LinksDTO
        {
            public string Self { get; set; }
            public string Schema { get; set; }
        }

        public class MetaDTO
        {
            // Define properties for the 'meta' object if needed
        }
    }
}