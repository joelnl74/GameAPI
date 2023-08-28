using API.Data;
using API.Models.Character;
using Game_API.Repository.Character.IRepository;

namespace Game_API.Repository.Character
{
    public class BaseCharacterRepository : Repository<BaseCharacter>, IBaseCharacterRepository
    {
        private readonly ApplicationDbContext _db;

        public BaseCharacterRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(BaseCharacter entity)
        {
            _db.contentCharacters.Update(entity);
            await Save();
        }
    }
}
