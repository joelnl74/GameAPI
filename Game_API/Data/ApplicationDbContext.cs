using Microsoft.EntityFrameworkCore;
using Pokemon_API.Models.Character;

namespace Game_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<BaseCharacter> contentCharacters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BaseCharacter>().HasData(
                new BaseCharacter {id = 1, name = "basic", typeId = 1  },
                new BaseCharacter {id = 2, name = "grass", typeId = 2 },
                new BaseCharacter {id = 3, name = "water", typeId = 3 },
                new BaseCharacter {id = 4, name = "fire", typeId = 4 }
                );
        }
    }
}
