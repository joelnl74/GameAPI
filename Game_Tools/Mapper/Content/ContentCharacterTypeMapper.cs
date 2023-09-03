using System.Collections.Generic;
using Tools.Mapper.Content.Interfaces;
using Tools.Models.Content;
using Tools.Models.DatabaseObject;

namespace Tools.Mapper.Content
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
