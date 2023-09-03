using Game_API.Models.Content;
using Game_API.Models.DatabaseObject;

namespace Game_API.Mapper.Content.Interfaces
{
    public interface IContentCharacterTypeMapper
    {
        public ContentCharacterTypeDTO MapSingle(ContentCharacterType contentCharacter);
        public ContentCharacterTypeDTO[] MapMany(IEnumerable<ContentCharacterType> contentCharacterTypes);
    }
}
