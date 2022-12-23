using Microsoft.AspNetCore.Mvc;
using WebApiModels.Models;

namespace WebApp.Controllers
{
    [Route("api/tariff")]
    [ApiController]
    public class TariffController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Tariff>))]
        public IEnumerable<Tariff> GetTariffs()
        {
            return DataBase.db.Tariffs.ToList();
        }

        [HttpGet("{id}", Name = nameof(GetTariff))]
        [ProducesResponseType(200, Type = typeof(Tariff))]
        [ProducesResponseType(404)]
        public IActionResult GetTariff(string id)
        {
            Tariff? reg = DataBase.db.Tariffs.ToList().Find(x => x.TariffId == id);

            if (reg == null)
                return NotFound();
            else
                return Ok(reg);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Tariff))]
        [ProducesResponseType(400)]
        public IActionResult CreateTariff([FromBody] Tariff ctg)
        {
            if (ctg == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DataBase.db.Tariffs.Add(ctg);
            DataBase.db.SaveChanges();

            return CreatedAtRoute(nameof(CreateTariff), new { id = ctg.TariffId }, ctg);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Update(string id, [FromBody] Tariff reg)
        {
            if (reg == null || reg.TariffId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tariff? freg = DataBase.db.Tariffs.ToList().Find(x => x.TariffId == id);

            if (freg == null)
                return NotFound();

            DataBase.db.Tariffs.Remove(freg);
            DataBase.db.Tariffs.Add(reg);
            DataBase.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTariff(string id)
        {
            Tariff? freg = DataBase.db.Tariffs.ToList().Find(x => x.TariffId == id);

            if (freg == null)
                return NotFound();


            DataBase.db.Tariffs.Remove(freg);
            DataBase.db.SaveChanges();

            return NoContent();
        }
    }


}
