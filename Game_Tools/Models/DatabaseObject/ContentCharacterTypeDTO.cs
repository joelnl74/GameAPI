using System.ComponentModel.DataAnnotations;

namespace Tools.Models.DatabaseObject
{
    public class ContentCharacterTypeDTO
    {
        public int id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public List<int> strongAgainst { get; set; }
        public List<int> weakAgainst { get; set; }
    }
}
