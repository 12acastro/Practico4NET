using BusinessLayer.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase

    {
        private readonly IBL_Personas _bl;

        public PersonasController(IBL_Personas bl)
        {
            _bl = bl;
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bl.Get());
        }

        // GET api/<PersonasController>/5
        [HttpGet("{documento}")]
        public IActionResult Get(string documento)
        {
            return Ok(_bl.Get(documento));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Persona p)
        {
            _bl.Insert(p);
            return Ok();
        }

        // PUT api/<PersonasController>/5
        [HttpPut]
        public IActionResult Put ([FromBody] Persona p)
        {
            _bl.Update(p);
            return Ok();
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{documento}")]
        public IActionResult Delete(string documento)
        {
            _bl.Delete(documento);
            return Ok();
        }
    }
}
