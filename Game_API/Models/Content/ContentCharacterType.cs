using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game_API.Models.Content
{
    public enum Type
    {
        Unknown = 0,
        Normale = 1,
        Grass = 2,
        Fire = 3,
        Water = 4,
        Electric = 5,
        Rock = 6,
        Steel = 7,
        Ground = 8,
        Fairy = 9,
        Dark = 10,
        Ghost = 11,
        Fighting = 12,
    }

    public class ContentCharacterType
    {
        [Key]
        public int id { get; set; }
        public int type { get; set; }
        public List<int> strongAgainst { get; set; }
        public List<int> weakAgainst { get; set; }
    }
}
