using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models.Character;
using API.Models.DatabaseObject;
using API.Data;
using AutoMapper;
using Game_API.Repository.Character.IRepository;

namespace API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ContentCharacterController : ControllerBase
    {
        private readonly IBaseCharacterRepository _repository;
        private readonly IMapper _mapper;

        public ContentCharacterController(IBaseCharacterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("content/character")]
        [ProducesResponseType(typeof(List<BaseCharacterDTO>), 200)]
        public async Task<ActionResult<IEnumerable<BaseCharacterDTO>>> GetAll()
        {
            IEnumerable<BaseCharacter> contentCharacters = await _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<BaseCharacterDTO>>(contentCharacters));
        }

        [HttpGet("content/character{id:int}", Name = "Get")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public async Task<ActionResult<BaseCharacterDTO>> Get(int id)
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

            return Ok(_mapper.Map<BaseCharacterDTO>(character));
        }

        [HttpPost("content/character")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public async Task<ActionResult<BaseCharacterDTO>> Create([FromBody] BaseCharacterDTO character)
        {
            if (character == null)
            {
                return BadRequest();
            }

            await _repository.Create(_mapper.Map<BaseCharacter>(character));

            return CreatedAtRoute("Get", new { character.id }, character);
        }

        [HttpDelete("content/character{id:int}", Name = "Delete")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public async Task<IActionResult> Delete(int id)
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

            await _repository.Delete(_mapper.Map<BaseCharacter>(character));
            
            return NoContent();
        }

        [HttpPut("content/character{id:int}", Name = "Put")]
        public async Task<IActionResult> Update(int id, [FromBody] BaseCharacterDTO character)
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

            await _repository.Update(_mapper.Map<BaseCharacter>(character));

            return NoContent();
        }
    }
}
