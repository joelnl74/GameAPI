using Game_API.Models;
using Microsoft.AspNetCore.Mvc;
using Pokemon_API.Models.DatabaseObject;

namespace Pokemon_API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class BaseCharacterController : ControllerBase
    {

        [HttpGet("base/character")]
        [ProducesResponseType(typeof(List<BaseCharacterDTO>), 200)]
        public ActionResult<IEnumerable<BaseCharacterDTO>> GetAll()
        {
            return Ok(CharacterDataStore.characters);
        }

        [HttpGet("base/character{id:int}", Name = "Get")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public ActionResult<BaseCharacterDTO> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var character = CharacterDataStore.characters.FirstOrDefault(x => x.id == id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        [HttpPost("base/character")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public ActionResult<BaseCharacterDTO> Create([FromBody] BaseCharacterDTO character)
        {
            if (character == null)
            {
                return BadRequest();
            }

            character.id = CharacterDataStore.characters.OrderBy(x => x.id).Last().id + 1;
            CharacterDataStore.characters.Add(character);

            return CreatedAtRoute("Get", new { character.id }, character);
        }

        [HttpDelete("base/character{id:int}", Name = "Delete")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var character = CharacterDataStore.characters.FirstOrDefault(_ => _.id == id);

            if (character == null)
            {
                return NotFound(nameof(character));
            }

            CharacterDataStore.characters.Remove(character);

            return NoContent();
        }

        [HttpPut("base/character{id:int}", Name = "Put")]
        public IActionResult Update(int id, [FromBody] BaseCharacterDTO character)
        {
            if (id == 0 || id != character.id)
            {
                return BadRequest();
            }

            var dbCharacter = CharacterDataStore.characters.FirstOrDefault(_ => _.id == id);

            if (dbCharacter == null)
            {
                return NotFound();
            }

            dbCharacter.name = character.name;
            dbCharacter.typeId = character.typeId;

            return NoContent();
        }
    }
}
