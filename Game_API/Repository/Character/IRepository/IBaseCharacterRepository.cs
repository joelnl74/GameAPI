using API.Models.Character;
using Game_API.Repository.Interfaces;

namespace Game_API.Repository.Character.IRepository
{
    public interface IBaseCharacterRepository : IRepository<BaseCharacter>
    {
        Task Update(BaseCharacter entity);
    }
}
