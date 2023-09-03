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

            var models = new List<ContentCharacterType>();

            foreach (int i in Enum.GetValues(typeof(Game_API.Models.Content.Type)))
            {
                var model = new ContentCharacterType { type = i, name = ((Game_API.Models.Content.Type)i).ToString(), strongAgainst = "", weakAgainst = "" };
                models.Add(model);
            }

            modelBuilder.Entity<ContentCharacterType>().HasData(models);
        }
    }
}
