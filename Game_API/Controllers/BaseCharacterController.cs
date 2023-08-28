using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models.Character;
using API.Models.DatabaseObject;
using API.Data;

namespace API.Controllers
{
    //TODO add repository pattern.
    //TODO add mapping.

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
        public async Task<ActionResult<IEnumerable<BaseCharacterDTO>>> GetAll()
        {
            return Ok(await _db.contentCharacters.ToListAsync());
        }

        [HttpGet("content/character{id:int}", Name = "Get")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public async Task<ActionResult<BaseCharacterDTO>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var character = await _db.contentCharacters.FirstOrDefaultAsync(x => x.id == id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        [HttpPost("content/character")]
        [ProducesResponseType(typeof(BaseCharacterDTO), 200)]
        public async Task<ActionResult<BaseCharacterDTO>> Create([FromBody] BaseCharacterDTO character)
        {
            if (character == null)
            {
                return BadRequest();
            }

            var contentCharacter = new BaseCharacter();
            contentCharacter.name = character.name;
            contentCharacter.typeId = character.typeId;

            await _db.contentCharacters.AddAsync(contentCharacter);
            _db.SaveChanges();

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

            var character = await _db.contentCharacters.FirstOrDefaultAsync(_ => _.id == id);

            if (character == null)
            {
                return NotFound(nameof(character));
            }

            _db.contentCharacters.Remove(character);
            _db.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("content/character{id:int}", Name = "Put")]
        public async Task<IActionResult> Update(int id, [FromBody] BaseCharacterDTO character)
        {
            if (id == 0 || id != character.id)
            {
                return BadRequest();
            }

            var dbCharacter = await _db.contentCharacters.FirstOrDefaultAsync(_ => _.id == id);

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
