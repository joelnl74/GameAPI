using Game_API.Mapper.Content.Interfaces;
using Game_API.Models.Content;
using Game_API.Models.DatabaseObject;
using System.Collections.Generic;

namespace Game_API.Mapper.Content
{
    public class ContentCharacterTypeMapper : IContentCharacterTypeMapper
    {
        public ContentCharacterTypeDTO[] MapMany(IEnumerable<ContentCharacterType> contentCharacterTypes)
            => contentCharacterTypes.Select(MapSingle).ToArray();

        public ContentCharacterTypeDTO MapSingle(ContentCharacterType contentCharacter)
            => new()
            {
                type = contentCharacter.type,
                name = contentCharacter.name,

                weakAgainst = string.IsNullOrEmpty(contentCharacter.weakAgainst) == false ? contentCharacter.weakAgainst?.Split(',')?.Select(int.Parse)?.ToList() : new List<int>(),
                strongAgainst = string.IsNullOrEmpty(contentCharacter.strongAgainst) == false ? contentCharacter.strongAgainst?.Split(',')?.Select(int.Parse)?.ToList() : new List<int>()
            };
    }
}
