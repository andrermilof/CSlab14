using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using WebApiModels.Models;

namespace WebApp.Controllers
{
    [Route("api/provider")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Provider>))]
        public IEnumerable<Provider> GetProviders()
        {
            return DataBase.db.Providers.ToList();
        }

        [HttpGet("{id}", Name = nameof(GetProvider))]
        [ProducesResponseType(200, Type = typeof(Provider))]
        [ProducesResponseType(404)]
        public IActionResult GetProvider(string id)
        {
            Provider? prov = DataBase.db.Providers.ToList().Find(x => x.ProviderId == id);

            if (prov == null)
                return NotFound();
            else
                return Ok(prov);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Provider))]
        [ProducesResponseType(400)]
        public IActionResult CreateProvider([FromBody] Provider prov)
        {
            if (prov == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DataBase.db.Providers.Add(prov);
            DataBase.db.SaveChanges();

            return CreatedAtRoute(nameof(CreateProvider), new { id = prov.ProviderId }, prov);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Update(string id, [FromBody] Provider prov)
        {
            if (prov == null || prov.ProviderId != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Provider? fprov = DataBase.db.Providers.ToList().Find(x => x.ProviderId == id);

            if (fprov == null)
                return NotFound();

            DataBase.db.Providers.Remove(fprov);
            DataBase.db.Providers.Add(prov);
            DataBase.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProvider(string id)
        {
            Provider? fctg = DataBase.db.Providers.ToList().Find(x => x.ProviderId == id);

            if (fctg == null)
                return NotFound();


            DataBase.db.Providers.Remove(fctg);
            DataBase.db.SaveChanges();

            return NoContent();
        }
    }
}
