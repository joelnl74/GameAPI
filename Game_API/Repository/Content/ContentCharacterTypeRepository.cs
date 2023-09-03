using API.Data;
using Game_API.Models.Content;
using Game_API.Repository.Content.Interfaces;

namespace Game_API.Repository.Content
{
    public class ContentCharacterTypeRepository : Repository<ContentCharacterType>,
        IContentCharacterTypeRepository
    {
        private ApplicationDbContext _db;

        public ContentCharacterTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(ContentCharacterType entity)
        {
            _db.contentCharacterTypes.Update(entity);
            await Save();
        }
    }
}
