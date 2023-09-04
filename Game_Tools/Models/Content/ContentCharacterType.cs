using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tools.Models.Content
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int type { get; set; }
        public string name { get; set; }
        public string strongAgainst { get; set; }
        public string weakAgainst { get; set; }
    }
}
