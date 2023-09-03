using System.ComponentModel.DataAnnotations;

namespace Tools.Models.DatabaseObject
{
    public class BaseCharacterDTO
    {
        public int id { get; set; }
        public int typeId { get; set; }
        public string name { get; set; }

    }
}
