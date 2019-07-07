using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmobiliarioController : ControllerBase
    {
        private IInmobiliarioService inmSer;
        public InmobiliarioController(IInmobiliarioService inmSer)
        {
            this.inmSer=inmSer;
        }

        [HttpGet]
        public ActionResult GetAll(){
            return Ok(
                inmSer.GetAll()
            );
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id){
            return Ok(
                inmSer.Get(id)
            );
        }

        [HttpPut]
        public ActionResult Update([FromBody] Inmobiliario cl){
            return Ok(
                inmSer.Update(cl)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            return Ok(
                inmSer.Delete(id)
            );
        }

        [HttpPost]
        public ActionResult Crear([FromBody] Inmobiliario cl){
            return Ok(
                inmSer.Save(cl)
            );
        }
    }
}