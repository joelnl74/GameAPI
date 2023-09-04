using Game_Tools.Models;
using Game_Utilities;
using Newtonsoft.Json;
using System;
using System.Text;
using Tools.Models;

namespace Game_Tools.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse response { get; set; }
        public IHttpClientFactory httpClientFactory { get; set; }


        public BaseService(IHttpClientFactory httpClientFactory) 
        {
            this.response = new APIResponse();
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<T> SendAsync<T>(APIRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient("Game_API");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accecpt", "application/json");
                message.RequestUri = new Uri(request.url);

                if (request.data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.data), Encoding.UTF8, "application/json");
                }

                message.Method = GetMethod(request.apiType);
                HttpResponseMessage apiResponse = null;

                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIReponse = JsonConvert.DeserializeObject<T>(apiContent);

                return APIReponse;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse();
                dto.errorMessages = new List<string> { Convert.ToString(ex.Message) };
                dto.isSucces = false;

                var res = JsonConvert.SerializeObject(dto);
                var APIReponse = JsonConvert.DeserializeObject<T>(res);
                
                return APIReponse;
            }
        }

        private HttpMethod GetMethod(SD.ApiType apiType)
        {
            switch (apiType)
            {
                case Game_Utilities.SD.ApiType.None:
                    break;
                case Game_Utilities.SD.ApiType.GET:
                    return HttpMethod.Get;
                case Game_Utilities.SD.ApiType.POST:
                    return HttpMethod.Post;
                case Game_Utilities.SD.ApiType.PUT:
                    return HttpMethod.Put;
                case Game_Utilities.SD.ApiType.DELETE:
                    return HttpMethod.Delete;
                default:
                    return HttpMethod.Get;
            }

            return HttpMethod.Get;
        }
    }
}
