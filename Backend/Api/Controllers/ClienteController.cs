using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteService clServ;
        public ClienteController(IClienteService clServ)
        {
            this.clServ=clServ;
        }
        
        [HttpGet]
        public ActionResult GetAll(){
            return Ok(
                clServ.GetAll()
            );
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id){
            return Ok(
                clServ.Get(id)
            );
        }

        [HttpPut]
        public ActionResult Update([FromBody] Cliente cl){
            return Ok(
                clServ.Update(cl)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            return Ok(
                clServ.Delete(id)
            );
        }

        [HttpPost]
        public ActionResult Crear([FromBody] Cliente cl){
            return Ok(
                clServ.Save(cl)
            );
        }

        [HttpGet("{nombre}")]
        public ActionResult fetchClienteByNombre([FromRoute] string nombre){
            return Ok(
                clServ.fetchClienteByNombre(nombre)
            );
        }

        [HttpGet("{dni}")]
        public ActionResult fetchClienteByDni([FromRoute] string dni){
            return Ok(
                clServ.fetchClienteByDni(dni)
            );
        }
    }
}