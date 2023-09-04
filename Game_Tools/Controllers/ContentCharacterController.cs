using AutoMapper;
using Game_Tools.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tools.Models;
using Tools.Models.Character;

namespace Game_Tools.Controllers
{
    public class ContentCharacterController : Controller
    {
        private readonly IGameAPIService _gameAPIService;
        private readonly IMapper _mapper;

        public ContentCharacterController(IGameAPIService gameAPIService, IMapper mapper)
        {
            _gameAPIService = gameAPIService;
            _mapper = mapper;
        }

        public async Task<IActionResult> ContentCharacterIndex()
        {
            List<BaseCharacter> list = new List<BaseCharacter>();

            var response = await _gameAPIService.GetAll<APIResponse>();
            if (response != null && response.isSucces)
            {
                list = JsonConvert.DeserializeObject<List<BaseCharacter>>(Convert.ToString(response.result));
            }
            return View(list);
        }
    }
}
