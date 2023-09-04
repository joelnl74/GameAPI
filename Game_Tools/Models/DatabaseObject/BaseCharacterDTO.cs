using System.ComponentModel.DataAnnotations;

namespace Tools.Models.DatabaseObject
{
    public enum Type
    {
        [Display(Name = "Unknown")]
        Unknown = 0,
        [Display(Name = "Normal")]
        Normale = 1,
        [Display(Name = "Grass")]
        Grass = 2,
        [Display(Name = "Fire")]
        Fire = 3,
        [Display(Name = "Water")]
        Water = 4,
        [Display(Name = "Electric")]
        Electric = 5,
        [Display(Name = "Rock")]
        Rock = 6,
        [Display(Name = "Steel")]
        Steel = 7,
        [Display(Name = "Ground")]
        Ground = 8,
        [Display(Name = "Fairy")]
        Fairy = 9,
        [Display(Name = "Dark")]
        Dark = 10,
        [Display(Name = "Ghost")]
        Ghost = 11,
        [Display(Name = "Fighting")]
        Fighting = 12,
    }

    public class BaseCharacterDTO
    {
        public int id { get; set; }
        public int typeId { get; set; }
        public string name { get; set; }

    }
}
