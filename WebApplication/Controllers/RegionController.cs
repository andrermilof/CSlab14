using Microsoft.AspNetCore.Mvc;
using WebApiModels.Models;

namespace WebApp.Controllers
{
    [Route("api/region")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Region>))]
        public IEnumerable<Region> GetProviders()
        {
            return DataBase.db.Regions.ToList();
        }

        [HttpGet("{id}", Name = nameof(GetRegion))]
        [ProducesResponseType(200, Type = typeof(Region))]
        [ProducesResponseType(404)]
        public IActionResult GetRegion(string id)
        {
            Region? reg = DataBase.db.Regions.ToList().Find(x => x.RegionId == id);

            if (reg == null)
                return NotFound();
            else
                return Ok(reg);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Region))]
        [ProducesResponseType(400)]
        public IActionResult CreateRegion([FromBody] Region ctg)
        {
            if (ctg == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DataBase.db.Regions.Add(ctg);
            DataBase.db.SaveChanges();

            return CreatedAtRoute(nameof(CreateRegion), new { id = ctg.RegionId }, ctg);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Update(string id, [FromBody] Region reg)
        {
            if (reg == null || reg.RegionId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Region? freg = DataBase.db.Regions.ToList().Find(x => x.RegionId == id);

            if (freg == null)
                return NotFound();

            DataBase.db.Regions.Remove(freg);
            DataBase.db.Regions.Add(reg);
            DataBase.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRegion(string id)
        {
            Region? freg = DataBase.db.Regions.ToList().Find(x => x.RegionId == id);

            if (freg == null)
                return NotFound();


            DataBase.db.Regions.Remove(freg);
            DataBase.db.SaveChanges();

            return NoContent();
        }
    }
}
