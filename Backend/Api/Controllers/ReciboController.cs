using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciboController : ControllerBase
    {
        private IReciboService recSer;
        public ReciboController(IReciboService recSer)
        {
            this.recSer=recSer;
        }

        [HttpGet]
        public ActionResult GetAll(){
            return Ok(
                recSer.GetAllRecibos()
            );
        }

        [HttpGet("{reciboId}")]
        public ActionResult Get([FromRoute] int reciboId){
            return Ok(
                recSer.ListarDetalles(reciboId)
            );
        }

        [HttpPut]
        public ActionResult Update([FromBody] Recibo cl){
            return Ok(
                recSer.Update(cl)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            return Ok(
                recSer.Delete(id)
            );
        }

        [HttpPost]
        public ActionResult Crear([FromBody] Recibo cl){
            return Ok(
                recSer.Save(cl)
            );
        }
    }
}