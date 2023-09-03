using static Game_Utilities.SD;

namespace Game_Tools.Models
{
    public class APIRequest
    {
        public ApiType apiType { get; set; } = ApiType.GET;
        public string url { get; set; }
        public object data { get; set; }
    }
}
