using Microsoft.EntityFrameworkCore;
using API.Models.Character;
using Game_API.Models.Content;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<BaseCharacter> contentCharacters { get; set; }
        public DbSet<ContentCharacterType> contentCharacterTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BaseCharacter>().HasData(
                new BaseCharacter {id = 1, name = "basic", typeId = 1  },
                new BaseCharacter {id = 2, name = "grass", typeId = 2 },
                new BaseCharacter {id = 3, name = "water", typeId = 3 },
                new BaseCharacter {id = 4, name = "fire", typeId = 4 }
                );

            modelBuilder.Entity<ContentCharacterType>().HasData(
                new ContentCharacterType { id = 1, strongAgainst = new List<int>(), weakAgainst = new List<int>() },
                new ContentCharacterType { id = 2, strongAgainst = new List<int> { (int)Game_API.Models.Content.Type.Water }, weakAgainst = new List<int> { (int)Game_API.Models.Content.Type.Fire } },
                new ContentCharacterType { id = 3, strongAgainst = new List<int> { (int)Game_API.Models.Content.Type.Fire }, weakAgainst = new List<int> { (int)Game_API.Models.Content.Type.Grass} },
                new ContentCharacterType { id = 4, strongAgainst = new List<int> { (int)Game_API.Models.Content.Type.Grass }, weakAgainst = new List<int> { (int)Game_API.Models.Content.Type.Water} }
                );
        }
    }
}
