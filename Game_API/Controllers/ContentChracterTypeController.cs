using API.Models.DatabaseObject;
using AutoMapper;
using Game_API.Mapper.Content.Interfaces;
using Game_API.Models;
using Game_API.Models.Content;
using Game_API.Models.DatabaseObject;
using Game_API.Repository.Character.IRepository;
using Game_API.Repository.Content.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Game_API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ContentChracterTypeController : ControllerBase
    {
        private APIResponse _response;
        private readonly IContentCharacterTypeRepository _repository;
        private readonly IContentCharacterTypeMapper _mapper;

        public ContentChracterTypeController(IContentCharacterTypeRepository repository, IContentCharacterTypeMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet("content/types")]
        [ProducesResponseType(typeof(List<ContentCharacterType>), 200)]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                IEnumerable<ContentCharacterType> contentCharacters = await _repository.GetAll();
                _response.result = _mapper.MapMany(contentCharacters);
                _response.statusCode = System.Net.HttpStatusCode.OK;
                _response.isSucces = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isSucces = false;
                _response.errorMessages = new List<string> { ex.Message };

                return _response;
            }
        }

        [HttpGet("content/types{type:int}")]
        [ProducesResponseType(typeof(ContentCharacterType), 200)]
        public async Task<ActionResult<APIResponse>> Get(int type)
        {
            try
            {
                if (type == 0)
                {
                    return BadRequest();
                }

                var character = await _repository.Get(x => x.type == type);

                if (character == null)
                {
                    return NotFound();
                }

                _response.result = _mapper.MapSingle(character);
                _response.statusCode = System.Net.HttpStatusCode.OK;
                _response.isSucces = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isSucces = false;
                _response.errorMessages = new List<string> { ex.Message };

                return _response;
            }
        }

        [HttpPost("content/types")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 201)]
        public async Task<ActionResult<APIResponse>> Create([FromBody] ContentCharacterType character)
        {
            try
            {
                if (character == null)
                {
                    return BadRequest();
                }

                var model = _mapper.MapSingle(character);

                await _repository.Create(character);

                _response.result = model;
                _response.statusCode = System.Net.HttpStatusCode.Created;
                _response.isSucces = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isSucces = false;
                _response.errorMessages = new List<string> { ex.Message };

                return _response;
            }
        }

        [HttpDelete("content/types{type:int}")]
        [ProducesResponseType(typeof(APIResponse), 200)]
        public async Task<ActionResult<APIResponse>> Delete(int type)
        {
            try
            {
                if (type == 0)
                {
                    return BadRequest();
                }

                var character = await _repository.Get(_ => _.type == type);

                if (character == null)
                {
                    return NotFound(nameof(character));
                }

                await _repository.Delete(character);

                var model = _mapper.MapSingle(character);
                _response.statusCode = System.Net.HttpStatusCode.NoContent;
                _response.isSucces = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isSucces = false;
                _response.errorMessages = new List<string> { ex.Message };

                return _response;
            }
        }

        [HttpPut("content/types{type:int}")]
        public async Task<ActionResult<APIResponse>> Update(int type, [FromBody] ContentCharacterType character)
        {
            try
            {
                if (type == 0 || type != character.type)
                {
                    return BadRequest();
                }

                var dbCharacter = await _repository.Get(_ => _.type == type);

                if (dbCharacter == null)
                {
                    return NotFound();
                }


                await _repository.Update(character);

                var model = _mapper.MapSingle(character);

                _response.statusCode = System.Net.HttpStatusCode.NoContent;
                _response.isSucces = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isSucces = false;
                _response.errorMessages = new List<string> { ex.Message };

                return _response;
            }
        }
    }
}
