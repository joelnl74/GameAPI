using Game_API.Data;
using Microsoft.AspNetCore.Mvc;
using Pokemon_API.Models.Character;
using Pokemon_API.Models.DatabaseObject;

namespace Pokemon_API.Controllers
{
    //TODO add repository pattern.

    [Route("api/v1")]
    [ApiController]
    public class BaseCharacterController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public BaseCharacterController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("content/character")]
        [ProducesResponseType(typeof(List<BaseCharacterDTO>), 200)]
        public ActionResult<IEnumerable<BaseCharacterDTO>> GetAll()
        {
            return Ok(_db.contentCharacters);
        }

        [HttpGet("content/character{id:int}", Name = "Get")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public ActionResult<BaseCharacterDTO> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var character = _db.contentCharacters.FirstOrDefault(x => x.id == id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        [HttpPost("content/character")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public ActionResult<BaseCharacterDTO> Create([FromBody] BaseCharacterDTO character)
        {
            if (character == null)
            {
                return BadRequest();
            }

            var contentCharacter = new BaseCharacter();
            contentCharacter.name = character.name;
            contentCharacter.typeId = character.typeId;

            _db.contentCharacters.Add(contentCharacter);
            _db.SaveChanges();

            return CreatedAtRoute("Get", new { character.id }, character);
        }

        [HttpDelete("content/character{id:int}", Name = "Delete")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var character = _db.contentCharacters.FirstOrDefault(_ => _.id == id);

            if (character == null)
            {
                return NotFound(nameof(character));
            }

            _db.contentCharacters.Remove(character);
            _db.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("content/character{id:int}", Name = "Put")]
        public IActionResult Update(int id, [FromBody] BaseCharacterDTO character)
        {
            if (id == 0 || id != character.id)
            {
                return BadRequest();
            }

            var dbCharacter = _db.contentCharacters.FirstOrDefault(_ => _.id == id);

            if (dbCharacter == null)
            {
                return NotFound();
            }

            dbCharacter.name = character.name;
            dbCharacter.typeId = character.typeId;

            _db.Update(dbCharacter);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
