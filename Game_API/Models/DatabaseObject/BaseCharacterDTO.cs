using System.ComponentModel.DataAnnotations;

namespace API.Models.DatabaseObject
{
    public class BaseCharacterDTO
    {
        public int id { get; set; }
        public int typeId { get; set; }
        public string name { get; set; }

    }
}
