using Tools.Models.Character;
using Tools.Models.DatabaseObject;

namespace Game_Tools.Services
{
    public interface IGameAPIService
    {
        Task<T> GetAll<T>();
        Task<T> Get<T>(int id);
        Task<T> Create<T>(BaseCharacterDTO baseCharacter);
        Task<T> Update<T>(BaseCharacterDTO baseCharacter);
        Task<T> Delete<T>(int id);

    }
}
