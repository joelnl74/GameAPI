using Tools.Models.Content;
using Tools.Models.DatabaseObject;

namespace Tools.Mapper.Content.Interfaces
{
    public interface IContentCharacterTypeMapper
    {
        public ContentCharacterTypeDTO MapSingle(ContentCharacterType contentCharacter);
        public ContentCharacterTypeDTO[] MapMany(IEnumerable<ContentCharacterType> contentCharacterTypes);
    }
}
