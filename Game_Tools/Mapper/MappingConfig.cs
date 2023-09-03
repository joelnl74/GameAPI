using AutoMapper;
using Tools.Models.Character;
using Tools.Models.Content;
using Tools.Models.DatabaseObject;

namespace Tools
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
