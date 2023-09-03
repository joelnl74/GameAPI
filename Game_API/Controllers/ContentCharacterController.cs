using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models.Character;
using API.Models.DatabaseObject;
using API.Data;
using AutoMapper;
using Game_API.Repository.Character.IRepository;
using Game_API.Models;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ContentCharacterController : ControllerBase
    {
        private APIResponse _response;
        private readonly IBaseCharacterRepository _repository;
        private readonly IMapper _mapper;

        public ContentCharacterController(IBaseCharacterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet("content/character")]
        [ProducesResponseType(typeof(List<BaseCharacterDTO>), 200)]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                IEnumerable<BaseCharacter> contentCharacters = await _repository.GetAll();
                _response.result = _mapper.Map<IEnumerable<BaseCharacterDTO>>(contentCharacters);
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

        [HttpGet("content/character{id:int}", Name = "Get")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public async Task<ActionResult<APIResponse>> Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var character = await _repository.Get(x => x.id == id);

                if (character == null)
                {
                    return NotFound();
                }

                _response.result = _mapper.Map<BaseCharacterDTO>(character);
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

        [HttpPost("content/character")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 201)]
        public async Task<ActionResult<APIResponse>> Create([FromBody] BaseCharacterDTO character)
        {
            try
            {
                if (character == null)
                {
                    return BadRequest();
                }

                var model = _mapper.Map<BaseCharacter>(character);

                await _repository.Create(model);

                _response.result = model;
                _response.statusCode = System.Net.HttpStatusCode.Created;
                _response.isSucces = true;

                return CreatedAtRoute("Get", new { character.id }, _response);
            }
            catch (Exception ex)
            {
                _response.isSucces = false;
                _response.errorMessages = new List<string> { ex.Message };

                return _response;
            }
        }

        [HttpDelete("content/character{id:int}", Name = "Delete")]
        [ProducesResponseType(typeof(APIResponse), 200)]
        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var character = await _repository.Get(_ => _.id == id);

                if (character == null)
                {
                    return NotFound(nameof(character));
                }

                var model = _mapper.Map<BaseCharacter>(character);

                await _repository.Delete(model);

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

        [HttpPut("content/character{id:int}", Name = "Put")]
        public async Task<ActionResult<APIResponse>> Update(int id, [FromBody] BaseCharacterDTO character)
        {
            try
            {
                if (id == 0 || id != character.id)
                {
                    return BadRequest();
                }

                var dbCharacter = await _repository.Get(_ => _.id == id);

                if (dbCharacter == null)
                {
                    return NotFound();
                }

                var model = _mapper.Map<BaseCharacter>(character);

                await _repository.Update(model);

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
