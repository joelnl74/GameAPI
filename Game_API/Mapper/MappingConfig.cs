using API.Models.Character;
using API.Models.DatabaseObject;
using AutoMapper;
using Game_API.Models.Content;
using Game_API.Models.DatabaseObject;

namespace Game_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<BaseCharacter, BaseCharacterDTO>();
            CreateMap<BaseCharacterDTO, BaseCharacter>();

            CreateMap<ContentCharacterType, ContentCharacterTypeDTO>();
            CreateMap<ContentCharacterTypeDTO, ContentCharacterType>();
        }
    }
}
