using Pokemon_API.Models.DatabaseObject;

namespace Game_API.Models
{
    public static class CharacterDataStore
    {
        public static List<BaseCharacterDTO> characters = new List<BaseCharacterDTO>
        {
            new BaseCharacterDTO
            {
                id = 1,
                name = "grass"
            },
            new BaseCharacterDTO
            {
                id = 2,
                name = "fire"
            },
            new BaseCharacterDTO
            {
                id = 3,
                name = "water"
            },
        };
    }
}
