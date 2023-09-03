using API.Models.Character;
using Game_API.Models.Content;
using Game_API.Repository.Interfaces;

namespace Game_API.Repository.Content.Interfaces
{
    public interface IContentCharacterTypeRepository : IRepository<ContentCharacterType>
    {
        Task Update(ContentCharacterType entity);
    }
}
