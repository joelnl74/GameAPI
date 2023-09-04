using AutoMapper;
using Game_Tools.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Tools.Models;
using Tools.Models.Character;
using Tools.Models.DatabaseObject;

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

        public async Task<IActionResult> CreateContentCharacter()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContentCharacter(BaseCharacterDTO baseCharacterDTO)
        {
            if (ModelState.IsValid == false)
            {
                return View(baseCharacterDTO);
            }

            var response = await _gameAPIService.Create<APIResponse>(baseCharacterDTO);
            
            if (response != null && response.isSucces)
            {
                return RedirectToAction(nameof(ContentCharacterIndex));
            }

            return View(baseCharacterDTO);
        }
    }
}
