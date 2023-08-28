using API.Models.Character;
using API.Models.DatabaseObject;
using AutoMapper;

namespace Game_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<BaseCharacter, BaseCharacterDTO>();
            CreateMap<BaseCharacterDTO, BaseCharacter>();
        }
    }
}
