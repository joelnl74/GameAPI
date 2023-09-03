using Tools.Models.DatabaseObject;

namespace Game_Tools.Services
{
    public class GameAPIService : BaseService, IGameAPIService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _apiKey;

        public GameAPIService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
            _apiKey = configuration.GetValue<string>("ServiceUrls:Game_API");
        }

        public Task<T> Create<T>(BaseCharacterDTO baseCharacter)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                apiType = Game_Utilities.SD.ApiType.POST,
                data = baseCharacter,
                url = _apiKey + "/api/v1/" + "content/character"
            });
        }

        public Task<T> Delete<T>(int id)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                apiType = Game_Utilities.SD.ApiType.DELETE,
                url = _apiKey + "/api/v1/" + "content/character/" + id
            });
        }

        public Task<T> Get<T>(int id)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                apiType = Game_Utilities.SD.ApiType.GET,
                url = _apiKey + "/api/v1/" + "content/character/" + id
            });
        }

        public Task<T> GetAll<T>()
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                apiType = Game_Utilities.SD.ApiType.GET,
                url = _apiKey + "/api/v1/" + "content/character"
            });
        }

        public Task<T> Update<T>(BaseCharacterDTO baseCharacter)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                apiType = Game_Utilities.SD.ApiType.PUT,
                data = baseCharacter,
                url = _apiKey + "/api/v1/" + "content/character/" + baseCharacter.id
            });
        }
    }
}
