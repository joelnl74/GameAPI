namespace API.Models.Character
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

    public class BaseCharacterType
    {
        public int id { get; set; }
        public Type type { get; set; }
        public required List<Type> strongAgainst { get; set; }
        public required List<Type> weakAgainst { get; set; }
    }
}
