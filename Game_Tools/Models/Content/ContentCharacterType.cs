using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tools.Models.Content
{
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
