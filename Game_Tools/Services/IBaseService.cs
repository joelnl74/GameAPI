using Game_Tools.Models;
using Tools.Models;

namespace Game_Tools.Services
{
    public interface IBaseService
    {
        APIResponse response { get; set; }
        Task<T> SendAsync<T>(APIRequest request);
    }
}
