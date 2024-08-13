namespace PubgAPI.Dtos
{
    public class MatchesResponse
    {
        public MatchDto Data { get; set; }
        public List<object> Included { get; set; } // Ajuste conforme a estrutura real, se necessário
        public LinksDTO Links { get; set; }
        public MetaDTO Meta { get; set; }

        public class MatchDto
        {
            public string Type { get; set; }
            public string Id { get; set; }
            public MatchAttributesDto Attributes { get; set; }
            public MatchRelationshipsDto Relationships { get; set; }
            public MatchLinksDto Links { get; set; }
        }

        public class MatchAttributesDto
        {
            public string CreatedAt { get; set; } // Mudei para string baseado no exemplo recebido
            public int Duration { get; set; }
            public string MatchType { get; set; }
            public string GameMode { get; set; }
            public string MapName { get; set; }
            public bool IsCustomMatch { get; set; }
            public string PatchVersion { get; set; }
            public string SeasonState { get; set; }
            public string ShardId { get; set; }
            public Dictionary<string, object> Stats { get; set; } // Ajustado para Dictionary
            public Dictionary<string, object> Tags { get; set; } // Ajustado para Dictionary
            public string TitleId { get; set; }
        }

        public class MatchRelationshipsDto
        {
            public RelationshipDataDto Assets { get; set; }
            public RelationshipDataDto Rosters { get; set; }
            public RelationshipDataDto Rounds { get; set; } // Ajuste conforme necessidade
            public RelationshipDataDto Spectators { get; set; } // Ajuste conforme necessidade
        }

        public class RelationshipDataDto
        {
            public List<RelationshipItemDto> Data { get; set; }
        }

        public class RelationshipItemDto
        {
            public string Type { get; set; }
            public string Id { get; set; }
        }

        public class MatchLinksDto
        {
            public string Self { get; set; }
            public string Schema { get; set; }
        }

        public class LinksDTO
        {
            public string Self { get; set; }
        }

        public class MetaDTO
        {
            // Defina propriedades para o objeto 'meta' se necessário
        }
    }
}
