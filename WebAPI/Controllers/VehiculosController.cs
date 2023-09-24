using BusinessLayer.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
   {
        private readonly IBL_Vehiculos _bl;

        public VehiculosController(IBL_Vehiculos bl)
        {
            _bl = bl;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bl.Get());
        }

        // GET api/<PersonasController>/5
        [HttpGet("{matricula}")]
        public IActionResult Get(string matricula)
        {
            return Ok(_bl.Get(matricula));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vehiculo v)
        {
            _bl.Insert(v);
            return Ok();
        }

        // PUT api/<PersonasController>/5
        [HttpPut]
        public IActionResult Put ([FromBody] Vehiculo v)
        {
            _bl.Update(v);
            return Ok();
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{matricula}")]
        public IActionResult Delete(string matricula)
        {
            _bl.Delete(matricula);
            return Ok();
        }
    }
}
